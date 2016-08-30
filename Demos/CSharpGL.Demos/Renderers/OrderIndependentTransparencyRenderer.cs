using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{
    class OrderIndependentTransparencyRenderer : RendererBase
    {
        private PickableRenderer buildListsRenderer;
        private PickableRenderer resolve_lists;

        private Texture headTexture;
        private const int MAX_FRAMEBUFFER_WIDTH = 2048;
        private const int MAX_FRAMEBUFFER_HEIGHT = 2048;
        private uint[] head_pointer_clear_buffer = new uint[1];
        private uint[] atomic_counter_buffer = new uint[1];
        private uint[] linked_list_buffer = new uint[1];
        private uint[] linked_list_texture = new uint[1];
        private DepthTestSwitch depthTestSwitch;

        public DepthTestSwitch DepthTestSwitch
        {
            get { return depthTestSwitch; }
        }
        private CullFaceSwitch cullFaceSwitch;

        public CullFaceSwitch CullFaceSwitch
        {
            get { return cullFaceSwitch; }
        }


        public OrderIndependentTransparencyRenderer(IBufferable model,
            string positionName, string normalName)
        {
            {
                var map = new PropertyNameMap();
                map.Add("position", positionName);
                map.Add("normal", normalName);
                var build_lists = new ShaderCode[2];
                build_lists[0] = new ShaderCode(File.ReadAllText(@"shaders\build_lists.vert"), ShaderType.VertexShader);
                build_lists[1] = new ShaderCode(File.ReadAllText(@"shaders\build_lists.frag"), ShaderType.FragmentShader);
                this.buildListsRenderer = new PickableRenderer(model, build_lists, map, positionName);
            }
            {
                var map = new PropertyNameMap();
                map.Add("position", positionName);
                var resolve_lists = new ShaderCode[2];
                resolve_lists[0] = new ShaderCode(File.ReadAllText(@"shaders\resolve_lists.vert"), ShaderType.VertexShader);
                resolve_lists[1] = new ShaderCode(File.ReadAllText(@"shaders\resolve_lists.frag"), ShaderType.FragmentShader);
                this.resolve_lists = new PickableRenderer(model, resolve_lists, map, positionName);
            }
            {
                this.depthTestSwitch = new DepthTestSwitch(false);
                this.cullFaceSwitch = new CullFaceSwitch(false);
            }
        }

        protected override void DoInitialize()
        {
            this.buildListsRenderer.Initialize();
            this.resolve_lists.Initialize();
            {
                var texture = new Texture(BindTextureTarget.Texture2D,
                    new NullImageBuilder(MAX_FRAMEBUFFER_WIDTH, MAX_FRAMEBUFFER_HEIGHT, OpenGL.GL_R32UI, OpenGL.GL_RED_INTEGER, OpenGL.GL_UNSIGNED_BYTE),
                    new SamplerParameters(TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat, TextureFilter.Nearest, TextureFilter.Nearest));
                texture.Initialize();
                this.headTexture = texture;
            }
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(0, this.headTexture.Id, 0, true, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_R32UI);

            // Create buffer for clearing the head pointer texture
            OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, head_pointer_clear_buffer);
            OpenGL.BindBuffer(BufferTarget.PixelUnpackBuffer, head_pointer_clear_buffer[0]);
            OpenGL.GetDelegateFor<OpenGL.glBufferData>()(OpenGL.GL_PIXEL_UNPACK_BUFFER, MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT * sizeof(uint), IntPtr.Zero, OpenGL.GL_STATIC_DRAW);
            IntPtr data = OpenGL.MapBuffer(BufferTarget.PixelUnpackBuffer, MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (uint*)data.ToPointer();
                for (int i = 0; i < MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT; i++)
                {
                    array[i] = 0;
                }
            }
            OpenGL.UnmapBuffer(BufferTarget.PixelUnpackBuffer);
            OpenGL.BindBuffer(BufferTarget.PixelUnpackBuffer, 0);

            // Create the atomic counter buffer
            OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, atomic_counter_buffer);
            OpenGL.BindBuffer(BufferTarget.AtomicCounterBuffer, atomic_counter_buffer[0]);
            OpenGL.GetDelegateFor<OpenGL.glBufferData>()(OpenGL.GL_ATOMIC_COUNTER_BUFFER, sizeof(uint), IntPtr.Zero, OpenGL.GL_DYNAMIC_COPY);
            OpenGL.BindBuffer(BufferTarget.AtomicCounterBuffer, 0);

            // Create the linked list storage buffer
            OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, linked_list_buffer);
            OpenGL.BindBuffer(BufferTarget.TextureBuffer, linked_list_buffer[0]);
            OpenGL.GetDelegateFor<OpenGL.glBufferData>()(OpenGL.GL_TEXTURE_BUFFER, MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT * 3 * Marshal.SizeOf(typeof(vec4)), IntPtr.Zero, OpenGL.GL_DYNAMIC_COPY);
            OpenGL.BindBuffer(BufferTarget.TextureBuffer, 0);

            // Bind it to a texture (for use as a TBO)
            OpenGL.GenTextures(1, linked_list_texture);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_BUFFER, linked_list_texture[0]);
            OpenGL.GetDelegateFor<OpenGL.glTexBuffer>()(OpenGL.GL_TEXTURE_BUFFER, OpenGL.GL_RGBA32UI, linked_list_buffer[0]);
            OpenGL.BindTexture(OpenGL.GL_TEXTURE_BUFFER, 0);

            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(1, linked_list_texture[0], 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32UI);

            OpenGL.ClearDepth(1.0f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.depthTestSwitch.On();
            this.cullFaceSwitch.On();

            // Reset atomic counter
            OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>()(OpenGL.GL_ATOMIC_COUNTER_BUFFER, 0, atomic_counter_buffer[0]);
            IntPtr data = OpenGL.MapBuffer(BufferTarget.AtomicCounterBuffer, MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (uint*)data.ToPointer();
                array[0] = 0;
            }
            OpenGL.UnmapBuffer(BufferTarget.AtomicCounterBuffer);
            OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>()(OpenGL.GL_ATOMIC_COUNTER_BUFFER, 0, 0);

            // Clear head-pointer image
            OpenGL.BindBuffer(BufferTarget.PixelUnpackBuffer, head_pointer_clear_buffer[0]);
            this.headTexture.Bind();
            OpenGL.TexSubImage2D(TexSubImage2DTarget.Texture2D, 0, 0, 0, arg.CanvasRect.Width, arg.CanvasRect.Height, TexSubImage2DFormats.RedInteger, TexSubImage2DType.UnsignedByte, IntPtr.Zero);
            this.headTexture.Unbind();
            OpenGL.BindBuffer(BufferTarget.PixelUnpackBuffer, 0);
            //

            // Bind head-pointer image for read-write
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(0, this.headTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_R32UI);

            // Bind linked-list buffer for write
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(1, linked_list_texture[0], 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32UI);

            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 projection = arg.Camera.GetProjectionMatrix();
            this.buildListsRenderer.SetUniform("model_matrix", model);
            this.buildListsRenderer.SetUniform("view_matrix", view);
            this.buildListsRenderer.SetUniform("projection_matrix", projection);
            this.resolve_lists.SetUniform("model_matrix", model);
            this.resolve_lists.SetUniform("view_matrix", view);
            this.resolve_lists.SetUniform("projection_matrix", projection);

            // first pass
            this.buildListsRenderer.Render(arg);
            // second pass
            this.resolve_lists.Render(arg);

            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(1, 0, 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32UI);
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(0, 0, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_R32UI);

            this.cullFaceSwitch.Off();
            this.depthTestSwitch.Off();
        }

        protected override void DisposeUnmanagedResources()
        {
            this.buildListsRenderer.Dispose();
            this.resolve_lists.Dispose();

            OpenGL.DeleteTextures(linked_list_texture.Length, linked_list_texture);
            OpenGL.DeleteBuffers(linked_list_buffer.Length, linked_list_buffer);
            OpenGL.DeleteBuffers(atomic_counter_buffer.Length, atomic_counter_buffer);
            this.headTexture.Dispose();
        }
    }
}
