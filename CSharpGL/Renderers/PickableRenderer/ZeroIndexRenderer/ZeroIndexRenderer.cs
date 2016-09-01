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
        /// <param name="bufferable">一种渲染方式</param>
        /// <param name="shaderCodes">各种类型的shader代码</param>
        /// <param name="propertyNameMap">关联<paramref name="bufferable"/>和<paramref name="shaderCodes"/>中的属性</param>
        /// <param name="positionNameInIBufferable">描述顶点位置信息的buffer的名字</param>
        ///<param name="switches"></param>
        internal ZeroIndexRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, string positionNameInIBufferable,
            params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, positionNameInIBufferable, switches)
        { }
    }
}