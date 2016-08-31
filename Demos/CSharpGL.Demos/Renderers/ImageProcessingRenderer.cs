using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL.Demos
{

    class ImageProcessingRenderer : RendererBase
    {
        private ShaderProgram computeProgram;
        private Texture inputTexture;
        private Texture intermediateTexture;
        private Texture outputTexture;
        private PickableRenderer renderer;
        private string textureFilename;

        public ImageProcessingRenderer(string textureFilename = @"Textures\teapot.bmp")
        {
            this.textureFilename = textureFilename;
        }

        protected override void DoInitialize()
        {
            {
                var computeProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(
                    @"shaders\ImageProcessing.comp"), ShaderType.ComputeShader);
                var shader = shaderCode.CreateShader();
                computeProgram.Create(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
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
                var texture = new Texture(BindTextureTarget.Texture2D,
                    new BitmapBuilder(bitmap, 0, OpenGL.GL_RGBA32F, 0, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE),
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
                var texture = new Texture(BindTextureTarget.Texture2D,
                    new TexStorageImageBuilder(8, OpenGL.GL_RGBA32F, 512, 512),
                    new NullSampler());
                texture.Initialize();
                this.intermediateTexture = texture;
            }
            {
                // This is the texture that the compute program will write into
                var texture = new Texture(BindTextureTarget.Texture2D,
           new TexStorageImageBuilder(8, OpenGL.GL_RGBA32F, 512, 512),
           new NullSampler());
                texture.Initialize();
                this.outputTexture = texture;
            }
            {
                var bufferable = new ImageProcessingModel();
                ShaderCode[] simpleShader = new ShaderCode[2];
                simpleShader[0] = new ShaderCode(File.ReadAllText(@"shaders\ImageProcessing.vert"), ShaderType.VertexShader);
                simpleShader[1] = new ShaderCode(File.ReadAllText(@"shaders\ImageProcessing.frag"), ShaderType.FragmentShader);
                var propertyNameMap = new PropertyNameMap();
                propertyNameMap.Add("vert", "position");
                propertyNameMap.Add("uv", "uv");
                var pickableRenderer = new PickableRenderer(
                    bufferable, simpleShader, propertyNameMap, "position");
                pickableRenderer.Name = string.Format("Pickable: [{0}]", this.GetType().Name);
                pickableRenderer.Initialize();
                pickableRenderer.SetUniform("output_image",
                    this.outputTexture.ToSamplerValue());
                this.renderer = pickableRenderer;
            }

        }


        protected override void DoRender(RenderEventArgs arg)
        {
            // Activate the compute program and bind the output texture image
            computeProgram.Bind();
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(
                (uint)computeProgram.GetUniformLocation("input_image"),
                //input_image[0], 
                inputTexture.Id,
                0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(
                (uint)computeProgram.GetUniformLocation("output_image"),
                //intermediate_image[0],
                intermediateTexture.Id,
                0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            // Dispatch
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(1, 512, 1);

            OpenGL.GetDelegateFor<OpenGL.glMemoryBarrier>()(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(
                (uint)computeProgram.GetUniformLocation("input_image"),
                //intermediate_image[0],
                intermediateTexture.Id,
                0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(
                (uint)computeProgram.GetUniformLocation("output_image"),
                //output_image[0],
                outputTexture.Id,
                0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            // Dispatch
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(1, 512, 1);
            OpenGL.GetDelegateFor<OpenGL.glMemoryBarrier>()(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            mat4 view = arg.Camera.GetViewMatrix();
            mat4 projection = arg.Camera.GetProjectionMatrix();
            this.renderer.SetUniform("mvp", projection * view);
            this.renderer.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            computeProgram.Delete();
            inputTexture.Dispose();
            intermediateTexture.Dispose();
            outputTexture.Dispose();
            this.renderer.Dispose();
        }

        class ImageProcessingModel : IBufferable
        {
            public const string strposition = "position";
            public const string struv = "uv";
            PropertyBufferPtr positionBufferPtr;
            PropertyBufferPtr uvBufferPtr;
            IndexBufferPtr indexBufferPtr;

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strposition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec3>(varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Create(4);
                            unsafe
                            {
                                var array = (vec3*)buffer.Header.ToPointer();
                                array[0] = new vec3(-1.0f, -1.0f, 0.5f);
                                array[1] = new vec3(1.0f, -1.0f, 0.5f);
                                array[2] = new vec3(1.0f, 1.0f, 0.5f);
                                array[3] = new vec3(-1.0f, 1.0f, 0.5f);
                            }
                            positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }
                    return positionBufferPtr;
                }
                else if (bufferName == struv)
                {
                    if (uvBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec2>(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                        {
                            buffer.Create(4);
                            unsafe
                            {
                                var array = (vec2*)buffer.Header.ToPointer();
                                array[0] = new vec2(1, 1);
                                array[1] = new vec2(0, 1);
                                array[2] = new vec2(0, 0);
                                array[3] = new vec2(1, 0);
                            }
                            uvBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }
                    return uvBufferPtr;
                }
                else
                { throw new NotImplementedException(); }
            }

            public IndexBufferPtr GetIndex()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(DrawMode.TriangleFan, 0, 4))
                    {
                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }
                return indexBufferPtr;
            }
        }

        internal void SwitchDisplayImage(bool forward)
        {
            if (forward)
            {
                switch (this.currentDisplay)
                {
                    case CurrentDisplayImage.Input:
                        this.renderer.SetUniform("output_image",
                            this.intermediateTexture.ToSamplerValue());
                        this.currentDisplay = CurrentDisplayImage.Intermediate;
                        break;
                    case CurrentDisplayImage.Intermediate:
                        this.renderer.SetUniform("output_image",
                            this.outputTexture.ToSamplerValue());
                        this.currentDisplay = CurrentDisplayImage.Output;
                        break;
                    case CurrentDisplayImage.Output:
                        this.renderer.SetUniform("output_image",
                            this.inputTexture.ToSamplerValue());
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
                        this.renderer.SetUniform("output_image",
                            this.outputTexture.ToSamplerValue());
                        this.currentDisplay = CurrentDisplayImage.Output;
                        break;
                    case CurrentDisplayImage.Intermediate:
                        this.renderer.SetUniform("output_image",
                            this.inputTexture.ToSamplerValue());
                        this.currentDisplay = CurrentDisplayImage.Input;
                        break;
                    case CurrentDisplayImage.Output:
                        this.renderer.SetUniform("output_image",
                            this.intermediateTexture.ToSamplerValue());
                        this.currentDisplay = CurrentDisplayImage.Intermediate;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        CurrentDisplayImage currentDisplay = CurrentDisplayImage.Output;

        enum CurrentDisplayImage
        {
            Input,
            Intermediate,
            Output,
        }
    }
}