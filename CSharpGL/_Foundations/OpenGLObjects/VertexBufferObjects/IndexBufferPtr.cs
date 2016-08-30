using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 索引buffer渲染器的基类。
    /// <para>Base type for Vertex Buffer Object' pointer storing vertex' index.</para>
    /// </summary>
    [Browsable(true)]
    [Editor(typeof(IndexBufferPtrEditor), typeof(UITypeEditor))]
    public abstract class IndexBufferPtr : BufferPtr
    {

        /// <summary>
        /// 用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// 索引buffer渲染器的基类。
        /// <para>Base type for Vertex Buffer Object' pointer storing vertex' index.</para>
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="bufferId"></param>
        /// <param name="length">此VBO含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal IndexBufferPtr(DrawMode mode, uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            this.Mode = mode;
        }
    }
}
