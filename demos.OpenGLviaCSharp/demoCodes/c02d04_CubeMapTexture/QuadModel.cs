using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c02d04_CubeMapTexture {
    class QuadModel : IBufferSource {

        private static readonly vec2[] positions = new vec2[4] { new vec2(0, 0), new vec2(1, 0), new vec2(1, 1), new vec2(0, 1), };
        private static readonly ushort[] indexes = new ushort[] { 0, 1, 2, 0, 2, 3 };

        public const string strPositions = "positions";
        private VertexBuffer positionBuffer;

        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPositions == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec2, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                IndexBuffer buffer = indexes.GenIndexBuffer(IndexBuffer.ElementType.UShort, GLBuffer.Usage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, CSharpGL.DrawMode.Triangles);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
