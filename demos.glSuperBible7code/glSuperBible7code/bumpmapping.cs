
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    // Note: this demo requires '#version 420 core' in shader.
    // and '#version 410 core' in shader in the super bible project will fail.
    // How can the super bible leave it like that? shame.
    public unsafe class bumpmapping : _glSuperBible7code {
        ~bumpmapping() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public bumpmapping(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        GLuint program;

        struct _textures {
            public GLuint color;
            public GLuint normals;
        }
        _textures textures;

        struct _uniforms {
            public GLint mv_matrix;
            public GLint proj_matrix;
            public GLint light_pos;
        }
        _uniforms uniforms;

        sb7object sb7Obj = new sb7object();
        bool paused = false;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/bumpmapping.vert";
                var fsCodeFile = "media/shaders/bumpmapping.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

                uniforms.mv_matrix = gl.glGetUniformLocation(program, "mv_matrix");
                uniforms.proj_matrix = gl.glGetUniformLocation(program, "proj_matrix");
                uniforms.light_pos = gl.glGetUniformLocation(program, "light_pos");
            }

            gl.glActiveTexture(GL.GL_TEXTURE0);
            textures.color = sb7ktx.load("media/textures/ladybug_co.ktx");
            gl.glActiveTexture(GL.GL_TEXTURE1);
            textures.normals = sb7ktx.load("media/textures/ladybug_nm.ktx");

            sb7Obj.load("media/objects/ladybug.sbm");
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        float time = 0;
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.01f;

            //fixed (GLfloat* p = gray) {
            //    gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            //}
            //fixed (GLfloat* p = ones) {
            //    gl.glClearBufferfv(GL.GL_DEPTH, 0, p);
            //}

            gl.glEnable(GL.GL_DEPTH_TEST);

            gl.glUseProgram(program);


            var proj_matrix = this.proj_matrix;
            gl.glUniformMatrix4fv(uniforms.proj_matrix, 1, false, (float*)&proj_matrix);

            mat4 mv_matrix = mat4.identity();
            //mv_matrix = glm.rotate(mv_matrix, -20.0f, 0.0f, 1.0f, 0.0f);
            //mv_matrix = glm.rotate(mv_matrix, 14.5f, 1.0f, 0.0f, 0.0f);
            //mv_matrix = glm.translate(mv_matrix, 0.0f, -0.2f, -5.5f);
            var position = glm.rotate(time * 10, new vec3(0, 1, 0)) * new vec4(5, 3, 4, 1);
            mv_matrix = glm.lookAt(new vec3(position) * 1.5f, new vec3(0, 0, 0), new vec3(0, 1, 0));
            gl.glUniformMatrix4fv(uniforms.mv_matrix, 1, false, (float*)&mv_matrix);

            var v = new vec3(40.0f * (float)Math.Sin(time), 30.0f + 20.0f * (float)Math.Cos(time), 40.0f);
            gl.glUniform3fv(uniforms.light_pos, 1, (float*)&v);

            sb7Obj.render();
        }
        int width; int height;
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
            case Keys.S:
            Utility.make_screenshot(this.width, this.height, gl);
            break;
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