
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 高亮显示指定的图元。
    /// </summary>
    public partial class HighlightRenderer : Renderer
    {

        /// <summary>
        /// 高亮显示指定的图元。
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="BufferPtr"/>和<see cref="ShaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public HighlightRenderer(IBufferable bufferable,
            string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, HighlightShaderHelper.GetHighlightShaderCode(),
                new PropertyNameMap("in_Position", positionNameInIBufferable),
                positionNameInIBufferable, switches)
        {
            this.Name = this.GetType().Name;

            var uniformHighlightColor = new UniformVec4("highlightColor");
            //another way: uniform.SetValue(new vec4(1, 1, 1, 1));
            uniformHighlightColor.Value = new vec4(1, 1, 1, 1);
            this.UniformVariables.Add(uniformHighlightColor);
            this.UniformVariables.Add(this.uniformMVP);
            var polygonModeSwitch = new PolygonModeSwitch(PolygonModes.Lines);
            this.SwitchList.Add(polygonModeSwitch);
            var lineWidthSwitch = new LineWidthSwitch(10.0f);
            this.SwitchList.Add(lineWidthSwitch);
            var pointSizeSwitch = new PointSizeSwitch(20.0f);
            this.SwitchList.Add(pointSizeSwitch);
            var polygonOffsetSwitch = new PolygonOffsetSwitch(PolugonOffset.Fill, true);
            this.SwitchList.Add(polygonOffsetSwitch);
            polygonOffsetSwitch = new PolygonOffsetSwitch(PolugonOffset.Point, true);
            this.SwitchList.Add(polygonOffsetSwitch);

        }

    }


}
