using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 没有显式的索引。等价于索引数组的值为[0,1,2,2,3,4,5,6,7,8,9...]
    /// </summary>
    public sealed class ZeroIndexBuffer : IndexBuffer<byte>
    {
        /// <summary>
        /// 没有显式的索引。等价于索引数组的值为[0,1,2,2,3,4,5,6,7,8,9...]
        /// </summary>
        /// <param name="mode">渲染模式。</param>
        /// <param name="firstVertex">要渲染的第一个顶点的索引。</param>
        /// <param name="vertexCount">有多少个顶点需要渲染？</param>
        public ZeroIndexBuffer(DrawMode mode, int firstVertex, int vertexCount)
            : base(mode, BufferUsage.StaticDraw)
        {
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
        }

        /// <summary>
        /// 要渲染的第一个顶点的索引。
        /// </summary>
        public int FirstVertex { get; private set; }

        /// <summary>
        /// 有多少个顶点需要渲染？
        /// </summary>
        public int VertexCount { get; private set; }

        protected override UnmanagedArray<byte> CreateElements(int elementCount)
        {
            return null;
        }

        protected override VertexBufferPtr Upload2GPU()
        {
            ZeroIndexBufferPtr bufferPtr = new ZeroIndexBufferPtr(
                 this.Mode, this.FirstVertex, this.VertexCount);

            return bufferPtr;
        }

    }
}
