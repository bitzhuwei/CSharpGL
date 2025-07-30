
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch09_Teapot : _glGuide8code {
        ~ch09_Teapot() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch09_Teapot(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        GLint PLoc;  // Projection matrix
        GLint InnerLoc;  // Inner tessellation paramter
        GLint OuterLoc;  // Outer tessellation paramter

        GLfloat Inner = 1.0f;
        GLfloat Outer = 1.0f;


        const int ArrayBuffer = 0, ElementBuffer = 1, NumVertexBuffers = 2;
        public override void init(CSharpGL.GL gl) {
            {
                // Create a vertex array object
                GLuint vao;
                gl.glGenVertexArrays(1, &vao);
                gl.glBindVertexArray(vao);

                // Create and initialize a buffer object
                var buffers = stackalloc uint[NumVertexBuffers];
                gl.glGenBuffers(NumVertexBuffers, buffers);
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, buffers[ArrayBuffer]);
                fixed (GLdouble* p = TeapotVertices) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(GLdouble) * TeapotVertices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, buffers[ElementBuffer]);
                fixed (int* p = TeapotIndices) {
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(int) * TeapotIndices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
            }
            {
                var vsCodeFile = "09/ch09_Teapot/teapot.vert";
                var tcCodeFile = "09/ch09_Teapot/teapot.cont";
                var teCodeFile = "09/ch09_Teapot/teapot.eval";
                var fsCodeFile = "09/ch09_Teapot/teapot.frag";
                var program = Utility.LoadShaders(vsCodeFile, tcCodeFile, teCodeFile, fsCodeFile);
                Debug.Assert(program != null); var programId = program.programId;
                gl.glUseProgram(programId);

                // set up vertex arrays
                GLint vPosition = gl.glGetAttribLocation(programId, "vPosition");
                gl.glEnableVertexAttribArray((uint)vPosition);
                gl.glVertexAttribPointer((uint)vPosition, 3, GL.GL_DOUBLE, false, 0, IntPtr.Zero);

                PLoc = gl.glGetUniformLocation(programId, "P");
                InnerLoc = gl.glGetUniformLocation(programId, "Inner");
                OuterLoc = gl.glGetUniformLocation(programId, "Outer");

                gl.glUniform1f(InnerLoc, Inner);
                gl.glUniform1f(OuterLoc, Outer);

                //mat4 modelview = mat4.identity();
                //modelview = glm.translate(modelview, -0.2625f, -1.575f, -1.0f);
                //modelview = glm.translate(modelview, 0.0f, 0.0f, -7.5f);
                mat4 modelview = glm.lookAt(new vec3(1, 0, 1) * 4.5f, new vec3(0, 0, 0), new vec3(0, 1, 0));
                var loc = gl.glGetUniformLocation(programId, "MV");
                gl.glUniformMatrix4fv(loc, 1, false, (float*)&modelview);

                gl.glPatchParameteri(GL.GL_PATCH_VERTICES, NumTeapotVerticesPerPatch);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            gl.glDrawElements(GL.GL_PATCHES, NumTeapotVertices, GL.GL_UNSIGNED_INT, IntPtr.Zero);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            GLfloat aspect = (float)width / (float)height;

            mat4 projection = glm.perspective(60.0f / 180.0f * (float)Math.PI, aspect, 0.1f, 10);
            //     mat4  projection = Frustum( -3, 3, -3, 3, 5, 10 );
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

            case Keys.J:
            Inner--;
            if (Inner < 1.0) Inner = 1.0f;
            gl.glUniform1f(InnerLoc, Inner);
            break;

            case Keys.I:
            Inner++;
            if (Inner > 64) Inner = 64.0f;
            gl.glUniform1f(InnerLoc, Inner);
            break;

            case Keys.K:
            Outer--;
            if (Outer < 1.0) Outer = 1.0f;
            gl.glUniform1f(OuterLoc, Outer);
            break;

            case Keys.O:
            Outer++;
            if (Outer > 64) Outer = 64.0f;
            gl.glUniform1f(OuterLoc, Outer);
            break;

            case Keys.R:
            Inner = 1.0f;
            Outer = 1.0f;
            gl.glUniform1f(InnerLoc, Inner);
            gl.glUniform1f(OuterLoc, Outer);
            break;

            case Keys.M: {
                mode = (mode == GL.GL_FILL ? GL.GL_LINE : GL.GL_FILL);
                gl.glPolygonMode(GL.GL_FRONT_AND_BACK, mode);
            }
            break;
            }

            this.mainForm.Invalidate();
        }


        public override Keys[] ValidKeys => [Keys.J, Keys.I, Keys.K, Keys.O, Keys.R, Keys.M];
        public override MouseButtons[] ValidButtons => [];


        const int NumTeapotVertices = 306;
        const int NumTeapotPatches = 32;
        const int NumTeapotVerticesPerPatch = 16;  // 4x4 Bezier patches
        const int NumTeapotIndices = NumTeapotVerticesPerPatch * NumTeapotPatches;

        //
        //  TeapotVerties - Control vertices of the patches forming the Utah teapot
        //

        static readonly GLdouble[] TeapotVertices = new double[NumTeapotVertices * 3] {
        1.4, 2.4, 0.0,
        1.4, 2.4, 0.784,
        0.784, 2.4, 1.4,
        0.0, 2.4, 1.4,
        1.3375, 2.53125, 0.0,
        1.3375, 2.53125, 0.749,
        0.749, 2.53125, 1.3375,
        0.0, 2.53125, 1.3375,
        1.4375, 2.53125, 0.0,
        1.4375, 2.53125, 0.805,
        0.805, 2.53125, 1.4375,
        0.0, 2.53125, 1.4375,
        1.5, 2.4, 0.0,
        1.5, 2.4, 0.84,
        0.84, 2.4, 1.5,
        0.0, 2.4, 1.5,
        -0.784, 2.4, 1.4,
        -1.4, 2.4, 0.784,
        -1.4, 2.4, 0.0,
        -0.749, 2.53125, 1.3375,
        -1.3375, 2.53125, 0.749,
        -1.3375, 2.53125, 0.0,
        -0.805, 2.53125, 1.4375,
        -1.4375, 2.53125, 0.805,
        -1.4375, 2.53125, 0.0,
        -0.84, 2.4, 1.5,
        -1.5, 2.4, 0.84,
        -1.5, 2.4, 0.0,
        -1.4, 2.4, 0.784,
        -0.784, 2.4, 1.4,
        0.0, 2.4, 1.4,
        -1.3375, 2.53125, 0.749,
        -0.749, 2.53125, 1.3375,
        0.0, 2.53125, 1.3375,
        -1.4375, 2.53125, 0.805,
        -0.805, 2.53125, 1.4375,
        0.0, 2.53125, 1.4375,
        -1.5, 2.4, 0.84,
        -0.84, 2.4, 1.5,
        0.0, 2.4, 1.5,
        0.784, 2.4, 1.4,
        1.4, 2.4, 0.784,
        0.749, 2.53125, 1.3375,
        1.3375, 2.53125, 0.749,
        0.805, 2.53125, 1.4375,
        1.4375, 2.53125, 0.805,
        0.84, 2.4, 1.5,
        1.5, 2.4, 0.84,
        1.75, 1.875, 0.0,
        1.75, 1.875, 0.98,
        0.98, 1.875, 1.75,
        0.0, 1.875, 1.75,
        2.0, 1.35, 0.0,
        2.0, 1.35, 1.12,
        1.12, 1.35, 2.0,
        0.0, 1.35, 2.0,
        2.0, 0.9, 0.0,
        2.0, 0.9, 1.12,
        1.12, 0.9, 2.0,
        0.0, 0.9, 2.0,
        -0.98, 1.875, 1.75,
        -1.75, 1.875, 0.98,
        -1.75, 1.875, 0.0,
        -1.12, 1.35, 2.0,
        -2.0, 1.35, 1.12,
        -2.0, 1.35, 0.0,
        -1.12, 0.9, 2.0,
        -2.0, 0.9, 1.12,
        -2.0, 0.9, 0.0,
        -1.75, 1.875, 0.98,
        -0.98, 1.875, 1.75,
        0.0, 1.875, 1.75,
        -2.0, 1.35, 1.12,
        -1.12, 1.35, 2.0,
        0.0, 1.35, 2.0,
        -2.0, 0.9, 1.12,
        -1.12, 0.9, 2.0,
        0.0, 0.9, 2.0,
        0.98, 1.875, 1.75,
        1.75, 1.875, 0.98,
        1.12, 1.35, 2.0,
        2.0, 1.35, 1.12,
        1.12, 0.9, 2.0,
        2.0, 0.9, 1.12,
        2.0, 0.45, 0.0,
        2.0, 0.45, 1.12,
        1.12, 0.45, 2.0,
        0.0, 0.45, 2.0,
        1.5, 0.225, 0.0,
        1.5, 0.225, 0.84,
        0.84, 0.225, 1.5,
        0.0, 0.225, 1.5,
        1.5, 0.15, 0.0,
        1.5, 0.15, 0.84,
        0.84, 0.15, 1.5,
        0.0, 0.15, 1.5,
        -1.12, 0.45, 2.0,
        -2.0, 0.45, 1.12,
        -2.0, 0.45, 0.0,
        -0.84, 0.225, 1.5,
        -1.5, 0.225, 0.84,
        -1.5, 0.225, 0.0,
        -0.84, 0.15, 1.5,
        -1.5, 0.15, 0.84,
        -1.5, 0.15, 0.0,
        -2.0, 0.45, 1.12,
        -1.12, 0.45, 2.0,
        0.0, 0.45, 2.0,
        -1.5, 0.225, 0.84,
        -0.84, 0.225, 1.5,
        0.0, 0.225, 1.5,
        -1.5, 0.15, 0.84,
        -0.84, 0.15, 1.5,
        0.0, 0.15, 1.5,
        1.12, 0.45, 2.0,
        2.0, 0.45, 1.12,
        0.84, 0.225, 1.5,
        1.5, 0.225, 0.84,
        0.84, 0.15, 1.5,
        1.5, 0.15, 0.84,
        -1.6, 2.025, 0.0,
        -1.6, 2.025, 0.3,
        -1.5, 2.25, 0.3,
        -1.5, 2.25, 0.0,
        -2.3, 2.025, 0.0,
        -2.3, 2.025, 0.3,
        -2.5, 2.25, 0.3,
        -2.5, 2.25, 0.0,
        -2.7, 2.025, 0.0,
        -2.7, 2.025, 0.3,
        -3.0, 2.25, 0.3,
        -3.0, 2.25, 0.0,
        -2.7, 1.8, 0.0,
        -2.7, 1.8, 0.3,
        -3.0, 1.8, 0.3,
        -3.0, 1.8, 0.0,
        -1.5, 2.25, 0.3,
        -1.6, 2.025, 0.3,
        -2.5, 2.25, 0.3,
        -2.3, 2.025, 0.3,
        -3.0, 2.25, 0.3,
        -2.7, 2.025, 0.3,
        -3.0, 1.8, 0.3,
        -2.7, 1.8, 0.3,
        -2.7, 1.575, 0.0,
        -2.7, 1.575, 0.3,
        -3.0, 1.35, 0.3,
        -3.0, 1.35, 0.0,
        -2.5, 1.125, 0.0,
        -2.5, 1.125, 0.3,
        -2.65, 0.9375, 0.3,
        -2.65, 0.9375, 0.0,
        -2.0, 0.9, 0.3,
        -1.9, 0.6, 0.3,
        -1.9, 0.6, 0.0,
        -3.0, 1.35, 0.3,
        -2.7, 1.575, 0.3,
        -2.65, 0.9375, 0.3,
        -2.5, 1.125, 0.3,
        -1.9, 0.6, 0.3,
        -2.0, 0.9, 0.3,
        1.7, 1.425, 0.0,
        1.7, 1.425, 0.66,
        1.7, 0.6, 0.66,
        1.7, 0.6, 0.0,
        2.6, 1.425, 0.0,
        2.6, 1.425, 0.66,
        3.1, 0.825, 0.66,
        3.1, 0.825, 0.0,
        2.3, 2.1, 0.0,
        2.3, 2.1, 0.25,
        2.4, 2.025, 0.25,
        2.4, 2.025, 0.0,
        2.7, 2.4, 0.0,
        2.7, 2.4, 0.25,
        3.3, 2.4, 0.25,
        3.3, 2.4, 0.0,
        1.7, 0.6, 0.66,
        1.7, 1.425, 0.66,
        3.1, 0.825, 0.66,
        2.6, 1.425, 0.66,
        2.4, 2.025, 0.25,
        2.3, 2.1, 0.25,
        3.3, 2.4, 0.25,
        2.7, 2.4, 0.25,
        2.8, 2.475, 0.0,
        2.8, 2.475, 0.25,
        3.525, 2.49375, 0.25,
        3.525, 2.49375, 0.0,
        2.9, 2.475, 0.0,
        2.9, 2.475, 0.15,
        3.45, 2.5125, 0.15,
        3.45, 2.5125, 0.0,
        2.8, 2.4, 0.0,
        2.8, 2.4, 0.15,
        3.2, 2.4, 0.15,
        3.2, 2.4, 0.0,
        3.525, 2.49375, 0.25,
        2.8, 2.475, 0.25,
        3.45, 2.5125, 0.15,
        2.9, 2.475, 0.15,
        3.2, 2.4, 0.15,
        2.8, 2.4, 0.15,
        0.0, 3.15, 0.0,
        0.0, 3.15, 0.002,
        0.002, 3.15, 0.0,
        0.8, 3.15, 0.0,
        0.8, 3.15, 0.45,
        0.45, 3.15, 0.8,
        0.0, 3.15, 0.8,
        0.0, 2.85, 0.0,
        0.2, 2.7, 0.0,
        0.2, 2.7, 0.112,
        0.112, 2.7, 0.2,
        0.0, 2.7, 0.2,
        -0.002, 3.15, 0.0,
        -0.45, 3.15, 0.8,
        -0.8, 3.15, 0.45,
        -0.8, 3.15, 0.0,
        -0.112, 2.7, 0.2,
        -0.2, 2.7, 0.112,
        -0.2, 2.7, 0.0,
        0.0, 3.15, 0.002,
        -0.8, 3.15, 0.45,
        -0.45, 3.15, 0.8,
        0.0, 3.15, 0.8,
        -0.2, 2.7, 0.112,
        -0.112, 2.7, 0.2,
        0.0, 2.7, 0.2,
        0.45, 3.15, 0.8,
        0.8, 3.15, 0.45,
        0.112, 2.7, 0.2,
        0.2, 2.7, 0.112,
        0.4, 2.55, 0.0,
        0.4, 2.55, 0.224,
        0.224, 2.55, 0.4,
        0.0, 2.55, 0.4,
        1.3, 2.55, 0.0,
        1.3, 2.55, 0.728,
        0.728, 2.55, 1.3,
        0.0, 2.55, 1.3,
        1.3, 2.4, 0.0,
        1.3, 2.4, 0.728,
        0.728, 2.4, 1.3,
        0.0, 2.4, 1.3,
        -0.224, 2.55, 0.4,
        -0.4, 2.55, 0.224,
        -0.4, 2.55, 0.0,
        -0.728, 2.55, 1.3,
        -1.3, 2.55, 0.728,
        -1.3, 2.55, 0.0,
        -0.728, 2.4, 1.3,
        -1.3, 2.4, 0.728,
        -1.3, 2.4, 0.0,
        -0.4, 2.55, 0.224,
        -0.224, 2.55, 0.4,
        0.0, 2.55, 0.4,
        -1.3, 2.55, 0.728,
        -0.728, 2.55, 1.3,
        0.0, 2.55, 1.3,
        -1.3, 2.4, 0.728,
        -0.728, 2.4, 1.3,
        0.0, 2.4, 1.3,
        0.224, 2.55, 0.4,
        0.4, 2.55, 0.224,
        0.728, 2.55, 1.3,
        1.3, 2.55, 0.728,
        0.728, 2.4, 1.3,
        1.3, 2.4, 0.728,
        0.0, 0.0, 0.0,
        1.5, 0.15, 0.0,
        1.5, 0.15, 0.84,
        0.84, 0.15, 1.5,
        0.0, 0.15, 1.5,
        1.5, 0.075, 0.0,
        1.5, 0.075, 0.84,
        0.84, 0.075, 1.5,
        0.0, 0.075, 1.5,
        1.425, 0.0, 0.0,
        1.425, 0.0, 0.798,
        0.798, 0.0, 1.425,
        0.0, 0.0, 1.425,
        -0.84, 0.15, 1.5,
        -1.5, 0.15, 0.84,
        -1.5, 0.15, 0.0,
        -0.84, 0.075, 1.5,
        -1.5, 0.075, 0.84,
        -1.5, 0.075, 0.0,
        -0.798, 0.0, 1.425,
        -1.425, 0.0, 0.798,
        -1.425, 0.0, 0.0,
        -1.5, 0.15, 0.84,
        -0.84, 0.15, 1.5,
        0.0, 0.15, 1.5,
        -1.5, 0.075, 0.84,
        -0.84, 0.075, 1.5,
        0.0, 0.075, 1.5,
        -1.425, 0.0, 0.798,
        -0.798, 0.0, 1.425,
        0.0, 0.0, 1.425,
        0.84, 0.15, 1.5,
        1.5, 0.15, 0.84,
        0.84, 0.075, 1.5,
        1.5, 0.075, 0.84,
        0.798, 0.0, 1.425,
        1.425, 0.0, 0.798
        };

        //
        //  TeapotIndices - Indices into patch control vertices (from vertices.h)
        //
        //    Each patch is a 4x4 Bezier patch, and there are 32 patches in the
        //      Utah teapot.
        //

        static readonly GLint[] TeapotIndices = new int[NumTeapotPatches * 4 * 4] {

        0, 1, 2, 3,
        4, 5, 6, 7,
        8, 9, 10, 11,
        12, 13, 14, 15,

        3, 16, 17, 18,
        7, 19, 20, 21,
        11, 22, 23, 24,
        15, 25, 26, 27,

        18, 28, 29, 30,
        21, 31, 32, 33,
        24, 34, 35, 36,
        27, 37, 38, 39,

        30, 40, 41, 0,
        33, 42, 43, 4,
        36, 44, 45, 8,
        39, 46, 47, 12,

        12, 13, 14, 15,
        48, 49, 50, 51,
        52, 53, 54, 55,
        56, 57, 58, 59,

        15, 25, 26, 27,
        51, 60, 61, 62,
        55, 63, 64, 65,
        59, 66, 67, 68,

        27, 37, 38, 39,
        62, 69, 70, 71,
        65, 72, 73, 74,
        68, 75, 76, 77,

        39, 46, 47, 12,
        71, 78, 79, 48,
        74, 80, 81, 52,
        77, 82, 83, 56,

        56, 57, 58, 59,
        84, 85, 86, 87,
        88, 89, 90, 91,
        92, 93, 94, 95,

        59, 66, 67, 68,
        87, 96, 97, 98,
        91, 99, 100, 101,
        95, 102, 103, 104,

        68, 75, 76, 77,
        98, 105, 106, 107,
        101, 108, 109, 110,
        104, 111, 112, 113,

        77, 82, 83, 56,
        107, 114, 115, 84,
        110, 116, 117, 88,
        113, 118, 119, 92,

        120, 121, 122, 123,
        124, 125, 126, 127,
        128, 129, 130, 131,
        132, 133, 134, 135,

        123, 136, 137, 120,
        127, 138, 139, 124,
        131, 140, 141, 128,
        135, 142, 143, 132,

        132, 133, 134, 135,
        144, 145, 146, 147,
        148, 149, 150, 151,
        68, 152, 153, 154,

        135, 142, 143, 132,
        147, 155, 156, 144,
        151, 157, 158, 148,
        154, 159, 160, 68,

        161, 162, 163, 164,
        165, 166, 167, 168,
        169, 170, 171, 172,
        173, 174, 175, 176,

        164, 177, 178, 161,
        168, 179, 180, 165,
        172, 181, 182, 169,
        176, 183, 184, 173,

        173, 174, 175, 176,
        185, 186, 187, 188,
        189, 190, 191, 192,
        193, 194, 195, 196,

        176, 183, 184, 173,
        188, 197, 198, 185,
        192, 199, 200, 189,
        196, 201, 202, 193,

        203, 203, 203, 203,
        206, 207, 208, 209,
        210, 210, 210, 210,
        211, 212, 213, 214,

        203, 203, 203, 203,
        209, 216, 217, 218,
        210, 210, 210, 210,
        214, 219, 220, 221,

        203, 203, 203, 203,
        218, 223, 224, 225,
        210, 210, 210, 210,
        221, 226, 227, 228,

        203, 203, 203, 203,
        225, 229, 230, 206,
        210, 210, 210, 210,
        228, 231, 232, 211,

        211, 212, 213, 214,
        233, 234, 235, 236,
        237, 238, 239, 240,
        241, 242, 243, 244,

        214, 219, 220, 221,
        236, 245, 246, 247,
        240, 248, 249, 250,
        244, 251, 252, 253,

        221, 226, 227, 228,
        247, 254, 255, 256,
        250, 257, 258, 259,
        253, 260, 261, 262,

        228, 231, 232, 211,
        256, 263, 264, 233,
        259, 265, 266, 237,
        262, 267, 268, 241,

        269, 269, 269, 269,
        278, 279, 280, 281,
        274, 275, 276, 277,
        270, 271, 272, 273,

        269, 269, 269, 269,
        281, 288, 289, 290,
        277, 285, 286, 287,
        273, 282, 283, 284,

        269, 269, 269, 269,
        290, 297, 298, 299,
        287, 294, 295, 296,
        284, 291, 292, 293,

        269, 269, 269, 269,
        299, 304, 305, 278,
        296, 302, 303, 274,
        293, 300, 301, 270

        };
    }
}