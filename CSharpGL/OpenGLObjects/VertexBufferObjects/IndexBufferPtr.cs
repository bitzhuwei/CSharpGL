using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 索引buffer渲染器的基类。
    /// </summary>
    [Browsable(true)]
    public abstract class IndexBufferPtr : BufferPtr
    {

        /// <summary>
        /// 用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// 索引buffer渲染器的基类。
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="bufferID"></param>
        /// <param name="length">此VBO含有多个个元素？</param>
        /// <param name="byteLength">此VBO占多少字节？</param>
        internal IndexBufferPtr(DrawMode mode, uint bufferID, int length, int byteLength)
            : base(bufferID, length, byteLength)
        {
            this.Mode = mode;
        }
    }
}
