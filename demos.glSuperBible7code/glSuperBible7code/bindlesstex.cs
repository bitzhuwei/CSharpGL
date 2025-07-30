
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class bindlesstex : _glSuperBible7code {
        ~bindlesstex() {
            var gl = GL.Current; if (gl == null) return;
            int i;

            for (i = 0; i < NUM_TEXTURES; i++) {
                gl.glMakeTextureHandleNonResidentARB(textures[i].handle);
                var name = textures[i].name;
                gl.glDeleteTextures(1, &name);
            }

            gl.glDeleteProgram(program);
            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public bindlesstex(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }
        const int NUM_TEXTURES = 384,
                TEXTURE_LEVELS = 5,
                TEXTURE_SIZE = (1 << (TEXTURE_LEVELS - 1));


        GLuint program;

        struct _uniforms {
            public GLint mv_matrix;
            public GLint vp_matrix;
        }
        _uniforms uniforms;

        struct _texture {
            public GLuint name;
            public GLuint64 handle;
        }
        _texture[] textures = new _texture[1024];

        struct _buffer {
            public GLuint transformBuffer;
            public GLuint textureHandleBuffer;
        }
        _buffer buffers;

        struct MATRICES {
            mat4 view;
            mat4 projection;
            public mat4[] model = new mat4[NUM_TEXTURES];

            public MATRICES() { }
        }

        sb7object sb7Obj = new sb7object();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/bindlesstex.vert";
                var fsCodeFile = "media/shaders/bindlesstex.frag";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.program = program.programId;
                gl.glUseProgram(this.program);
            }
            {

                byte[] tex_data = new byte[32 * 32 * 4];
                uint[] mutated_data = new uint[32 * 32];

                for (var i = 0; i < 32; i++) {
                    for (var j = 0; j < 32; j++) {
                        tex_data[i * 4 * 32 + j * 4] = (byte)((i ^ j) << 3);
                        tex_data[i * 4 * 32 + j * 4 + 1] = (byte)((i ^ j) << 3);
                        tex_data[i * 4 * 32 + j * 4 + 2] = (byte)((i ^ j) << 3);
                    }
                }

                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); buffers.transformBuffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, buffers.transformBuffer);
                gl.glBufferStorage(GL.GL_UNIFORM_BUFFER,
                    sizeof(mat4) * (2 + NUM_TEXTURES),//sizeof(MATRICES), 
                    IntPtr.Zero, GL.GL_MAP_WRITE_BIT);

                gl.glGenBuffers(1, id); buffers.textureHandleBuffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, buffers.textureHandleBuffer);
                gl.glBufferStorage(GL.GL_UNIFORM_BUFFER,
                    NUM_TEXTURES * sizeof(GLuint64) * 2, IntPtr.Zero, GL.GL_MAP_WRITE_BIT);

                fixed (byte* p = tex_data) fixed (uint* p2 = mutated_data) {
                    var pHandles = (GLuint64*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                        0, NUM_TEXTURES * sizeof(GLuint64) * 2, GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                    for (var i = 0; i < NUM_TEXTURES; i++) {
                        var a = random_uint(); var b = random_uint();
                        uint r = (a & 0xFCFF3F) << (int)(b % 12);
                        gl.glGenTextures(1, id); textures[i].name = id[0];
                        gl.glBindTexture(GL.GL_TEXTURE_2D, textures[i].name);
                        gl.glTexStorage2D(GL.GL_TEXTURE_2D, TEXTURE_LEVELS, GL.GL_RGBA8, TEXTURE_SIZE, TEXTURE_SIZE);
                        for (var j = 0; j < 32 * 32; j++) {
                            mutated_data[j] = (((uint*)p)[j] & r) | 0x20202020;
                        }
                        gl.glTexSubImage2D(GL.GL_TEXTURE_2D, 0, 0, 0,
                            TEXTURE_SIZE, TEXTURE_SIZE, GL.GL_RGBA, GL.GL_UNSIGNED_BYTE, (IntPtr)p2);
                        gl.glGenerateMipmap(GL.GL_TEXTURE_2D);
                        textures[i].handle = gl.glGetTextureHandleARB(textures[i].name);
                        gl.glMakeTextureHandleResidentARB(textures[i].handle);
                        pHandles[i * 2] = textures[i].handle;
                    }
                    gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);
                }

                sb7Obj.load("media/objects/torus_nrms_tc.sbm");
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float last_time = 0.0f;
        float total_time = 0.0f;
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            total_time += 0.01f;

            int i;
            var black = Utility.color.Black;
            gl.glClearBufferfv(GL.GL_COLOR, 0, (float*)&black);
            gl.glClearBufferfi(GL.GL_DEPTH_STENCIL, 0, 1.0f, 0);

            gl.glFinish();

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, buffers.transformBuffer);

            var pMatrices = (mat4*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, sizeof(mat4) * (2 + NUM_TEXTURES), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            pMatrices[0] = glm.translate(0.0f, 0.0f, -80.0f);
            pMatrices[1] = proj_matrix;
            float angle = total_time;
            float angle2 = 0.7f * total_time;
            float angle3 = 0.1f * total_time;
            for (i = 0; i < NUM_TEXTURES; i++) {
                var m = glm.rotate(angle * 140.0f, 0.0f, 0.0f, 1.0f)
                    * glm.rotate(angle * 130.0f, 1.0f, 0.0f, 0.0f)
                    * glm.translate(
                        (i % 32) * 4.0f - 62.0f,
                        (i >> 5) * 6.0f - 33.0f,
                        15.0f * (float)Math.Sin(angle * 0.19f)
                            + 3.0f * (float)Math.Cos(angle2 * 6.26f)
                            + 40.0f * (float)Math.Sin(angle3));
                pMatrices[2 + i] = m;
                angle += 1.0f;
                angle2 += 4.1f;
                angle3 += 0.01f;
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            gl.glFinish();

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 1, buffers.textureHandleBuffer);

            gl.glEnable(GL.GL_DEPTH_TEST);

            gl.glUseProgram(program);

            sb7Obj.render(NUM_TEXTURES);
            // glBindVertexArray(object.get_vao());
            // glDrawArraysInstanced(GL.GL_POINTS, 0, 4900, 384);
        }

        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            //aspect = (float)height / (float)width;
            this.proj_matrix = glm.perspective(70.0f * (float)Math.PI / 180.0f,
                        (float)width / (float)height,
                        0.1f, 500.0f);
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


        uint seed = 0x13371337;

        uint random_uint() {
            float res;
            uint tmp;

            seed *= 16807;

            tmp = seed ^ (seed >> 4) ^ (seed << 15);

            return tmp;
        }
    }
}