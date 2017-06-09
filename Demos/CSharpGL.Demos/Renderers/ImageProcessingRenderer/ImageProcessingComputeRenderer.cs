using System.IO;

namespace CSharpGL.Demos
{
    internal class ImageProcessingComputeRenderer : RendererBase
    {
        private ShaderProgram computeProgram;
        private InnerImageProcessingRenderer innerRenderer;

        private static readonly GLDelegates.void_uint glMemoryBarrier;
        private static readonly GLDelegates.void_uint_uint_int_bool_int_uint_uint glBindImageTexture;
        static ImageProcessingComputeRenderer()
        {
            glMemoryBarrier = OpenGL.GetDelegateFor("glMemoryBarrier", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glBindImageTexture = OpenGL.GetDelegateFor("glBindImageTexture", GLDelegates.typeof_void_uint_uint_int_bool_int_uint_uint) as GLDelegates.void_uint_uint_int_bool_int_uint_uint;
        }

        public static ImageProcessingComputeRenderer Create(InnerImageProcessingRenderer innerRenderer)
        {
            var renderer = new ImageProcessingComputeRenderer(innerRenderer);

            return renderer;
        }

        private ImageProcessingComputeRenderer(InnerImageProcessingRenderer innerRenderer)
        {
            this.innerRenderer = innerRenderer;
        }

        protected override void DoInitialize()
        {
            var shaderCode = new ShaderCode(File.ReadAllText(
@"shaders\ImageProcessingRenderer\ImageProcessing.comp"), ShaderType.ComputeShader);
            ShaderProgram computeProgram = shaderCode.CreateProgram();

            this.computeProgram = computeProgram;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            // Activate the compute program and bind the output texture image
            computeProgram.Bind();
            glBindImageTexture((uint)computeProgram.GetUniformLocation("input_image"), this.innerRenderer.InputTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            glBindImageTexture((uint)computeProgram.GetUniformLocation("output_image"), this.innerRenderer.IntermediateTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            // Dispatch
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(1, 512, 1);
            glMemoryBarrier(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
            computeProgram.Unbind();

            computeProgram.Bind();
            glBindImageTexture((uint)computeProgram.GetUniformLocation("input_image"), this.innerRenderer.IntermediateTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            glBindImageTexture((uint)computeProgram.GetUniformLocation("output_image"), this.innerRenderer.OutputTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            // Dispatch
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(1, 512, 1);
            glMemoryBarrier(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);
            computeProgram.Unbind();
        }
    }
}