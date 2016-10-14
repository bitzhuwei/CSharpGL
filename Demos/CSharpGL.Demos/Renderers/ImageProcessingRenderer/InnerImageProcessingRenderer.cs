using System;
using System.Drawing;
using System.IO;

namespace CSharpGL.Demos
{
    internal class InnerImageProcessingRenderer : PickableRenderer
    {
        private string textureFilename;
        private Texture inputTexture;

        public Texture InputTexture
        {
            get { return inputTexture; }
        }
        private Texture intermediateTexture;

        public Texture IntermediateTexture
        {
            get { return intermediateTexture; }
        }
        private Texture outputTexture;

        public Texture OutputTexture
        {
            get { return outputTexture; }
        }

        public static InnerImageProcessingRenderer Create(string textureFilename = @"Textures\edgeDetection.bmp")
        {
            var model = new ImageProcessingModel();
            ShaderCode[] simpleShader = new ShaderCode[2];
            simpleShader[0] = new ShaderCode(File.ReadAllText(@"shaders\ImageProcessingRenderer\ImageProcessing.vert"), ShaderType.VertexShader);
            simpleShader[1] = new ShaderCode(File.ReadAllText(@"shaders\ImageProcessingRenderer\ImageProcessing.frag"), ShaderType.FragmentShader);
            var propertyNameMap = new AttributeMap();
            propertyNameMap.Add("vert", "position");
            propertyNameMap.Add("uv", "uv");
            var renderer = new InnerImageProcessingRenderer(
                model, simpleShader, propertyNameMap, ImageProcessingModel.strposition);
            renderer.textureFilename = textureFilename;

            return renderer;
        }

        private InnerImageProcessingRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                Bitmap bitmap = new System.Drawing.Bitmap(this.textureFilename);
                if (bitmap.Width != 512 || bitmap.Height != 512)
                {
                    bitmap = (Bitmap)bitmap.GetThumbnailImage(512, 512, null, IntPtr.Zero);
                }
                /* We require 1 byte alignment when uploading texture data */
                //GL.PixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
                /* Clamping to edges is important to prevent artifacts when scaling */
                /* Linear filtering usually looks best for text */
                var texture = new Texture(TextureTarget.Texture2D,
                    new BitmapFiller(bitmap, 0, OpenGL.GL_RGBA32F, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE),
                    new SamplerParameters(
                        TextureWrapping.ClampToEdge,
                        TextureWrapping.ClampToEdge,
                        TextureWrapping.ClampToEdge,
                        TextureFilter.Linear,
                        TextureFilter.Linear));
                texture.Initialize();
                bitmap.Dispose();
                this.inputTexture = texture;
            }
            {
                var texture = new Texture(TextureTarget.Texture2D,
                    new TexStorage2DImageFiller(8, OpenGL.GL_RGBA32F, 512, 512),
                    new NullSampler());
                texture.Initialize();
                this.intermediateTexture = texture;
            }
            {
                // This is the texture that the compute program will write into
                var texture = new Texture(TextureTarget.Texture2D,
           new TexStorage2DImageFiller(8, OpenGL.GL_RGBA32F, 512, 512),
           new NullSampler());
                texture.Initialize();
                this.outputTexture = texture;
            }

            this.SetUniform("output_image", this.outputTexture);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            inputTexture.Dispose();
            intermediateTexture.Dispose();
            outputTexture.Dispose();
        }

        private class ImageProcessingModel : IBufferable
        {
            public const string strposition = "position";
            public const string struv = "uv";
            private VertexAttributeBufferPtr positionBufferPtr;
            private VertexAttributeBufferPtr uvBufferPtr;
            private IndexBufferPtr indexBufferPtr;

            public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
            {
                if (bufferName == strposition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new VertexAttributeBuffer<vec3>(varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
                        {
                            buffer.DoAlloc(4);
                            unsafe
                            {
                                var array = (vec3*)buffer.Header.ToPointer();
                                array[0] = new vec3(-1.0f, -1.0f, 0.5f);
                                array[1] = new vec3(1.0f, -1.0f, 0.5f);
                                array[2] = new vec3(1.0f, 1.0f, 0.5f);
                                array[3] = new vec3(-1.0f, 1.0f, 0.5f);
                            }
                            positionBufferPtr = buffer.GetBufferPtr();
                        }
                    }
                    return positionBufferPtr;
                }
                else if (bufferName == struv)
                {
                    if (uvBufferPtr == null)
                    {
                        using (var buffer = new VertexAttributeBuffer<vec2>(varNameInShader, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw))
                        {
                            buffer.DoAlloc(4);
                            unsafe
                            {
                                var array = (vec2*)buffer.Header.ToPointer();
                                array[0] = new vec2(1, 1);
                                array[1] = new vec2(0, 1);
                                array[2] = new vec2(0, 0);
                                array[3] = new vec2(1, 0);
                            }
                            uvBufferPtr = buffer.GetBufferPtr();
                        }
                    }
                    return uvBufferPtr;
                }
                else
                { throw new NotImplementedException(); }
            }

            public IndexBufferPtr GetIndexBufferPtr()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(DrawMode.TriangleFan, 0, 4))
                    {
                        indexBufferPtr = buffer.GetBufferPtr();
                    }
                }
                return indexBufferPtr;
            }

            /// <summary>
            /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
            /// </summary>
            /// <returns></returns>
            public bool UsesZeroIndexBuffer() { return true; }
        }

        internal void SwitchDisplayImage(bool forward)
        {
            if (forward)
            {
                switch (this.currentDisplay)
                {
                    case CurrentDisplayImage.Input:
                        this.SetUniform("output_image",
                            this.intermediateTexture);
                        this.currentDisplay = CurrentDisplayImage.Intermediate;
                        break;

                    case CurrentDisplayImage.Intermediate:
                        this.SetUniform("output_image",
                            this.outputTexture);
                        this.currentDisplay = CurrentDisplayImage.Output;
                        break;

                    case CurrentDisplayImage.Output:
                        this.SetUniform("output_image",
                            this.inputTexture);
                        this.currentDisplay = CurrentDisplayImage.Input;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            else
            {
                switch (this.currentDisplay)
                {
                    case CurrentDisplayImage.Input:
                        this.SetUniform("output_image",
                            this.outputTexture);
                        this.currentDisplay = CurrentDisplayImage.Output;
                        break;

                    case CurrentDisplayImage.Intermediate:
                        this.SetUniform("output_image",
                            this.inputTexture);
                        this.currentDisplay = CurrentDisplayImage.Input;
                        break;

                    case CurrentDisplayImage.Output:
                        this.SetUniform("output_image",
                            this.intermediateTexture);
                        this.currentDisplay = CurrentDisplayImage.Intermediate;
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private CurrentDisplayImage currentDisplay = CurrentDisplayImage.Output;

        private enum CurrentDisplayImage
        {
            Input,
            Intermediate,
            Output,
        }
    }
}