using System.IO;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    internal partial class WaterRenderer : Renderer
    {
        public static WaterRenderer Create(int waterPlaneLength)
        {
            var model = new WaterPlaneModel(waterPlaneLength);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\water\Water.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\water\Water.frag.glsl"), ShaderType.FragmentShader);
            var provider = new ShaderCodeArray(shaderCodes);
            var map = new AttributeMap();
            map.Add("a_vertex", WaterPlaneModel.strPosition);
            var renderer = new WaterRenderer(model, provider, map, new FrontFaceState(FrontFaceMode.CCW));
            renderer.waterTextureRenderer = WaterTextureRenderer.Create(waterPlaneLength);
            renderer.backgroundRenderer = WaterBackgroundRenderer.Create(waterPlaneLength);
            renderer.ModelSize = new vec3(waterPlaneLength + 1, waterPlaneLength + 1, waterPlaneLength + 1);
            renderer.waterPlaneLength = waterPlaneLength;

            return renderer;
        }

        private WaterTextureRenderer waterTextureRenderer;

        public WaterTextureRenderer WaterTextureRenderer
        {
            get { return waterTextureRenderer; }
        }

        private WaterBackgroundRenderer backgroundRenderer;

        public WaterBackgroundRenderer BackgroundRenderer
        {
            get { return backgroundRenderer; }
        }

        private int waterPlaneLength;
        private CullFaceState cullfaceState;

        private WaterRenderer(
            IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, switches)
        {
        }
    }
}