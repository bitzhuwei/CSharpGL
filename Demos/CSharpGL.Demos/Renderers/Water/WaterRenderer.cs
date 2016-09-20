using System;
using System.IO;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    internal partial class WaterRenderer : Renderer
    {
        public static WaterRenderer Create(int sideLength)
        {
            var model = new WaterPlaneModel(sideLength);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\water\Water.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\water\Water.frag.glsl"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", WaterPlaneModel.strPosition);
            var renderer = new WaterRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.Lengths = new vec3(sideLength, 0, sideLength);

            return renderer;
        }

        private WaterRenderer(
            IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
        }

    }
}