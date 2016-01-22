using CSharpGL;
using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using RedBook.Common;
using RedBook.Common.LightingExample;
using System;
using System.Runtime.InteropServices;

namespace RedBook.Winforms.Demo
{
    class ParticleSimulatorExample : RendererBase, IDisposable
    {
        const int PARTICLE_GROUP_SIZE = 128;
        const int PARTICLE_GROUP_COUNT = 8000;
        const int PARTICLE_COUNT = (PARTICLE_GROUP_SIZE * PARTICLE_GROUP_COUNT);
        const int MAX_ATTRACTORS = 64;

        // Compute program
        uint compute_prog;
        int dt_location;

        /// <summary>
        /// Posisition and velocity buffers
        /// </summary>
        uint[] buffers = new uint[2];

        /// <summary>
        /// position_tbo, velocity_tbo
        /// </summary>
        uint[] tbos = new uint[2];
        // Attractor UBO
        uint[] attractor_buffer = new uint[1];

        // Program, vao and vbo to render a full screen quad
        uint render_prog;
        uint[] render_vao = new uint[1];
        uint[] render_vbo = new uint[1];

        // Mass of the attractors
        float[] attractor_masses = new float[MAX_ATTRACTORS];

        float aspect_ratio;


        static string render_vs =
@"#version 430 core

in vec4 vert;

uniform mat4 mvp;

out float intensity;

void main(void)
{
    intensity = vert.w;
    gl_Position = mvp * vec4(vert.xyz, 1.0);
}";

        static string compute_shader_source =
            @"#version 430 core

layout (std140, binding = 0) uniform attractor_block
{
    vec4 attractor[64]; // xyz = position, w = mass
};

layout (local_size_x = 128) in;

layout (rgba32f, binding = 0) uniform imageBuffer velocity_buffer;
layout (rgba32f, binding = 1) uniform imageBuffer position_buffer;

uniform float dt = 1.0;

void main(void)
{
    vec4 vel = imageLoad(velocity_buffer, int(gl_GlobalInvocationID.x));
    vec4 pos = imageLoad(position_buffer, int(gl_GlobalInvocationID.x));

    int i;

    pos.xyz += vel.xyz * dt;
    pos.w -= 0.0001 * dt;

    for (i = 0; i < 4; i++)
    {
        vec3 dist = (attractor[i].xyz - pos.xyz);
        vel.xyz += dt * dt * attractor[i].w * normalize(dist) / (dot(dist, dist) + 10.0);
    }

    if (pos.w <= 0.0)
    {
        pos.xyz = -pos.xyz * 0.01;
        vel.xyz *= 0.01;
        pos.w += 1.0f;
    }

    imageStore(position_buffer, int(gl_GlobalInvocationID.x), pos);
    imageStore(velocity_buffer, int(gl_GlobalInvocationID.x), vel);
}";

        static string render_fs =
@"#version 430 core

layout (location = 0) out vec4 color;

in float intensity;

void main(void)
{
    color = mix(vec4(0.0f, 0.2f, 1.0f, 1.0f), vec4(0.2f, 0.05f, 0.0f, 1.0f), intensity);
}";

        public virtual void Reshape(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }


        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~ParticleSimulatorExample()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: Dispose managed resources.
                    GL.DeleteProgram(this.compute_prog);
                    GL.DeleteProgram(this.render_prog);
                    GL.DeleteVertexArrays(1, this.render_vao);
                } // end if

                // TODO: Dispose unmanaged resources.
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        static Random random = new Random();

