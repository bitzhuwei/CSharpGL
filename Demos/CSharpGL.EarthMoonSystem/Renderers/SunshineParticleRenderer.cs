using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.EarthMoonSystem
{
    class SunshineParticleRenderer : Renderer
    {
        public VertexArrayObject VertexArrayObject { get; private set; }
        public PropertyBufferPtr PositionBufferPtr { get; private set; }
        public uint VelocityBufferPtrId { get; private set; }

        public SunshineParticleRenderer(IBufferable bufferable, ShaderCode[] shaderCodes,
            PropertyNameMap propertyNameMap, params GLSwitch[] switches)
            : base(bufferable, shaderCodes, propertyNameMap, switches)
        { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            {
                // velocity
                var velocity_buffer = new uint[1];
                OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, velocity_buffer);
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, velocity_buffer[0]);
                var velocities = new UnmanagedArray<vec4>(SunshineParticleModel.particleCount);
                unsafe
                {
                    var random = new Random();
                    var array = (vec4*)velocities.Header.ToPointer();
                    for (int i = 0; i < SunshineParticleModel.particleCount; i++)
                    {
                        array[i] = new vec4(
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            0);
                    }
                }
                OpenGL.BufferData(BufferTarget.ArrayBuffer, velocities, BufferUsage.DynamicCopy);
                velocities.Dispose();
                //GL.GetDelegateFor<GL.glVertexAttribPointer>()(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                //GL.GetDelegateFor<GL.glEnableVertexAttribArray>()(0);
                //
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, 0);
                this.VelocityBufferPtrId = velocity_buffer[0];
            }

            this.PositionBufferPtr = this.bufferable.GetProperty(SunshineParticleModel.strPosition, null);
            this.VertexArrayObject = this.vertexArrayObject;
        }

        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            OpenGL.DeleteBuffers(1, new uint[] { this.VelocityBufferPtrId, });
        }
    }
}