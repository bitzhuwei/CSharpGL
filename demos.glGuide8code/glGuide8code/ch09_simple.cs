
using CSharpGL;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch09_simple : _glGuide8code {
        ~ch09_simple() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch09_simple(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        GLint PLoc;  // Projection matrix

        const GLfloat zNear = 0.1f;
        const GLfloat zFar = 30f;

        const int NumVertices = 4;  // vertices in our patch


        const int Patch = 0, NumVAOs = 1;
        const int Array = 0, NumBuffers = 1;

        static readonly GLfloat[] vertices = new float[NumVertices * 2] {
        -0.5f, -0.5f,
         0.5f, -0.5f,
         0.5f,  0.5f,
        -0.5f,  0.5f
        };

        public override void init(CSharpGL.GL gl) {
            {
                // Load shaders and use the resulting shader program
                var vsCodeFile = "09/ch09_simple/simple.vert";
                var tcCodeFile = "09/ch09_simple/simple.cont";
                var teCodeFile = "09/ch09_simple/simple.eval";
                var fsCodeFile = "09/ch09_simple/simple.frag";
                var program = Utility.LoadShaders(vsCodeFile, tcCodeFile, teCodeFile, fsCodeFile);
                Debug.Assert(program != null); var programId = program.programId;
                gl.glUseProgram(programId);

                // set up vertex arrays
                GLint vPosition = gl.glGetAttribLocation(programId, "vPosition");
                gl.glEnableVertexAttribArray((uint)vPosition);
                gl.glVertexAttribPointer((uint)vPosition, 2, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                PLoc = gl.glGetUniformLocation(programId, "P");

                //mat4 modelview = mat4.identity();
                //modelview = glm.rotate(modelview, -50, new vec3(1, 0, 0));
                //modelview = glm.translate(modelview, 0.0f, 0.0f, -0.5f * (zNear + zFar));
                mat4 modelview = glm.lookAt(new vec3(-1, 1, 1) * 0.5f, new vec3(0, 0, 0), new vec3(0, 1, 0));
                var locMV = gl.glGetUniformLocation(programId, "MV");
                gl.glUniformMatrix4fv(locMV, 1, false, (float*)&modelview);
            }
            {
                // Create a vertex array object
                var VAOs = stackalloc GLuint[NumVAOs];
                gl.glGenVertexArrays(NumVAOs, VAOs);
                gl.glBindVertexArray(VAOs[Patch]);

                // Create and initialize a buffer object
                var buffers = stackalloc GLuint[NumBuffers];
                gl.glGenBuffers(NumBuffers, buffers);
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, buffers[Array]);
                fixed (float* p = vertices) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * vertices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glPatchParameteri(GL.GL_PATCH_VERTICES, 4);

                gl.glEnable(GL.GL_DEPTH_TEST);

            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glDrawArrays(GL.GL_PATCHES, 0, NumVertices);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            GLfloat aspect = (float)width / (float)height;

            mat4 projection = glm.perspective(60.0f / 180.0f * (float)Math.PI, aspect, zNear, zFar);
            gl.glUniformMatrix4fv(PLoc, 1, false, (float*)&projection);

        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        GLenum mode = GL.GL_FILL;
        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.Escape:// 033 /* Escape key */:
            this.mainForm.Close();
            break;

            case Keys.M: {
                mode = (mode == GL.GL_FILL ? GL.GL_LINE : GL.GL_FILL);
                gl.glPolygonMode(GL.GL_FRONT_AND_BACK, mode);
            }
            break;
            }
            this.mainForm.Invalidate();
        }


        public override Keys[] ValidKeys => [Keys.M];
        public override MouseButtons[] ValidButtons => [];

    }
}