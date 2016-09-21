namespace CSharpGL
{
    /// <summary>
    /// 支持"拾取"的渲染器
    /// </summary>
    public partial class PickableRenderer : Renderer, IColorCodedPicking
    {
        private InnerPickableRenderer innerPickableRenderer;

        /// <summary>
        ///
        /// </summary>
        public string PositionNameInIBufferable { get { return this.innerPickableRenderer.PositionNameInIBufferable; } }

        /// <summary>
        /// 支持"拾取"的渲染器
        /// </summary>
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="attributeNameMap">关联<paramref name="bufferable"/>和<paramref name="shaderCodes"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        public PickableRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            AttributeNameMap attributeNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, attributeNameMap, switches)
        {
            var innerPickableRenderer = InnerPickableRendererFactory.GetRenderer(
                bufferable, attributeNameMap, positionNameInIBufferable);
            this.innerPickableRenderer = innerPickableRenderer;
        }
    }
}