
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch03_instancing2 : _glGuide8code, IDisposable {

        public ch03_instancing2(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        // Member variables
        float aspect;

        GLuint color_buffer;
        GLuint model_matrix_buffer;
        GLuint render_prog;
        GLint model_matrix_loc;
        GLint view_matrix_loc;
        GLint projection_matrix_loc;
        VBObject vbObject = new VBObject();

        const int INSTANCE_COUNT = 100;

        mat4 projection_matrix;
        public override void init(CSharpGL.GL gl) {
            var vsCodeFile = "03/ch03_instancing2/ch03_instancing2.vs.glsl";
            var fsCodeFile = "03/ch03_instancing2/ch03_instancing2.fs.glsl";
            var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
            Debug.Assert(program != null); this.render_prog = program.programId; //this.program = program;
            gl.glUseProgram(this.render_prog);//this.program.Bind();

            // Get the location of the projetion_matrix uniform
            view_matrix_loc = gl.glGetUniformLocation(render_prog, "view_matrix");
            projection_matrix_loc = gl.glGetUniformLocation(render_prog, "projection_matrix");

            // Load the object
            vbObject.LoadFromVBM("media/armadillo_low.vbm", 0, 1, 2);

            // Bind its vertex array object so that we can append the instanced attributes
            vbObject.BindVertexArray(gl);

            // Get the locations of the vertex attributes in 'prog', which is the
            // (linked) program object that we're going to be rendering with. Note
            // that this isn't really necessary because we specified locations for
            // all the attributes in our vertex shader. This code could be made
            // more concise by assuming the vertex attributes are where we asked
            // the compiler to put them.
            int position_loc = gl.glGetAttribLocation(render_prog, "position");
            int normal_loc = gl.glGetAttribLocation(render_prog, "normal");
            int color_loc = gl.glGetAttribLocation(render_prog, "color");
            int matrix_loc = gl.glGetAttribLocation(render_prog, "model_matrix");

            // Configure the regular vertex attribute arrays - position and color.
            /*
            // This is commented out here because the VBM object takes care
            // of it for us.
            glBindBuffer(GL_ARRAY_BUFFER, position_buffer);
            glVertexAttribPointer(position_loc, 4, GL_FLOAT, GL_FALSE, 0, NULL);
            glEnableVertexAttribArray(position_loc);
            glBindBuffer(GL_ARRAY_BUFFER, normal_buffer);
            glVertexAttribPointer(normal_loc, 3, GL_FLOAT, GL_FALSE, 0, NULL);
            glEnableVertexAttribArray(normal_loc);
            */

            // Generate the colors of the objects
            var colors = new vec4[INSTANCE_COUNT];

            for (var n = 0; n < INSTANCE_COUNT; n++) {
                float a = n / 4.0f;
                float b = n / 5.0f;
                float c = n / 6.0f;

                colors[n][0] = 0.5f + 0.25f * ((float)Math.Sin(a + 1.0f) + 1.0f);
                colors[n][1] = 0.5f + 0.25f * ((float)Math.Sin(b + 2.0f) + 1.0f);
                colors[n][2] = 0.5f + 0.25f * ((float)Math.Sin(c + 3.0f) + 1.0f);
                colors[n][3] = 1.0f;
            }

            var id = stackalloc GLuint[1];
            gl.glGenBuffers(1, id); this.color_buffer = id[0];
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, color_buffer);
            fixed (vec4* p = colors) {
                gl.glBufferData(GL.GL_ARRAY_BUFFER, sizeof(vec4) * colors.Length, (IntPtr)p, GL.GL_DYNAMIC_DRAW);
            }

            // Now we set up the color array. We want each instance of our geometry
            // to assume a different color, so we'll just pack colors into a buffer
            // object and make an instanced vertex attribute out of it.
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, this.color_buffer);
            gl.glVertexAttribPointer((uint)color_loc, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            gl.glEnableVertexAttribArray((uint)color_loc);
            // This is the important bit... set the divisor for the color array to
            // 1 to get OpenGL to give us a new value of 'color' per-instance
            // rather than per-vertex.
            gl.glVertexAttribDivisor((uint)color_loc, 1);

            // Likewise, we can do the same with the model matrix. Note that a
            // matrix input to the vertex shader consumes N consecutive input
            // locations, where N is the number of columns in the matrix. So...
            // we have four vertex attributes to set up.
            gl.glGenBuffers(1, id); this.model_matrix_buffer = id[0];
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, model_matrix_buffer);
            gl.glBufferData(GL.GL_ARRAY_BUFFER, INSTANCE_COUNT * sizeof(mat4), IntPtr.Zero, GL.GL_DYNAMIC_DRAW);
            // Loop over each column of the matrix...
            for (int i = 0; i < 4; i++) {
                // Set up the vertex attribute
                gl.glVertexAttribPointer((uint)(matrix_loc + i),              // Location
                                      4, GL.GL_FLOAT, false,       // vec4
                                      sizeof(mat4),                // Stride
                                      (IntPtr)(sizeof(vec4) * i)); // Start offset
                                                                   // Enable it
                gl.glEnableVertexAttribArray((uint)(matrix_loc + i));
                // Make it instanced
                gl.glVertexAttribDivisor((uint)(matrix_loc + i), 1);
            }

            // Done (unbind the object's VAO)
            gl.glBindVertexArray(0);
        }

        float time = 0.0f;
        public override void display(CSharpGL.GL gl) {
            //float t = float(GetTickCount() & 0x3FFF) / float(0x3FFF);
            //float time = (float)(DateTime.Now.Second & 0x3FFF) / (float)(0x3FFF);
            time += 0.001f;
            //static float q = 0.0f;
            //static const vec3 X(1.0f, 0.0f, 0.0f);
            //static const vec3 Y(0.0f, 1.0f, 0.0f);
            //static const vec3 Z(0.0f, 0.0f, 1.0f);
            //int n;

            // Clear
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            // Setup
            gl.glEnable(GL.GL_CULL_FACE);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            // Bind the weight VBO and change its data
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, model_matrix_buffer);

            // Set model matrices for each instance
            mat4* matrices = (mat4*)gl.glMapBuffer(GL.GL_ARRAY_BUFFER, GL.GL_WRITE_ONLY);

            for (var n = 0; n < INSTANCE_COUNT; n++) {
                float a = 50.0f * n / 4.0f;
                float b = 50.0f * n / 5.0f;
                float c = 50.0f * n / 6.0f;

                matrices[n] = glm.rotate(a + time, 1.0f, 0.0f, 0.0f) *
                              glm.rotate(b + time, 0.0f, 1.0f, 0.0f) *
                              glm.rotate(c + time, 0.0f, 0.0f, 1.0f) *
                              glm.translate(new vec3(10.0f + a, 40.0f + b, 50.0f + c));
                //var m = glm.translate(mat4.identity(), new vec3(10.0f + a, 40.0f + b, 50.0f + c));
                //m = glm.rotate(m, c + t * 360.0f, new vec3(0.0f, 0.0f, 1.0f));
                //m = glm.rotate(m, b + t * 360.0f, new vec3(0.0f, 1.0f, 0.0f));
                //m = glm.rotate(m, a + t * 360.0f, new vec3(1.0f, 0.0f, 0.0f));
                //matrices[n] = m;
            }

            gl.glUnmapBuffer(GL.GL_ARRAY_BUFFER);

            // Activate instancing program
            gl.glUseProgram(render_prog);

            // Set up the view and projection matrices
            mat4 view_matrix = glm.rotate(time * 360.0f * 2.0f, new vec3(0.0f, 1.0f, 0.0f))
                 * glm.translate(new vec3(0.0f, 0.0f, -1500.0f));
            mat4 projection_matrix = glm.frustum(-1.0f, 1.0f, -aspect, aspect, 1.0f, 5000.0f);

            gl.glUniformMatrix4fv(view_matrix_loc, 1, false, (float*)&view_matrix);
            gl.glUniformMatrix4fv(projection_matrix_loc, 1, false, (float*)&projection_matrix);

            // Render INSTANCE_COUNT objects
            vbObject.Render(0, INSTANCE_COUNT);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            aspect = (float)height / (float)width;
            //var camera = new Camera(new(0.0f, 0.0f, 0.0f), new(1.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), CameraType.Perspective, width, height);
            //this.projection_matrix = camera.GetProjectionMatrix() * camera.GetViewMatrix();
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

        public void Dispose() {
            var gl = GL.Current; if (gl == null) return;

            gl.glUseProgram(0);
            gl.glDeleteProgram(render_prog);
            var id = color_buffer;
            gl.glDeleteBuffers(1, &id);
            id = model_matrix_buffer;
            gl.glDeleteBuffers(1, &id);
        }

        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];


        // A single triangle
        static readonly GLfloat[] vertex_positions =
        {
        -1.0f, -1.0f,  0.0f, 1.0f,
         1.0f, -1.0f,  0.0f, 1.0f,
        -1.0f,  1.0f,  0.0f, 1.0f,
        -1.0f, -1.0f,  0.0f, 1.0f,
        };

        // Color for each vertex
        static readonly GLfloat[] vertex_colors =
        {
        1.0f, 1.0f, 1.0f, 1.0f,
        1.0f, 1.0f, 0.0f, 1.0f,
        1.0f, 0.0f, 1.0f, 1.0f,
        0.0f, 1.0f, 1.0f, 1.0f
        };

        // Indices for the triangle strips
        static readonly GLushort[] vertex_indices = { 0, 1, 2 };

    }
}