using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.ColorCodedPicking
{
    /// <summary>
    /// The color-coded picking result.
    /// <para>Representing a primitive.</para>
    /// </summary>
    public class PickedGeometryColored : PickedGeometryBase 
    {
        /// <summary>
        /// Gets or sets colors of this primitive.
        /// </summary>
        public vec3[] colors { get; set; }

        public override string ToString()
        {
            var positions = this.positions;
            if (positions == null) { positions = new vec3[0]; }
            var colors = this.colors;
            if (colors == null) { colors = new vec3[0]; }

            string strPositions = positions.PrintArray();
            string strColors = colors.PrintArray();

            uint stageVertexID = this.StageVertexID;
            IColorCodedPicking picking = this.From;

            string lastVertexID = "?";
            if (picking != null)
            {
                uint tmp;
                if (picking.GetLastVertexIDOfPickedGeometry(stageVertexID, out tmp))
                {
                    lastVertexID = string.Format("{0}", tmp);
                }
            }

            string result = string.Format("{0}: P: {1} C: {2} ID:{3}/{4} ∈{5}",
                GeometryType, strPositions, strColors, lastVertexID, stageVertexID, From);

            return result;
            //return base.ToString();
        }

    }
}
