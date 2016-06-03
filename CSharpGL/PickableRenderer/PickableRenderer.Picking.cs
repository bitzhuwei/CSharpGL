
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class PickableRenderer : IColorCodedPicking
    {
        // Color Coded Picking
        protected VertexArrayObject vertexArrayObject4Picking;

        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        protected UniformMat4 uniformmMVP4Picking = new UniformMat4("MVP");

        protected ShaderProgram pickingShaderProgram;
        protected ShaderProgram PickingShaderProgram
        {
            get
            {
                if (pickingShaderProgram == null)
                { pickingShaderProgram = PickingShaderHelper.GetPickingShaderProgram(); }

                return pickingShaderProgram;
            }
        }

        /// <summary>
        /// uniform mat4 VMP; (in shader)
        /// </summary>
        public mat4 MVP
        {
            get { return uniformmMVP4Picking.Value; }
            set { uniformmMVP4Picking.Value = value; }
        }

        public uint PickingBaseId { get; internal set; }

        public uint GetVertexCount()
        {
            PropertyBufferPtr positionBufferPtr = this.positionBufferPtr;
            if (positionBufferPtr == null) { return 0; }
            int byteLength = positionBufferPtr.ByteLength;
            int vertexLength = positionBufferPtr.DataSize * positionBufferPtr.DataTypeByteLength;
            uint vertexCount = (uint)(byteLength / vertexLength);
            return vertexCount;
        }

        public PickedGeometry Pick(
            RenderEventArgs arg,
            uint stageVertexId,
            int x, int y)
        {
            return this.innerPickableRenderer.Pick(arg, stageVertexId, x, y);
        }

    }
}
