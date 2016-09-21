using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterBackgroundRenderer : Renderer
    {
        public float passedTime;

        public static WaterBackgroundRenderer Create(int waterPlaneLength)
        {
            var model = new Sphere(waterPlaneLength / 2.0f + 0.5f, 20, 80);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\water\Background.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\water\Background.frag.glsl"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            map.Add("a_vertex", PlaneModel.strPosition);
            //map.Add("a_normal", PlaneModel.strNormal);
            var renderer = new WaterBackgroundRenderer(model, shaderCodes, map, new FrontFaceSwitch(FrontFaceMode.CW));
            renderer.Lengths = new vec3(waterPlaneLength + 1, waterPlaneLength + 1, waterPlaneLength + 1);

            return renderer;
        }

        private WaterBackgroundRenderer(
            IBufferable bufferable, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, attributeNameMap, switches)
        {
        }
    }
}