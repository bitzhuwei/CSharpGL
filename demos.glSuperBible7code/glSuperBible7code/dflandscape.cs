
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class dflandscape : _glSuperBible7code {
        ~dflandscape() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public dflandscape(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint map_texture;
        GLuint grass_texture;
        GLuint rocks_texture;
        GLuint sdf_program;

        GLuint vao;

        enum RENDER_MODE {
            MODE_LOGO,
            MODE_TEXT
        };

        RENDER_MODE render_mode;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/dflandscape.vert";
                var fsCodeFile = "media/shaders/dflandscape.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.sdf_program = programObj.programId;
                gl.glUseProgram(this.sdf_program);

                GLint foo = gl.glGetUniformLocation(sdf_program, "uv_transform");
            }
            {
                map_texture = sb7ktx.load("media/textures/psycho-map-df-sm.ktx");
                grass_texture = sb7ktx.load("media/textures/mossygrass.ktx");
                rocks_texture = sb7ktx.load("media/textures/rocks.ktx");

                gl.glBindTexture(GL.GL_TEXTURE_2D, map_texture);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);
                gl.glBindTexture(GL.GL_TEXTURE_2D, grass_texture);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);
                gl.glBindTexture(GL.GL_TEXTURE_2D, rocks_texture);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR_MIPMAP_LINEAR);

                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
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

            float scale = (float)((float)Math.Cos(currentTime * 0.2) * (float)Math.Sin(currentTime * 0.15) * 3.0 + 3.2);
            float cos_t = (float)(float)Math.Cos(currentTime * 0.03) * 0.25f;
            float sin_t = (float)(float)Math.Sin(currentTime * 0.02) * 0.25f;

            float[] m =
            {
            cos_t, sin_t, 0.0f,
            -sin_t, cos_t, 0.0f,
            0.0f, 0.0f, 1.0f
            };

            float[] m2 =
            {
            cos_t * scale, sin_t * scale, 0.0f,
            -sin_t * scale, cos_t * scale, 0.0f,
            cos_t, sin_t, 1.0f
            };

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, map_texture);
            gl.glActiveTexture(GL.GL_TEXTURE1);
            gl.glBindTexture(GL.GL_TEXTURE_2D, grass_texture);
            gl.glActiveTexture(GL.GL_TEXTURE2);
            gl.glBindTexture(GL.GL_TEXTURE_2D, rocks_texture);


            var transform = glm.translate(0.0f, 0.0f, -1.0f) *
                  glm.scale(10.0f, 10.0f, 1.0f);

            var projection = glm.frustum(-aspect, aspect, 1.0f, -1.0f, 1.0f, 100.0f);

            gl.glUseProgram(sdf_program);
            gl.glUniformMatrix3fv(0, 1, false, m2);
            var mvp = projection * transform;
            gl.glUniformMatrix4fv(1, 1, false, (float*)&mvp);
            // glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
            gl.glDrawArraysInstanced(GL.GL_TRIANGLE_STRIP, 0, 4, 1);
        }

        float aspect;
        int width, height;
        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            aspect = (float)width / (float)height;
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


        public override Keys[] ValidKeys => [Keys.D1, Keys.D2];
        public override MouseButtons[] ValidButtons => [];

    }
}