using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace HowTransformFeedbackWorks
{
    partial class ParticleDemoModel : IBufferSource
    {
        public const string inPosition = "inPosition";
        public const string inPosition2 = "inPosition2";
        public const string inVelocity = "inVelocity";
        public const string inVelocity2 = "inVelocity2";
        private VertexBuffer positionBuffer;
        private VertexBuffer positionBuffer2;
        private VertexBuffer velocityBuffer;
        private VertexBuffer velocityBuffer2;

        private IndexBuffer indexBuffer;

        private readonly vec3[] positions;
        private readonly vec3[] velocitys;

        private static Random random = new Random();

        public ParticleDemoModel(int particleCount)
        {
            {
                var positions = new vec3[particleCount];
                for (int i = 0; i < particleCount; i++)
                {
                    positions[i] = new vec3(
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() - 0.5),
                        (float)(random.NextDouble() - 0.5));
                }
                this.positions = positions;
            }
            {
                this.velocitys = new vec3[particleCount];
            }
        }

        #region IBufferSource 成员

        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == inPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                return this.positionBuffer;
            }
            else if (bufferName == inPosition2)
            {
                if (this.positionBuffer2 == null)
                {
                    this.positionBuffer2 = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                return this.positionBuffer2;
            }
            else if (bufferName == inVelocity)
            {
                if (this.velocityBuffer == null)
                {
                    this.velocityBuffer = velocitys.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                return this.velocityBuffer;
            }
            else if (bufferName == inVelocity2)
            {
                if (this.velocityBuffer2 == null)
                {
                    this.velocityBuffer2 = velocitys.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                return this.velocityBuffer2;
            }
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IEnumerable<IndexBuffer> GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, positions.Length);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
