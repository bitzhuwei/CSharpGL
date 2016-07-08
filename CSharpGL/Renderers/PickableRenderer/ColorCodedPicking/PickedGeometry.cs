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
        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projection"></param>
        /// <param name="view"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public string ToString(mat4 projection, mat4 view, mat4 model)
        {
            StringBuilder builder = BasicInfo();
            builder.AppendLine();

            vec3[] positions = this.Positions;
            if (positions == null) { positions = new vec3[0]; }
            uint[] indexes = this.Indexes;
            var worldPos = new vec4[positions.Length];
            var viewPos = new vec4[positions.Length];
            var projectionPos = new vec4[positions.Length];
            var normalizedPos = new vec3[positions.Length];
            var screenPos = new vec3[positions.Length];

            builder.Append("Positions in World Space:");
            builder.AppendLine();

            for (int i = 0; i < positions.Length; i++)
            {
                var pos4 = new vec4(positions[i], 1);
                worldPos[i] = model * pos4;
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                builder.Append(worldPos[i]);
                builder.AppendLine();
            }

            builder.Append("Positions in Camera/View Space:");
            builder.AppendLine();

            for (int i = 0; i < positions.Length; i++)
            {
                var pos4 = new vec4(positions[i], 1);
                viewPos[i] = view * worldPos[i];
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                builder.Append(viewPos[i]);
                builder.AppendLine();
            }
            builder.Append("Positions in Projection Space:");
            builder.AppendLine();
            for (int i = 0; i < positions.Length; i++)
            {
                projectionPos[i] = projection * viewPos[i];
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                builder.Append(projectionPos[i]);
                builder.AppendLine();
            }
            builder.Append("Positions in Normalized Space:");
            builder.AppendLine();
            for (int i = 0; i < positions.Length; i++)
            {
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                normalizedPos[i] = new vec3(projectionPos[i] / projectionPos[i].w);
                builder.Append(normalizedPos[i]);
                builder.AppendLine();
            }
            builder.Append("Positions in Screen Space:");
            builder.AppendLine();
            int x, y, width, height;
            OpenGL.GetViewport(out x, out y, out width, out height);
            float near, far;
            OpenGL.GetDepthRange(out near, out far);
            for (int i = 0; i < positions.Length; i++)
            {
                builder.Append('['); builder.Append(indexes[i]); builder.Append("]: ");
                screenPos[i] = new vec3(
                    normalizedPos[i].x * width / 2 + (x + width / 2),
                    normalizedPos[i].y * height / 2 + (y + height / 2),
                    normalizedPos[i].z * (far - near) / 2 + ((far + near) / 2)
                    );
                builder.Append(screenPos[i]);
                builder.AppendLine();
            }

            return builder.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
