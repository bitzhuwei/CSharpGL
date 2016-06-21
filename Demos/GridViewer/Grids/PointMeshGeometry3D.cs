using SimLab.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab
{
    public class PointMeshGeometry3D : MeshBase
    {

        public PointRadiusBuffer Radius { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="positions"></param>
        /// <param name="count">有多少个顶点</param>
        public PointMeshGeometry3D(PointPositionBuffer positions, PointRadiusBuffer radius, int count)
            : base(positions)
        {
            this.Radius = radius;
            this.Count = count;
        }

        /// <summary>
        /// 顶点数目
        /// </summary>
        public int Count { get; private set; }

    }
}
