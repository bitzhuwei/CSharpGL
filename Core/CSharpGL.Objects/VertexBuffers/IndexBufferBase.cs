using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VertexBuffers
{
    /// <summary>
    /// 用于存储索引的VBO。
    /// </summary>
    public abstract class IndexBufferBase : VertexBuffer
    {
        /// <summary>
        /// 用于存储索引的VBO。
        /// </summary>
        /// <param name="name">此索引VBO的名字。如果有多个时，可用于区分索引。</param>
        /// <param name="mode">用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）</param>
        /// <param name="type">type in GL.DrawElements(uint mode, int count, uint type, IntPtr indices);
        /// <para>表示第3个参数，表示索引元素的类型。</para></param>
        public IndexBufferBase(string name, DrawMode mode, BufferUsage usage)
            : base(name, usage)
        {
            this.Mode = mode;
        }

        /// <summary>
        /// 此索引VBO的名字。如果有多个时，可用于区分索引。
        /// </summary>
        public string Name { get { return base.name; } }

        /// <summary>
        /// 用哪种方式渲染各个顶点？（OpenGL.GL_TRIANGLES etc.）
        /// </summary>
        public DrawMode Mode { get; private set; }

    }


}
