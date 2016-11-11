using System;

namespace CSharpGL.Demos
{
    internal class ParticleRenderer : Renderer
    {
        public VertexAttributeBuffer PositionBuffer { get; private set; }
        public VertexAttributeBuffer VelocityBuffer { get; private set; }

        public ParticleRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                // velocity
                var bufferPtr = VertexAttributeBuffer.Create(typeof(vec4), ParticleModel.particleCount, VertexAttributeConfig.Vec4, BufferUsage.DynamicCopy, "empty");
                unsafe
                {
                    var random = new Random();
                    var array = (vec4*)bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                    for (int i = 0; i < ParticleModel.particleCount; i++)
                    {
                        array[i] = new vec4(
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            0);
                    }
                    bufferPtr.UnmapBuffer();
                }
                this.VelocityBuffer = bufferPtr;
            }

            this.PositionBuffer = this.Model.GetVertexAttributeBuffer(ParticleModel.strPosition, null);
        }

        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            this.VelocityBuffer.Dispose();
        }
    }
}