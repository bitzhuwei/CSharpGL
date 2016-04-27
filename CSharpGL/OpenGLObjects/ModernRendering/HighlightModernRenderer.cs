using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 高亮显示某些图元
    /// </summary>
    public partial class HighlightModernRenderer : ModernRenderer
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="VertexBufferPtr"/>和<see cref="ShaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal HighlightModernRenderer(IBufferable bufferable,
            string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, PickingShaderHelper.GetPickingShaderCode(),
                new PropertyNameMap("in_Position", positionNameInIBufferable),
                positionNameInIBufferable, switches)
        {
            var uniform = new UniformVec4("highlightColor");
            //another way: uniform.SetValue(new vec4(1, 1, 1, 1));
            uniform.Value = new vec4(1, 1, 1, 1);
            this.UniformVariables.Add(uniform);
            var glSwitch = new PolygonModeSwitch(PolygonModes.Lines);
            this.SwitchList.Add(glSwitch);
        }

    }


}
