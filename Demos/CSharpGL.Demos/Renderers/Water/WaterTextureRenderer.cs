using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterTextureRenderer : Renderer
    {
        public static WaterTextureRenderer Create(int sideLength)
        {
            var model = new WaterPlaneModel(sideLength);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\water\WaterTexture.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\water\WaterTexture.frag.glsl"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", WaterPlaneModel.strPosition);
            var renderer = new WaterTextureRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.Lengths = new vec3(sideLength, 0, sideLength);

            return renderer;
        }

        private WaterTextureRenderer(
            IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
        }

    }
}