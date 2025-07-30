
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static CSharpGL.TransformFeedbackObject;

namespace demos.glSuperBible7code {

    public unsafe class programinfo : _glSuperBible7code {
        unsafe struct type_to_name_entry {
            public GLenum type;
            public string name;
            public type_to_name_entry(GLenum type, string name) {
                this.type = type; this.name = name;
            }
        }
        static readonly type_to_name_entry[] type_to_name_table = new type_to_name_entry[]{
        new(GL.GL_FLOAT, "float"),
        new(0x8B50/*GL_FLOAT_VEC2*/, "vec2"),
        new(0x8B51/*GL_FLOAT_VEC3*/, "vec3"),
        new(0x8B52/*GL_FLOAT_VEC4*/, "vec4"),
        new(GL.GL_DOUBLE, "double"),
        new(0x8FFC/*GL_DOUBLE_VEC2*/, "dvec2"),
        new(0x8FFD/*GL_DOUBLE_VEC3*/, "dvec3"),
        new(0x8FFE/*GL_DOUBLE_VEC4*/, "dvec4"),
        new(GL.GL_INT, "int"),
        new(0x8B53/*GL_INT_VEC2*/, "ivec2"),
        new(0x8B54/*GL_INT_VEC3*/, "ivec3"),
        new(0x8B55/*GL_INT_VEC4*/, "ivec4"),
        new(GL.GL_UNSIGNED_INT, "uint"),
        new(GL.GL_UNSIGNED_INT_VEC2, "uvec2"),
        new(GL.GL_UNSIGNED_INT_VEC3, "uvec3"),
        new(GL.GL_UNSIGNED_INT_VEC4, "uvec4"),
        new(0x8B56/*GL_BOOL*/, "bool"),
        new(0x8B57/*GL_BOOL_VEC2*/, "bvec2"),
        new(0x8B58/*GL_BOOL_VEC3*/, "bvec3"),
        new(0x8B59/*GL_BOOL_VEC4*/, "bvec4"),
        };

        static string type_to_name(GLenum type) {
            foreach (var item in type_to_name_table) {
                if (item.type == type) return item.name;
            }
            return string.Empty;
        }

        ~programinfo() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public programinfo(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        text_overlay overlay = new text_overlay();

        static GLenum[] props = { 0x92FA/*GL_TYPE*/, 0x930E/*GL_LOCATION*/, 0x92FB/*GL_ARRAY_SIZE*/ };
        static string[] prop_name = { "type", "location", "array size" };

        public override void init(CSharpGL.GL gl) {
            overlay.init(80, 50);

            GLuint program = gl.glCreateProgram();
            gl.glProgramParameteri(program, 0x8258/*GL_PROGRAM_SEPARABLE*/, 1/*GL_TRUE*/);

            GLuint fs = gl.glCreateShader(0x8B30/*GL_FRAGMENT_SHADER*/);
            gl.glAttachShader(program, fs);

            var fs_source = File.ReadAllText("media/shaders/programinfo.frag");
            var lengths = fs_source.Length;
            gl.glShaderSource(fs, 1, new string[] { fs_source }, &lengths);
            gl.glCompileShader(fs);

            gl.glLinkProgram(program);

            GLint outputs;

            gl.glGetProgramInterfaceiv(program, 0x92E4/*GL_PROGRAM_OUTPUT*/, 0x92F5/*GL_ACTIVE_RESOURCES*/, &outputs);

            GLint[] params_ = new int[4];
            var il = new StringBuilder(1024);
            gl.glGetProgramInfoLog(program, 1024, Array.Empty<int>(), il);

            overlay.print("Program linked\n");
            overlay.print(il.ToString());

            for (uint i = 0; i < outputs; i++) {
                var name = new StringBuilder(64);
                var length0 = 0;
                gl.glGetProgramResourceName(program, 0x92E4/*GL_PROGRAM_OUTPUT*/, i, 64, &length0, name);
                var length1 = 0;
                fixed (GLenum* pProps = props) fixed (GLint* pParams_ = params_) {
                    gl.glGetProgramResourceiv(program, 0x92E4/*GL_PROGRAM_OUTPUT*/, i, 3, pProps, 3, &length1, pParams_);
                }
                var type_name = type_to_name((uint)params_[0]);
                string str;
                if (params_[2] != 0) {
                    //sprintf(buffer, "Index %d: %s %s[%d] @ location %d.\n", i, type_name, name, params_[2], params_[1]);
                    str = $"index: {i}: {type_name} {name}[{params_[2]} @ location {params_[1]}\n";
                }
                else {
                    //sprintf(buffer, "Index %d: %s %s @ location %d.\n", i, type_name, name, params_[1]);
                    str = $"index: {i}: {type_name} {name} @ location {params_[1]}\n";
                }
                overlay.print(str);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float t = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            t += 0.01f;

            var proj_matrix = this.proj_matrix;

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