using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// glDrawArrays*().
    /// </summary>
    public sealed class GLZeroIndexNode : GLNode
    {
        private ZeroIndexBuffer buffer;

        private static readonly Type type = typeof(GLZeroIndexNode);
        internal override Type ThisTypeCache
        {
            get { return type; }
        }

        public GLZeroIndexNode(DrawMode mode, int firstVertex, int vertexCount, int primCount = 1)
        {
            this.Mode = mode;
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
            this.PrimCount = primCount;
        }

        public ZeroIndexBuffer GetIndexBuffer()
        {
            if (this.buffer == null)
            {
                this.buffer = ZeroIndexBuffer.Create(this.Mode, this.FirstVertex, this.VertexCount, this.PrimCount);
            }

            return this.buffer;
        }

        public DrawMode Mode { get; set; }

        public int FirstVertex { get; set; }

        public int VertexCount { get; set; }

        public int PrimCount { get; set; }
    }
}
