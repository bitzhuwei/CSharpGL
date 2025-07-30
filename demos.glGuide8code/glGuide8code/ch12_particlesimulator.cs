
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch12_particlesimulator : _glGuide8code {
        ~ch12_particlesimulator() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch12_particlesimulator(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int
            PARTICLE_GROUP_SIZE = 128,
            PARTICLE_GROUP_COUNT = 8000,
            PARTICLE_COUNT = (PARTICLE_GROUP_SIZE * PARTICLE_GROUP_COUNT),
            MAX_ATTRACTORS = 64;

        // Compute program
        GLuint compute_prog;
        GLint dt_location;

        // Posisition and velocity buffers
        [StructLayout(LayoutKind.Explicit)]
        public struct _union {
            [FieldOffset(0)]
            public GLuint position_buffer;
            [FieldOffset(sizeof(GLuint))]
            public GLuint velocity_buffer;
            [FieldOffset(0)]
            public fixed GLuint buffers[2];
        };
        _union attrs = new _union();
        // TBOs
        [StructLayout(LayoutKind.Explicit)]
        public struct _union2 {
            [FieldOffset(0)]
            public GLuint position_tbo;
            [FieldOffset(sizeof(GLuint))]
            public GLuint velocity_tbo;
            [FieldOffset(0)]
            public fixed GLuint tbos[2];
        };
        _union2 tbos = new _union2();

        // Attractor UBO
        GLuint attractor_buffer;

        // Program, vao and vbo to render a full screen quad
        GLuint render_prog;
        GLuint render_vao;
        GLuint render_vbo;

        // Mass of the attractors
        float[] attractor_masses = new float[MAX_ATTRACTORS];

        float aspect_ratio;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "12/ch12_particlesimulator/particle.comp";
                var program = Utility.LoadShaders((vsCodeFile, Shader.Kind.comp));
                Debug.Assert(program != null); this.compute_prog = program.programId;
                gl.glUseProgram(this.compute_prog);
                dt_location = gl.glGetUniformLocation(compute_prog, "dt");
            }
            {
                var vsCodeFile = "12/ch12_particlesimulator/render.vert";
                var fsCodeFile = "12/ch12_particlesimulator/render.frag";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.render_prog = program.programId;
                gl.glUseProgram(this.render_prog);
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); render_vao = id[0];
                gl.glBindVertexArray(render_vao);

                var id2 = stackalloc GLuint[2];
                gl.glGenBuffers(2, id2); attrs.buffers[0] = id2[0]; attrs.buffers[1] = id2[1];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, attrs.position_buffer);
                gl.glBufferData(GL.GL_ARRAY_BUFFER,
                    PARTICLE_COUNT * sizeof(vec4), IntPtr.Zero, GL.GL_DYNAMIC_COPY);
                var positions = (vec4*)gl.glMapBufferRange(GL.GL_ARRAY_BUFFER,
                    0, PARTICLE_COUNT * sizeof(vec4),
                    GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                for (var i = 0; i < PARTICLE_COUNT; i++) {
                    positions[i] = new vec4(random_vector(-10.0f, 10.0f), random_float());
                }
                gl.glUnmapBuffer(GL.GL_ARRAY_BUFFER);

                gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glEnableVertexAttribArray(0);
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, attrs.velocity_buffer);
                gl.glBufferData(GL.GL_ARRAY_BUFFER,
                    PARTICLE_COUNT * sizeof(vec4), IntPtr.Zero, GL.GL_DYNAMIC_COPY);
                var velocities = (vec4*)gl.glMapBufferRange(GL.GL_ARRAY_BUFFER,
                    0, PARTICLE_COUNT * sizeof(vec4),
                    GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                for (var i = 0; i < PARTICLE_COUNT; i++) {
                    velocities[i] = new vec4(random_vector(-0.1f, 0.1f), 0.0f);
                }
                gl.glUnmapBuffer(GL.GL_ARRAY_BUFFER);

                gl.glGenTextures(2, id2); tbos.tbos[0] = id2[0]; tbos.tbos[1] = id2[1];

                for (var i = 0; i < 2; i++) {
                    gl.glBindTexture(GL.GL_TEXTURE_BUFFER, tbos.tbos[i]);
                    gl.glTexBuffer(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32F, attrs.buffers[i]);
                }

                gl.glGenBuffers(1, id); attractor_buffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, attractor_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER,
                    32 * sizeof(vec4), IntPtr.Zero, GL.GL_STATIC_DRAW);
                for (var i = 0; i < MAX_ATTRACTORS; i++) {
                    attractor_masses[i] = 0.5f + random_float() * 0.5f;
                }

                gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, attractor_buffer);
            }
        }

        long start_ticks = DateTime.Now.Ticks;
        long last_ticks;
        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {
            //gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            var current_ticks = DateTime.Now.Ticks;
            float time = ((start_ticks - current_ticks) & 0xFFFFF) / (float)(0xFFFFF);
            float delta_time = (float)(current_ticks - last_ticks) * 0.075f;

            var attractors = (vec4*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, 32 * sizeof(vec4),
                GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            for (var i = 0; i < 32; i++) {
                attractors[i] = new vec4(
                    (float)Math.Sin(time * (float)(i + 4) * 7.5f * 20.0f) * 50.0f,
                    (float)Math.Cos(time * (float)(i + 7) * 3.9f * 20.0f) * 50.0f,
                    (float)Math.Sin(time * (float)(i + 3) * 5.3f * 20.0f) * (float)Math.Cos(time * (float)(i + 5) * 9.1f) * 100.0f,
                    attractor_masses[i]);
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            // If dt is too large, the system could explode, so cap it to
            // some maximum allowed value
            if (delta_time >= 2.0f) { delta_time = 2.0f; }

            // Activate the compute program and bind the position and velocity buffers
            gl.glUseProgram(compute_prog);
            gl.glBindImageTexture(0, tbos.velocity_tbo, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            gl.glBindImageTexture(1, tbos.position_tbo, 0, false, 0, GL.GL_READ_WRITE, GL.GL_RGBA32F);
            // Set delta time
            gl.glUniform1f(dt_location, delta_time);
            // Dispatch
            gl.glDispatchCompute(PARTICLE_GROUP_COUNT, 1, 1);

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            //var mvp = vmath::perspective(45.0f, aspect_ratio, 0.1f, 1000.0f) *
            //vmath::translate(0.0f, 0.0f, -60.0f) *
            //vmath::rotate(time * 1000.0f, vmath::vec3(0.0f, 1.0f, 0.0f));
            var mvp = glm.perspective(45.0f / 180.0f * (float)Math.PI, aspect_ratio, 0.1f, 1000.0f)
                * glm.lookAt(new vec3(5, 1, 4) * 10.0f, new vec3(0, 0, 0), new vec3(0, 1, 0));

            // Clear, select the rendering program and draw a full screen quad
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glDisable(GL.GL_DEPTH_TEST);
            gl.glUseProgram(render_prog);
            gl.glUniformMatrix4fv(0, 1, false, (float*)&mvp);
            gl.glBindVertexArray(render_vao);
            gl.glEnable(GL.GL_BLEND);
            gl.glBlendFunc(GL.GL_ONE, GL.GL_ONE);
            // glPointSize(2.0f);
            gl.glDrawArrays(GL.GL_POINTS, 0, PARTICLE_COUNT);

            last_ticks = current_ticks;
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            aspect_ratio = (float)width / (float)height;
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.Escape:// 27:
                             //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];


        static uint seed = 0xFFFF0C59;
        static float random_float() {
            float res;
            uint tmp;

            seed *= 16807;

            tmp = seed ^ (seed >> 4) ^ (seed << 15);

            *((uint*)&res) = (tmp >> 9) | 0x3F800000;

            return (res - 1.0f);
        }

        static vec3 random_vector(float minmag = 0.0f, float maxmag = 1.0f) {
            vec3 randomvec = new vec3(random_float() * 2.0f - 1.0f, random_float() * 2.0f - 1.0f, random_float() * 2.0f - 1.0f);
            randomvec = randomvec.normalize();
            randomvec *= (random_float() * (maxmag - minmag) + minmag);

            return randomvec;
        }
    }
}