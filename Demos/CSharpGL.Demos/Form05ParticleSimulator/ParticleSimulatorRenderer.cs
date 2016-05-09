using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Demos
{

    class ParticleSimulatorRenderer : RendererBase
    {
        private ShaderProgram computeProgram;
        private uint[] render_vao = new uint[1];
        private uint[] position_buffer = new uint[1];
        private uint[] velocity_buffer = new uint[1];
        private uint[] textureBufferPosition = new uint[1];
        private uint[] textureBufferVelocity = new uint[1];
        private uint[] attractor_buffer = new uint[1];
        private ShaderProgram visualProgram;

        Random random = new Random();

        protected override void DoInitialize()
        {
            {
                var computeProgram = new ShaderProgram();
                var shaderCode = new ShaderCode(File.ReadAllText(@"Shaders\particleSimulator.comp"), ShaderType.ComputeShader);
                var shader = shaderCode.CreateShader();
                computeProgram.Create(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
            {
                //var bufferable = new ParticleSimulatorCompute();
                GL.GetDelegateFor<GL.glGenVertexArrays>()(1, render_vao);
                GL.GetDelegateFor<GL.glBindVertexArray>()(render_vao[0]);
                // position
                GL.GetDelegateFor<GL.glGenBuffers>()(1, position_buffer);
                GL.BindBuffer(BufferTarget.ArrayBuffer, position_buffer[0]);
                var positions = new UnmanagedArray<vec4>(ParticleSimulatorCompute.particleCount);
                unsafe
                {
                    var array = (vec4*)positions.FirstElement();
                    for (int i = 0; i < ParticleSimulatorCompute.particleCount; i++)
                    {
                        array[i] = new vec4(
                            (float)(random.NextDouble() - 0.5) * 20,
                            (float)(random.NextDouble() - 0.5) * 20,
                            (float)(random.NextDouble() - 0.5) * 20,
                            (float)(random.NextDouble())
                            );
                    }
                }
                GL.BufferData(BufferTarget.ArrayBuffer, positions, BufferUsage.DynamicCopy);
                positions.Dispose();
                GL.GetDelegateFor<GL.glVertexAttribPointer>()(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.GetDelegateFor<GL.glEnableVertexAttribArray>()(0);
                // velocity
                GL.GetDelegateFor<GL.glGenBuffers>()(1, velocity_buffer);
                GL.BindBuffer(BufferTarget.ArrayBuffer, velocity_buffer[0]);
                var velocities = new UnmanagedArray<vec4>(ParticleSimulatorCompute.particleCount);
                unsafe
                {
                    var array = (vec4*)velocities.FirstElement();
                    for (int i = 0; i < ParticleSimulatorCompute.particleCount; i++)
                    {
                        array[i] = new vec4(
                            (float)(random.NextDouble() - 0.5) * 2,
                            (float)(random.NextDouble() - 0.5) * 2,
                            (float)(random.NextDouble() - 0.5) * 2,
                            0);
                    }
                }
                GL.BufferData(BufferTarget.ArrayBuffer, velocities, BufferUsage.DynamicCopy);
                velocities.Dispose();
                //GL.GetDelegateFor<GL.glVertexAttribPointer>()(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                //GL.GetDelegateFor<GL.glEnableVertexAttribArray>()(0);
                //
                GL.GenTextures(1, textureBufferPosition);
                GL.BindTexture(GL.GL_TEXTURE_BUFFER, textureBufferPosition[0]);
                GL.GetDelegateFor<GL.glTexBuffer>()(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32F, position_buffer[0]);
                GL.GenTextures(1, textureBufferVelocity);
                GL.BindTexture(GL.GL_TEXTURE_BUFFER, textureBufferVelocity[0]);
                GL.GetDelegateFor<GL.glTexBuffer>()(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32F, velocity_buffer[0]);

                GL.GetDelegateFor<GL.glGenBuffers>()(1, attractor_buffer);
                GL.BindBuffer(BufferTarget.UniformBuffer, attractor_buffer[0]);
                var attractorArray = new UnmanagedArray<vec4>(32);
                for (int i = 0; i < 32; i++)
                {
                    attractorArray[i] = new vec4(
                        (float)(random.NextDouble()) * 0.5f + 0.5f,
                        (float)(random.NextDouble()) * 0.5f + 0.5f,
                        (float)(random.NextDouble()) * 0.5f + 0.5f,
                        (float)(random.NextDouble()) * 0.5f + 0.5f);
                }
                GL.BufferData(BufferTarget.UniformBuffer, attractorArray, BufferUsage.StaticDraw);
                attractorArray.Dispose();
                GL.GetDelegateFor<GL.glBindBufferBase>()(GL.GL_UNIFORM_BUFFER, 0, attractor_buffer[0]);
            }
            {
                var visualProgram = new ShaderProgram();
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"Shaders\particleSimulator.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"Shaders\particleSimulator.frag"), ShaderType.FragmentShader);
                var shaders = (from item in shaderCodes select item.CreateShader()).ToArray();
                visualProgram.Create(shaders);
                foreach (var item in shaders) { item.Delete(); }
                this.visualProgram = visualProgram;
            }
        }

        float tick = 0;

        protected override void DoRender(RenderEventArgs arg)
        {
            float deltaTick = random.Next(0, 10);
            tick += (float)random.NextDouble() / 100;

            GL.BindBuffer(BufferTarget.UniformBuffer, attractor_buffer[0]);
            IntPtr attractors = GL.MapBufferRange(BufferTarget.UniformBuffer,
                0, 32 * sizeof(float) * 4, MapBufferRangeAccess.MapWriteBit | MapBufferRangeAccess.MapInvalidateBufferBit);
            unsafe
            {
                var array = (vec4*)attractors.ToPointer();
                for (int i = 0; i < 32; i++)
                {
                    array[i] = new vec4(
                        (float)(Math.Sin(tick)) * 50.0f,
                        (float)(Math.Cos(tick)) * 50.0f,
                        (float)(Math.Sin(tick)) * 50.0f * (float)(Math.Cos(tick)),
                        ParticleSimulatorCompute.attractor_masses[i]);
                }
            }

            GL.UnmapBuffer(BufferTarget.UniformBuffer);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);

            // If dt is too large, the system could explode, so cap it to
            // some maximum allowed value
            //if (delta_time >= 2.0f)
            //{
            //    delta_time = 2.0f;
            //}

            // Activate the compute program and bind the position and velocity buffers
            computeProgram.Bind();
            GL.GetDelegateFor<GL.glBindImageTexture>()(0, textureBufferVelocity[0], 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            GL.GetDelegateFor<GL.glBindImageTexture>()(1, textureBufferPosition[0], 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            // Set delta time
            computeProgram.SetUniform("dt", deltaTick);
            // Dispatch
            GL.GetDelegateFor<GL.glDispatchCompute>()(ParticleSimulatorCompute.particleGroupCount, 1, 1);

            GL.GetDelegateFor<GL.glMemoryBarrier>()(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            
            // Clear, select the rendering program and draw a full screen quad
            GL.Disable(GL.GL_DEPTH_TEST);
            visualProgram.Bind();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            visualProgram.SetUniformMatrix4("mvp", (projection * view).to_array());
            GL.GetDelegateFor<GL.glBindVertexArray>()(render_vao[0]);
            GL.Enable(GL.GL_BLEND);
            GL.BlendFunc(GL.GL_ONE, GL.GL_ONE);
            // glPointSize(2.0f);
            GL.DrawArrays(DrawMode.Points, 0, ParticleSimulatorCompute.particleCount);
            GL.Disable(GL.GL_BLEND);
            GL.Enable(GL.GL_DEPTH_TEST);
        }

        protected override void DisposeUnmanagedResources()
        {
            computeProgram.Delete();
            IntPtr ptr = Win32.wglGetCurrentContext();
            if (ptr != IntPtr.Zero)
            {
                GL.GetDelegateFor<GL.glDeleteVertexArrays>()(1, render_vao);
            }
            GL.DeleteBuffers(1, position_buffer);
            GL.DeleteBuffers(1, velocity_buffer);
            GL.DeleteBuffers(1, textureBufferPosition);
            GL.DeleteBuffers(1, textureBufferVelocity);
            GL.DeleteBuffers(1, attractor_buffer);
            visualProgram.Delete();
        }


        class ParticleSimulatorCompute : IBufferable
        {
            public static readonly float[] attractor_masses = new float[maxAttractor];

            public const int particleGroupSize = 128;
            public const int particleGroupCount = 800;
            public const int particleCount = (particleGroupSize * particleGroupCount);
            public const int maxAttractor = 64;

            public const string strPosition = "position";
            public const string strVelocity = "velocity";
            private PropertyBufferPtr positionBufferPtr = null;
            private PropertyBufferPtr velocityBufferPtr = null;
            private IndexBufferPtr indexBufferPtr;
            Random random = new Random();

            static ParticleSimulatorCompute()
            {
                Random random = new Random();
                for (int i = 0; i < maxAttractor; i++)
                {
                    attractor_masses[i] = 0.5f + (float)random.NextDouble() * 0.5f;
                }
            }

            public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            {
                if (bufferName == strPosition)
                {
                    if (positionBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec4>(
                            varNameInShader, 4, GL.GL_FLOAT, BufferUsage.DynamicCopy))
                        {
                            buffer.Alloc(particleCount);
                            unsafe
                            {
                                var array = (vec4*)buffer.FirstElement();
                                for (int i = 0; i < particleCount; i++)
                                {
                                    array[i] = new vec4(
                                        (float)(random.NextDouble() - 0.5) * 20,
                                        (float)(random.NextDouble() - 0.5) * 20,
                                        (float)(random.NextDouble() - 0.5) * 20,
                                        (float)(random.NextDouble())
                                        );
                                }
                            }

                            positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }

                    return positionBufferPtr;
                }
                else if (bufferName == strVelocity)
                {
                    if (velocityBufferPtr == null)
                    {
                        using (var buffer = new PropertyBuffer<vec4>(
                            varNameInShader, 4, GL.GL_FLOAT, BufferUsage.DynamicCopy))
                        {
                            buffer.Alloc(particleCount);
                            unsafe
                            {
                                var array = (vec4*)buffer.FirstElement();
                                for (int i = 0; i < particleCount; i++)
                                {
                                    array[i] = new vec4(
                                        (float)(random.NextDouble() - 0.5) * 2,
                                        (float)(random.NextDouble() - 0.5) * 2,
                                        (float)(random.NextDouble() - 0.5) * 2,
                                        0
                                        );
                                }
                            }

                            velocityBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                        }
                    }

                    return velocityBufferPtr;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            public IndexBufferPtr GetIndex()
            {
                if (indexBufferPtr == null)
                {
                    using (var buffer = new ZeroIndexBuffer(DrawMode.Points, 0, particleCount))
                    {
                        indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                    }
                }

                return indexBufferPtr;
            }
        }
    }
}