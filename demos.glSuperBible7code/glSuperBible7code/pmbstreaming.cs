
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class pmbstreaming : _glSuperBible7code {
        ~pmbstreaming() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public pmbstreaming(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        text_overlay overlay = new text_overlay();
        const int CHUNK_COUNT = 4;
        static readonly int CHUNK_SIZE = 3 * sizeof(mat4);
        static readonly int BUFFER_SIZE = (CHUNK_SIZE * CHUNK_COUNT);

        enum MODE {
            NO_SYNC = 0,
            FINISH = 1,
            ONE_SYNC = 2,
            RINGED_SYNC = 3,
            NUM_MODES
        }
        MODE mode = MODE.NO_SYNC;

        struct MATRICES {
            public mat4 modelview;
            public mat4 projection;
        }

        sb7object sb7Obj = new sb7object();
        GLuint program;
        GLuint buffer;
        GLuint texture;
        GLsync[] fence = new nint[CHUNK_COUNT];
        MATRICES* vs_uniforms;
        uint sync_index;
        bool stalled;


        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/pmbstreaming.vert";
                var fsCodeFile = "media/shaders/pmbstreaming.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program = programObj.programId;
                gl.glUseProgram(this.program);

            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); buffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, buffer);

                gl.glBufferStorage(GL.GL_UNIFORM_BUFFER,
                    BUFFER_SIZE, 0,
                    GL.GL_MAP_WRITE_BIT | 0x0040/*GL_MAP_PERSISTENT_BIT*/ | 0x0080/*GL_MAP_COHERENT_BIT*/);
                vs_uniforms = (MATRICES*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                    0, BUFFER_SIZE,
                    GL.GL_MAP_WRITE_BIT | 0x0040/*GL_MAP_PERSISTENT_BIT*/ | 0x0080/*GL_MAP_COHERENT_BIT*/);

                sb7Obj.load("media/objects/torus_nrms_tc.sbm");

                gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, buffer);

                overlay.init(128, 50);

                gl.glActiveTexture(GL.GL_TEXTURE0);
                texture = sb7ktx.load("media/textures/pattern1.ktx");

                for (int i = 0; i < CHUNK_COUNT; i++) {
                    fence[i] = 0;
                }
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

            mat4 mv_matrix = glm.translate(0.0f, 0.0f, -3.0f) *
                glm.rotate((float)currentTime * 43.75f, 0.0f, 1.0f, 0.0f) *
                glm.rotate((float)currentTime * 17.75f, 0.0f, 0.0f, 1.0f) *
                glm.rotate((float)currentTime * 35.3f, 1.0f, 0.0f, 0.0f);

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, black);
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, one);

            gl.glUseProgram(program);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LESS);
            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, texture);

            if (mode == MODE.ONE_SYNC) {
                if (fence[0] != 0) {
                    int length; int isSignaled;
                    gl.glGetSynciv(fence[0], 0x9114/*GL_SYNC_STATUS*/, sizeof(int), &length, &isSignaled);
                    stalled = isSignaled == 0x9118/*GL_UNSIGNALED*/;
                    gl.glClientWaitSync(fence[0], 0, UInt64.MaxValue/*GL_TIMEOUT_IGNORED*/);
                    gl.glDeleteSync(fence[0]);
                }
            }
            else if (mode == MODE.RINGED_SYNC) {
                if (fence[sync_index] != 0) {
                    int length; int isSignaled;
                    gl.glGetSynciv(fence[sync_index], 0x9114/*GL_SYNC_STATUS*/, sizeof(int), &length, &isSignaled);
                    stalled = isSignaled == 0x9118/*GL_UNSIGNALED*/;
                    gl.glClientWaitSync(fence[sync_index], 0, UInt64.MaxValue/*GL_TIMEOUT_IGNORED*/);
                    gl.glDeleteSync(fence[sync_index]);
                }
            }

            vs_uniforms[sync_index].modelview = mv_matrix;
            vs_uniforms[sync_index].projection = proj_matrix;

            if (mode == MODE.RINGED_SYNC) {
                sb7Obj.render(1, sync_index);
            }
            else {
                sb7Obj.render(1, 0);
            }

            updateOverlay();

            if (mode == MODE.FINISH) {
                gl.glFinish();
                stalled = true;
            }
            else if (mode == MODE.ONE_SYNC) {
                fence[0] = gl.glFenceSync(0x9117/*GL_SYNC_GPU_COMMANDS_COMPLETE*/, 0);
            }
            else if (mode == MODE.RINGED_SYNC) {
                fence[sync_index] = gl.glFenceSync(0x9117/*GL_SYNC_GPU_COMMANDS_COMPLETE*/, 0);
            }

            sync_index = (sync_index + 1) % CHUNK_COUNT;

        }

        void updateOverlay() {
            overlay.clear();
            overlay.drawText($"time:{currentTime}", 0, 0);
            overlay.drawText($"mode: {mode}", 0, 1);
            if (stalled) {
                overlay.drawText("STALLED", 0, 2);
            }

            overlay.draw();
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
            case Keys.M:
            mode = (MODE)((int)(mode + 1) % (int)MODE.NUM_MODES);
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