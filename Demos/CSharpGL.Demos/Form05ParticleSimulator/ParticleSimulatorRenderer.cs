using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
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
        private float time = 0;
        private DepthTestSwitch depthTestSwitch = new DepthTestSwitch(false);
        private List<GLSwitch> switchList = new List<GLSwitch>();

        [Editor(typeof(GLSwithListEditor), typeof(UITypeEditor))]
        public List<GLSwitch> SwitchList
        {
            get { return switchList; }
            set { switchList = value; }
        }

        Random random = new Random();

        public ParticleSimulatorRenderer()
        {
            this.SwitchList.Add(depthTestSwitch);
        }

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
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
                            (float)(random.NextDouble() - 0.5) * 0.2f,
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
                GL.GetDelegateFor<GL.glBufferData>()(GL.GL_UNIFORM_BUFFER, 64 * Marshal.SizeOf(typeof(vec4)), IntPtr.Zero, GL.GL_DYNAMIC_COPY);
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


        protected override void DoRender(RenderEventArgs arg)
        {
            float deltaTime = (float)random.NextDouble() * 5;
            time += (float)random.NextDouble() * 5;

            GL.BindBuffer(BufferTarget.UniformBuffer, attractor_buffer[0]);
            IntPtr attractors = GL.MapBufferRange(BufferTarget.UniformBuffer,
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
                        ParticleSimulatorCompute.attractor_masses[i]);
                }
            }

            GL.UnmapBuffer(BufferTarget.UniformBuffer);
            GL.BindBuffer(BufferTarget.UniformBuffer, 0);

            // Activate the compute program and bind the position and velocity buffers
            computeProgram.Bind();
            GL.GetDelegateFor<GL.glBindImageTexture>()(0, textureBufferVelocity[0], 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            GL.GetDelegateFor<GL.glBindImageTexture>()(1, textureBufferPosition[0], 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            // Set delta time
            computeProgram.SetUniform("dt", deltaTime);
            // Dispatch
            GL.GetDelegateFor<GL.glDispatchCompute>()(ParticleSimulatorCompute.particleGroupCount, 1, 1);

            GL.GetDelegateFor<GL.glMemoryBarrier>()(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);


            // Clear, select the rendering program and draw a full screen quad
            SwitchesOn();
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
            SwitchesOff();
        }

        private void SwitchesOff()
        {
            for (int i = this.switchList.Count - 1; i >= 0; i--)
            {
                this.switchList[i].Off();
            }
        }

        private void SwitchesOn()
        {
            for (int i = 0; i < this.switchList.Count; i++)
            {
                this.switchList[i].On();
            }
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
            public const int particleGroupCount = 8000;
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