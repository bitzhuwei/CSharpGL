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
    class SunshineComputeRenderer : RendererBase
    {
        private ShaderProgram computeProgram;
        private uint[] textureBufferPosition = new uint[1];
        private uint[] attractor_buffer = new uint[1];
        private uint positionBufferPtrId;
        private float time = 0;
        Random random = new Random();

        public SunshineComputeRenderer(uint positionBufferPtrId)
        {
            this.positionBufferPtrId = positionBufferPtrId;
        }

        protected override void DoInitialize()
        {
            {
                var computeProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"shaders\SunshineCompute.comp"), ShaderType.ComputeShader);
                var shader = shaderCode.CreateShader();
                computeProgram.Create(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
            {
                OpenGL.GenTextures(1, textureBufferPosition);
                OpenGL.BindTexture(OpenGL.GL_TEXTURE_BUFFER, textureBufferPosition[0]);
                OpenGL.GetDelegateFor<OpenGL.glTexBuffer>()(OpenGL.GL_TEXTURE_BUFFER,
                    OpenGL.GL_RGBA32F, this.positionBufferPtrId);
            }
            {
                OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, attractor_buffer);
                OpenGL.BindBuffer(BufferTarget.UniformBuffer, attractor_buffer[0]);
                OpenGL.GetDelegateFor<OpenGL.glBufferData>()(OpenGL.GL_UNIFORM_BUFFER,
                    64 * Marshal.SizeOf(typeof(vec4)), IntPtr.Zero, OpenGL.GL_DYNAMIC_COPY);
                OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>()(OpenGL.GL_UNIFORM_BUFFER,
                    0, attractor_buffer[0]);
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            var deltaDistance = (float)random.NextDouble() * 0.1f;
            time += (float)random.NextDouble() * 5;

            OpenGL.BindBuffer(BufferTarget.UniformBuffer, attractor_buffer[0]);
            IntPtr attractors = OpenGL.MapBufferRange(BufferTarget.UniformBuffer,
                0, 64 * Marshal.SizeOf(typeof(vec4)),
                MapBufferRangeAccess.MapWriteBit | MapBufferRangeAccess.MapInvalidateBufferBit);
            unsafe
            {
                var array = (vec4*)attractors.ToPointer();
                for (int i = 0; i < 64; i++)
                {
                    array[i] = new vec4(
                        (float)(Math.Sin(time)) * 50.0f,
                        (float)(Math.Cos(time)) * 50.0f,
                        (float)(Math.Cos(time)) * (float)(Math.Sin(time)) * 5.0f,
                        SunshineParticleModel.attractor_masses[i]);
                }
            }

            OpenGL.UnmapBuffer(BufferTarget.UniformBuffer);
            OpenGL.BindBuffer(BufferTarget.UniformBuffer, 0);

            // Activate the compute program and bind the position and velocity buffers
            computeProgram.Bind();
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(0,
                textureBufferPosition[0], 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            // Set delta time
            computeProgram.SetUniform("dt", deltaDistance);
            // Dispatch
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(SunshineParticleModel.particleGroupCount, 1, 1);

        }

        protected override void DisposeUnmanagedResources()
        {
            this.computeProgram.Delete();
            OpenGL.DeleteBuffers(1, textureBufferPosition);
            OpenGL.DeleteBuffers(1, attractor_buffer);
        }
    }
}