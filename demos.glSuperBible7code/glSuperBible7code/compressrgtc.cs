
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class compressrgtc : _glSuperBible7code {
        ~compressrgtc() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public compressrgtc(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint compress_program;
        GLuint render_program;
        GLuint input_texture;
        GLuint output_texture;
        GLuint output_buffer;
        GLuint output_buffer_texture;
        GLuint dummy_vao;


        const int SHOW_INPUT = 0,
               SHOW_OUTPUT = 1,
               MAX_MODE = 2;

        int display_mode;

        const int TEXTURE_WIDTH = 512;
        const int TEXTURE_HEIGHT = 512;

        public override void init(CSharpGL.GL gl) {
            {
                var csCodeFile = "media/shaders/compressrgtc.rgtccompress.comp";
                var programObj = Utility.LoadShaders((csCodeFile, Shader.Kind.comp));
                Debug.Assert(programObj != null); this.compress_program = programObj.programId;
                gl.glUseProgram(this.compress_program);
            }
            {
                var vsCodeFile = "media/shaders/compressrgtc.drawquad.vert";
                var fsCodeFile = "media/shaders/compressrgtc.drawquad.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_program = programObj.programId;
                gl.glUseProgram(this.render_program);
            }
            {
                // input_texture = sb7::ktx::file::load("media/textures/sdftexture.ktx");
                // input_texture = sb7::ktx::file::load("media/textures/frog_eye_magnified_linear.ktx");
                input_texture = sb7ktx.load("media/textures/gllogodistsm.ktx");

                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); output_texture = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, output_texture);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                // glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_COMPRESSED_RED_RGTC1, TEXTURE_WIDTH / 4, TEXTURE_HEIGHT / 4);

                gl.glGenBuffers(1, id); output_buffer = id[0];
                gl.glBindBuffer(GL.GL_TEXTURE_BUFFER, output_buffer);
                gl.glBufferStorage(GL.GL_TEXTURE_BUFFER, TEXTURE_WIDTH * TEXTURE_HEIGHT / 2, 0, GL.GL_MAP_READ_BIT);

                gl.glGenTextures(1, id); output_buffer_texture = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_BUFFER, output_buffer_texture);
                gl.glTexBuffer(GL.GL_TEXTURE_BUFFER, GL.GL_RG32UI, output_buffer);

                gl.glGenVertexArrays(1, id); dummy_vao = id[0];
                display_mode = SHOW_OUTPUT;
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float time = 0;
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.01f;

            var proj_matrix = this.proj_matrix;
            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, input_texture);
            gl.glBindImageTexture(0, output_buffer_texture, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RG32UI);

            gl.glUseProgram(compress_program);
            gl.glDispatchCompute(TEXTURE_WIDTH / 4, TEXTURE_WIDTH / 4, 1);

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            var ptr = (byte*)gl.glMapBufferRange(GL.GL_TEXTURE_BUFFER, 0, TEXTURE_WIDTH * TEXTURE_HEIGHT / 2, GL.GL_MAP_READ_BIT);

            gl.glUnmapBuffer(GL.GL_TEXTURE_BUFFER);

            gl.glBindBuffer(GL.GL_PIXEL_UNPACK_BUFFER, output_buffer);
            gl.glBindTexture(GL.GL_TEXTURE_2D, output_texture);
            // glCompressedTexSubImage2D(GL.GL_TEXTURE_2D, 0, 0, 0, 1024, 1024, GL.GL_COMPRESSED_RED_RGTC1, 1024 * 1024 / 2, NULL);
            gl.glCompressedTexImage2D(GL.GL_TEXTURE_2D, 0, GL.GL_COMPRESSED_RED_RGTC1, TEXTURE_WIDTH, TEXTURE_HEIGHT, 0, TEXTURE_WIDTH * TEXTURE_HEIGHT / 2, 0);
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
            gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);

            gl.glBindVertexArray(dummy_vao);
            gl.glUseProgram(render_program);
            // glBindTexture(GL.GL_TEXTURE_2D, input_texture);
            switch (display_mode) {
            case SHOW_INPUT:
            gl.glBindTexture(GL.GL_TEXTURE_2D, input_texture);
            break;
            case SHOW_OUTPUT:
            gl.glBindTexture(GL.GL_TEXTURE_2D, output_texture);
            break;
            }
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
        }

        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            //aspect = (float)height / (float)width;
            this.proj_matrix = glm.perspective(50.0f * (float)Math.PI / 180.0f, (float)width / (float)height, 0.1f, 1000.0f);
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.M:
            display_mode = display_mode + 1;
            if (display_mode == MAX_MODE) display_mode = SHOW_INPUT;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.M];
        public override MouseButtons[] ValidButtons => [];

    }
}