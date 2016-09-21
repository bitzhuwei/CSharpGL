using System.IO;
namespace CSharpGL.Demos
{
    /// <summary>
    /// Raycast Volume Rendering Demo.
    /// </summary>
    partial class RayTracingComputeRenderer : RendererBase
    {

        public static RayTracingComputeRenderer Create()
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\RayTracingRenderer\raytrace.comp.glsl"), ShaderType.ComputeShader);

            throw new System.NotImplementedException();
        }

        protected override void DoInitialize()
        {
            throw new System.NotImplementedException();
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            throw new System.NotImplementedException();
        }
    }
}