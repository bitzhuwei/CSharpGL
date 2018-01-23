using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace OrderIndependentTransparency
{
    public partial class OITNode : PickableNode
    {
        private const string vPosition = "vPosition";
        private const string vNormal = "vNormal";
        private const string mvpMatrix = "mvpMatrix";

        const int buildLists = 0;
        const int resolveLists = 1;
        /// <summary>
        /// bind texture to an image unit.(which reminds me of texture unit)
        /// </summary>
        private static readonly GLDelegates.void_uint_uint_int_bool_int_uint_uint glBindImageTexture;
        static OITNode()
        {
            glBindImageTexture = GL.Instance.GetDelegateFor("glBindImageTexture", GLDelegates.typeof_void_uint_uint_int_bool_int_uint_uint) as GLDelegates.void_uint_uint_int_bool_int_uint_uint;
        }

        public static OITNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            var builders = new RenderMethodBuilder[2];
            {
                var vs = new VertexShader(buildListsVert);
                var fs = new FragmentShader(buildListsFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(vPosition, position);
                map.Add(vNormal, normal);
                builders[buildLists] = new RenderMethodBuilder(provider, map);
            }
            {
                var vs = new VertexShader(resolveListsVert);
                var fs = new FragmentShader(resolveListsFrag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add(vPosition, position);
                builders[resolveLists] = new RenderMethodBuilder(provider, map);
            }
            var node = new OITNode(model, position, builders);
            node.ModelSize = size;

            node.Initialize();

            return node;
        }

        private OITNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }

        private int canvasWidth = 0;
        private int canvasHeight = 0;
        private Texture headTexture;
        private PixelUnpackBuffer headClearBuffer;
        private AtomicCounterBuffer atomicCounterBuffer;
        private Texture linkedListTexture;
        private DepthTestState depthTestState;
        private CullFaceState cullFaceState;

        private void UpdateResources(int width, int height)
        {
            {
                if (this.headTexture != null) { this.headTexture.Dispose(); }

                uint internalformat = GL.GL_R32UI, format = GL.GL_RED_INTEGER, type = GL.GL_UNSIGNED_BYTE;
                TexStorageBase storage = new TexImage2D(TexImage2D.Target.Texture2D, internalformat, width, height, format, type);
                var texture = new Texture(storage,
                    TexParameter.Create(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                    TexParameter.Create(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                    TexParameter.Create(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                    TexParameter.Create(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                    TexParameter.Create(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST)
                    );
                texture.Initialize();

                this.headTexture = texture;
            }
            // Create buffer for clearing the head pointer texture
            {
                if (this.headClearBuffer != null) { this.headClearBuffer.Dispose(); }

                int length = width * height;
                // NOTE: not all initial values are zero in this unmanged array.
                PixelUnpackBuffer buffer = PixelUnpackBuffer.Create(typeof(uint), length, BufferUsage.StaticDraw);
                // initialize buffer's value to 0.
                //unsafe
                //{
                //    IntPtr pointer = ptr.MapBuffer(MapBufferAccess.WriteOnly);
                //    var array = (uint*)pointer.ToPointer();
                //    for (int i = 0; i < MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT; i++)
                //    {
                //        array[i] = 0;
                //    }
                //}
                // another way to initialize buffer's value to 0.
                //using (var data = new UnmanagedArray<uint>(1))
                //{
                //    data[0] = 0;
                //    ptr.ClearBufferData(OpenGL.GL_UNSIGNED_INT, OpenGL.GL_RED, OpenGL.GL_UNSIGNED_INT, data);
                //}

                this.headClearBuffer = buffer;
            }
            // Bind it to a texture (for use as a TBO)
            {
                if (this.linkedListTexture != null) { this.linkedListTexture.Dispose(); }

                int length = width * height * 3;
                TextureBuffer buffer = TextureBuffer.Create(typeof(vec4), length, BufferUsage.DynamicCopy);
                uint internalFormat = GL.GL_RGBA32UI;
                Texture texture = buffer.DumpBufferTexture(internalFormat, autoDispose: true);
                texture.Initialize();
                buffer.Dispose();// dispose it ASAP.

                this.linkedListTexture = texture;
            }
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            // Create the atomic counter buffer
            {
                const int length = 1;
                AtomicCounterBuffer buffer = AtomicCounterBuffer.Create(typeof(uint), length, BufferUsage.DynamicCopy);
                // another way to do this:
                //uint data = 1;
                //AtomicCounterBuffer buffer = data.GenAtomicCounterBuffer(BufferUsage.DynamicCopy);
                // Reset atomic counter
                IntPtr data = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                unsafe
                {
                    var array = (uint*)data.ToPointer();
                    array[0] = 0;
                }
                buffer.UnmapBuffer();

                this.atomicCounterBuffer = buffer;
            }

            {
                this.depthTestState = new DepthTestState(false); // disable depth test.
                this.cullFaceState = new CullFaceState(CullFaceMode.Back, false); // disable cull face.
            }
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            {
                int width = arg.Param.Viewport.width, height = arg.Param.Viewport.height;
                if (width != this.canvasWidth || height != this.canvasHeight)
                {
                    UpdateResources(width, height);
                    this.canvasWidth = width;
                    this.canvasHeight = height;
                }
            }
            {
                this.cullFaceState.On();
                this.depthTestState.On();
            }
            {
                // Clear head-pointer image
                this.headClearBuffer.Bind();
                this.headTexture.Bind();
                int width = this.canvasWidth, height = this.canvasHeight;
                uint format = GL.GL_RED_INTEGER, type = GL.GL_UNSIGNED_BYTE;
                GL.Instance.TexSubImage2D((uint)GL.GL_TEXTURE_2D, 0, 0, 0, width, height, format, type, IntPtr.Zero);
                this.headTexture.Unbind();
                this.headClearBuffer.Unbind();
            }
            uint imageUnit0 = 0, imageUnit1 = 1;
            {
                // Bind head-pointer image for read-write
                glBindImageTexture(imageUnit0, this.headTexture.Id, 0, false, 0, GL.GL_READ_WRITE, GL.GL_R32UI);
                // Bind linked-list buffer for write
                glBindImageTexture(imageUnit1, this.linkedListTexture.Id, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32UI);
            }
            {
                ICamera camera = arg.CameraStack.Peek();
                mat4 projection = camera.GetProjectionMatrix();
                mat4 view = camera.GetViewMatrix();
                mat4 model = this.GetModelMatrix();
                {
                    // first pass
                    RenderMethod method = this.RenderUnit.Methods[buildLists];
                    ShaderProgram program = method.Program;
                    program.SetUniform(mvpMatrix, projection * view * model);
                    method.Render();
                }
                {
                    // second pass
                    RenderMethod method = this.RenderUnit.Methods[resolveLists];
                    ShaderProgram program = method.Program;
                    program.SetUniform(mvpMatrix, projection * view * model);
                    method.Render();
                }
            }
            {
                glBindImageTexture(imageUnit1, 0, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32UI);
                glBindImageTexture(imageUnit0, 0, 0, false, 0, GL.GL_READ_WRITE, GL.GL_R32UI);
            }
            {
                this.cullFaceState.Off();
                this.depthTestState.Off();
            }
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
