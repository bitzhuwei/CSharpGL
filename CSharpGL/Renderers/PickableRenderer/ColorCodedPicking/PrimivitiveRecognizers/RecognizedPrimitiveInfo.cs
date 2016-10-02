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
        /// <param name="lastVertexId">last vertex' id of picked geometry.</param>
        /// <param name="index">index of <paramref name="lastVertexId"/> in the <see cref="IndexBuffer"/>.</param>
        /// <param name="vertexIds">All vertexs' ids of picked geometry.
        /// <para>Note: <paramref name="vertexIds"/>.Last() must equal to <paramref name="lastVertexId"/>.</para></param>
        public RecognizedPrimitiveInfo(uint lastVertexId, uint index, params uint[] vertexIds)
        {
            this.LastVertexId = lastVertexId;
            this.index = index;
            this.VertexIdList = new List<uint>();
            this.VertexIdList.AddRange(vertexIds);
        }

        public uint LastVertexId { get; set; }

        public List<uint> VertexIdList { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.VertexIdList.Count - 1; i++)
            {
                builder.Append(this.VertexIdList[i]); builder.Append(", ");
            }

            builder.Append(this.VertexIdList[this.VertexIdList.Count - 1]);
            builder.AppendFormat(" | index buffer[{0}] is <{1}>", index, LastVertexId);

            return builder.ToString();
        }
    }
}