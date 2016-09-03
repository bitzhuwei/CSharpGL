using System;

namespace CSharpGL.Demos
{
    internal class ParticleRenderer : Renderer
    {
        public VertexArrayObject VertexArrayObject { get; private set; }
        public PropertyBufferPtr PositionBufferPtr { get; private set; }
        public PropertyBufferPtr VelocityBufferPtr { get; private set; }

        public ParticleRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                // velocity
                var buffer = new PropertyBuffer<vec4>("empty", 4, OpenGL.GL_FLOAT, BufferUsage.DynamicCopy);
                buffer.Create(ParticleModel.particleCount);
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
                var ptr = buffer.GetBufferPtr() as PropertyBufferPtr;
                this.VelocityBufferPtr = ptr;
            }

            this.PositionBufferPtr = this.model.GetProperty(ParticleModel.strPosition, null);
            this.VertexArrayObject = this.vertexArrayObject;
        }

        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            this.VelocityBufferPtr.Dispose();
        }
    }
}