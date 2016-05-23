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
                var worldPos = view * pos4;
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                builder.Append(worldPos);
                builder.AppendLine();
            }
            builder.Append("Positions in Projection Space:");
            builder.AppendLine();
            for (int i = 0; i < positions.Length; i++)
            {
                var pos4 = new vec4(positions[i], 1);
                var projectionPos = projection * view * pos4;
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                builder.Append(projectionPos);
                builder.AppendLine();
            }
            builder.Append("Positions in Normalized Space:");
            builder.AppendLine();
            for (int i = 0; i < positions.Length; i++)
            {
                var pos4 = new vec4(positions[i], 1);
                var projectionPos = projection * view * pos4;
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                vec3 normalizedPos = new vec3(projectionPos / projectionPos.w);
                builder.Append(normalizedPos);
                builder.AppendLine();
            }
            builder.Append("Positions in Screen Space:");
            builder.AppendLine();
            int x, y, width, height;
            GL.GetViewport(out x, out y, out width, out height);
            float near, far;
            GL.GetDepthRange(out near, out far);
            for (int i = 0; i < positions.Length; i++)
            {
                var pos4 = new vec4(positions[i], 1);
                var projectionPos = projection * view * pos4;
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                vec3 normalizedPos = new vec3(projectionPos / projectionPos.w);
                vec3 screenPos = new vec3(
                    normalizedPos.x * width / 2 + (x + width / 2),
                    normalizedPos.y * height / 2 + (y + height / 2),
                    normalizedPos.z * (far - near) / 2 + ((far + near) / 2)
                    );
                builder.Append(screenPos);
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
