using System.IO;

namespace CSharpGL.Demos
{
    internal class ImageProcessingRenderer : RendererBase
    {
        private ShaderProgram computeProgram;
        private InnerImageProcessingRenderer innerRenderer;

        public ImageProcessingRenderer(string textureFilename = @"Textures\edgeDetection.bmp")
        {
            this.innerRenderer = InnerImageProcessingRenderer.Create(textureFilename);
        }

        protected override void DoInitialize()
        {
            {
                var shaderCode = new ShaderCode(File.ReadAllText(
                    @"shaders\ImageProcessingRenderer\ImageProcessing.comp"), ShaderType.ComputeShader);
                this.computeProgram = shaderCode.CreateProgram();
            }

            this.innerRenderer.Initialize();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            // Activate the compute program and bind the output texture image
            computeProgram.Bind();
            OpenGL.BindImageTexture((uint)computeProgram.GetUniformLocation("input_image"), this.innerRenderer.InputTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            OpenGL.BindImageTexture((uint)computeProgram.GetUniformLocation("output_image"), this.innerRenderer.IntermediateTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            // Dispatch
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(1, 512, 1);

            OpenGL.GetDelegateFor<OpenGL.glMemoryBarrier>()(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            OpenGL.BindImageTexture((uint)computeProgram.GetUniformLocation("input_image"), this.innerRenderer.IntermediateTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            OpenGL.BindImageTexture((uint)computeProgram.GetUniformLocation("output_image"), this.innerRenderer.OutputTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            // Dispatch
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(1, 512, 1);
            OpenGL.GetDelegateFor<OpenGL.glMemoryBarrier>()(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            this.innerRenderer.Render(arg);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.computeProgram.Dispose();
            this.innerRenderer.Dispose();
        }

        public void SwitchDisplayImage(bool forward)
        {
            this.innerRenderer.SwitchDisplayImage(forward);
        }
    }
}