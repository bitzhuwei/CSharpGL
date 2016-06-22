using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 支持"拾取"的渲染器
    /// </summary>
    public partial class PickableRenderer : Renderer, IColorCodedPicking
    {

        InnerPickableRenderer innerPickableRenderer;

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<see cref="PropertyBufferPtr"/>和<see cref="shaderCode"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public PickableRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        {
            var innerPickableRenderer = InnerPickableRendererFactory.GetRenderer(
                bufferable, propertyNameMap, positionNameInIBufferable);
            this.innerPickableRenderer = innerPickableRenderer;
        }

    }
}
