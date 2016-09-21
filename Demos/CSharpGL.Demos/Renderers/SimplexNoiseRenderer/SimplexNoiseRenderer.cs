using System.IO;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    partial class SimplexNoiseRenderer : PickableRenderer
    {
        public static SimplexNoiseRenderer Create()
        {
            var model = new Sphere(1, 180, 360);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.frag"), ShaderType.FragmentShader);
            var map = new AttributeNameMap();
            map.Add("in_Position", Sphere.strPosition);
            var renderer = new SimplexNoiseRenderer(model, shaderCodes, map, Sphere.strPosition);
            renderer.Lengths = model.Lengths;

            return renderer;
        }

        private SimplexNoiseRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeNameMap, positionNameInIBufferable, switches)
        {
        }
    }
}