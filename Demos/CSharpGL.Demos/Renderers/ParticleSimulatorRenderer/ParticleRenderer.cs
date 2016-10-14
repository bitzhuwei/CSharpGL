using System;

namespace CSharpGL.Demos
{
    internal class ParticleRenderer : Renderer
    {
        public VertexAttributeBufferPtr PositionBufferPtr { get; private set; }
        public VertexAttributeBufferPtr VelocityBufferPtr { get; private set; }

        public ParticleRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, params GLSwitch[] switches)
            : base(model, shaderCodes, attributeMap, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                // velocity
                var buffer = new VertexAttributeBuffer<vec4>("empty", VertexAttributeConfig.Vec4, BufferUsage.DynamicCopy);
                buffer.DoAlloc(ParticleModel.particleCount);
                unsafe
                {
                    var random = new Random();
                    var array = (vec4*)buffer.Header.ToPointer();
                    for (int i = 0; i < ParticleModel.particleCount; i++)
                    {
                        array[i] = new vec4(
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            0);
                    }
                }
                var ptr = buffer.GetBufferPtr();
                this.VelocityBufferPtr = ptr;
            }

            this.PositionBufferPtr = this.Model.GetVertexAttributeBufferPtr(ParticleModel.strPosition, null);
        }

        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            this.VelocityBufferPtr.Dispose();
        }
    }
}