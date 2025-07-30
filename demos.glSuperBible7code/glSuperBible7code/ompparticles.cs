
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class ompparticles : _glSuperBible7code {
        ~ompparticles() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ompparticles(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int PARTICLE_COUNT = 2048;

        struct PARTICLE {
            public vec3 position;
            public vec3 velocity;
        }
        GLuint particle_buffer;
        PARTICLE* mapped_buffer;
        PARTICLE[][] particles = new PARTICLE[2][];
        int frame_index;
        GLuint vao;
        GLuint draw_program;
        bool use_omp = true;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/ompparticles.vert";
                var fsCodeFile = "media/shaders/ompparticles.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.draw_program = programObj.programId;
                gl.glUseProgram(this.draw_program);

            }
            {
                // Application memory particle buffers (double buffered)
                particles[0] = new PARTICLE[PARTICLE_COUNT];
                particles[1] = new PARTICLE[PARTICLE_COUNT];

                var id = stackalloc GLuint[1];
                // Create GPU buffer
                gl.glGenBuffers(1, id); particle_buffer = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, particle_buffer);
                gl.glBufferStorage(GL.GL_ARRAY_BUFFER,
                    PARTICLE_COUNT * sizeof(PARTICLE), 0, GL.GL_MAP_WRITE_BIT | 0x0040/*GL_MAP_PERSISTENT_BIT*/);
                mapped_buffer = (PARTICLE*)gl.glMapBufferRange(
                    GL.GL_ARRAY_BUFFER,
                    0, PARTICLE_COUNT * sizeof(PARTICLE),
                    GL.GL_MAP_WRITE_BIT | 0x0040/*GL_MAP_PERSISTENT_BIT*/ | GL.GL_MAP_FLUSH_EXPLICIT_BIT);

                iniitialize_particles();

                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                gl.glVertexAttribFormat(0, 3, GL.GL_FLOAT, false, 0);
                gl.glBindVertexBuffer(0, particle_buffer, 0, sizeof(PARTICLE));
                gl.glEnableVertexAttribArray(0);

                //int maxThreads = omp_get_max_threads();
                //omp_set_num_threads(maxThreads);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float currentTime = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        static double previousTime = 0.0;
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            currentTime += 0.1f;

            var proj_matrix = this.proj_matrix;


            // Calculate delta time
            float deltaTime = (float)(currentTime - previousTime);
            previousTime = currentTime;

            // Update particle positions using OpenMP... or not.
            if (use_omp) {
                update_particles_omp(deltaTime * 0.001f);
            }
            else {
                update_particles(deltaTime * 0.001f);
            }

            // Clear
            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, black);

            // Bind our vertex arrays
            gl.glBindVertexArray(vao);

            // Let OpenGL know we've changed the contents of the buffer
            gl.glFlushMappedBufferRange(GL.GL_ARRAY_BUFFER, 0, PARTICLE_COUNT * sizeof(PARTICLE));

            gl.glPointSize(3.0f);

            // Draw!
            gl.glUseProgram(draw_program);
            gl.glDrawArrays(GL.GL_POINTS, 0, PARTICLE_COUNT);
        }

        int width, height;
        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            this.width = width; this.height = height;
            gl.glViewport(0, 0, width, height);

            //aspect = (float)height / (float)width;
            this.proj_matrix = glm.perspective(50.0f * (float)Math.PI / 180.0f, (float)width / (float)height, 0.1f, 1000.0f);
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.M:
            use_omp = !use_omp;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];

        // Random number generator
        static uint seed = 0x13371337;

        static float random_float() {
            float res;
            uint tmp;

            seed *= 16807;

            tmp = seed ^ (seed >> 4) ^ (seed << 15);

            *((uint*)&res) = (tmp >> 9) | 0x3F800000;

            return (res - 1.0f);
        }

        void iniitialize_particles() {
            int i;

            for (i = 0; i < PARTICLE_COUNT; i++) {
                particles[0][i].position[0] = random_float() * 6.0f - 3.0f;
                particles[0][i].position[1] = random_float() * 6.0f - 3.0f;
                particles[0][i].position[2] = random_float() * 6.0f - 3.0f;
                particles[0][i].velocity = particles[0][i].position * 0.001f;

                mapped_buffer[i] = particles[0][i];
            }
        }

        void update_particles(float deltaTime) {
            // Double buffer source and destination
            fixed (PARTICLE* src = particles[frame_index & 1])
            fixed (PARTICLE* dst = particles[(frame_index + 1) & 1]) {
                // For each particle in the system
                //#pragma omp parallel for schedule (dynamic, 16)
                for (int i = 0; i < PARTICLE_COUNT; i++) {
                    // Get my own data
                    PARTICLE me = src[i];
                    var delta_v = new vec3(0.0f);

                    // For all the other particles
                    for (int j = 0; j < PARTICLE_COUNT; j++) {
                        if (i != j) // ... not me!
                        {
                            //  Get the vector to the other particle
                            vec3 delta_pos = src[j].position - me.position;
                            float distance = delta_pos.length();
                            // Normalize
                            vec3 delta_dir = delta_pos / distance;
                            // This clamp stops the system from blowing up if particles get
                            // too close...
                            distance = distance < 0.005f ? 0.005f : distance;
                            // Update velocity
                            delta_v += (delta_dir / (distance * distance));
                        }
                    }
                    // Add my current velocity to my position.
                    dst[i].position = me.position + me.velocity;
                    // Produce new velocity from my current velocity plus the calculated delta
                    dst[i].velocity = me.velocity + delta_v * deltaTime * 0.01f;
                    // Write to mapped buffer
                    mapped_buffer[i].position = dst[i].position;
                }
            }

            // Count frames so we can double buffer next frame
            frame_index++;
        }

        void update_particles_omp(float deltaTime) {
            // Double buffer source and destination
            fixed (PARTICLE* src = particles[frame_index & 1])
            fixed (PARTICLE* dst = particles[(frame_index + 1) & 1]) {
                // For each particle in the system
                //#pragma omp parallel for schedule (dynamic, 16)
                for (int i = 0; i < PARTICLE_COUNT; i++) {
                    // Get my own data
                    PARTICLE me = src[i];
                    vec3 delta_v = new vec3(0.0f);

                    // For all the other particles
                    for (int j = 0; j < PARTICLE_COUNT; j++) {
                        if (i != j) // ... not me!
                        {
                            //  Get the vector to the other particle
                            vec3 delta_pos = src[j].position - me.position;
                            float distance = delta_pos.length();
                            // Normalize
                            vec3 delta_dir = delta_pos / distance;
                            // This clamp stops the system from blowing up if particles get
                            // too close...
                            distance = distance < 0.005f ? 0.005f : distance;
                            // Update velocity
                            delta_v += (delta_dir / (distance * distance));
                        }
                    }
                    // Add my current velocity to my position.
                    dst[i].position = me.position + me.velocity;
                    // Produce new velocity from my current velocity plus the calculated delta
                    dst[i].velocity = me.velocity + delta_v * deltaTime * 0.01f;
                    // Write to mapped buffer
                    mapped_buffer[i].position = dst[i].position;
                }

                // Count frames so we can double buffer next frame
                frame_index++;
            }


        }

    }
}