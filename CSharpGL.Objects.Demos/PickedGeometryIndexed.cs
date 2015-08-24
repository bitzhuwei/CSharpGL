using CSharpGL.Maths;
using CSharpGL.Objects.ColorCodedPicking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos
{
    class PickedGeometryIndexed : PickedGeometryBase
    {
        /// <summary>
        /// Gets or sets colors of this primitive.
        /// </summary>
        //public int PrimitiveIndex { get; set; }
        public uint CubeIndex { get; set; }

        public override string ToString()
        {
            var positions = this.positions;
            if (positions == null) { positions = new vec3[0]; }

            string strPositions = positions.PrintArray();

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

            string result = string.Format("{0}: Pos: {1} Cube Index: {2} ID:{3}/{4} ∈{5}",
                GeometryType, strPositions, CubeIndex, lastVertexID, stageVertexID, From);

            return result;
            //return base.ToString();
        }
    }
}
