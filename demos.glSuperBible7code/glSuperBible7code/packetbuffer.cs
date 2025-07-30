
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace demos.glSuperBible7code {

    abstract class exeBase {
        //PFN_EXECUTE pfnExecute;
        public abstract void execute();
    }

    unsafe class BIND_PROGRAM : exeBase {
        public GLuint program;

        public override void execute() {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glUseProgram(program);
        }
    }

    unsafe class BIND_VERTEX_ARRAY : exeBase {
        public GLuint vao;

        public override void execute() {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glBindVertexArray(vao);
        }
    }

    unsafe class BIND_BUFFER_RANGE : exeBase {
        public GLenum target;
        public GLuint index;
        public GLuint buffer;
        public GLintptr offset;
        public GLsizeiptr size;

        public override void execute() {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glBindBufferRange(
                target, index, buffer, offset, size);
        }
    };

    unsafe class DRAW_ELEMENTS : exeBase {
        public GLenum mode;
        public GLsizei count;
        public GLenum type;
        public IntPtr indices;
        public GLsizei instancecount;
        public GLint basevertex;
        public GLuint baseinstance;

        public override void execute() {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glDrawElementsInstancedBaseVertexBaseInstance(
                mode, count, type, indices, instancecount, basevertex, baseinstance);
        }
    }

    unsafe class DRAW_ARRAYS : exeBase {
        public GLenum mode;
        public GLint first;
        public GLsizei count;
        public GLsizei instancecount;
        public GLuint baseinstance;

        public override void execute() {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glDrawArraysInstancedBaseInstance(
                mode, first, count, instancecount, baseinstance);
        }
    }

    unsafe class ENABLE : exeBase {
        public GLenum cap;

        public override void execute() {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glEnable(cap);
        }
    }
    unsafe class DISABLE : exeBase {
        public GLenum cap;

        public override void execute() {
            var gl = GL.Current; Debug.Assert(gl != null);
            gl.glDisable(cap);
        }
    }

    //struct ALL_PACKETS {

    //    //public PFN_EXECUTE execute;
    //    public exeBase Base;
    //    public BIND_PROGRAM BindProgram;
    //    public BIND_VERTEX_ARRAY BindVertexArray;
    //    public DRAW_ELEMENTS DrawElements;
    //    public DRAW_ARRAYS DrawArrays;
    //    public ENABLE Enable;
    //    public DISABLE Disable;
    //}

    public unsafe class packet_stream {

        public enum FINIALIZE_MODE {
            FINILIZE_TERMINATE,
            FINALIZE_RETURN_TO_DEFAULTS
        }

        public enum RESET_MODE {
            RESET_INHERIT,
            RESET_RETURN_TO_DEFAULTS
        }

        uint max_packets;
        exeBase[] m_packets;
        uint num_packets;

        public struct uintStruct {
            uint all_bits;
            public bool cull_face {
                get { return (all_bits & 1) != 0; }
                set { all_bits = all_bits | 1; }
            }
            public bool rasterizer_discard {
                get { return (all_bits & 2) != 0; }
                set { all_bits = all_bits | 2; }
            }
            public bool depth_test {
                get { return (all_bits & 4) != 0; }
                set { all_bits = all_bits | 4; }
            }
            public bool stencil_test {
                get { return (all_bits & 8) != 0; }
                set { all_bits = all_bits | 8; }
            }
            public bool depth_clamp {
                get { return (all_bits & 16) != 0; }
                set { all_bits = all_bits | 16; }
            }
        }
        public struct _state {
            public uintStruct enables;
            public uintStruct valid;
        }
        public _state state;

        public packet_stream(uint max_packets_) {
            max_packets = max_packets_;
            num_packets = 0;
            m_packets = new exeBase[max_packets];
            //memset(m_packets, 0, max_packets * sizeof(packet::ALL_PACKETS));
        }

        public void clear() {
            num_packets = 0;
        }

        public void execute() {
            foreach (var item in this.m_packets) {
                if (item != null) item.execute();
            }
        }

        public void BindProgram(GLuint program) {
            m_packets[num_packets++] = new BIND_PROGRAM() { program = program };
        }

        public void BindVertexArray(GLuint vao) {
            m_packets[num_packets++] = new BIND_VERTEX_ARRAY() { vao = vao };
        }

        public void BindBufferRange(GLenum target, GLuint index, GLuint buffer, GLintptr offset, GLsizeiptr size) {
            m_packets[num_packets++] = new BIND_BUFFER_RANGE() { target = target, index = index, buffer = buffer, offset = offset, size = size };
        }

        public void DrawElements(GLenum mode, GLsizei count, GLenum type, IntPtr start, GLsizei instancecount, GLint basevertex, GLuint baseinstance) {
            m_packets[num_packets++] = new DRAW_ELEMENTS() {
                mode = mode, count = count, type = type, indices = start,
                instancecount = instancecount, basevertex = basevertex, baseinstance = baseinstance
            };
        }

        public void DrawArrays(GLenum mode, GLint first, GLsizei count, GLsizei instancecount, GLuint baseinstance) {
            m_packets[num_packets++] = new DRAW_ARRAYS() { mode = mode, first = first, count = count, instancecount = instancecount, baseinstance = baseinstance };
        }

        public void EnableDisable(GLenum cap, GLboolean enable) {
            switch (cap) {
            case GL.GL_CULL_FACE:
            if (state.valid.cull_face && // already initialized before
                state.enables.cull_face == enable)
                return;
            state.enables.cull_face = enable;
            state.valid.cull_face = true;
            break;
            case GL.GL_RASTERIZER_DISCARD:
            if (state.valid.rasterizer_discard && // already initialized before
                state.enables.rasterizer_discard == enable)
                return;
            state.enables.rasterizer_discard = enable;
            state.valid.rasterizer_discard = true;
            break;
            case GL.GL_DEPTH_TEST:
            if (state.valid.depth_test && // already initialized before
                state.enables.depth_test == enable)
                return;
            state.enables.depth_test = enable;
            state.valid.depth_test = true;
            break;
            case GL.GL_STENCIL_TEST:
            if (state.valid.stencil_test && // already initialized before
                state.enables.stencil_test == enable)
                return;
            state.enables.stencil_test = enable;
            state.valid.stencil_test = true;
            break;
            case GL.GL_DEPTH_CLAMP:
            if (state.valid.depth_clamp && // already initialized before
                state.enables.depth_clamp == enable)
                return;
            state.enables.depth_clamp = enable;
            state.valid.depth_clamp = true;
            break;
            default:
            break;
            }

            if (enable) {
                m_packets[num_packets++] = new ENABLE() { cap = cap };
            }
            else {
                m_packets[num_packets++] = new DISABLE() { cap = cap };
            }
        }
    }

    public unsafe class packetbuffer : _glSuperBible7code {
        ~packetbuffer() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public packetbuffer(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        packet_stream? stream;
        text_overlay overlay = new text_overlay();

        struct _matrices {
            public mat4 mv_matrix;
            public mat4 view_matrix;
            public mat4 proj_matrix;
        }
        _matrices matrices;

        public override void init(CSharpGL.GL gl) {

            {
                stream = new packet_stream(max_packets_: 256);
                uint program;
                {
                    var vsCodeFile = "media/shaders/packetbuffer.vert";
                    var fsCodeFile = "media/shaders/packetbuffer.frag";
                    var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                    Debug.Assert(programObj != null);
                    program = programObj.programId;
                }

                GLuint vao;
                gl.glGenVertexArrays(1, &vao);

                GLuint buffer;
                gl.glGenBuffers(1, &buffer);
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, buffer);
                fixed (float* p = colors) {
                    gl.glBufferStorage(GL.GL_UNIFORM_BUFFER, sizeof(GLfloat) * colors.Length, (IntPtr)p, 0);
                }

                stream.BindProgram(program);
                stream.BindBufferRange(GL.GL_UNIFORM_BUFFER, 0, buffer, 0, sizeof(GLfloat) * colors.Length);
                stream.BindVertexArray(vao);
                stream.DrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4, 1, 0);

                sb7object sb7Obj = new sb7object();
                sb7Obj.load("media/objects/sphere.sbm");
                {
                    var vsCodeFile = "media/shaders/blinnphong.vert";
                    var fsCodeFile = "media/shaders/blinnphong.frag";
                    var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                    Debug.Assert(programObj != null);
                    program = programObj.programId;
                }
                GLuint first; GLuint count;
                sb7Obj.get_vao();
                sb7Obj.get_sub_object_info(0, &first, &count);

                matrices.view_matrix = glm.translate(0.0f, 0.0f, -1.0f);
                matrices.mv_matrix = matrices.view_matrix * glm.rotate(30.0f, 0.0f, 1.0f, 0.0f);
                matrices.proj_matrix = glm.frustum(-1.0f, 1.0f, 1.0f, -1.0f, 0.1f, 1000.0f);

                gl.glGenBuffers(1, &buffer);
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, buffer);
                {
                    var value = matrices;
                    gl.glBufferStorage(GL.GL_UNIFORM_BUFFER, sizeof(_matrices), (IntPtr)(&value), 0);
                }

                stream.BindProgram(program);
                stream.BindVertexArray(sb7Obj.get_vao());
                stream.BindBufferRange(GL.GL_UNIFORM_BUFFER, 0, buffer, 0, sizeof(_matrices));
                stream.DrawArrays(GL.GL_TRIANGLES, (int)first, (int)count, 1, 0);

                overlay.init(80, 40);
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

            if (stream != null) { stream.execute(); }

            gl.glEnable(GL.GL_BLEND);
            gl.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);
            gl.glBlendEquation(GL.GL_MAX);

            overlay.drawText($"time: {currentTime}", 0, 0);
            overlay.draw();

            gl.glDisable(GL.GL_BLEND);
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


        static GLfloat[] colors =
        {
        1.0f, 0.0f, 0.0f, 1.0f,
        0.0f, 1.0f, 0.0f, 1.0f,
        0.0f, 0.0f, 1.0f, 1.0f,
        1.0f, 0.0f, 1.0f, 1.0f,
        };
    }
}