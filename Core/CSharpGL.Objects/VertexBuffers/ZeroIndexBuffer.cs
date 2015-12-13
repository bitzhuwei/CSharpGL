using CSharpGL.Objects.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VertexBuffers
{
    /// <summary>
    /// 没有显式的索引。等价于索引数组的值为[0,1,2,2,3,4,5,6,7,8,9...]
    /// </summary>
    public class ZeroIndexBuffer : IndexBufferBase
    {
        /// <summary>
        /// 没有显式的索引。等价于索引数组的值为[0,1,2,2,3,4,5,6,7,8,9...]
        /// </summary>
        /// <param name="mode">渲染模式。</param>
        /// <param name="vertexCount">有多少个顶点需要渲染？</param>
        public ZeroIndexBuffer(DrawMode mode, int vertexCount)
            : base(mode, BufferUsage.StaticDraw)
        {
            this.VertexCount = vertexCount;
        }

        /// <summary>
        /// 有多少个顶点需要渲染？
        /// </summary>
        public int VertexCount { get; private set; }

        protected override UnmanagedArrayBase CreateElements(int elementCount)
        {
            return null;
        }

        protected override BufferRenderer CreateRenderer()
        {
            ZeroIndexBufferRenderer renderer = new ZeroIndexBufferRenderer(
                 this.Mode, this.VertexCount);

            return renderer;
        }

    }
}
