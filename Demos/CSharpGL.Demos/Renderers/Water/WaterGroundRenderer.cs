using System;
using System.IO;

namespace CSharpGL.Demos
{
    internal partial class WaterGroundRenderer : Renderer
    {
        public static WaterGroundRenderer Create(int length)
        {
            var model = new Sphere(length / 2.0f + 0.5f);
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\water\Background.vert.glsl"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\water\Background.frag.glsl"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("a_vertex", PlaneModel.strPosition);
            map.Add("a_normal", PlaneModel.strNormal);
            var renderer = new WaterGroundRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.Lengths = new vec3(length + 1, length + 1, length + 1);

            return renderer;
        }

        private WaterGroundRenderer(
            IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
        }

    }
}