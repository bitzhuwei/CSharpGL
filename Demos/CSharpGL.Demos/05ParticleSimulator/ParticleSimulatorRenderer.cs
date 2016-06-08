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
        private ShaderProgram visualProgram;
        private DepthTestSwitch depthTestSwitch = new DepthTestSwitch(false);

        private uint[] textureBufferPosition = new uint[1];
        private uint[] textureBufferVelocity = new uint[1];
        private uint[] attractor_buffer = new uint[1];
        private float time = 0;

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
                var shaderCode = new ShaderCode(File.ReadAllText(@"05ParticleSimulator\particleSimulator.comp"), ShaderType.ComputeShader);
                var shader = shaderCode.CreateShader();
                computeProgram.Create(shader);
                shader.Delete();
                this.computeProgram = computeProgram;
            }
            {
                //var bufferable = new ParticleSimulatorCompute();
                OpenGL.GetDelegateFor<OpenGL.glGenVertexArrays>()(1, render_vao);
                OpenGL.GetDelegateFor<OpenGL.glBindVertexArray>()(render_vao[0]);
                // position
                OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, position_buffer);
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, position_buffer[0]);
                var positions = new UnmanagedArray<vec4>(ParticleModel.particleCount);
                unsafe
                {
                    var array = (vec4*)positions.Header.ToPointer();
                    for (int i = 0; i < ParticleModel.particleCount; i++)
                    {
                        array[i] = new vec4(
                            (float)(random.NextDouble() - 0.5) * 20,
                            (float)(random.NextDouble() - 0.5) * 20,
                            (float)(random.NextDouble() - 0.5) * 20,
                            (float)(random.NextDouble())
                            );
                    }
                }
                OpenGL.BufferData(BufferTarget.ArrayBuffer, positions, BufferUsage.DynamicCopy);
                positions.Dispose();
                OpenGL.GetDelegateFor<OpenGL.glVertexAttribPointer>()(0, 4, OpenGL.GL_FLOAT, false, 0, IntPtr.Zero);
                OpenGL.GetDelegateFor<OpenGL.glEnableVertexAttribArray>()(0);
                // velocity
                OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, velocity_buffer);
                OpenGL.BindBuffer(BufferTarget.ArrayBuffer, velocity_buffer[0]);
                var velocities = new UnmanagedArray<vec4>(ParticleModel.particleCount);
                unsafe
                {
                    var array = (vec4*)velocities.Header.ToPointer();
                    for (int i = 0; i < ParticleModel.particleCount; i++)
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
                OpenGL.GetDelegateFor<OpenGL.glBindVertexArray>()(0);

                OpenGL.GenTextures(1, textureBufferPosition);
                OpenGL.BindTexture(OpenGL.GL_TEXTURE_BUFFER, textureBufferPosition[0]);
                OpenGL.GetDelegateFor<OpenGL.glTexBuffer>()(OpenGL.GL_TEXTURE_BUFFER, OpenGL.GL_RGBA32F, position_buffer[0]);
                OpenGL.GenTextures(1, textureBufferVelocity);
                OpenGL.BindTexture(OpenGL.GL_TEXTURE_BUFFER, textureBufferVelocity[0]);
                OpenGL.GetDelegateFor<OpenGL.glTexBuffer>()(OpenGL.GL_TEXTURE_BUFFER, OpenGL.GL_RGBA32F, velocity_buffer[0]);

                OpenGL.GetDelegateFor<OpenGL.glGenBuffers>()(1, attractor_buffer);
                OpenGL.BindBuffer(BufferTarget.UniformBuffer, attractor_buffer[0]);
                OpenGL.GetDelegateFor<OpenGL.glBufferData>()(OpenGL.GL_UNIFORM_BUFFER, 64 * Marshal.SizeOf(typeof(vec4)), IntPtr.Zero, OpenGL.GL_DYNAMIC_COPY);
                OpenGL.GetDelegateFor<OpenGL.glBindBufferBase>()(OpenGL.GL_UNIFORM_BUFFER, 0, attractor_buffer[0]);
            }
            {
                var visualProgram = new ShaderProgram();
                var shaderCodes = new ShaderCode[2];
                shaderCodes[0] = new ShaderCode(File.ReadAllText(@"05ParticleSimulator\particleSimulator.vert"), ShaderType.VertexShader);
                shaderCodes[1] = new ShaderCode(File.ReadAllText(@"05ParticleSimulator\particleSimulator.frag"), ShaderType.FragmentShader);
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
                        ParticleModel.attractor_masses[i]);
                }
            }

            OpenGL.UnmapBuffer(BufferTarget.UniformBuffer);
            OpenGL.BindBuffer(BufferTarget.UniformBuffer, 0);

            // Activate the compute program and bind the position and velocity buffers
            computeProgram.Bind();
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(0, textureBufferVelocity[0], 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            OpenGL.GetDelegateFor<OpenGL.glBindImageTexture>()(1, textureBufferPosition[0], 0, false, 0, OpenGL.GL_READ_WRITE, OpenGL.GL_RGBA32F);
            // Set delta time
            computeProgram.SetUniform("dt", deltaTime);
            // Dispatch
            OpenGL.GetDelegateFor<OpenGL.glDispatchCompute>()(ParticleModel.particleGroupCount, 1, 1);

            OpenGL.GetDelegateFor<OpenGL.glMemoryBarrier>()(OpenGL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);


            // Clear, select the rendering program and draw a full screen quad
            SwitchesOn();
            visualProgram.Bind();
            mat4 view = arg.Camera.GetViewMat4();
            mat4 projection = arg.Camera.GetProjectionMat4();
            visualProgram.SetUniformMatrix4("mvp", (projection * view).to_array());
            OpenGL.GetDelegateFor<OpenGL.glBindVertexArray>()(render_vao[0]);
            OpenGL.Enable(OpenGL.GL_BLEND);
            OpenGL.BlendFunc(OpenGL.GL_ONE, OpenGL.GL_ONE);
            // glPointSize(2.0f);
            OpenGL.DrawArrays(DrawMode.Points, 0, ParticleModel.particleCount);
            OpenGL.Disable(OpenGL.GL_BLEND);
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
                OpenGL.GetDelegateFor<OpenGL.glDeleteVertexArrays>()(1, render_vao);
            }
            OpenGL.DeleteBuffers(1, position_buffer);
            OpenGL.DeleteBuffers(1, velocity_buffer);
            OpenGL.DeleteBuffers(1, textureBufferPosition);
            OpenGL.DeleteBuffers(1, textureBufferVelocity);
            OpenGL.DeleteBuffers(1, attractor_buffer);
            visualProgram.Delete();
        }

    }
}