using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Renders an axis with white circle on arrow.
    /// </summary>
    class AxisRenderer : PickableRenderer
    {

        public static AxisRenderer Create(int partCount = 24)
        {
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.UIAxis.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(ManifestResourceLoader.LoadTextFile(
@"Resources.UIAxis.frag"), ShaderType.FragmentShader);
            var map = new PropertyNameMap();
            map.Add("in_Position", Axis.strPosition);
            map.Add("in_Color", Axis.strColor);
            var model = new Axis(partCount);
            var renderer = new AxisRenderer(model, shaderCodes, map, "position");
            return renderer;
        }

        private AxisRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        { }

    }
}
