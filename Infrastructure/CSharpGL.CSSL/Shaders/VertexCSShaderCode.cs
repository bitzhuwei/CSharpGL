namespace CSharpGL.CSSL
{
    /// <summary>
    /// vertex shader共有的内容。
    /// 想写一个vertex shader，就继承此类型吧。
    /// </summary>
    public abstract partial class VertexCSShaderCode : CSShaderCode
    {
        protected vec4 gl_Position;

        protected float gl_PointSize;
    }
}