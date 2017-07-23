using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class TranslateRenderer : PickableNode
    {
        public static TranslateRenderer Create()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="model">一种渲染方式</param>
        /// <param name="positionNameInIBufferSource">vertex shader种描述顶点位置信息的in变量的名字</param>
        ///<param name="builders"></param>
        private TranslateRenderer(IBufferSource model, string positionNameInIBufferSource, params RenderUnitBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders)
        {
        }
    }
}
