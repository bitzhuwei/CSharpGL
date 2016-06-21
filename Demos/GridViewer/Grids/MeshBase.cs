using SharpGL.SceneGraph;
using SimLab.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab
{
    public abstract class MeshBase
    {

        public MeshBase(PositionBuffer positions)
        {
            this.Positions = positions;
        }

        /// <summary>
        /// 点的位置
        /// </summary>
        public PositionBuffer Positions { get; private set; }

        /// <summary>
        /// 最小边界坐标
        /// </summary>
        public Vertex Min { get; set; }

        /// <summary>
        /// 最大边界坐标
        /// </summary>
        public Vertex Max { get; set; }
    }
}
