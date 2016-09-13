using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal class OrderIndependentTransparencyRenderer : RendererBase
    {
        private PickableRenderer buildListsRenderer;
        private PickableRenderer resolve_lists;

        private Texture headTexture;
        private const int MAX_FRAMEBUFFER_WIDTH = 2048;
        private const int MAX_FRAMEBUFFER_HEIGHT = 2048;
        private PixelUnpackBufferPtr headClearBufferPtr;
        private AtomicCounterBufferPtr atomicCountBufferPtr;
        private Texture linkedListTexture;
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
                    new NullImageFiller(MAX_FRAMEBUFFER_WIDTH, MAX_FRAMEBUFFER_HEIGHT, OpenGL.GL_R32UI, OpenGL.GL_RED_INTEGER, OpenGL.GL_UNSIGNED_BYTE),
                    new SamplerParameters(TextureWrapping.Repeat, TextureWrapping.Repeat, TextureWrapping.Repeat, TextureFilter.Nearest, TextureFilter.Nearest));
                texture.Initialize();
                this.headTexture = texture;
            }
            {
                OpenGL.BindImageTexture(0, this.headTexture.Id, 0, true, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_R32UI);

                // Create buffer for clearing the head pointer texture
                //var buffer = new IndependentBuffer<uint>(BufferTarget.PixelUnpackBuffer, BufferUsage.StaticDraw, false);
                var buffer = new PixelUnpackBuffer<uint>(BufferUsage.StaticDraw, false);
                buffer.Create(MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    for (int i = 0; i < MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT; i++)
                    {
                        array[i] = 0;
                    }
                }
                this.headClearBufferPtr = buffer.GetBufferPtr() as PixelUnpackBufferPtr;
            }
            // Create the atomic counter buffer
            {
                var buffer = new AtomicCounterBuffer<uint>(BufferUsage.DynamicCopy, false);
                buffer.Create(1);
                this.atomicCountBufferPtr = buffer.GetBufferPtr() as AtomicCounterBufferPtr;
            }
            {
                // Bind it to a texture (for use as a TBO)
                const bool noDataCopyed = false;
                var buffer = new TextureBuffer<vec4>(BufferUsage.DynamicCopy, noDataCopyed);
                const int elementCount = MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT * 3;
                buffer.Create(elementCount);
                BufferPtr bufferPtr = buffer.GetBufferPtr();
                const bool autoDispose = true;
                Texture texture = bufferPtr.DumpBufferTexture(OpenGL.GL_RGBA32UI, autoDispose);
                texture.Initialize();
                this.linkedListTexture = texture;
            }
            {
                OpenGL.BindImageTexture(1, this.linkedListTexture.Id, 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32UI);
            }
            OpenGL.ClearDepth(1.0f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.depthTestSwitch.On();
            this.cullFaceSwitch.On();

            // Reset atomic counter
            atomicCountBufferPtr.Bind();
            IntPtr data = OpenGL.MapBuffer(BufferTarget.AtomicCounterBuffer, MapBufferAccess.WriteOnly);
            unsafe
            {
                var array = (uint*)data.ToPointer();
                array[0] = 0;
            }
            OpenGL.UnmapBuffer(BufferTarget.AtomicCounterBuffer);
            atomicCountBufferPtr.Unbind();

            // Clear head-pointer image
            this.headClearBufferPtr.Bind();
            this.headTexture.Bind();
            OpenGL.TexSubImage2D(TexSubImage2DTarget.Texture2D, 0, 0, 0, arg.CanvasRect.Width, arg.CanvasRect.Height, TexSubImage2DFormats.RedInteger, TexSubImage2DType.UnsignedByte, IntPtr.Zero);
            this.headTexture.Unbind();
            this.headClearBufferPtr.Unbind();
            //

            // Bind head-pointer image for read-write
            OpenGL.BindImageTexture(0, this.headTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_R32UI);

            // Bind linked-list buffer for write
            OpenGL.BindImageTexture(1, this.linkedListTexture.Id, 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32UI);

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

            OpenGL.BindImageTexture(1, 0, 0, false, 0, OpenGL.GL_WRITE_ONLY, OpenGL.GL_RGBA32UI);
            OpenGL.BindImageTexture(0, 0, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_R32UI);

            this.cullFaceSwitch.Off();
            this.depthTestSwitch.Off();
        }

        protected override void DisposeUnmanagedResources()
        {
            this.buildListsRenderer.Dispose();
            this.resolve_lists.Dispose();

            this.linkedListTexture.Dispose();
            this.atomicCountBufferPtr.Dispose();
            this.headTexture.Dispose();
        }
    }


}