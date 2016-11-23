using System;

namespace CSharpGL.Demos
{
    internal class ParticleRenderer : Renderer
    {
        public VertexBuffer PositionBuffer { get; private set; }
        public VertexBuffer VelocityBuffer { get; private set; }

        public ParticleRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                // velocity
                var buffer = VertexBuffer.Create(typeof(vec4), ParticleModel.particleCount, VBOConfig.Vec4, "empty", BufferUsage.DynamicCopy);
                unsafe
                {
                    var random = new Random();
                    var array = (vec4*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    for (int i = 0; i < ParticleModel.particleCount; i++)
                    {
                        array[i] = new vec4(
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            0);
                    }
                    buffer.UnmapBuffer();
                }
                this.VelocityBuffer = buffer;
            }

            this.PositionBuffer = this.DataSource.GetVertexAttributeBuffer(ParticleModel.strPosition, null);
        }

        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            this.VelocityBuffer.Dispose();
        }
    }
}