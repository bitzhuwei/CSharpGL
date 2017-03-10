namespace CSharpGL
{
    /// <summary>
    /// 用glDrarArrays进行渲染。
    /// </summary>
    partial class ZeroIndexRenderer : InnerPickableRenderer
    {
        /// <summary>
        /// 用glDrarArrays进行渲染。
        /// </summary>
        /// <param name="model">一种渲染方式</param>
        /// <param name="shaderProgramProvider">各种类型的shader代码</param>
        /// <param name="attributeMap">关联<paramref name="model"/>和<paramref name="shaderProgramProvider"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal ZeroIndexRenderer(IBufferable model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, positionNameInIBufferable, switches)
        { }
    }
}