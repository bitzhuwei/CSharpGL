using System.ComponentModel;
namespace CSharpGL
{
    public partial class PickableNode
    {
        #region IPickable 成员

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual uint GetVertexCount()
        {
            uint vertexCount = 0;

            VertexBuffer[] positionBuffers = this.PickingRenderMethod.PositionBuffers;
            foreach (var positionBuffer in positionBuffers)
            {
                if (positionBuffer != null)
                {
                    int byteLength = positionBuffer.ByteLength;
                    int vertexLength = positionBuffer.Config.GetDataSize() * positionBuffer.Config.GetDataTypeByteLength();
                    vertexCount += (uint)(byteLength / vertexLength);
                }
            }

            return vertexCount;
        }

        #endregion
    }
}