using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c14d03_ParticleSystem {
    partial class ParticleModel : IBufferSource {
        public const string inPosition = "inPosition";
        public const string inPosition2 = "inPosition2";
        public const string inVelocity = "inVelocity";
        public const string inVelocity2 = "inVelocity2";
        private VertexBuffer positionBuffer;
        private VertexBuffer positionBuffer2;
        private VertexBuffer velocityBuffer;
        private VertexBuffer velocityBuffer2;

        private IDrawCommand drawCmd;

        private readonly vec3[] positions;
        private readonly vec4[] velocitys;

        private static Random random = new Random();

        public ParticleModel(int particleCount) {
            {
                var positions = new vec3[particleCount];
                for (int i = 0; i < particleCount; i++) {
                    positions[i] = new vec3(
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() - 0.5));
                }
                this.positions = positions;
            }
            {
                var velocitys = new vec4[particleCount];
                for (int i = 0; i < particleCount; i++) {
                    velocitys[i] = new vec4(
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() * 6));
                }
                this.velocitys = velocitys;
            }
        }

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (bufferName == inPosition) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.DynamicCopy);
                }

                yield return this.positionBuffer;
            }
            else if (bufferName == inPosition2) {
                if (this.positionBuffer2 == null) {
                    this.positionBuffer2 = positions.GenVertexBuffer(VBOConfig.Vec3, GLBuffer.Usage.DynamicCopy);
                }

                yield return this.positionBuffer2;
            }
            else if (bufferName == inVelocity) {
                if (this.velocityBuffer == null) {
                    this.velocityBuffer = velocitys.GenVertexBuffer(VBOConfig.Vec4, GLBuffer.Usage.DynamicCopy);
                }

                yield return this.velocityBuffer;
            }
            else if (bufferName == inVelocity2) {
                if (this.velocityBuffer2 == null) {
                    this.velocityBuffer2 = velocitys.GenVertexBuffer(VBOConfig.Vec4, GLBuffer.Usage.DynamicCopy);
                }

                yield return this.velocityBuffer2;
            }
            else {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                this.drawCmd = new DrawArraysCmd(CSharpGL.DrawMode.Points, positions.Length);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}
