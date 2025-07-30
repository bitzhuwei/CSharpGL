using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c09d01_FixedSizeQuad {
    class FixedSizeQuadModel : IBufferSource {
        private vec2[] positions;
        private static readonly vec2[] uvs = new vec2[]
        {
            new vec2(1, 1),
            new vec2(0, 1),
            new vec2(0, 0),
            new vec2(1, 0),
        };

        public FixedSizeQuadModel(int width, int height) {
            float halfWidth = width / 2.0f;
            float halfHeight = height / 2.0f;
            var positions = new vec2[4];
            positions[0] = new vec2(halfWidth, halfHeight);
            positions[1] = new vec2(-halfWidth, halfHeight);
            positions[2] = new vec2(-halfWidth, -halfHeight);
            positions[3] = new vec2(halfWidth, -halfHeight);

            this.positions = positions;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strUV = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec2, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strUV == bufferName) {
                if (this.colorBuffer == null) {
                    this.colorBuffer = uvs.GenVertexBuffer(VBOConfig.Vec2, GLBuffer.Usage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.Quads, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

    }
}
