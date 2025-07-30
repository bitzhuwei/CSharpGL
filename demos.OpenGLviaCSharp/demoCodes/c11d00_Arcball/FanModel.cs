using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c11d00_Arcball {
    class FanModel : IBufferSource {
        private readonly vec3[] positions;
        private readonly vec3[] colors;

        public FanModel(float radius) {
            float length = radius / (float)Math.Sqrt(2);
            const int count = 12;
            {
                var positions = new vec3[count];
                positions[0] = new vec3(0, 0, 0);
                for (int i = 0; i < count - 1; i++) {
                    float x = -length * (float)(i) / (float)(count - 1 - 1)
                        + length * (float)(count - 1 - i - 1) / (float)(count - 1 - 1);
                    float y = (float)Math.Sqrt(radius * radius - x * x);
                    positions[i + 1] = new vec3(x, y, 0);
                }
                this.positions = positions;
            }
            {
                var colors = new vec3[count];
                colors[0] = new vec3(1, 1, 1);
                for (int i = 0; i < count - 1; i++) {
                    colors[i + 1] = new vec3(
                        1.0f * (float)(i) / (float)(count - 1 - 1)
                        + 0.0f * (float)(count - 1 - i - 1) / (float)(count - 1 - 1),
                        0.0f * (float)(i) / (float)(count - 1 - 1)
                        + 1.0f * (float)(count - 1 - i - 1) / (float)(count - 1 - 1),
                        0.0f);
                }
                this.colors = colors;
            }
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strColor = "color";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.positionBuffer;
            }
            else if (strColor == bufferName) {
                if (this.colorBuffer == null) {
                    this.colorBuffer = this.colors.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
                }

                yield return this.colorBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.TriangleFan, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion

    }
}
