using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace ParticleSystem.TransformFeedback
{
    public class ParticleModel : IBufferSource
    {
        public const string position = "position";
        private VertexBuffer positionBuffer;
        public const string pre_position = "pre_position";
        private VertexBuffer prePositionBuffer;
        public const string direction = "direction";
        private VertexBuffer directionBuffer;

        private IndexBuffer indexBuffer;

        private int particleCount;

        public ParticleModel(int particleCount)
        {
            this.particleCount = particleCount;
        }

        #region IBufferSource 成员

        public VertexBuffer GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == position)
            {
                if (this.positionBuffer == null)
                {
                    var data = new vec4[particleCount];
                    var random = new Random();
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = new vec4(
                            (float)random.NextDouble(),
                            (float)random.NextDouble(),
                            (float)random.NextDouble(),
                            (float)random.NextDouble()
                            ) - new vec4(1, 1, 1, 1) * 0.5f;
                    }
                    this.positionBuffer = data.GenVertexBuffer(VBOConfig.Vec4, BufferUsage.DynamicCopy);
                    //this.positionBuffer = VertexBuffer.Create(typeof(vec4), particleCount, VBOConfig.Vec4, BufferUsage.DynamicCopy);
                }

                return this.positionBuffer;
            }
            else if (bufferName == pre_position)
            {
                if (this.prePositionBuffer == null)
                {
                    this.prePositionBuffer = VertexBuffer.Create(typeof(vec4), particleCount, VBOConfig.Vec4, BufferUsage.DynamicCopy);
                }

                return this.prePositionBuffer;
            }
            else if (bufferName == direction)
            {
                if (this.directionBuffer == null)
                {
                    var data = new vec4[particleCount];
                    var random = new Random();
                    for (int i = 0; i < data.Length; i++)
                    {
                        data[i] = new vec4(
                            (float)random.NextDouble(),
                            (float)random.NextDouble(),
                            (float)random.NextDouble(),
                            (float)random.NextDouble()
                            ) - new vec4(1, 1, 1, 1) * 0.5f;
                    }
                    this.directionBuffer = data.GenVertexBuffer(VBOConfig.Vec4, BufferUsage.DynamicCopy);
                    //this.directionBuffer = VertexBuffer.Create(typeof(vec4), particleCount, VBOConfig.Vec4, BufferUsage.DynamicCopy); ;
                }

                return this.directionBuffer;
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
                this.indexBuffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, this.particleCount);
            }

            return this.indexBuffer;
        }

        #endregion
    }
}
