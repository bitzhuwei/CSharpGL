
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class sdfdemo : _glSuperBible7code {
        ~sdfdemo() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public sdfdemo(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint sdf_texture;
        GLuint logo_texture;
        GLuint sdf_program;

        GLuint vao;

        enum RENDER_MODE {
            MODE_LOGO,
            MODE_TEXT
        };

        RENDER_MODE render_mode = RENDER_MODE.MODE_LOGO;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/sdfdemo.vert";
                var fsCodeFile = "media/shaders/sdfdemo.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.sdf_program = programObj.programId;
                gl.glUseProgram(this.sdf_program);

                GLint foo = gl.glGetUniformLocation(sdf_program, "uv_transform");

            }
            {
                logo_texture = sb7ktx.load("media/textures/gllogodistsmarray.ktx");
                gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, sdf_texture);
                gl.glTexParameteri(GL.GL_TEXTURE_2D_ARRAY, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D_ARRAY, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);

                sdf_texture = sb7ktx.load("media/textures/chars-df-array.ktx");
                gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, sdf_texture);
                gl.glTexParameteri(GL.GL_TEXTURE_2D_ARRAY, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D_ARRAY, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);

                GLuint id;
                gl.glGenVertexArrays(1, &id); vao = id;
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
            currentTime += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glBindVertexArray(vao);

            //gl.glViewport(0, 0, this.width, this.height);

            //gl.glClearBufferfv(GL.GL_COLOR, 0, black);

            float scale = (float)((float)Math.Cos(currentTime * 0.2) * (float)Math.Sin(currentTime * 0.15) * 6.0 + 3.001);
            float cos_t = (float)(float)Math.Cos(currentTime) * scale;
            float sin_t = (float)(float)Math.Sin(currentTime) * scale;

            float[] m =
            {
            cos_t, sin_t, 0.0f,
            -sin_t, cos_t, 0.0f,
            0.0f, 0.0f, 1.0f
            };

            float[] m2 =
            {
            1.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 1.0f
            };

            mat4 transform = mat4.identity();

            int num_chars = 1;
            float tz = -10.0f;
            float rs = 1.0f;

            switch (render_mode) {
            case RENDER_MODE.MODE_LOGO:
            num_chars = 1;
            tz = -4.0f;
            gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, logo_texture);
            transform = glm.translate(0.0f, 0.0f, -6.0f + cos_t * 0.25f) *
                glm.rotate(cos_t * 12.0f, new vec3(1.0f, 0.0f, 0.0f)) *
                glm.rotate(sin_t * 15.0f, new vec3(0.0f, 1.0f, 0.0f)) *
                glm.scale(6.0f, 6.0f, 1.0f);
            break;
            case RENDER_MODE.MODE_TEXT:
            num_chars = 24;
            tz = -10.0f;
            rs = 4.0f;
            gl.glBindTexture(GL.GL_TEXTURE_2D_ARRAY, sdf_texture);
            transform = glm.translate(0.0f, 0.0f, tz + cos_t) *
                glm.rotate(cos_t * 4.0f * rs, new vec3(1.0f, 0.0f, 0.0f)) *
                glm.rotate(sin_t * 3.0f * rs, new vec3(0.0f, 0.0f, 1.0f)) *
                glm.translate(-(float)((num_chars - 1)) + sin_t, 0.0f, 0.0f);
            break;
            }

            mat4 projection;

            var aspect = (float)this.width / (float)this.height;
            projection = glm.frustum(-aspect, aspect, 1.0f, -1.0f, 1.0f, 100.0f);

            gl.glUseProgram(sdf_program);
            gl.glUniformMatrix3fv(0, 1, false, m2);
            {
                var value = projection * transform;
                gl.glUniformMatrix4fv(1, 1, false, (float*)&value);
            }
            // glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
            gl.glDrawArraysInstanced(GL.GL_TRIANGLE_STRIP, 0, 4, num_chars);
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
            case Keys.D1:
            render_mode = RENDER_MODE.MODE_LOGO;
            //setWindowTitle("OpenGL SuperBible - Distance Field (Logo)");
            break;
            case Keys.D2:
            render_mode = RENDER_MODE.MODE_TEXT;
            //setWindowTitle("OpenGL SuperBible - Distance Field (Text)");
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