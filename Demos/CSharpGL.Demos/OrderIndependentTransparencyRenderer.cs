using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{
    class OrderIndependentTransparencyRenderer : RendererBase
    {
        private PickableRenderer buildListsRenderer;

        public PickableRenderer BuildListsRenderer
        {
            get { return buildListsRenderer; }
        }
        private PickableRenderer resolve_lists;

        public PickableRenderer ResolveListsRenderer
        {
            get { return resolve_lists; }
        }
        private uint[] head_pointer_texture = new uint[1];
        private const int MAX_FRAMEBUFFER_WIDTH = 2048;
        private const int MAX_FRAMEBUFFER_HEIGHT = 2048;
        private uint[] head_pointer_clear_buffer = new uint[1];
        private uint[] atomic_counter_buffer = new uint[1];
        private uint[] linked_list_buffer = new uint[1];
        private uint[] linked_list_texture = new uint[1];
        private DepthTestSwitch depthTestSwitch;
        private CullFaceSwitch cullFaceSwitch;


        public OrderIndependentTransparencyRenderer(IBufferable model,
            string positionName, string normalName)
        {
            {
                var map = new PropertyNameMap();
                map.Add("position", positionName);
                map.Add("normal", normalName);
                var build_lists = new ShaderCode[2];
                build_lists[0] = new ShaderCode(File.ReadAllText(@"Shaders\build_lists.vert"), ShaderType.VertexShader);
                build_lists[1] = new ShaderCode(File.ReadAllText(@"Shaders\build_lists.frag"), ShaderType.FragmentShader);
                this.buildListsRenderer = PickableRendererFactory.GetRenderer(model, build_lists, map, positionName);
            }
            {
                var map = new PropertyNameMap();
                map.Add("position", positionName);
                var resolve_lists = new ShaderCode[2];
                resolve_lists[0] = new ShaderCode(File.ReadAllText(@"Shaders\resolve_lists.vert"), ShaderType.VertexShader);
                resolve_lists[1] = new ShaderCode(File.ReadAllText(@"Shaders\resolve_lists.frag"), ShaderType.FragmentShader);
                this.resolve_lists = PickableRendererFactory.GetRenderer(model, resolve_lists, map, positionName);
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

            // Create head pointer texture
            GL.GetDelegateFor<GL.glActiveTexture>()(GL.GL_TEXTURE0);
            GL.GenTextures(1, head_pointer_texture);
            GL.BindTexture(GL.GL_TEXTURE_2D, head_pointer_texture[0]);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
            GL.TexImage2D(GL.GL_TEXTURE_2D, 0, GL.GL_R32UI, MAX_FRAMEBUFFER_WIDTH, MAX_FRAMEBUFFER_HEIGHT, 0, GL.GL_RED_INTEGER, GL.GL_UNSIGNED_INT, IntPtr.Zero);
            GL.BindTexture(GL.GL_TEXTURE_2D, 0);

            GL.GetDelegateFor<GL.glBindImageTexture>()(0, head_pointer_texture[0], 0, true, 0, GL.GL_READ_WRITE, GL.GL_R32UI);

            // Create buffer for clearing the head pointer texture
            GL.GetDelegateFor<GL.glGenBuffers>()(1, head_pointer_clear_buffer);
            GL.BindBuffer(BufferTarget.PixelUnpackBuffer, head_pointer_clear_buffer[0]);
            GL.GetDelegateFor<GL.glBufferData>()(GL.GL_PIXEL_UNPACK_BUFFER, MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT * sizeof(uint), IntPtr.Zero, GL.GL_STATIC_DRAW);
            IntPtr data = GL.MapBuffer(BufferTarget.PixelUnpackBuffer, MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (uint*)data.ToPointer();
                for (int i = 0; i < MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT; i++)
                {
                    array[i] = 0;
                }
            }
            GL.UnmapBuffer(BufferTarget.PixelUnpackBuffer);
            GL.BindBuffer(BufferTarget.PixelUnpackBuffer, 0);

            // Create the atomic counter buffer
            GL.GetDelegateFor<GL.glGenBuffers>()(1, atomic_counter_buffer);
            GL.BindBuffer(BufferTarget.AtomicCounterBuffer, atomic_counter_buffer[0]);
            GL.GetDelegateFor<GL.glBufferData>()(GL.GL_ATOMIC_COUNTER_BUFFER, sizeof(uint), IntPtr.Zero, GL.GL_DYNAMIC_COPY);
            GL.BindBuffer(BufferTarget.AtomicCounterBuffer, 0);

            // Create the linked list storage buffer
            GL.GetDelegateFor<GL.glGenBuffers>()(1, linked_list_buffer);
            GL.BindBuffer(BufferTarget.TextureBuffer, linked_list_buffer[0]);
            GL.GetDelegateFor<GL.glBufferData>()(GL.GL_TEXTURE_BUFFER, MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT * 3 * Marshal.SizeOf(typeof(vec4)), IntPtr.Zero, GL.GL_DYNAMIC_COPY);
            GL.BindBuffer(BufferTarget.TextureBuffer, 0);

            // Bind it to a texture (for use as a TBO)
            GL.GenTextures(1, linked_list_texture);
            GL.BindTexture(GL.GL_TEXTURE_BUFFER, linked_list_texture[0]);
            GL.GetDelegateFor<GL.glTexBuffer>()(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32UI, linked_list_buffer[0]);
            GL.BindTexture(GL.GL_TEXTURE_BUFFER, 0);

            GL.GetDelegateFor<GL.glBindImageTexture>()(1, linked_list_texture[0], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32UI);

            GL.ClearDepth(1.0f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.depthTestSwitch.On();
            this.cullFaceSwitch.On();

            // Reset atomic counter
            GL.GetDelegateFor<GL.glBindBufferBase>()(GL.GL_ATOMIC_COUNTER_BUFFER, 0, atomic_counter_buffer[0]);
            IntPtr data = GL.MapBuffer(BufferTarget.AtomicCounterBuffer, MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (uint*)data.ToPointer();
                array[0] = 0;
            }
            GL.UnmapBuffer(BufferTarget.AtomicCounterBuffer);
            GL.GetDelegateFor<GL.glBindBufferBase>()(GL.GL_ATOMIC_COUNTER_BUFFER, 0, 0);

            // Clear head-pointer image
            GL.BindBuffer(BufferTarget.PixelUnpackBuffer, head_pointer_clear_buffer[0]);
            GL.BindTexture(GL.GL_TEXTURE_2D, head_pointer_texture[0]);
            GL.TexSubImage2D(TexSubImage2DTarget.Texture2D, 0, 0, 0, arg.CanvasRect.Width, arg.CanvasRect.Height, TexSubImage2DFormats.RedInteger, TexSubImage2DType.UnsignedByte, IntPtr.Zero);
            GL.BindTexture(GL.GL_TEXTURE_2D, 0);
            GL.BindBuffer(BufferTarget.PixelUnpackBuffer, 0);
            //

            // Bind head-pointer image for read-write
            GL.GetDelegateFor<GL.glBindImageTexture>()(0, head_pointer_texture[0], 0, false, 0, GL.GL_READ_WRITE, GL.GL_R32UI);

            // Bind linked-list buffer for write
            GL.GetDelegateFor<GL.glBindImageTexture>()(1, linked_list_texture[0], 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32UI);

            mat4 model = mat4.identity();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            this.buildListsRenderer.SetUniformValue("model_matrix", model);
            this.buildListsRenderer.SetUniformValue("view_matrix", view);
            this.buildListsRenderer.SetUniformValue("projection_matrix", projection);
            this.resolve_lists.SetUniformValue("model_matrix", model);
            this.resolve_lists.SetUniformValue("view_matrix", view);
            this.resolve_lists.SetUniformValue("projection_matrix", projection);

            // first pass
            this.buildListsRenderer.Render(arg);
            // second pass
            this.resolve_lists.Render(arg);

            GL.GetDelegateFor<GL.glBindImageTexture>()(1, 0, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32UI);
            GL.GetDelegateFor<GL.glBindImageTexture>()(0, 0, 0, false, 0, GL.GL_READ_WRITE, GL.GL_R32UI);

            this.cullFaceSwitch.Off();
            this.depthTestSwitch.Off();
        }

        protected override void DisposeUnmanagedResources()
        {
            this.buildListsRenderer.Dispose();
            this.resolve_lists.Dispose();

            GL.DeleteTextures(linked_list_texture.Length, linked_list_texture);
            GL.DeleteBuffers(linked_list_buffer.Length, linked_list_buffer);
            GL.DeleteBuffers(atomic_counter_buffer.Length, atomic_counter_buffer);
            GL.DeleteTextures(head_pointer_texture.Length, head_pointer_texture);
        }
    }
}
