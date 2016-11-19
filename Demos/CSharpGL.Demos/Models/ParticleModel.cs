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
        private VertexBuffer positionBuffer = null;
        private VertexBuffer velocityBuffer = null;
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

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    var array = new vec4[particleCount];
                    for (int i = 0; i < particleCount; i++)
                    {
                        array[i] = new vec4(
                            (float)(random.NextDouble() - 0.5) * 20,
                            (float)(random.NextDouble() - 0.5) * 20,
                            (float)(random.NextDouble() - 0.5) * 20,
                            (float)(random.NextDouble())
                            );
                    }
                    VertexBuffer buffer = array.GenVertexBuffer(VBOConfig.Vec4, varNameInShader, BufferUsage.DynamicCopy);
                    this.positionBuffer = buffer;
                }

                return this.positionBuffer;
            }
            else if (bufferName == strVelocity)
            {
                if (this.velocityBuffer == null)
                {
                    var array = new vec4[particleCount];
                    for (int i = 0; i < particleCount; i++)
                    {
                        array[i] = new vec4(
                               (float)(random.NextDouble() - 0.5) * 0.2f,
                               (float)(random.NextDouble() - 0.5) * 0.2f,
                               (float)(random.NextDouble() - 0.5) * 0.2f,
                               0
                               );
                    }
                    VertexBuffer buffer = array.GenVertexBuffer(VBOConfig.Vec4, varNameInShader, BufferUsage.StaticDraw);
                    this.velocityBuffer = buffer;
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
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.Points, 0, vertexCount);
                this.indexBuffer = buffer;
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