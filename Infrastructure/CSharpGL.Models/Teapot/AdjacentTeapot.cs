using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class AdjacentTeapot : IBufferSource
    {
        public vec3 GetModelSize()
        {
            return new vec3(3.214815f * 2, 1.575f * 2, 2.0f * 2);
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;
        public const string strNormal = "normal";
        private VertexBuffer normalBuffer;

        internal static readonly AdjacentFace[] adjacentFaceData;

        private IDrawCommand drawCmd;

        #region IBufferable 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = Teapot.positionData.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = Teapot.normalData.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else if (bufferName == strNormal)
            {
                if (this.normalBuffer == null)
                {
                    this.normalBuffer = Teapot.normalData.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.normalBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                IndexBuffer buffer = adjacentFaceData.GenIndexBuffer(IndexBufferElementType.UShort, BufferUsage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, DrawMode.TrianglesAdjacency);
            }

            yield return this.drawCmd;
        }

        #endregion

        static AdjacentTeapot()
        {
            adjacentFaceData = FaceHelper.CalculateAdjacentFaces(Teapot.faceData);
        }
    }
}
