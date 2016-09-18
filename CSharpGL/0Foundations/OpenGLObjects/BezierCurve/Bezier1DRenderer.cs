using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class Bezier1DRenderer : PickableRenderer
    {
        /// <summary>
        /// Gets a renderer that renders a bitmap in a square.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="lengths"></param>
        /// <returns></returns>
        public static Bezier1DRenderer Create(IBufferable model, vec3 lengths)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.Bezier1DRenderer.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.Bezier1DRenderer.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", Square.strPosition);
            map.Add("in_TexCoord", Square.strTexCoord);
            var renderer = new Bezier1DRenderer(model, shaderCodes, map, Square.strPosition);
            renderer.Lengths = lengths;

            return renderer;
        }

        public Bezier1DRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        { }

    }
}
