using System.IO;
namespace CSharpGL.Demos
{
    [DemoRenderer]
    partial class SimplexNoiseRenderer : Renderer
    {
        public static SimplexNoiseRenderer Create()
        {
            var model = new Sphere(1, 180, 360);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\SimplexNoise.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", Sphere.strPosition);
            var renderer = new SimplexNoiseRenderer(model, shaderCodes, map);
            //this.Lengths = staticBufferable.Lengths;
            renderer.Lengths = model.Lengths;

            return renderer;
        }

        private SimplexNoiseRenderer(IBufferable model, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(model, shaderCodes, propertyNameMap, switches)
        {
        }
    }
}