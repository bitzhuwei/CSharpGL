using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c15d00_ParticleSystem {
    class ParticlesModel : IBufferSource {
        private readonly int count;
        private vec4[] positions;
        private vec4[] velocities;

        public ParticlesModel(int count) {
            var random = new Random();
            this.count = count;
            {
                const float max = 1;
                var positions = new vec4[count];
                for (int i = 0; i < count; i++) {
                    positions[i] = new vec4(
                        (float)(random.NextDouble() - 0.5) * max,
                        (float)(random.NextDouble() - 0.5) * max,
                        (float)(random.NextDouble() - 0.5) * max,
                        (float)(random.NextDouble() * 6)
                    );
                }
                this.positions = positions;
            }
            {
                var velocities = new vec4[count];
                for (int i = 0; i < count; i++) {
                    velocities[i] = new vec4(
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() * 6));
                }
                this.velocities = velocities;
            }
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;
        public const string strVelocity = "velocity";
        private VertexBuffer velocityBuffer;

        private IDrawCommand drawCommand;

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (strPosition == bufferName) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = this.positions.GenVertexBuffer(VBOConfig.Vec4, GLBuffer.Usage.DynamicCopy);
                }

                yield return this.positionBuffer;
            }

            else if (strVelocity == bufferName) {
                if (this.velocityBuffer == null) {
                    this.velocityBuffer = this.velocities.GenVertexBuffer(VBOConfig.Vec4, GLBuffer.Usage.DynamicCopy);
                }

                yield return this.velocityBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCommand == null) {
                this.drawCommand = new DrawArraysCmd(CSharpGL.DrawMode.Points, count, 0, count);
            }

            yield return this.drawCommand;
        }

        #endregion
    }
}
