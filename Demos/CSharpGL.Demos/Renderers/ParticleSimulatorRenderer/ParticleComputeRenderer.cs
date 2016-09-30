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
        private IndependentBufferPtr attractorBufferPtr;

        private BufferPtr positionBufferPtr;
        private BufferPtr velocityBufferPtr;
        private float time = 0;
        private Random random = new Random();

        public ParticleComputeRenderer(BufferPtr positionBufferPtr, BufferPtr velocityBufferPtr)
        {
            this.positionBufferPtr = positionBufferPtr;
            this.velocityBufferPtr = velocityBufferPtr;
        }

        protected override void DoInitialize()
        {
            {
                // particleSimulator.comp is also OK.
                var shaderCode = new ShaderCode(File.ReadAllText(@"shaders\ParticleSimulatorRenderer\particleSimulator.comp"), ShaderType.ComputeShader);
                this.computeProgram = shaderCode.CreateProgram();
            }
            {
                BufferPtr bufferPtr = this.positionBufferPtr;
                Texture texture = bufferPtr.DumpBufferTexture(OpenGL.GL_RGBA32F, autoDispose: false);
                texture.Initialize();
                this.positionTexture = texture;
            }
            {
                BufferPtr bufferPtr = this.velocityBufferPtr;
                Texture texture = bufferPtr.DumpBufferTexture(OpenGL.GL_RGBA32F, autoDispose: false);
                texture.Initialize();
                this.velocityTexture = texture;
            }
            {
                //OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, attractor_buffer);
                //OpenGL.BindBuffer(BufferTarget.UniformBuffer, attractor_buffer[0]);
                //OpenGL.GetDelegateFor<OpenGL.glBufferData>()(OpenGL.GL_UNIFORM_BUFFER,
                //    64 * Marshal.SizeOf(typeof(vec4)), IntPtr.Zero, OpenGL.GL_DYNAMIC_COPY);
                //OpenGL.BindBufferBase(BindBufferBaseTarget.UniformBuffer, 0, attractor_buffer[0]);
                var buffer = new UniformBuffer<vec4>(BufferUsage.DynamicCopy, true);
                buffer.Create(elementCount: 64);
                var ptr = buffer.GetBufferPtr() as IndependentBufferPtr;
                ptr.Bind();
                OpenGL.BindBufferBase((BindBufferBaseTarget)BufferTarget.UniformBuffer, 0, ptr.BufferId);
                this.attractorBufferPtr = ptr;
            }
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            float deltaTime = (float)random.NextDouble() * 5;
            time += (float)random.NextDouble() * 5;

            IntPtr attractors = this.attractorBufferPtr.MapBufferRange(
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
            this.attractorBufferPtr.UnmapBuffer();

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
            attractorBufferPtr.Dispose();
        }
    }
}