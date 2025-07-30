
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class grass : _glSuperBible7code {
        ~grass() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public grass(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint grass_buffer;
        GLuint grass_vao;

        GLuint grass_program;

        GLuint tex_grass_color;
        GLuint tex_grass_length;
        GLuint tex_grass_orientation;
        GLuint tex_grass_bend;

        struct _uniforms {
            public GLint mvpMatrix;
        }
        _uniforms uniforms;
        static GLfloat[] grass_blade = {
            -0.3f, 0.0f,
             0.3f, 0.0f,
            -0.20f, 1.0f,
             0.1f, 1.3f,
            -0.05f, 2.3f,
             0.0f, 3.3f
        };
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/grass.vert";
                var fsCodeFile = "media/shaders/grass.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.grass_program = programObj.programId;
                gl.glUseProgram(this.grass_program);

                uniforms.mvpMatrix = gl.glGetUniformLocation(grass_program, "mvpMatrix");

            }
            {

                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); grass_buffer = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, grass_buffer);
                fixed (float* p = grass_blade) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER, sizeof(float) * grass_blade.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                gl.glGenVertexArrays(1, id); grass_vao = id[0];
                gl.glBindVertexArray(grass_vao);

                gl.glVertexAttribPointer(0, 2, GL.GL_FLOAT, false, 0, 0);
                gl.glEnableVertexAttribArray(0);

                gl.glActiveTexture(GL.GL_TEXTURE1);
                tex_grass_length = sb7ktx.load("media/textures/grass_length.ktx");
                gl.glActiveTexture(GL.GL_TEXTURE2);
                tex_grass_orientation = sb7ktx.load("media/textures/grass_orientation.ktx");
                gl.glActiveTexture(GL.GL_TEXTURE3);
                tex_grass_color = sb7ktx.load("media/textures/grass_color.ktx");
                gl.glActiveTexture(GL.GL_TEXTURE4);
                tex_grass_bend = sb7ktx.load("media/textures/grass_bend.ktx");
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
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            currentTime += 0.001f;

            var proj_matrix = this.proj_matrix;
            float r = 550.0f;

            mat4 mv_matrix = glm.lookAt(
                new vec3((float)Math.Sin(currentTime) * r, 25.0f, (float)Math.Cos(currentTime) * r),
                new vec3(0.0f, -50.0f, 0.0f),
                new vec3(0.0f, 1.0f, 0.0f));

            gl.glUseProgram(grass_program);
            var mvp = proj_matrix * mv_matrix;
            gl.glUniformMatrix4fv(uniforms.mvpMatrix, 1, false, (float*)&mvp);

            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            gl.glViewport(0, 0, this.width, this.height);

            gl.glBindVertexArray(grass_vao);
            gl.glDrawArraysInstanced(GL.GL_TRIANGLE_STRIP, 0, 6, 1024 * 1024);
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
            case Keys.Escape:// 27:
                             //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];

    }
}