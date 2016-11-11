using System;

namespace CSharpGL.Demos
{
    internal class ParticleModel : IBufferable
    {
        public static readonly float[] attractor_masses = new float[maxAttractor];

        public const int particleGroupSize = 128;
        public const int particleGroupCount = 8000;
        public const int particleCount = (particleGroupSize * particleGroupCount);
        public const int maxAttractor = 64;

        public const string strPosition = "position";
        public const string strVelocity = "velocity";
        private VertexAttributeBuffer positionBuffer = null;
        private VertexAttributeBuffer velocityBuffer = null;
        private IndexBuffer indexBuffer;
        private Random random = new Random();

        static ParticleModel()
        {
            Random random = new Random();
            for (int i = 0; i < maxAttractor; i++)
            {
                attractor_masses[i] = 0.5f + (float)random.NextDouble() * 0.5f;
            }
        }

        public VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    int length = particleCount;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec4), length, VertexAttributeConfig.Vec4, BufferUsage.DynamicCopy, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec4*)pointer;
                        for (int i = 0; i < particleCount; i++)
                        {
                            array[i] = new vec4(
                                (float)(random.NextDouble() - 0.5) * 20,
                                (float)(random.NextDouble() - 0.5) * 20,
                                (float)(random.NextDouble() - 0.5) * 20,
                                (float)(random.NextDouble())
                                );
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBuffer = bufferPtr;
                }

                return this.positionBuffer;
            }
            else if (bufferName == strVelocity)
            {
                if (this.velocityBuffer == null)
                {
                    int length = particleCount;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec4), length, VertexAttributeConfig.Vec4, BufferUsage.DynamicCopy, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec4*)pointer;
                        for (int i = 0; i < particleCount; i++)
                        {
                            array[i] = new vec4(
                                (float)(random.NextDouble() - 0.5) * 0.2f,
                                (float)(random.NextDouble() - 0.5) * 0.2f,
                                (float)(random.NextDouble() - 0.5) * 0.2f,
                                0
                                );
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.velocityBuffer = bufferPtr;
                }

                return this.velocityBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int vertexCount = particleCount;
                ZeroIndexBuffer bufferPtr = ZeroIndexBuffer.Create(DrawMode.Points, 0, vertexCount);
                this.indexBuffer = bufferPtr;
            }

            return this.indexBuffer;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}