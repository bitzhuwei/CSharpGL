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
        public GeometryType GeometryType { get; set; }

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
            vec3[] positions = this.Positions;
            if (positions == null) { positions = new vec3[0]; }
            uint[] indexes = this.Indexes;

            for (int i = 0; i < positions.Length; i++)
            {
                var pos4 = new vec4(positions[i], 1);
                var worldPos = new vec3(view * pos4);
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                builder.Append(worldPos);
                builder.AppendLine();
            }
            builder.Append("Positions in Projection Space:");
            builder.AppendLine();
            for (int i = 0; i < positions.Length; i++)
            {
                var pos4 = new vec4(positions[i], 1);
                var projectionPos = new vec3(projection * view * pos4);
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                builder.Append(projectionPos);
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

            builder.AppendFormat("Stage Vertex ID: {0}", this.StageVertexId);
            builder.AppendLine();
            builder.AppendFormat("From: {0}", this.From);
            builder.AppendLine();

            if (!string.IsNullOrEmpty(this.ErrorInfo))
            {
                builder.AppendLine("Error:");
                builder.AppendLine(this.ErrorInfo);
            }

            builder.AppendFormat("Geometry Type: {0}", this.GeometryType);
            builder.AppendLine();

            vec3[] positions = this.Positions;
            if (positions == null) { positions = new vec3[0]; }
            uint[] indexes = this.Indexes;

            builder.Append("Positions in Model Space:");
            builder.AppendLine();
            for (int i = 0; i < positions.Length; i++)
            {
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                builder.Append(positions[i]);
                if (i + 1 < positions.Length)
                {
                    builder.AppendLine();
                }
            }


            return builder;
        }
    }
}
