
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Transactions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch03_instancing3 : _glGuide8code {

        public ch03_instancing3(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        // Member variables
        float aspect;

        GLuint color_buffer;
        GLuint model_matrix_buffer;
        GLuint color_tbo;
        GLuint model_matrix_tbo;
        GLuint render_prog;

        GLint view_matrix_loc;
        GLint projection_matrix_loc;

        VBObject vbObject = new VBObject();
        const int INSTANCE_COUNT = 100;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "03/ch03_instancing3/ch03_instancing3.vs.glsl";
                var fsCodeFile = "03/ch03_instancing3/ch03_instancing3.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.render_prog = program.programId; //this.program = program;
                gl.glUseProgram(this.render_prog);//this.program.Bind();


                // Get the location of the projetion_matrix uniform
                view_matrix_loc = gl.glGetUniformLocation(render_prog, "view_matrix");
                projection_matrix_loc = gl.glGetUniformLocation(render_prog, "projection_matrix");

                // Set up the TBO samplers
                GLint color_tbo_loc = gl.glGetUniformLocation(render_prog, "color_tbo");
                GLint model_matrix_tbo_loc = gl.glGetUniformLocation(render_prog, "model_matrix_tbo");

                // Set them to the right texture unit indices
                gl.glUniform1i(color_tbo_loc, 0);
                gl.glUniform1i(model_matrix_tbo_loc, 1);

                // Load the object
                vbObject.LoadFromVBM("media/armadillo_low.vbm", 0, 1, 2);

                /*

                    THIS IS COMMENTED OUT HERE BECAUSE THE VBM OBJECT TAKES
                    CARE OF IT FOR US

                // Get the locations of the vertex attributes in 'prog', which is the
                // (linked) program object that we're going to be rendering with. Note
                // that this isn't really necessary because we specified locations for
                // all the attributes in our vertex shader. This code could be made
                // more concise by assuming the vertex attributes are where we asked
                // the compiler to put them.
                int position_loc    = glGetAttribLocation(prog, "position");
                int normal_loc      = glGetAttribLocation(prog, "normal");

                // Configure the regular vertex attribute arrays - position and normal.
                glBindBuffer(GL_ARRAY_BUFFER, position_buffer);
                glVertexAttribPointer(position_loc, 4, GL_FLOAT, GL_FALSE, 0, NULL);
                glEnableVertexAttribArray(position_loc);
                glBindBuffer(GL_ARRAY_BUFFER, normal_buffer);
                glVertexAttribPointer(normal_loc, 3, GL_FLOAT, GL_FALSE, 0, NULL);
                glEnableVertexAttribArray(normal_loc);

                */
            }

            {
                // Now we set up the TBOs for the instance colors and the model matrices...

                // First, create the TBO to store colors, bind a buffer to it and initialize
                // its format. The buffer has previously been created and sized to store one
                // vec4 per-instance.
                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); color_tbo = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_BUFFER, color_tbo);

                // Generate the colors of the objects
                var colors = new vec4[INSTANCE_COUNT];

                for (var n = 0; n < INSTANCE_COUNT; n++) {
                    float a = (n) / 4.0f;
                    float b = (n) / 5.0f;
                    float c = (n) / 6.0f;

                    colors[n][0] = 0.5f + 0.25f * ((float)Math.Sin(a + 1.0f) + 1.0f);
                    colors[n][1] = 0.5f + 0.25f * ((float)Math.Sin(b + 2.0f) + 1.0f);
                    colors[n][2] = 0.5f + 0.25f * ((float)Math.Sin(c + 3.0f) + 1.0f);
                    colors[n][3] = 1.0f;
                }

                // Create the buffer, initialize it and attach it to the buffer texture
                gl.glGenBuffers(1, id); color_buffer = id[0];
                gl.glBindBuffer(GL.GL_TEXTURE_BUFFER, color_buffer);
                fixed (vec4* p = colors) {
                    gl.glBufferData(GL.GL_TEXTURE_BUFFER,
                        sizeof(vec4) * colors.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glTexBuffer(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32F, color_buffer);

            }
            {
                // Now do the same thing with a TBO for the model matrices. The buffer object
                // (model_matrix_buffer) has been created and sized to store one mat4 per-
                // instance.
                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); model_matrix_tbo = id[0];
                gl.glActiveTexture(GL.GL_TEXTURE1);
                gl.glBindTexture(GL.GL_TEXTURE_BUFFER, model_matrix_tbo);
                gl.glGenBuffers(1, id); model_matrix_buffer = id[0];
                gl.glBindBuffer(GL.GL_TEXTURE_BUFFER, model_matrix_buffer);
                gl.glBufferData(GL.GL_TEXTURE_BUFFER,
                    INSTANCE_COUNT * sizeof(mat4), IntPtr.Zero, GL.GL_DYNAMIC_DRAW);
                gl.glTexBuffer(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32F, model_matrix_buffer);
                gl.glActiveTexture(GL.GL_TEXTURE0);
            }
        }

        static float q = 0.0f;
        public override void display(CSharpGL.GL gl) {
            //float t = float(GetTickCount() & 0x3FFF) / float(0x3FFF);
            //float t = (float)(DateTime.Now.Millisecond & 0x3FFF) / (float)(0x3FFF);
            float t = q; q += 0.5f;//TODO: 0.4f makes it flash, why?
            //static const vec3 X(1.0f, 0.0f, 0.0f);
            //static const vec3 Y(0.0f, 1.0f, 0.0f);
            //static const vec3 Z(0.0f, 0.0f, 1.0f);
            //int n;

            // Set model matrices for each instance
            var matrices = new mat4[INSTANCE_COUNT];

            for (var n = 0; n < INSTANCE_COUNT; n++) {
                float a = 50.0f * (n) / 4.0f;
                float b = 50.0f * (n) / 5.0f;
                float c = 50.0f * (n) / 6.0f;

                //m = glm.translate(m, new vec3(10.0f + a, 40.0f + b, 50.0f + c));
                var m = glm.rotate(c + t, new vec3(0.0f, 0.0f, 1.0f))
                    * glm.rotate(b + t, new vec3(0.0f, 1.0f, 0.0f))
                    * glm.rotate(a + t, new vec3(1.0f, 0.0f, 0.0f));
                matrices[n] = m;
            }

            // Bind the weight VBO and change its data
            gl.glBindBuffer(GL.GL_TEXTURE_BUFFER, model_matrix_buffer);
            fixed (mat4* p = matrices) {
                gl.glBufferData(GL.GL_TEXTURE_BUFFER,
                    sizeof(mat4) * matrices.Length, (IntPtr)p, GL.GL_DYNAMIC_DRAW);
            }

            // Clear
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            // Setup
            gl.glEnable(GL.GL_CULL_FACE);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            // Activate instancing program
            gl.glUseProgram(render_prog);

            // Set up the view and projection matrices
            var view_matrix = glm.rotate(t * 360.0f * 2.0f, new vec3(0.0f, 1.0f, 0.0f))
                * glm.translate(new vec3(0.0f, 0.0f, -300.0f));
            mat4 projection_matrix = glm.frustum(-1.0f, 1.0f, -aspect, aspect, 1.0f, 500.0f);
            //mat4 view_matrix = glm.lookAt(new(5, 4, 3), new(0, 0, 0), new(0, 1, 0));
            //mat4 projection_matrix = glm.perspective((float)Math.PI / 2.0f, aspect, 0.1f, 1000);

            gl.glUniformMatrix4fv(view_matrix_loc, 1, false, (float*)&view_matrix);
            gl.glUniformMatrix4fv(projection_matrix_loc, 1, false, (float*)&projection_matrix);

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

        ~ch03_instancing3() {
            var gl = GL.Current; if (gl == null) return;
            gl.glUseProgram(0);
            gl.glDeleteProgram(render_prog);
            var id = color_buffer;
            gl.glDeleteBuffers(1, &id);
            id = model_matrix_buffer;
            gl.glDeleteBuffers(1, &id);
        }
    }
}