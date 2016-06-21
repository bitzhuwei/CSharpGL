using SharpGL.SceneGraph;
using SimLab.SimGrid;
using SimLab.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab
{
    public class HexahedronMeshGeometry3D : MeshBase
    {
        /// <summary>
        /// 三角形的索引
        /// </summary>
        private HalfHexahedronIndexBuffer halfHexahedronIndices;

        public HexahedronMeshGeometry3D(PositionBuffer positions, HalfHexahedronIndexBuffer triangleIndices)
            :base(positions)
        {
            this.halfHexahedronIndices = triangleIndices;
        }


        public HalfHexahedronIndexBuffer HalfHexahedronIndices
        {
            get { return this.halfHexahedronIndices; }
        }

    }
}
