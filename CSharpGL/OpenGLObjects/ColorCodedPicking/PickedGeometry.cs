using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// The color-coded picking result.
    /// <para>Representing a primitive.</para>
    /// </summary>
    public class PickedGeometry : IPickedGeometry
    {
        public string ErrorInfo { get; set; }

        /// <summary>
        /// Gets or sets primitive's geometry type.
        /// </summary>
        public GeometryTypes GeometryType { get; set; }

        /// <summary>
        /// Gets or sets positions of this primitive's vertices.
        /// </summary>
        public vec3[] Positions { get; set; }

        /// <summary>
        /// Gets or sets indexes of this primitive's vertexes' index in the VBO.
        /// </summary>
        public uint[] Indexes { get; set; }

        /// <summary>
        /// The last vertex's id that constructs the picked primitive.
        /// <para>This id is in scene's all <see cref="IColorCodedPicking"/>s' order.</para>
        /// </summary>
        public uint StageVertexId { get; set; }

        /// <summary>
        /// The element that this picked primitive belongs to.
        /// </summary>
        public virtual IColorCodedPicking From { get; set; }

        public string ToString(mat4 projection, mat4 view)
        {
            StringBuilder builder = BasicInfo();
            builder.AppendLine();

            builder.Append("Positions in World Space:");
            builder.AppendLine();
            var positions = this.Positions;
            if (positions == null) { positions = new vec3[0]; }
            for (int i = 0; i < positions.Length; i++)
            {
                var pos4 = new vec4(positions[i], 1);
                vec4 worldPos4 = projection * view * pos4;
                vec3 worldPos = new vec3(worldPos4);
                builder.Append(string.Format("[{0}]: {1}", this.Indexes[i], worldPos));
                builder.AppendLine();
            }

            return builder.ToString();
        }
        public override string ToString()
        {
            StringBuilder builder = BasicInfo();

            return builder.ToString();
        }

        private StringBuilder BasicInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Geometry Type: {0}", this.GeometryType);
            builder.AppendLine();

            var positions = this.Positions;
            if (positions == null) { positions = new vec3[0]; }

            uint stageVertexId = this.StageVertexId;
            //uint lastVertexId = uint.MaxValue;
            //string strLastVertexID;
            //IColorCodedPicking picking = this.From;
            //if (picking != null)
            //{
            //    if (picking.GetLastVertexIdOfPickedGeometry(stageVertexId, out lastVertexId))
            //    { strLastVertexID = string.Format("{0}", lastVertexId); }
            //}

            for (int i = 0; i < positions.Length; i++)
            {
                //builder.Append(lastVertexId - (positions.Length - 1) + i); 
                builder.Append('['); builder.Append(Indexes[i]); builder.Append("]: ");
                builder.AppendLine(positions[i].ToString());
            }

            builder.AppendFormat("Stage Vertex ID: {0}", stageVertexId);
            builder.AppendLine();
            builder.AppendFormat("From: {0}", this.From);

            if (!string.IsNullOrEmpty(this.ErrorInfo))
            {
                builder.AppendLine("Error:");
                builder.AppendLine(this.ErrorInfo);
            }

            return builder;
        }
    }
}
