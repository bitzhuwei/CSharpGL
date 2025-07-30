
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class dof : _glSuperBible7code {
        ~dof() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public dof(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int FBO_SIZE = 2048;
        const int FRUSTUM_DEPTH = 1000;

        GLuint view_program;
        GLuint filter_program;
        GLuint display_program;

        struct _uniforms {
            public struct _dof {
                public GLint focal_distance;
                public GLint focal_depth;
            }
            public _dof dof;
            public struct _view {
                public GLint mv_matrix;
                public GLint proj_matrix;
                public GLint full_shading;
                public GLint diffuse_albedo;
            }
            public _view view;
        }
        _uniforms uniforms;

        GLuint depth_fbo;
        GLuint depth_tex;
        GLuint color_tex;
        GLuint temp_tex;

        const int OBJECT_COUNT = 5;
        struct _object {
            public sb7object obj;
            public mat4 model_matrix;
            public vec4 diffuse_albedo;
            public _object() {
                this.obj = new sb7object();
                this.model_matrix = mat4.identity();
                this.diffuse_albedo = new vec4(1, 1, 1, 1);
            }
        }
        _object[] objects = new _object[OBJECT_COUNT];

        mat4 camera_view_matrix;
        mat4 camera_proj_matrix;

        GLuint quad_vao;

        bool paused;

        float focal_distance = 40;
        float focal_depth = 50;
        static string[] object_names =
        {
        "media/objects/dragon.sbm",
        "media/objects/sphere.sbm",
        "media/objects/cube.sbm",
        "media/objects/cube.sbm",
        "media/objects/cube.sbm",
        };

        static vec4[] object_colors =
        {
        new vec4(1.0f, 0.7f, 0.8f, 1.0f),
        new vec4(0.7f, 0.8f, 1.0f, 1.0f),
        new vec4(0.3f, 0.9f, 0.4f, 1.0f),
        new vec4(0.6f, 0.4f, 0.9f, 1.0f),
        new vec4(0.8f, 0.2f, 0.1f, 1.0f),
        };
        text_overlay overlay = new text_overlay();
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/dof.render.vert";
                var fsCodeFile = "media/shaders/dof.render.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.view_program = programObj.programId;
                gl.glUseProgram(this.view_program);

                uniforms.view.proj_matrix = gl.glGetUniformLocation(view_program, "proj_matrix");
                uniforms.view.mv_matrix = gl.glGetUniformLocation(view_program, "mv_matrix");
                uniforms.view.full_shading = gl.glGetUniformLocation(view_program, "full_shading");
                uniforms.view.diffuse_albedo = gl.glGetUniformLocation(view_program, "diffuse_albedo");
            }
            {
                var vsCodeFile = "media/shaders/dof.display.vert";
                var fsCodeFile = "media/shaders/dof.display.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.display_program = programObj.programId;
                gl.glUseProgram(this.display_program);

                uniforms.dof.focal_distance = gl.glGetUniformLocation(display_program, "focal_distance");
                uniforms.dof.focal_depth = gl.glGetUniformLocation(display_program, "focal_depth");
            }
            {
                var csCodeFile = "media/shaders/dof.gensat.comp";
                var programObj = Utility.LoadShaders((csCodeFile, Shader.Kind.comp));
                Debug.Assert(programObj != null); this.filter_program = programObj.programId;
                gl.glUseProgram(this.filter_program);

            }
            {
                for (var i = 0; i < OBJECT_COUNT; i++) {
                    var obj = new _object();
                    obj.obj.load(object_names[i]);
                    obj.diffuse_albedo = object_colors[i];
                    objects[i] = obj;
                }
                var id = stackalloc GLuint[1];
                gl.glGenFramebuffers(1, id); depth_fbo = id[0];
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, depth_fbo);

                gl.glGenTextures(1, id); depth_tex = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, depth_tex);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 11, GL.GL_DEPTH_COMPONENT32F, FBO_SIZE, FBO_SIZE);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);

                gl.glGenTextures(1, id); color_tex = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, color_tex);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGBA32F, FBO_SIZE, FBO_SIZE);

                gl.glGenTextures(1, id); temp_tex = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, temp_tex);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGBA32F, FBO_SIZE, FBO_SIZE);

                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, depth_tex, 0);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0, color_tex, 0);

                gl.glBindTexture(GL.GL_TEXTURE_2D, 0);
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);

                gl.glEnable(GL.GL_DEPTH_TEST);

                gl.glGenVertexArrays(1, id); quad_vao = id[0];
                gl.glBindVertexArray(quad_vao);

                overlay.init(80, 50);
                overlay.clear();
                overlay.drawText("Q: Increas focal distance", 0, 0);
                overlay.drawText("A: Decrease focal distance", 0, 1);
                overlay.drawText("W: Increase focal depth", 0, 2);
                overlay.drawText("S: Decrease focal depth", 0, 3);
                //overlay.drawText("P: Pause", 0, 4);
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float time = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.01f;

            var proj_matrix = this.proj_matrix;


            float f = (float)time + 30.0f;

            vec3 view_position = new vec3(0.0f, 0.0f, 40.0f);

            camera_proj_matrix = proj_matrix;

            camera_view_matrix = glm.lookAt(view_position, new vec3(0.0f), new vec3(0.0f, 1.0f, 0.0f));

            objects[0].model_matrix = glm.translate(5.0f, 0.0f, 20.0f) *
                glm.rotate(f * 14.5f, 0.0f, 1.0f, 0.0f) *
                glm.rotate(20.0f, 1.0f, 0.0f, 0.0f) *
                glm.translate(0.0f, -4.0f, 0.0f);

            objects[1].model_matrix = glm.translate(-5.0f, 0.0f, 0.0f) *
                glm.rotate(f * 14.5f, 0.0f, 1.0f, 0.0f) *
                glm.rotate(20.0f, 1.0f, 0.0f, 0.0f) *
                glm.translate(0.0f, -4.0f, 0.0f);

            objects[2].model_matrix = glm.translate(-15.0f, 0.0f, -20.0f) *
                glm.rotate(f * 14.5f, 0.0f, 1.0f, 0.0f) *
                glm.rotate(20.0f, 1.0f, 0.0f, 0.0f) *
                glm.translate(0.0f, -4.0f, 0.0f);

            objects[3].model_matrix = glm.translate(-25.0f, 0.0f, -40.0f) *
                glm.rotate(f * 14.5f, 0.0f, 1.0f, 0.0f) *
                glm.rotate(20.0f, 1.0f, 0.0f, 0.0f) *
                glm.translate(0.0f, -4.0f, 0.0f);

            objects[4].model_matrix = glm.translate(-35.0f, 0.0f, -60.0f) *
                glm.rotate(f * 14.5f, 0.0f, 1.0f, 0.0f) *
                glm.rotate(20.0f, 1.0f, 0.0f, 0.0f) *
                glm.translate(0.0f, -4.0f, 0.0f);

            gl.glEnable(GL.GL_DEPTH_TEST);
            render_scene(time, gl);

            gl.glUseProgram(filter_program);

            gl.glBindImageTexture(0, color_tex, 0, false, 0, GL.GL_READ_ONLY, GL.GL_RGBA32F);
            gl.glBindImageTexture(1, temp_tex, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);

            gl.glDispatchCompute((uint)this.height, 1, 1);

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            gl.glBindImageTexture(0, temp_tex, 0, false, 0, GL.GL_READ_ONLY, GL.GL_RGBA32F);
            gl.glBindImageTexture(1, color_tex, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32F);

            gl.glDispatchCompute((uint)this.width, 1, 1);

            gl.glMemoryBarrier(GL.GL_SHADER_IMAGE_ACCESS_BARRIER_BIT);

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, color_tex);
            gl.glDisable(GL.GL_DEPTH_TEST);
            gl.glUseProgram(display_program);
            gl.glUniform1f(uniforms.dof.focal_distance, focal_distance);
            gl.glUniform1f(uniforms.dof.focal_depth, focal_depth);
            gl.glBindVertexArray(quad_vao);
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            overlay.draw();
        }

        static mat4 scale_bias_matrix = new mat4(
            new vec4(0.5f, 0.0f, 0.0f, 0.0f),
            new vec4(0.0f, 0.5f, 0.0f, 0.0f),
            new vec4(0.0f, 0.0f, 0.5f, 0.0f),
            new vec4(0.5f, 0.5f, 0.5f, 1.0f));
        void render_scene(double currentTime, GL gl) {

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, depth_fbo);

            var attachments = GL.GL_COLOR_ATTACHMENT0;
            gl.glDrawBuffers(1, &attachments);
            //gl.glViewport(0, 0, this.width, this.height);
            fixed (float* p = gray) {
                gl.glClearBufferfv(GL.GL_COLOR, 0, p);
            }
            fixed (float* p = ones) {
                gl.glClearBufferfv(GL.GL_DEPTH, 0, p);
            }
            gl.glUseProgram(view_program);
            var proj_matrix = camera_proj_matrix;
            gl.glUniformMatrix4fv(uniforms.view.proj_matrix, 1, false, (float*)&proj_matrix);

            //fixed (float* p = ones) {
            //    gl.glClearBufferfv(GL.GL_DEPTH, 0, p);
            //}

            for (var i = 0; i < OBJECT_COUNT; i++) {
                mat4 model_matrix = objects[i].model_matrix;
                var mv = camera_view_matrix * objects[i].model_matrix;
                gl.glUniformMatrix4fv(uniforms.view.mv_matrix, 1, false, (float*)&mv);
                var diffuse_albedo = objects[i].diffuse_albedo;
                gl.glUniform3fv(uniforms.view.diffuse_albedo, 1, (float*)&diffuse_albedo);
                objects[0].obj.render();
            }

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);
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
            case Keys.Q:
            focal_distance *= 1.1f;
            break;
            case Keys.A:
            focal_distance /= 1.1f;
            break;
            case Keys.W:
            focal_depth *= 1.1f;
            break;
            case Keys.S:
            focal_depth /= 1.1f;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.Q, Keys.A, Keys.W, Keys.S];
        public override MouseButtons[] ValidButtons => [];

    }
}