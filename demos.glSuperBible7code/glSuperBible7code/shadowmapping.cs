
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class shadowmapping : _glSuperBible7code {
        ~shadowmapping() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public shadowmapping(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int DEPTH_TEXTURE_SIZE = 4096;
        const int FRUSTUM_DEPTH = 1000;

        GLuint light_program;
        GLuint view_program;
        GLuint show_light_depth_program;

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
            }
            public _view view;
        }
        _uniforms uniforms;

        GLuint depth_fbo;
        GLuint depth_tex;
        GLuint depth_debug_tex;

        const int OBJECT_COUNT = 4;
        struct _object {
            public sb7object obj;
            public mat4 model_matrix;
        }
        _object[] objects = new _object[OBJECT_COUNT];

        mat4 light_view_matrix;
        mat4 light_proj_matrix;

        mat4 camera_view_matrix;
        mat4 camera_proj_matrix;

        GLuint quad_vao;

        enum RenderMode {
            RENDER_FULL,
            RENDER_LIGHT,
            RENDER_DEPTH
        }
        RenderMode mode = RenderMode.RENDER_FULL;

        static string[] object_names =
        {
        "media/objects/dragon.sbm",
        "media/objects/sphere.sbm",
        "media/objects/cube.sbm",
        "media/objects/torus.sbm"
        };

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/shadowmapping-light.vert";
                var fsCodeFile = "media/shaders/shadowmapping-light.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.light_program = programObj.programId;
                gl.glUseProgram(this.light_program);
                uniforms.light.mvp = gl.glGetUniformLocation(light_program, "mvp");

            }
            {
                var vsCodeFile = "media/shaders/shadowmapping-camera.vert";
                var fsCodeFile = "media/shaders/shadowmapping-camera.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.view_program = programObj.programId;
                gl.glUseProgram(this.view_program);

                uniforms.view.proj_matrix = gl.glGetUniformLocation(view_program, "proj_matrix");
                uniforms.view.mv_matrix = gl.glGetUniformLocation(view_program, "mv_matrix");
                uniforms.view.shadow_matrix = gl.glGetUniformLocation(view_program, "shadow_matrix");
                uniforms.view.full_shading = gl.glGetUniformLocation(view_program, "full_shading");
            }
            {
                var vsCodeFile = "media/shaders/shadowmapping-light-view.vert";
                var fsCodeFile = "media/shaders/shadowmapping-light-view.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.show_light_depth_program = programObj.programId;
                gl.glUseProgram(this.show_light_depth_program);

            }
            {

                for (var i = 0; i < OBJECT_COUNT; i++) {
                    objects[i].obj = new sb7object();
                    objects[i].obj.load(object_names[i]);
                }

                GLuint id;
                gl.glGenFramebuffers(1, &id); depth_fbo = id;
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, depth_fbo);

                gl.glGenTextures(1, &id); depth_tex = id;
                gl.glBindTexture(GL.GL_TEXTURE_2D, depth_tex);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 11, GL.GL_DEPTH_COMPONENT32F, DEPTH_TEXTURE_SIZE, DEPTH_TEXTURE_SIZE);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_COMPARE_MODE, (int)GL.GL_COMPARE_REF_TO_TEXTURE);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_COMPARE_FUNC, (int)GL.GL_LEQUAL);

                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, depth_tex, 0);

                gl.glGenTextures(1, &id); depth_debug_tex = id;
                gl.glBindTexture(GL.GL_TEXTURE_2D, depth_debug_tex);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_R32F, DEPTH_TEXTURE_SIZE, DEPTH_TEXTURE_SIZE);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0, depth_debug_tex, 0);

                gl.glBindTexture(GL.GL_TEXTURE_2D, 0);
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);

                gl.glEnable(GL.GL_DEPTH_TEST);

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

            camera_view_matrix = glm.lookAt(view_position,
                new vec3(0.0f),
                new vec3(0.0f, 1.0f, 0.0f));

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
            render_scene(total_time, true, gl);

            if (mode == RenderMode.RENDER_DEPTH) {
                gl.glDisable(GL.GL_DEPTH_TEST);
                gl.glBindVertexArray(quad_vao);
                gl.glUseProgram(show_light_depth_program);
                gl.glBindTexture(GL.GL_TEXTURE_2D, depth_debug_tex);
                gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
            }
            else {
                render_scene(total_time, false, gl);
            }
        }
        static mat4 scale_bias_matrix = new mat4(
            new vec4(0.5f, 0.0f, 0.0f, 0.0f),
            new vec4(0.0f, 0.5f, 0.0f, 0.0f),
            new vec4(0.0f, 0.0f, 0.5f, 0.0f),
            new vec4(0.5f, 0.5f, 0.5f, 1.0f));
        static GLfloat[] ones = { 1.0f };
        static GLfloat[] zero = { 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLenum[] buffs = { GL.GL_COLOR_ATTACHMENT0 };
        void render_scene(double currentTime, bool from_light, GL gl) {
            mat4 light_vp_matrix = light_proj_matrix * light_view_matrix;
            mat4 shadow_sbpv_matrix = scale_bias_matrix * light_proj_matrix * light_view_matrix;

            if (from_light) {
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, depth_fbo);
                gl.glViewport(0, 0, DEPTH_TEXTURE_SIZE, DEPTH_TEXTURE_SIZE);
                gl.glEnable(GL.GL_POLYGON_OFFSET_FILL);
                gl.glPolygonOffset(4.0f, 4.0f);
                gl.glUseProgram(light_program);
                fixed (GLenum* p = buffs) {
                    gl.glDrawBuffers(1, p);
                }
                fixed (GLfloat* p = zero) {
                    gl.glClearBufferfv(GL.GL_COLOR, 0, p);
                }
            }
            else {
                gl.glViewport(0, 0, this.width, this.height);
                fixed (GLfloat* p = gray) {
                    gl.glClearBufferfv(GL.GL_COLOR, 0, p);
                }
                gl.glUseProgram(view_program);
                gl.glActiveTexture(GL.GL_TEXTURE0);
                gl.glBindTexture(GL.GL_TEXTURE_2D, depth_tex);
                {
                    var value = camera_proj_matrix;
                    gl.glUniformMatrix4fv(uniforms.view.proj_matrix, 1, false, (float*)&value);
                }
                gl.glDrawBuffer(GL.GL_BACK);
            }

            fixed (GLfloat* p = ones) {
                gl.glClearBufferfv(GL.GL_DEPTH, 0, p);
            }

            for (var i = 0; i < 4; i++) {
                mat4 model_matrix = objects[i].model_matrix;
                if (from_light) {
                    var value = light_vp_matrix * objects[i].model_matrix;
                    gl.glUniformMatrix4fv(uniforms.light.mvp, 1, false, (float*)&value);
                }
                else {
                    mat4 shadow_matrix = shadow_sbpv_matrix * model_matrix;
                    gl.glUniformMatrix4fv(uniforms.view.shadow_matrix, 1, false, (float*)&shadow_matrix);
                    {
                        var value = camera_view_matrix * objects[i].model_matrix;
                        gl.glUniformMatrix4fv(uniforms.view.mv_matrix, 1, false, (float*)&value);
                    }
                    gl.glUniform1i(uniforms.view.full_shading, mode == RenderMode.RENDER_FULL ? 1 : 0);
                }
                objects[i].obj.render();
            }

            if (from_light) {
                gl.glDisable(GL.GL_POLYGON_OFFSET_FILL);
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);
            }
            else {
                gl.glBindTexture(GL.GL_TEXTURE_2D, 0);
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
            mode = RenderMode.RENDER_FULL;
            break;
            case Keys.D2:
            mode = RenderMode.RENDER_LIGHT;
            break;
            case Keys.D3:
            mode = RenderMode.RENDER_DEPTH;
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