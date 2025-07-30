
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch03_instancing : _glGuide8code {

        public ch03_instancing(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }
        // Member variables
        float aspect;
        GLuint update_prog;
        GLuint[] vao = new uint[2];
        GLuint[] vbo = new uint[2];
        GLuint xfb;

        GLuint weight_vbo;
        GLuint color_vbo;
        GLuint render_prog;
        GLint render_model_matrix_loc;
        GLint render_projection_matrix_loc;

        GLuint geometry_tex;

        GLuint geometry_xfb;
        GLuint particle_xfb;

        GLint model_matrix_loc;
        GLint projection_matrix_loc;
        GLint triangle_count_loc;
        GLint time_step_loc;

        VBObject vbObject = new VBObject();

        const int INSTANCE_COUNT = 200;

        public override void init(CSharpGL.GL gl) {
            var vsCodeFile = "03/ch03_instancing/ch03_instancing.vs.glsl";
            var fsCodeFile = "03/ch03_instancing/ch03_instancing.fs.glsl";
            var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
            Debug.Assert(program != null); this.render_prog = program.programId; //this.program = program;
            gl.glUseProgram(this.render_prog);//this.program.Bind();


            // "model_matrix" is actually an array of 4 matrices
            render_model_matrix_loc = gl.glGetUniformLocation(render_prog, "model_matrix");
            render_projection_matrix_loc = gl.glGetUniformLocation(render_prog, "projection_matrix");

            // Load the object
            vbObject.LoadFromVBM("media/armadillo_low.vbm", 0, 1, 2);

            // Bind its vertex array object so that we can append the instanced attributes
            vbObject.BindVertexArray(gl);

            // Generate the colors of the objects
            var colors = new vec4[INSTANCE_COUNT];

            for (var n = 0; n < INSTANCE_COUNT; n++) {
                float a = (n) / 4.0f;
                float b = (n) / 5.0f;
                float c = (n) / 6.0f;

                colors[n][0] = 0.5f * ((float)Math.Sin(a + 1.0f) + 1.0f);
                colors[n][1] = 0.5f * ((float)Math.Sin(b + 2.0f) + 1.0f);
                colors[n][2] = 0.5f * ((float)Math.Sin(c + 3.0f) + 1.0f);
                colors[n][3] = 1.0f;
            }

            // Create and allocate the VBO to hold the weights
            // Notice that we use the 'colors' array as the initial data, but only because
            // we know it's the same size.
            var id = stackalloc GLuint[1];
            gl.glGenBuffers(1, id); this.weight_vbo = id[0];
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, weight_vbo);
            fixed (vec4* p = colors) {
                gl.glBufferData(GL.GL_ARRAY_BUFFER,
                    sizeof(vec4) * colors.Length, (IntPtr)p, GL.GL_DYNAMIC_DRAW);
            }

            // Here is the instanced vertex attribute - set the divisor
            gl.glVertexAttribDivisor(3, 1);
            // It's otherwise the same as any other vertex attribute - set the pointer and enable it
            gl.glVertexAttribPointer(3, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            gl.glEnableVertexAttribArray(3);

            // Same with the instance color array
            gl.glGenBuffers(1, id); this.color_vbo = id[0];
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, color_vbo);
            fixed (vec4* p = colors) {
                gl.glBufferData(GL.GL_ARRAY_BUFFER,
                    sizeof(vec4) * colors.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
            }

            gl.glVertexAttribDivisor(4, 1);
            gl.glVertexAttribPointer(4, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            gl.glEnableVertexAttribArray(4);

            // Done (unbind the object's VAO)
            gl.glBindVertexArray(0);
        }

        static float q = 0.0f;
        public override void display(CSharpGL.GL gl) {

            //float t = float(GetTickCount() & 0x3FFFF) / float(0x3FFFF);
            //float t = (float)(DateTime.Now.Second & 0x3FFF) / (float)(0x3FFF);
            float t = q; q += 0.0001f;
            //static float q = 0.0f;
            //static const vmath::vec3 X(1.0f, 0.0f, 0.0f);
            //static const vmath::vec3 Y(0.0f, 1.0f, 0.0f);
            //static const vmath::vec3 Z(0.0f, 0.0f, 1.0f);
            //int n;

            // Set weights for each instance
            var weights = new vec4[INSTANCE_COUNT];

            for (var n = 0; n < INSTANCE_COUNT; n++) {
                float a = (n) / 4.0f;
                float b = (n) / 5.0f;
                float c = (n) / 6.0f;

                weights[n][0] = 0.5f * ((float)Math.Sin(t * 6.28318531f * 8.0f + a) + 1.0f);
                weights[n][1] = 0.5f * ((float)Math.Sin(t * 6.28318531f * 26.0f + b) + 1.0f);
                weights[n][2] = 0.5f * ((float)Math.Sin(t * 6.28318531f * 21.0f + c) + 1.0f);
                weights[n][3] = 0.5f * ((float)Math.Sin(t * 6.28318531f * 13.0f + a + b) + 1.0f);
            }

            // Bind the weight VBO and change its data
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, weight_vbo);
            fixed (vec4* p = weights) {
                gl.glBufferData(GL.GL_ARRAY_BUFFER,
                    sizeof(vec4) * weights.Length, (IntPtr)p, GL.GL_DYNAMIC_DRAW);
            }

            // Clear
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            // Setup
            gl.glEnable(GL.GL_CULL_FACE);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            // Activate instancing program
            gl.glUseProgram(render_prog);

            // Set four model matrices
            var model_matrix = new mat4[4];

            for (var n = 0; n < 4; n++) {
                var mat = glm.scale(new vec3(0.01f, 0.01f, 0.01f))
                    * glm.translate(new vec3((float)n * 10.0f - 15.0f, 0.0f, 0.0f))
                    * glm.rotate(t * 360.0f * 30.0f + (n + 1) * 67.0f, new vec3(0.0f, 1.0f, 0.0f))
                    * glm.rotate(t * 360.0f * 20.0f + (n + 1) * 35.0f, new vec3(0.0f, 0.0f, 1.0f))
                    * glm.rotate(t * 360.0f * 40.0f + (n + 1) * 29.0f, new vec3(0.0f, 1.0f, 0.0f))
                    * glm.scale(new vec3(5.0f, 5.0f, 5.0f));
                model_matrix[n] = mat;
            }

            fixed (mat4* p = model_matrix) {
                gl.glUniformMatrix4fv(render_model_matrix_loc, 4/*4 matrix*/, false, (float*)p);
            }

            // Set up the projection matrix
            mat4 projection_matrix = glm.frustum(-1.0f, 1.0f, -aspect, aspect, 1.0f, 5000.0f)
                 * glm.translate(new vec3(0.0f, 0.0f, -10.0f));

            gl.glUniformMatrix4fv(render_projection_matrix_loc, 1, false, (float*)&projection_matrix);

            // Render INSTANCE_COUNT objects
            vbObject.Render(0, INSTANCE_COUNT);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            aspect = (float)height / (float)width;
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


        static uint seed = 0x13371337;

        static float random_float() {
            float res;
            uint tmp;

            seed *= 16807;

            tmp = seed ^ (seed >> 4) ^ (seed << 15);

            *((uint*)&res) = (tmp >> 9) | 0x3F800000;

            return (res - 1.0f);
        }

        static vec3 random_vector(float minmag = 0.0f, float maxmag = 1.0f) {
            var randomvec = new vec3(random_float() * 2.0f - 1.0f, random_float() * 2.0f - 1.0f, random_float() * 2.0f - 1.0f);
            randomvec = randomvec.normalize();
            randomvec *= (random_float() * (maxmag - minmag) + minmag);

            return randomvec;
        }

        ~ch03_instancing() {
            var gl = GL.Current; if (gl == null) return;

            gl.glUseProgram(0);
            gl.glDeleteProgram(update_prog);
            fixed (GLuint* p = vao) {
                gl.glDeleteVertexArrays(2, p);
            }
            fixed (GLuint* p = vbo) {
                gl.glDeleteBuffers(2, p);
            }
        }
    }
}