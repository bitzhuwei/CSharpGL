using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class ModernRenderer : IColorCodedPicking
    {

        public mat4 MVP
        {
            get { return pickingMVP.Value; }
            set { pickingMVP.Value = value; }
        }

        public uint PickingBaseID { get; private set; }

        public void SetPickingBaseID(uint value)
        {
            this.PickingBaseID = value;
        }

        public uint GetVertexCount()
        {
            PropertyBufferPtr positionBufferPtr = this.positionBufferPtr;
            if (positionBufferPtr == null) { return 0; }
            int byteLength = positionBufferPtr.ByteLength;
            int vertexLength = positionBufferPtr.DataSize * positionBufferPtr.DataTypeByteLength;
            uint vertexCount = (uint)(byteLength / vertexLength);
            return vertexCount;
        }

        public abstract IPickedGeometry Pick(ICamera camera, uint stageVertexId,
            int x, int y, int canvasWidth, int canvasHeight);

    }
}
