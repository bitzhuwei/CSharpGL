using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CSharpGL.Demos
{
    internal class ParticleComputeRenderer : RendererBase
    {
        private ShaderProgram computeProgram;

        //private uint[] textureBufferPosition = new uint[1];
        //private uint[] textureBufferVelocity = new uint[1];
        private Texture positionTexture;

        private Texture velocityTexture;

        //private uint[] attractor_buffer = new uint[1];
        private IndependentBuffer attractorBuffer;

        private Buffer positionBuffer;
        private Buffer velocityBuffer;
        private float time = 0;
        private Random random = new Random();

        public ParticleComputeRenderer(Buffer positionBuffer, Buffer velocityBuffer)
        {
            this.positionBuffer = positionBuffer;
            this.velocityBuffer = velocityBuffer;
        }

        protected override void DoInitialize()
        {
            {
                // particleSimulator-fountain.comp is also OK.
                var shaderCode = new ShaderCode(File.ReadAllText(@"shaders\ParticleSimulatorRenderer\particleSimulator.comp"), ShaderType.ComputeShader);
                this.computeProgram = shaderCode.CreateProgram();
            }
            {
                Buffer bufferPtr = this.positionBuffer;
                Texture texture = bufferPtr.DumpBufferTexture(OpenGL.GL_RGBA32F, autoDispose: false);
                texture.Initialize();
                this.positionTexture = texture;
            }
            {
                Buffer bufferPtr = this.velocityBuffer;
                Texture texture = bufferPtr.DumpBufferTexture(OpenGL.GL_RGBA32F, autoDispose: false);
                texture.Initialize();
                this.velocityTexture = texture;
            }
            {
                UniformBuffer bufferPtr = UniformBuffer.Create(typeof(vec4), BufferUsage.DynamicCopy, length: 64);
                bufferPtr.Bind();
                OpenGL.BindBufferBase((BindBufferBaseTarget)BufferTarget.UniformBuffer, 0, bufferPtr.BufferId);
                bufferPtr.Unbind();
                this.attractorBuffer = bufferPtr;

                OpenGL.CheckError();
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            float deltaTime = (float)random.NextDouble() * 5;
            time += (float)random.NextDouble() * 5;

            IntPtr attractors = this.attractorBuffer.MapBufferRange(
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
                        ParticleModel.attractor_masses[i]);
                }
            }
            this.attractorBuffer.UnmapBuffer();

            // Activate the compute program and bind the position and velocity buffers
            computeProgram.Bind();
            OpenGL.BindImageTexture(0, this.velocityTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            OpenGL.BindImageTexture(1, this.positionTexture.Id, 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            // Set delta time
            computeProgram.SetUniform("dt", deltaTime);
            // Dispatch
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(ParticleModel.particleGroupCount, 1, 1);
        }

        protected override void DisposeUnmanagedResources()
        {
            this.computeProgram.Dispose();
            this.positionTexture.Dispose();
            this.velocityTexture.Dispose();
            this.attractorBuffer.Dispose();
        }
    }
}