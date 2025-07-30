
using CSharpGL;
using demos.glSuperBible7code;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class deferredshading : _glSuperBible7code {
        ~deferredshading() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public deferredshading(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int MAX_DISPLAY_WIDTH = 2048,
            MAX_DISPLAY_HEIGHT = 2048,
            NUM_LIGHTS = 64,
            NUM_INSTANCES = (15 * 15);

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/deferredshading.render.vert";
                var fsCodeFile = "media/shaders/deferredshading.render.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_program = programObj.programId;
                gl.glUseProgram(this.render_program);

            }
            {
                var vsCodeFile = "media/shaders/deferredshading.render-nm.vert";
                var fsCodeFile = "media/shaders/deferredshading.render-nm.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_program_nm = programObj.programId;
                gl.glUseProgram(this.render_program_nm);

            }
            {
                var vsCodeFile = "media/shaders/deferredshading.light.vert";
                var fsCodeFile = "media/shaders/deferredshading.light.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.light_program = programObj.programId;
                gl.glUseProgram(this.light_program);

            }
            {
                var vsCodeFile = "media/shaders/deferredshading.light.vert";
                var fsCodeFile = "media/shaders/deferredshading.render-vis.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.vis_program = programObj.programId;
                gl.glUseProgram(this.vis_program);

                loc_vis_mode = gl.glGetUniformLocation(vis_program, "vis_mode");
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenFramebuffers(1, id); gbuffer = id[0];
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, gbuffer);

                var id3 = stackalloc GLuint[3];
                gl.glGenTextures(3, id3); for (var i = 0; i < gbuffer_tex.Length; i++) { gbuffer_tex[i] = id3[i]; }
                gl.glBindTexture(GL.GL_TEXTURE_2D, gbuffer_tex[0]);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGBA32UI, MAX_DISPLAY_WIDTH, MAX_DISPLAY_HEIGHT);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);

                gl.glBindTexture(GL.GL_TEXTURE_2D, gbuffer_tex[1]);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGBA32F, MAX_DISPLAY_WIDTH, MAX_DISPLAY_HEIGHT);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);

                gl.glBindTexture(GL.GL_TEXTURE_2D, gbuffer_tex[2]);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_DEPTH_COMPONENT32F, MAX_DISPLAY_WIDTH, MAX_DISPLAY_HEIGHT);

                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0, gbuffer_tex[0], 0);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT1, gbuffer_tex[1], 0);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, gbuffer_tex[2], 0);

                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);

                gl.glGenVertexArrays(1, id); fs_quad_vao = id[0];
                gl.glBindVertexArray(fs_quad_vao);

                sb7Obj.load("media/objects/ladybug.sbm");
                tex_nm = sb7ktx.load("media/textures/ladybug_nm.ktx");
                tex_diffuse = sb7ktx.load("media/textures/ladybug_co.ktx");

                //load_shaders();

                gl.glGenBuffers(1, id); light_ubo = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, light_ubo);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, NUM_LIGHTS * sizeof(light_t), 0, GL.GL_DYNAMIC_DRAW);

                gl.glGenBuffers(1, id); render_transform_ubo = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, render_transform_ubo);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, (2 + NUM_INSTANCES) * sizeof(mat4), 0, GL.GL_DYNAMIC_DRAW);
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
        static GLuint[] uint_zeros = { 0, 0, 0, 0 };
        static GLfloat[] float_zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] float_ones = { 1.0f, 1.0f, 1.0f, 1.0f };
        static GLenum[] draw_buffers = { GL.GL_COLOR_ATTACHMENT0, GL.GL_COLOR_ATTACHMENT1 };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.01f;

            var proj_matrix = this.proj_matrix;

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, gbuffer);
            gl.glViewport(0, 0, this.width, this.height);
            fixed (GLenum* p = draw_buffers) {
                gl.glDrawBuffers(2, p);
            }
            gl.glClearBufferuiv(GL.GL_COLOR, 0, uint_zeros);
            gl.glClearBufferuiv(GL.GL_COLOR, 1, uint_zeros);
            fixed (float* p = float_ones) {
                gl.glClearBufferfv(GL.GL_DEPTH, 0, p);
            }

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, render_transform_ubo);
            var matrices = (mat4*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, (2 + NUM_INSTANCES) * sizeof(mat4), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

            matrices[0] = proj_matrix;
            float d = ((float)Math.Sin(time * 0.131f) + 2.0f) * 0.15f;
            vec3 eye_pos = new vec3(d * 120.0f * (float)Math.Sin(time * 0.11f),
                5.5f,
                d * 120.0f * (float)Math.Cos(time * 0.01f));
            matrices[1] = glm.lookAt(eye_pos, new vec3(0.0f, -20.0f, 0.0f), new vec3(0.0f, 1.0f, 0.0f));

            for (var j = 0; j < 15; j++) {
                float j_f = (float)j;
                for (var i = 0; i < 15; i++) {
                    float i_f = (float)i;

                    matrices[j * 15 + i + 2] = glm.translate((i - 7.5f) * 7.0f, 0.0f, (j - 7.5f) * 11.0f);
                }
            }

            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            gl.glUseProgram(use_nm ? render_program_nm : render_program);

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_diffuse);
            gl.glActiveTexture(GL.GL_TEXTURE1);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_nm);

            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            sb7Obj.render(NUM_INSTANCES);

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);
            gl.glViewport(0, 0, this.width, this.height);
            gl.glDrawBuffer(GL.GL_BACK);

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, gbuffer_tex[0]);

            gl.glActiveTexture(GL.GL_TEXTURE1);
            gl.glBindTexture(GL.GL_TEXTURE_2D, gbuffer_tex[1]);

            if (vis_mode == _vis_mode.VIS_OFF) {
                gl.glUseProgram(light_program);
            }
            else {
                gl.glUseProgram(vis_program);
                gl.glUniform1i(loc_vis_mode, (int)vis_mode);
            }

            gl.glDisable(GL.GL_DEPTH_TEST);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, light_ubo);
            var lights = (light_t*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, NUM_LIGHTS * sizeof(light_t), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            for (var i = 0; i < NUM_LIGHTS; i++) {
                float i_f = ((float)i - 7.5f) * 0.1f + 0.3f;
                // t = 0.0f;
                lights[i].position = new vec3(100.0f * (float)Math.Sin(time * 1.1f + (5.0f * i_f)) * (float)Math.Cos(time * 2.3f + (9.0f * i_f)),
                    15.0f,
                    100.0f * (float)Math.Sin(time * 1.5f + (6.0f * i_f)) * (float)Math.Cos(time * 1.9f + (11.0f * i_f))); // 300.0f * (float)Math.Sin(t * i_f * 0.7f) * (float)Math.Cos(t * i_f * 0.9f) - 600.0f);
                lights[i].color = new vec3(
                    (float)Math.Cos(i_f * 14.0f) * 0.5f + 0.8f,
                    (float)Math.Sin(i_f * 17.0f) * 0.5f + 0.8f,
                    (float)Math.Sin(i_f * 13.0f) * (float)Math.Cos(i_f * 19.0f) * 0.5f + 0.8f);
                // lights[i].color = vec3(1.0);
                // vec3(0.5f, 0.4f, 0.75f);
            }

            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            gl.glBindVertexArray(fs_quad_vao);
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            gl.glBindTexture(GL.GL_TEXTURE_2D, 0);
            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, 0);
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
            case Keys.N:
            use_nm = !use_nm;
            break;
            case Keys.D1:
            vis_mode = _vis_mode.VIS_OFF;
            break;
            case Keys.D2:
            vis_mode = _vis_mode.VIS_NORMALS;
            break;
            case Keys.D3:
            vis_mode = _vis_mode.VIS_WS_COORDS;
            break;
            case Keys.D4:
            vis_mode = _vis_mode.VIS_DIFFUSE;
            break;
            case Keys.D5:
            vis_mode = _vis_mode.VIS_META;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.N, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5];
        public override MouseButtons[] ValidButtons => [];

        GLuint gbuffer;
        GLuint[] gbuffer_tex = new uint[3];
        GLuint fs_quad_vao;

        sb7object sb7Obj = new sb7object();

        GLuint render_program;
        GLuint render_program_nm;
        GLuint render_transform_ubo;

        GLuint light_program;
        GLuint light_ubo;

        GLuint vis_program;
        GLint loc_vis_mode;

        GLuint tex_diffuse;
        GLuint tex_nm;

        bool use_nm;
        bool paused;

        enum _vis_mode {
            VIS_OFF,
            VIS_NORMALS,
            VIS_WS_COORDS,
            VIS_DIFFUSE,
            VIS_META
        }
        _vis_mode vis_mode;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct light_t {
            public vec3 position;
            public uint noUse;// : 32;       // pad0
            public vec3 color;
            public uint noUse2;// : 32;       // pad1
        };
    }
}