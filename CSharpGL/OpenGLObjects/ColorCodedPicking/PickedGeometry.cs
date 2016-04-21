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
        public uint StageVertexID { get; set; }

        /// <summary>
        /// The element that this picked primitive belongs to.
        /// </summary>
        public virtual IColorCodedPicking From { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Geometry Type: {0}", this.GeometryType);
            builder.AppendLine();

            var positions = this.Positions;
            if (positions == null) { positions = new vec3[0]; }

            uint stageVertexID = this.StageVertexID;
            //uint lastVertexID = uint.MaxValue;
            //string strLastVertexID;
            //IColorCodedPicking picking = this.From;
            //if (picking != null)
            //{
            //    if (picking.GetLastVertexIDOfPickedGeometry(stageVertexID, out lastVertexID))
            //    { strLastVertexID = string.Format("{0}", lastVertexID); }
            //}

            for (int i = 0; i < positions.Length; i++)
            {
                //builder.Append(lastVertexID - (positions.Length - 1) + i); 
                builder.Append('['); builder.Append(Indexes[i]); builder.Append("]: ");
                builder.AppendLine(positions[i].ToString());
            }

            builder.AppendFormat("Stage Vertex ID: {0}", stageVertexID);
            builder.AppendLine();
            builder.AppendFormat("From: {0}", this.From);

            return builder.ToString();
        }

    }
}
