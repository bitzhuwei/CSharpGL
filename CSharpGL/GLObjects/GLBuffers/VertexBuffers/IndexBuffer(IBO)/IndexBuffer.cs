using System.ComponentModel;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// The indexes in which order the rendering command renders vertexes.
    /// </summary>
    [Browsable(true)]
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public class IndexBuffer : GLBuffer
    {
        /// <summary>
        /// The indexes in which order the rendering command renders vertexes.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="elementType">type in glDrawElements(uint mode, int count, uint type, IntPtr indices);</param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer</para></param>
        internal IndexBuffer(uint bufferId, IndexBufferElementType elementType, int byteLength)
            : base(bufferId, byteLength / elementType.GetSize(), byteLength)
        {
            this.Target = BufferTarget.ElementArrayBuffer;

            this.ElementType = elementType;
        }

        /// <summary>
        /// type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// </summary>
        public IndexBufferElementType ElementType { get; private set; }
    }
}