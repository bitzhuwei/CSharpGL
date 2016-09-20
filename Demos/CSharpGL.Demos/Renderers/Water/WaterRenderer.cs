using System;
using System.IO;

namespace CSharpGL.Demos
{
    [DemoRenderer]
    internal partial class WaterRenderer : Renderer
    {
        public static WaterRenderer Create(IBufferable model, vec3 lengths)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\AnalyzedPointSprite.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\AnalyzedPointSprite.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("position", "position");
            var renderer = new WaterRenderer(model, shaderCodes, map, new PointSpriteSwitch());
            renderer.Lengths = lengths;

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