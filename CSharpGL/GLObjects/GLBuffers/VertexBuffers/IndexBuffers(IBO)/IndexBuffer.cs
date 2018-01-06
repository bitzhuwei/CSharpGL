using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// 索引buffer渲染器的基类。
    /// <para>Base type for Vertex Buffer Object's pointer storing vertex' index.</para>
    /// </summary>
    [Browsable(true)]
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class IndexBuffer : GLBuffer
    {
        /// <summary>
        /// 索引buffer。
        /// <para>Base type for Vertex Buffer Object' pointer storing vertex' index.</para>
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="elementType">type in glDrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <param name="vertexCount">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal IndexBuffer(uint bufferId, IndexBufferElementType elementType, int vertexCount, int byteLength)
            : base(bufferId, vertexCount, byteLength)
        {
            this.ElementType = elementType;

        }

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// </summary>
        public IndexBufferElementType ElementType { get; private set; }


    }
}