        protected override void DoInitialize()
        {
            // Initialize our compute program
            compute_prog = GL.CreateProgram();
            ShaderHelper.vglAttachShaderSource(compute_prog, ShaderType.ComputerShader, compute_shader_source);
            GL.LinkProgram(compute_prog);
            dt_location = GL.GetUniformLocation(compute_prog, "dt");

            GL.GenVertexArrays(1, render_vao);
            GL.BindVertexArray(render_vao[0]);

            GL.GenBuffers(2, buffers);
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, buffers[0]);//position buffer
                UnmanagedArray<vec4> tmp = new UnmanagedArray<vec4>(PARTICLE_COUNT);
                GL.BufferData(BufferTarget.ArrayBuffer, tmp, BufferUsage.DynamicCopy);
                tmp.Dispose();
                IntPtr positions = GL.MapBufferRange(GL.GL_ARRAY_BUFFER,
                    0, PARTICLE_COUNT * Marshal.SizeOf(typeof(vec4)), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                unsafe
                {
                    vec4* array = (vec4*)positions.ToPointer();
                    for (int i = 0; i < PARTICLE_COUNT; i++)
                    {
                        array[i] = new vec4(Vec3Helper.GetRandomVec3(), (float)random.NextDouble());
                    }
                }
                GL.UnmapBuffer(BufferTarget.ArrayBuffer);
                GL.VertexAttribPointer(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                GL.EnableVertexAttribArray(0);
            }
            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, buffers[1]);// velocity buffer
                UnmanagedArray<vec4> tmp = new UnmanagedArray<vec4>(PARTICLE_COUNT);
                GL.BufferData(BufferTarget.ArrayBuffer, tmp, BufferUsage.DynamicCopy);
                tmp.Dispose();
                IntPtr velocities = GL.MapBufferRange(GL.GL_ARRAY_BUFFER,
                    0, PARTICLE_COUNT * Marshal.SizeOf(typeof(vec4)), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                unsafe
                {
                    vec4* array = (vec4*)velocities.ToPointer();
                    for (int i = 0; i < PARTICLE_COUNT; i++)
                    {
                        array[i] = new vec4(Vec3Helper.GetRandomVec3(), (float)random.NextDouble());
                    }
                }
                GL.UnmapBuffer(BufferTarget.ArrayBuffer);
            }
            {
                GL.GenTextures(2, tbos);
                for (int i = 0; i < 2; i++)
                {
                    GL.BindTexture(GL.GL_TEXTURE_BUFFER, tbos[i]);
                    GL.TexBuffer(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32F, buffers[i]);
                }
            }
            {
                GL.GenBuffers(1, attractor_buffer);
                GL.BindBuffer(BufferTarget.UniformBuffer, attractor_buffer[0]);
                UnmanagedArray<vec4> tmp = new UnmanagedArray<vec4>(32);
                GL.BufferData(BufferTarget.UniformBuffer, tmp, BufferUsage.StaticDraw);
                tmp.Dispose();

                for (int i = 0; i < MAX_ATTRACTORS; i++)
                {
                    attractor_masses[i] = 0.5f + (float)random.NextDouble() * 0.5f;
                }

                GL.BindBufferBase(TransformFeedbackBufferTarget.UniformBuffer, 0, attractor_buffer[0]);
            }
            {
                render_prog = GL.CreateProgram();
                ShaderHelper.vglAttachShaderSource(render_prog, ShaderType.VertexShader, render_vs);
                ShaderHelper.vglAttachShaderSource(render_prog, ShaderType.FragmentShader, render_fs);

                GL.LinkProgram(render_prog);
            }

        }

        uint start_ticks = 0;
        uint last_ticks;
        protected override void DoRender(RenderEventArgs e)
        {
            if (start_ticks == 0)
            {
                start_ticks = TimerHelper.GetTickCount();
                last_ticks = TimerHelper.GetTickCount();
            }
            uint current_ticks = TimerHelper.GetTickCount();
            const float factor = 0xFFFFF;
            float time = ((start_ticks - current_ticks) & 0xFFFFF) / factor;// *1.0f / 0.075f;
            float delta_time = (float)(current_ticks - last_ticks) * 0.075f;

            IntPtr attractors = GL.MapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, 32 * Marshal.SizeOf(typeof(vec4)), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            unsafe
            {
                vec4* array = (vec4*)attractors.ToPointer();
                for (int i = 0; i < 32; i++)
                {
                    array[i] = new vec4(
                        (float)Math.Sin(time * (float)(i + 4) * 7.5f * 20.0f) * 50.0f,
                        (float)Math.Cos(time * (float)(i + 7) * 3.9f * 20.0f) * 50.0f,
                        (float)(Math.Sin(time * (float)(i + 3) * 5.3f * 20.0f) * Math.Cos(time * (float)(i + 5) * 9.1f) * 100.0f),
                        attractor_masses[i]
                        );
                }
            }
            GL.UnmapBuffer(GL.GL_UNIFORM_BUFFER);

            // If dt is too large, the system could explode, so cap it to
            // some maximum allowed value
            if (delta_time >= 2.0f)
            {
                delta_time = 2.0f;
            }

            // Activate the compute program and bind the position and velocity buffers
            GL.UseProgram(compute_prog);
            //GL.BindImageTexture(0, velocity_tbo, 0, GL_FALSE, 0, GL_READ_WRITE, GL_RGBA32F);
            GL.BindImageTexture(0, tbos[1], 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            //GL.BindImageTexture(1, position_tbo, 0, GL_FALSE, 0, GL_READ_WRITE, GL_RGBA32F);
            GL.BindImageTexture(1, tbos[0], 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            // Set delta time
            GL.Uniform1(dt_location, delta_time);
            // Dispatch
            GL.DispatchCompute(PARTICLE_GROUP_COUNT, 1, 1);

            GL.MemoryBarrier(MemoryBarrierFlags.ShaderImageAccessBarrier);

            //vmath::mat4 mvp = vmath::perspective(45.0f, aspect_ratio, 0.1f, 1000.0f) *
            //vmath::translate(0.0f, 0.0f, -60.0f) *
            //vmath::rotate(time * 1000.0f, vmath::vec3(0.0f, 1.0f, 0.0f));

            //int[] viewport = new int[4];
            //GL.GetInteger(GetTarget.Viewport, viewport);
            //mat4 projection = glm.perspective((float)(45.0f * Math.PI / 180.0f), (float)viewport[2] / (float)viewport[3], 0.1f, 1000.0f);
            //mat4 view1 = glm.translate(mat4.identity(), new vec3(0.0f, 0.0f, -60.0f));
            //mat4 view2 = glm.rotate(mat4.identity(), time * 1000.0f, new vec3(0.0f, 1.0f, 0.0f));
            //mat4 mvp = projection * view1 * view2;

            mat4 mvp = e.Camera.GetProjectionMat4() * e.Camera.GetViewMat4();


            // Clear, select the rendering program and draw a full screen quad
            //GL.Disable(GL.GL_DEPTH_TEST);
            GL.UseProgram(render_prog);
            GL.UniformMatrix4(0, 1, false, mvp.to_array());
            GL.BindVertexArray(render_vao[0]);
            GL.Enable(GL.GL_BLEND);
            GL.BlendFunc(GL.GL_ONE, GL.GL_ONE);
            // GL.PointSize(2.0f);
            GL.DrawArrays(GL.GL_POINTS, 0, PARTICLE_COUNT);
            GL.Disable(GL.GL_BLEND);

            last_ticks = current_ticks;
        }

    }
}
