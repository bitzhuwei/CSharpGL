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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="firstVertex"></param>
        /// <param name="vertexCount"></param>
        /// <param name="primCount"></param>
        public GLZeroIndexNode(DrawMode mode, int firstVertex, int vertexCount, int primCount = 1)
        {
            this.Mode = mode;
            this.FirstVertex = firstVertex;
            this.VertexCount = vertexCount;
            this.PrimCount = primCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ZeroIndexBuffer GetIndexBuffer()
        {
            if (this.buffer == null)
            {
                this.buffer = ZeroIndexBuffer.Create(this.Mode, this.FirstVertex, this.VertexCount, this.PrimCount);
            }

            return this.buffer;
        }

        /// <summary>
        /// 
        /// </summary>
        public DrawMode Mode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FirstVertex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int VertexCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PrimCount { get; set; }
    }
}
