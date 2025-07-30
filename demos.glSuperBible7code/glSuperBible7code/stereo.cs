
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    // Note: it prints "WGL: Failed to find a suitable pixel format" in my PC in the original C++ stereo project.
    public unsafe class stereo : _glSuperBible7code {
        ~stereo() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public stereo(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        GLuint view_program;
        GLint show_light_depth_program;

        struct _uniforms {
            public struct _light {
                public GLint mvp;
            }
            public _light light;
            public struct _view {
                public GLint mv_matrix;
                public GLint proj_matrix;
                public GLint shadow_matrix;
                public GLint full_shading;
                public GLint specular_albedo;
                public GLint diffuse_albedo;
            }
            public _view view;
        }
        _uniforms uniforms;

        const int OBJECT_COUNT = 4;
        struct _object {
            public sb7object obj;
            public mat4 model_matrix;
        }
        _object[] objects = new _object[OBJECT_COUNT];

        mat4 light_view_matrix;
        mat4 light_proj_matrix;

        mat4[] camera_view_matrix = new mat4[2];
        mat4 camera_proj_matrix;

        GLuint quad_vao;

        float separation = 2;

        enum _Mode {
            RENDER_FULL,
            RENDER_LIGHT,
            RENDER_DEPTH
        }
        _Mode mode = _Mode.RENDER_FULL;

        static string[] object_names =
        {
        "media/objects/dragon.sbm",
        "media/objects/sphere.sbm",
        "media/objects/cube.sbm",
        "media/objects/torus.sbm"
        };

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/stereo.vert";
                var fsCodeFile = "media/shaders/stereo.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.view_program = programObj.programId;
                gl.glUseProgram(this.view_program);

                uniforms.view.proj_matrix = gl.glGetUniformLocation(view_program, "proj_matrix");
                uniforms.view.mv_matrix = gl.glGetUniformLocation(view_program, "mv_matrix");
                uniforms.view.shadow_matrix = gl.glGetUniformLocation(view_program, "shadow_matrix");
                uniforms.view.full_shading = gl.glGetUniformLocation(view_program, "full_shading");
                uniforms.view.specular_albedo = gl.glGetUniformLocation(view_program, "specular_albedo");
                uniforms.view.diffuse_albedo = gl.glGetUniformLocation(view_program, "diffuse_albedo");
            }
            {

                for (var i = 0; i < OBJECT_COUNT; i++) {
                    objects[i].obj = new sb7object();
                    objects[i].obj.load(object_names[i]);
                }

                gl.glEnable(GL.GL_DEPTH_TEST);

                GLuint id;
                gl.glGenVertexArrays(1, &id); quad_vao = id;
                gl.glBindVertexArray(quad_vao);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float total_time = 0;// time
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            total_time += 0.01f;

            var proj_matrix = this.proj_matrix;

            float f = (float)total_time + 30.0f;

            vec3 light_position = new vec3(20.0f, 20.0f, 20.0f);
            vec3 view_position = new vec3(0.0f, 0.0f, 40.0f);

            light_proj_matrix = glm.frustum(-1.0f, 1.0f, -1.0f, 1.0f, 1.0f, 200.0f);
            light_view_matrix = glm.lookAt(light_position, new vec3(0.0f), new vec3(0.0f, 1.0f, 0.0f));

            camera_proj_matrix = this.proj_matrix;

            camera_view_matrix[0] = glm.lookAt(view_position - new vec3(separation, 0.0f, 0.0f),
                new vec3(0.0f, 0.0f, -50.0f), new vec3(0.0f, 1.0f, 0.0f));

            camera_view_matrix[1] = glm.lookAt(view_position + new vec3(separation, 0.0f, 0.0f),
                new vec3(0.0f, 0.0f, -50.0f), new vec3(0.0f, 1.0f, 0.0f));

            objects[0].model_matrix = glm.rotate(f * 14.5f, 0.0f, 1.0f, 0.0f) *
                glm.rotate(20.0f, 1.0f, 0.0f, 0.0f) *
                glm.translate(0.0f, -4.0f, 0.0f);

            objects[1].model_matrix = glm.rotate(f * 3.7f, 0.0f, 1.0f, 0.0f) *
                glm.translate((float)Math.Sin(f * 0.37f) * 12.0f, (float)Math.Cos(f * 0.37f) * 12.0f, 0.0f) *
                glm.scale(2.0f);

            objects[2].model_matrix = glm.rotate(f * 6.45f, 0.0f, 1.0f, 0.0f) *
                glm.translate((float)Math.Sin(f * 0.25f) * 10.0f, (float)Math.Cos(f * 0.25f) * 10.0f, 0.0f) *
                glm.rotate(f * 99.0f, 0.0f, 0.0f, 1.0f) *
                glm.scale(2.0f);

            objects[3].model_matrix = glm.rotate(f * 5.25f, 0.0f, 1.0f, 0.0f) *
                glm.translate((float)Math.Sin(f * 0.51f) * 14.0f, (float)Math.Cos(f * 0.51f) * 14.0f, 0.0f) *
                glm.rotate(f * 120.3f, 0.707106f, 0.0f, 0.707106f) *
                glm.scale(2.0f);

            gl.glEnable(GL.GL_DEPTH_TEST);

            render_scene(total_time, gl);
        }

        static GLfloat[] ones = { 1.0f };
        static GLfloat[] zero = { 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static mat4 scale_bias_matrix = new mat4(
            new vec4(0.5f, 0.0f, 0.0f, 0.0f),
            new vec4(0.0f, 0.5f, 0.0f, 0.0f),
            new vec4(0.0f, 0.0f, 0.5f, 0.0f),
            new vec4(0.5f, 0.5f, 0.5f, 1.0f)
        );

        static vec3[] diffuse_colors =
        {
        new vec3(1.0f, 0.6f, 0.3f),
        new vec3(0.2f, 0.8f, 0.9f),
        new vec3(0.3f, 0.9f, 0.4f),
        new vec3(0.5f, 0.2f, 1.0f)
        };
        static GLenum[] buffs = { GL.GL_BACK_LEFT, GL.GL_BACK_RIGHT };

        void render_scene(float currentTime, GL gl) {
            mat4 light_vp_matrix = light_proj_matrix * light_view_matrix;
            mat4 shadow_sbpv_matrix = scale_bias_matrix * light_proj_matrix * light_view_matrix;

            //gl.glViewport(0, 0, this.width, this.height);
            fixed (float* p = gray) {
                gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            }

            gl.glUseProgram(view_program);
            gl.glActiveTexture(GL.GL_TEXTURE0);
            {
                var value = camera_proj_matrix;
                gl.glUniformMatrix4fv(uniforms.view.proj_matrix, 1, false, (float*)&value);
            }
            gl.glDrawBuffer(GL.GL_BACK);

            for (var j = 0; j < 2; j++) {
                gl.glDrawBuffer(buffs[j]);
                fixed (float* p = gray) {
                    gl.glClearBufferfv(GL.GL_COLOR, 0, p);
                }
                fixed (float* p = ones) {
                    gl.glClearBufferfv(GL.GL_DEPTH, 0, p);
                }
                for (var i = 0; i < 4; i++) {
                    mat4 model_matrix = objects[i].model_matrix;
                    mat4 shadow_matrix = shadow_sbpv_matrix * model_matrix;
                    gl.glUniformMatrix4fv(uniforms.view.shadow_matrix, 1, false, (float*)&shadow_matrix);
                    {
                        var value = camera_view_matrix[j] * objects[i].model_matrix;
                        gl.glUniformMatrix4fv(uniforms.view.mv_matrix, 1, false, (float*)&value);
                    }
                    gl.glUniform1i(uniforms.view.full_shading, mode == _Mode.RENDER_FULL ? 1 : 0);
                    {
                        var value = diffuse_colors[i];
                        gl.glUniform3fv(uniforms.view.diffuse_albedo, 1, (float*)&value);
                    }
                    objects[i].obj.render();
                }
            }
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
            mode = _Mode.RENDER_FULL;
            break;
            case Keys.D2:
            mode = _Mode.RENDER_LIGHT;
            break;
            case Keys.D3:
            mode = _Mode.RENDER_DEPTH;
            break;
            case Keys.Z:
            separation += 0.05f;
            break;
            case Keys.X:
            separation -= 0.05f;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.D1, Keys.D2, Keys.D3, Keys.Z, Keys.X];
        public override MouseButtons[] ValidButtons => [];

    }
}