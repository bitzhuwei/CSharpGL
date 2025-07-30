
using CSharpGL;
using demos.glSuperBible7code;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static CSharpGL.TransformFeedbackObject;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class hdrbloom : _glSuperBible7code {
        ~hdrbloom() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public hdrbloom(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const int MAX_SCENE_WIDTH = 2048, MAX_SCENE_HEIGHT = 2048, SPHERE_COUNT = 32;

        GLuint tex_src;
        GLuint tex_lut;

        GLuint render_fbo;
        GLuint[] filter_fbo = new uint[2];

        GLuint tex_scene;
        GLuint tex_brightpass;
        GLuint tex_depth;
        GLuint[] tex_filter = new uint[2];

        GLuint program_render;
        GLuint program_filter;
        GLuint program_resolve;
        GLuint vao;
        float exposure = 1;
        int mode;
        bool paused;
        float bloom_factor = 1;
        bool show_bloom = true;
        bool show_scene = true;
        bool show_prefilter;
        float bloom_thresh_min = 0.8f;
        float bloom_thresh_max = 1.2f;

        struct _uniforms {
            public struct _scene {
                public int bloom_thresh_min;
                public int bloom_thresh_max;
            }
            public _scene scene;
            public struct _resolve {
                public int exposure;
                public int bloom_factor;
                public int scene_factor;
            }
            public _resolve resolve;
        }
        _uniforms uniforms;

        GLuint ubo_transform;
        GLuint ubo_material;

        sb7object sb7Obj = new sb7object();


        struct material {
            public vec3 diffuse_color;
            public uint noUse;// : 32;           // pad
            public vec3 specular_color;
            public float specular_power;
            public vec3 ambient_color;
            public uint noUse2;// : 32;           // pad
        }

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/hdrbloom.scene.vert";
                var fsCodeFile = "media/shaders/hdrbloom.scene.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_render = programObj.programId;
                gl.glUseProgram(this.program_render);

                uniforms.scene.bloom_thresh_min = gl.glGetUniformLocation(program_render, "bloom_thresh_min");
                uniforms.scene.bloom_thresh_max = gl.glGetUniformLocation(program_render, "bloom_thresh_max");

            }
            {
                var vsCodeFile = "media/shaders/hdrbloom.filter.vert";
                var fsCodeFile = "media/shaders/hdrbloom.filter.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_filter = programObj.programId;
                gl.glUseProgram(this.program_filter);

            }
            {
                var vsCodeFile = "media/shaders/hdrbloom.resolve.vert";
                var fsCodeFile = "media/shaders/hdrbloom.resolve.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.program_resolve = programObj.programId;
                gl.glUseProgram(this.program_resolve);

                uniforms.resolve.exposure = gl.glGetUniformLocation(program_resolve, "exposure");
                uniforms.resolve.bloom_factor = gl.glGetUniformLocation(program_resolve, "bloom_factor");
                uniforms.resolve.scene_factor = gl.glGetUniformLocation(program_resolve, "scene_factor");
            }
            {
                var buffers = stackalloc GLenum[] { GL.GL_COLOR_ATTACHMENT0, GL.GL_COLOR_ATTACHMENT1 };
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); vao = id[0];
                gl.glBindVertexArray(vao);

                var exposureLUT = stackalloc GLfloat[20] { 11.0f, 6.0f, 3.2f, 2.8f, 2.2f, 1.90f, 1.80f, 1.80f, 1.70f, 1.70f, 1.60f, 1.60f, 1.50f, 1.50f, 1.40f, 1.40f, 1.30f, 1.20f, 1.10f, 1.00f };

                gl.glGenFramebuffers(1, id); render_fbo = id[0];
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, render_fbo);

                gl.glGenTextures(1, id); tex_scene = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, tex_scene);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGBA16F, MAX_SCENE_WIDTH, MAX_SCENE_HEIGHT);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0, tex_scene, 0);
                gl.glGenTextures(1, id); tex_brightpass = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, tex_brightpass);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGBA16F, MAX_SCENE_WIDTH, MAX_SCENE_HEIGHT);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT1, tex_brightpass, 0);
                gl.glGenTextures(1, id); tex_depth = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, tex_depth);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_DEPTH_COMPONENT32F, MAX_SCENE_WIDTH, MAX_SCENE_HEIGHT);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_ATTACHMENT, tex_depth, 0);
                gl.glDrawBuffers(2, buffers);

                var id2 = stackalloc GLuint[2];
                gl.glGenFramebuffers(2, id2); filter_fbo[0] = id2[0]; filter_fbo[1] = id2[1];
                gl.glGenTextures(2, id2); tex_filter[0] = id2[0]; tex_filter[1] = id2[1];
                for (var i = 0; i < 2; i++) {
                    gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, filter_fbo[i]);
                    gl.glBindTexture(GL.GL_TEXTURE_2D, tex_filter[i]);
                    gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGBA16F,
                        i != 0 ? MAX_SCENE_WIDTH : MAX_SCENE_HEIGHT, i != 0 ? MAX_SCENE_HEIGHT : MAX_SCENE_WIDTH);
                    gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0, tex_filter[i], 0);
                    gl.glDrawBuffers(1, buffers);
                }

                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);

                gl.glGenTextures(1, id); tex_lut = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_1D, tex_lut);
                gl.glTexStorage1D(GL.GL_TEXTURE_1D, 1, GL.GL_R32F, 20);
                gl.glTexSubImage1D(GL.GL_TEXTURE_1D, 0, 0, 20, GL.GL_RED, GL.GL_FLOAT, (IntPtr)exposureLUT);
                gl.glTexParameteri(GL.GL_TEXTURE_1D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_1D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_1D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);

                sb7Obj.load("media/objects/torus.sbm");

                gl.glGenBuffers(1, id); ubo_transform = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, ubo_transform);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, (2 + SPHERE_COUNT) * sizeof(mat4), 0, GL.GL_DYNAMIC_DRAW);


                gl.glGenBuffers(1, id); ubo_material = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, ubo_material);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, SPHERE_COUNT * sizeof(material), 0, GL.GL_STATIC_DRAW);

                var m = (material*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                    0, SPHERE_COUNT * sizeof(material), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                float ambient = 0.002f;
                for (var i = 0; i < SPHERE_COUNT; i++) {
                    float fi = 3.14159267f * (float)i / 8.0f;
                    m[i].diffuse_color = new vec3((float)Math.Sin(fi) * 0.5f + 0.5f, (float)Math.Sin(fi + 1.345f) * 0.5f + 0.5f, (float)Math.Sin(fi + 2.567f) * 0.5f + 0.5f);
                    m[i].specular_color = new vec3(2.8f, 2.8f, 2.9f);
                    m[i].specular_power = 30.0f;
                    m[i].ambient_color = new vec3(ambient * 0.025f);
                    ambient *= 1.5f;
                }
                gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);
            }
        }

        struct transforms_t {
            public mat4 mat_proj;
            public mat4 mat_view;
            public fixed float/*mat4*/ mat_model[SPHERE_COUNT * 16];

            public void SetMat(int index, mat4 mat) {
                for (int i = 0; i < 4; i++) {
                    var col = mat[i];
                    mat_model[index * 16 + i * 4 + 0] = col.x;
                    mat_model[index * 16 + i * 4 + 1] = col.y;
                    mat_model[index * 16 + i * 4 + 2] = col.z;
                    mat_model[index * 16 + i * 4 + 3] = col.w;
                }
            }
        }

        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float total_time = 0;// time
        static GLfloat[] zeros = { 0.0f, 0.0f, 0.0f, 0.0f };
        static GLfloat[] gray = { 0.1f, 0.1f, 0.1f, 0.0f };
        static GLfloat[] ones = { 1.0f };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            total_time += 0.01f;

            var proj_matrix = this.proj_matrix;

            var black = stackalloc GLfloat[] { 0.0f, 0.0f, 0.0f, 1.0f };
            GLfloat one = 1.0f;

            gl.glViewport(0, 0, this.width, this.height);

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, render_fbo);
            gl.glClearBufferfv(GL.GL_COLOR, 0, black);
            gl.glClearBufferfv(GL.GL_COLOR, 1, black);
            gl.glClearBufferfv(GL.GL_DEPTH, 0, &one);

            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LESS);

            gl.glUseProgram(program_render);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, ubo_transform);

            var transforms = (transforms_t*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER, 0, sizeof(transforms_t), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            transforms->mat_proj = this.proj_matrix; // glm.perspective(50.0f, (float)info.windowWidth / (float)info.windowHeight, 1.0f, 1000.0f);
            transforms->mat_view = glm.translate(0.0f, 0.0f, -20.0f);
            for (var i = 0; i < SPHERE_COUNT; i++) {
                float fi = 3.141592f * (float)i / 16.0f;
                // float r = (float)Math.Cos(fi * 0.25f) * 0.4f + 1.0f;
                float r = ((i & 2) != 0) ? 0.6f : 1.5f;
                var mat =
                    glm.translate(
                        (float)Math.Cos(total_time + fi) * 5.0f * r,
                        (float)Math.Sin(total_time + fi * 4.0f) * 4.0f,
                        (float)Math.Sin(total_time + fi) * 5.0f * r)
                    * glm.rotate(
                        (float)Math.Sin(total_time + fi * 2.13f) * 75.0f,
                        (float)Math.Cos(total_time + fi * 1.37f) * 92.0f,
                        0.0f);
                transforms->SetMat(i, mat);
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);
            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 1, ubo_material);

            gl.glUniform1f(uniforms.scene.bloom_thresh_min, bloom_thresh_min);
            gl.glUniform1f(uniforms.scene.bloom_thresh_max, bloom_thresh_max);

            sb7Obj.render(SPHERE_COUNT);

            gl.glDisable(GL.GL_DEPTH_TEST);

            gl.glUseProgram(program_filter);

            gl.glBindVertexArray(vao);

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, filter_fbo[0]);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_brightpass);
            gl.glViewport(0, 0, this.width, this.height);

            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, filter_fbo[1]);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_filter[0]);
            gl.glViewport(0, 0, this.width, this.height);

            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            gl.glUseProgram(program_resolve);

            gl.glUniform1f(uniforms.resolve.exposure, exposure);
            if (show_prefilter) {
                gl.glUniform1f(uniforms.resolve.bloom_factor, 0.0f);
                gl.glUniform1f(uniforms.resolve.scene_factor, 1.0f);
            }
            else {
                gl.glUniform1f(uniforms.resolve.bloom_factor, show_bloom ? bloom_factor : 0.0f);
                gl.glUniform1f(uniforms.resolve.scene_factor, show_scene ? 1.0f : 0.0f);
            }

            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);
            gl.glActiveTexture(GL.GL_TEXTURE1);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_filter[1]);
            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, show_prefilter ? tex_brightpass : tex_scene);

            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
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
            case Keys.D2:
            case Keys.D3:
            mode = key - Keys.D1;
            break;
            case Keys.B:
            show_bloom = !show_bloom;
            break;
            case Keys.V:
            show_scene = !show_scene;
            break;
            case Keys.A:
            bloom_factor += 0.1f;
            break;
            case Keys.Z:
            bloom_factor -= 0.1f;
            break;
            case Keys.S:
            bloom_thresh_min += 0.1f;
            break;
            case Keys.X:
            bloom_thresh_min -= 0.1f;
            break;
            case Keys.D:
            bloom_thresh_max += 0.1f;
            break;
            case Keys.C:
            bloom_thresh_max -= 0.1f;
            break;
            case Keys.N:
            show_prefilter = !show_prefilter;
            break;
            case Keys.M:
            mode = (mode + 1) % 3;
            break;
            case Keys.P:
            paused = !paused;
            break;
            case Keys.Q:
            exposure *= 1.1f;
            break;
            case Keys.E:
            exposure /= 1.1f;
            break;
            case Keys.Escape:// 27:
                             //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.D1, Keys.D2, Keys.D3,
            Keys.B, Keys.V, Keys.A, Keys.Z, Keys.S, Keys.X,
            Keys.D, Keys.C, Keys.N, Keys.M, Keys.P, Keys.Q, Keys.E];
        public override MouseButtons[] ValidButtons => [];

    }
}