using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace Transparency.Blending {
    class RectGlassModel : IBufferSource {
        private readonly vec3[] positions;

        public RectGlassModel(float width, float height) {
            var positions = new vec3[4];
            positions[0] = new vec3(width / 2.0f, height / 2.0f, 0);
            positions[1] = new vec3(-width / 2.0f, height / 2.0f, 0);
            positions[2] = new vec3(-width / 2.0f, -height / 2.0f, 0);
            positions[3] = new vec3(width / 2.0f, -height / 2.0f, 0);

            this.positions = positions;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private IDrawCommand command;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.command == null) {
                this.command = new DrawArraysCmd(CSharpGL.DrawMode.Quads, 4);
            }

            yield return this.command;
        }

        #endregion
    }
}
