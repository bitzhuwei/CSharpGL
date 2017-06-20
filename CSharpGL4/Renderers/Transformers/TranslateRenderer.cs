using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public class TranslateRenderer : PickableRenderer
    {
        public static TranslateRenderer Create()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="model">一种渲染方式</param>
        /// <param name="renderProgramProvider">各种类型的shader代码</param>
        /// <param name="attributeMap">关联<paramref name="model"/>和<paramref name="shaderProgramProvider"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        private TranslateRenderer(IBufferable model, IShaderProgramProvider renderProgramProvider,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
            : base(model, renderProgramProvider, attributeMap, positionNameInIBufferable, switches)
        {
        }
    }
}
