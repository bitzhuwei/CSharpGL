using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// 支持"拾取"的渲染器
    /// </summary>
    public partial class PickableRenderer : Renderer, IPickable
    {
        private InnerPickableRenderer innerPickableRenderer;

        /// <summary>
        ///
        /// </summary>
        [Browsable(false)]
        public string PositionNameInIBufferable { get { return this.innerPickableRenderer.PositionNameInIBufferable; } }

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="model">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="attributeMap">关联<paramref name="model"/>和<paramref name="shaderCodes"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public PickableRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        {
            var innerPickableRenderer = InnerPickableRendererFactory.GetRenderer(
                model, attributeMap, positionNameInIBufferable);
            this.innerPickableRenderer = innerPickableRenderer;
        }
    }
}