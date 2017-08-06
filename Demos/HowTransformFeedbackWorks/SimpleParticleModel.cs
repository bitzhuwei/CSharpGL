using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace HowTransformFeedbackWorks
{
    class SimpleParticleModel : IBufferSource
    {
        public const string position = "position";
        private VertexBuffer positionBuffer;
        public const string velocity = "velocity";
        private VertexBuffer velocityBuffer;

        private IndexBuffer indexBuffer;

        private static readonly vec3[] positions = new vec3[4];
        private static readonly vec3[] velocitys = new vec3[4]
        {
            new vec3(1, 0, 0), new vec3(0, 0, 1), new vec3(-1, 0, 0), new vec3(0, 0, -1),
        };

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == position)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                return this.positionBuffer;
            }
            else if (bufferName == velocity)
            {
                if (this.velocityBuffer == null)
                {
                    this.velocityBuffer = velocitys.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.DynamicCopy);
                }

                return this.velocityBuffer;
            }
            else
            {
                throw new ArgumentException("bufferName");
            }
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, positions.Length);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
