using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c12d00_StaticSlices
{
    class StaticSlicesModel : IBufferSource
    {
        public StaticSlicesModel(int sliceCount)
        {
            if (sliceCount < 1) { throw new ArgumentOutOfRangeException(); }

            var positions = new vec3[sliceCount * 4];
            for (int i = 0; i < sliceCount; i++)
            {
                positions[i * 4 + 0] = new vec3(1, 1, (float)i / (float)(sliceCount - 1));
                positions[i * 4 + 1] = new vec3(-1, 1, (float)i / (float)(sliceCount - 1));
                positions[i * 4 + 2] = new vec3(-1, -1, (float)i / (float)(sliceCount - 1));
                positions[i * 4 + 3] = new vec3(1, -1, (float)i / (float)(sliceCount - 1));
            }
            positions.Move2Center();
            this.positions = positions;

            var texCoords = new vec3[sliceCount * 4];
            for (int i = 0; i < sliceCount; i++)
            {
                texCoords[i * 4 + 0] = new vec3(1, 1, (float)i / (float)(sliceCount - 1));
                texCoords[i * 4 + 1] = new vec3(0, 1, (float)i / (float)(sliceCount - 1));
                texCoords[i * 4 + 2] = new vec3(0, 0, (float)i / (float)(sliceCount - 1));
                texCoords[i * 4 + 3] = new vec3(1, 0, (float)i / (float)(sliceCount - 1));
            }
            this.texCoords = texCoords;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        private vec3[] positions;
        public const string strTexCoord = "texCoord";
        private VertexBuffer texCoordBuffer;
        private vec3[] texCoords;

        IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (strPosition == bufferName)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strTexCoord == bufferName)
            {
                if (this.texCoordBuffer == null)
                {
                    this.texCoordBuffer = this.texCoords.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }

                yield return this.texCoordBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCommand == null)
            {
                this.drawCommand = new DrawArraysCmd(DrawMode.Quads, this.positions.Length);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
