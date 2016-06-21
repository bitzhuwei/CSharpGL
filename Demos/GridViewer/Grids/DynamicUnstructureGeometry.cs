using SimLab.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimLab
{
    public class DynamicUnstructureGeometry : MeshBase
    {

        private IndexBuffer matrixIndices;
        private FracturePositionBuffer fracturePositions;

        /// <summary>
        /// 基质的模型
        /// </summary>
        /// <param name="matrixPositions"></param>
        public DynamicUnstructureGeometry(PositionBuffer matrixPositions)
            : base(matrixPositions)
        { }

        /// <summary>
        /// 基质基质的索引
        /// </summary>
        public IndexBuffer MatrixIndices
        {
            get { return this.matrixIndices; }
            set { this.matrixIndices = value; }
        }

        /// <summary>
        /// 基质的位置信息描述
        /// </summary>
        public MatrixPositionBuffer MatrixPositions
        {
            get
            {
                return (MatrixPositionBuffer)base.Positions;
            }
        }

        public FracturePositionBuffer FracturePositions
        {
            get
            {
                return this.fracturePositions;
            }
            internal set
            {
                this.fracturePositions = value;
            }
        }

    }
}
