using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// All vertexs' ids of picked geometry and their indexes in <see cref="IndexBuffer"/>.
    /// </summary>
    internal class RecognizedPrimitiveInfo
    {
        private uint index;

        /// <summary>
        /// All vertexs' ids of picked geometry and their indexes in <see cref="IndexBuffer"/>.
        /// </summary>
        /// <param name="index">index of LastVertexId in the <see cref="IndexBuffer"/>.</param>
        /// <param name="vertexIds">All vertexs' ids of picked geometry.</param>
        public RecognizedPrimitiveInfo(uint index, params uint[] vertexIds)
        {
            if (vertexIds.Length < 1) { throw new Exception("This should not happen!"); }

            this.index = index;
            this.VertexIdList = vertexIds;
        }

        /// <summary>
        /// last vertex' id of picked geometry.
        /// </summary>
        public uint LastVertexId { get { return this.VertexIdList[this.VertexIdList.Length - 1]; } }

        /// <summary>
        /// All vertexs' ids of picked geometry.
        /// </summary>
        public uint[] VertexIdList { get; private set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.VertexIdList.Length - 1; i++)
            {
                builder.Append(this.VertexIdList[i]); builder.Append(", ");
            }

            builder.Append(this.VertexIdList[this.VertexIdList.Length - 1]);
            builder.AppendFormat(" | index buffer[{0}] is <{1}>", index, LastVertexId);

            return builder.ToString();
        }
    }
}