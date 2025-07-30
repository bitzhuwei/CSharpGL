
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class raytracer : _glSuperBible7code {
        ~raytracer() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public raytracer(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }


        GLuint prepare_program;
        GLuint trace_program;
        GLuint blit_program;

        struct uniforms_block {
            public mat4 mv_matrix;
            public mat4 view_matrix;
            public mat4 proj_matrix;
        };

        GLuint uniforms_buffer;
        GLuint sphere_buffer;
        GLuint plane_buffer;
        GLuint light_buffer;

        struct _uniforms {
            public GLint ray_origin;
            public GLint ray_lookat;
            public GLint aspect;
        }
        _uniforms uniforms;

        GLuint vao;

        struct sphere {
            public vec3 center;
            public float radius;
            // uint    : 32; // pad
            public vec4 color;
        };

        struct plane {
            public vec3 normal;
            public float d;
        };

        struct light {
            public vec3 position;
            public uint noUse;// : 32;       // pad
        };

        const int MAX_RECURSION_DEPTH = 5,
            MAX_FB_WIDTH = 2048,
            MAX_FB_HEIGHT = 1024;


        enum DEBUG_MODE {
            DEBUG_NONE,
            DEBUG_REFLECTED,
            DEBUG_REFRACTED,
            DEBUG_REFLECTED_COLOR,
            DEBUG_REFRACTED_COLOR
        };

        GLuint tex_composite;
        GLuint[] ray_fbo = new uint[MAX_RECURSION_DEPTH];
        GLuint[] tex_position = new uint[MAX_RECURSION_DEPTH];
        GLuint[] tex_reflected = new uint[MAX_RECURSION_DEPTH];
        GLuint[] tex_reflection_intensity = new uint[MAX_RECURSION_DEPTH];
        GLuint[] tex_refracted = new uint[MAX_RECURSION_DEPTH];
        GLuint[] tex_refraction_intensity = new uint[MAX_RECURSION_DEPTH];

        int max_depth = 1;
        int debug_depth;
        DEBUG_MODE debug_mode;
        bool paused;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/raytracer.trace-prepare.vert";
                var fsCodeFile = "media/shaders/raytracer.trace-prepare.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.prepare_program = programObj.programId;
                gl.glUseProgram(this.prepare_program);

                uniforms.ray_origin = gl.glGetUniformLocation(prepare_program, "ray_origin");
                uniforms.ray_lookat = gl.glGetUniformLocation(prepare_program, "ray_lookat");
                uniforms.aspect = gl.glGetUniformLocation(prepare_program, "aspect");
            }
            {
                var vsCodeFile = "media/shaders/raytracer.vert";
                var fsCodeFile = "media/shaders/raytracer.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.trace_program = programObj.programId;
                gl.glUseProgram(this.trace_program);

            }
            {
                var vsCodeFile = "media/shaders/raytracer.blit.vert";
                var fsCodeFile = "media/shaders/raytracer.blit.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.blit_program = programObj.programId;
                gl.glUseProgram(this.blit_program);

            }
            {
                uint id;
                gl.glGenBuffers(1, &id); uniforms_buffer = id;
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, uniforms_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, sizeof(uniforms_block), 0, GL.GL_DYNAMIC_DRAW);

                gl.glGenBuffers(1, &id); sphere_buffer = id;
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, sphere_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, 128 * sizeof(sphere), 0, GL.GL_DYNAMIC_DRAW);

                gl.glGenBuffers(1, &id); plane_buffer = id;
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, plane_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, 128 * sizeof(plane), 0, GL.GL_DYNAMIC_DRAW);

                gl.glGenBuffers(1, &id); light_buffer = id;
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, light_buffer);
                gl.glBufferData(GL.GL_UNIFORM_BUFFER, 128 * sizeof(sphere), 0, GL.GL_DYNAMIC_DRAW);

                gl.glGenVertexArrays(1, &id); vao = id;
                gl.glBindVertexArray(vao);

                var ids = new GLuint[MAX_RECURSION_DEPTH];
                fixed (GLuint* p = ids) {
                    gl.glGenFramebuffers(MAX_RECURSION_DEPTH, p); for (var i = 0; i < MAX_RECURSION_DEPTH; i++) { ray_fbo[i] = ids[i]; }
                    gl.glGenTextures(1, &id); tex_composite = id;
                    gl.glGenTextures(MAX_RECURSION_DEPTH, p); for (var i = 0; i < MAX_RECURSION_DEPTH; i++) { tex_position[i] = ids[i]; }
                    gl.glGenTextures(MAX_RECURSION_DEPTH, p); for (var i = 0; i < MAX_RECURSION_DEPTH; i++) { tex_reflected[i] = ids[i]; }
                    gl.glGenTextures(MAX_RECURSION_DEPTH, p); for (var i = 0; i < MAX_RECURSION_DEPTH; i++) { tex_refracted[i] = ids[i]; }
                    gl.glGenTextures(MAX_RECURSION_DEPTH, p); for (var i = 0; i < MAX_RECURSION_DEPTH; i++) { tex_reflection_intensity[i] = ids[i]; }
                    gl.glGenTextures(MAX_RECURSION_DEPTH, p); for (var i = 0; i < MAX_RECURSION_DEPTH; i++) { tex_refraction_intensity[i] = ids[i]; }
                }
                gl.glBindTexture(GL.GL_TEXTURE_2D, tex_composite);
                gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGB16F, MAX_FB_WIDTH, MAX_FB_HEIGHT);

                for (var i = 0; i < MAX_RECURSION_DEPTH; i++) {
                    gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, ray_fbo[i]);
                    gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT0, tex_composite, 0);

                    gl.glBindTexture(GL.GL_TEXTURE_2D, tex_position[i]);
                    gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGB32F, MAX_FB_WIDTH, MAX_FB_HEIGHT);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                    gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT1, tex_position[i], 0);

                    gl.glBindTexture(GL.GL_TEXTURE_2D, tex_reflected[i]);
                    gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGB16F, MAX_FB_WIDTH, MAX_FB_HEIGHT);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                    gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT2, tex_reflected[i], 0);

                    gl.glBindTexture(GL.GL_TEXTURE_2D, tex_refracted[i]);
                    gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGB16F, MAX_FB_WIDTH, MAX_FB_HEIGHT);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                    gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT3, tex_refracted[i], 0);

                    gl.glBindTexture(GL.GL_TEXTURE_2D, tex_reflection_intensity[i]);
                    gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGB16F, MAX_FB_WIDTH, MAX_FB_HEIGHT);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                    gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT4, tex_reflection_intensity[i], 0);

                    gl.glBindTexture(GL.GL_TEXTURE_2D, tex_refraction_intensity[i]);
                    gl.glTexStorage2D(GL.GL_TEXTURE_2D, 1, GL.GL_RGB16F, MAX_FB_WIDTH, MAX_FB_HEIGHT);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                    gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                    gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_COLOR_ATTACHMENT5, tex_refraction_intensity[i], 0);
                }

                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);
                gl.glBindTexture(GL.GL_TEXTURE_2D, 0);
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
        static GLenum[] draw_buffers = {
        GL.GL_COLOR_ATTACHMENT0,
        GL.GL_COLOR_ATTACHMENT1,
        GL.GL_COLOR_ATTACHMENT2,
        GL.GL_COLOR_ATTACHMENT3,
        GL.GL_COLOR_ATTACHMENT4,
        GL.GL_COLOR_ATTACHMENT5
        };
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.01f;

            var proj_matrix = this.proj_matrix;


            vec3 view_position = new vec3((float)Math.Sin(time * 0.3234f) * 28.0f, (float)Math.Cos(time * 0.4234f) * 28.0f, (float)Math.Cos(time * 0.1234f) * 28.0f); // (float)Math.Sin(f * 0.2341f) * 20.0f - 8.0f);
            vec3 lookat_point = new vec3((float)Math.Sin(time * 0.214f) * 8.0f, (float)Math.Cos(time * 0.153f) * 8.0f, (float)Math.Sin(time * 0.734f) * 8.0f);
            mat4 view_matrix = glm.lookAt(view_position,
                lookat_point,
                new vec3(0.0f, 1.0f, 0.0f));

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, uniforms_buffer);
            uniforms_block* block = (uniforms_block*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0,
                sizeof(uniforms_block),
                GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

            mat4 model_matrix = glm.scale(7.0f);

            // f = 0.0f;

            block->mv_matrix = view_matrix * model_matrix;
            block->view_matrix = view_matrix;
            block->proj_matrix = this.proj_matrix;

            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 1, sphere_buffer);
            sphere* s = (sphere*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER, 0, 128 * sizeof(sphere), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

            int i;

            for (i = 0; i < 128; i++) {
                // float f = 0.0f;
                float fi = (float)i / 128.0f;
                s[i].center = new vec3((float)Math.Sin(fi * 123.0f + time) * 15.75f, (float)Math.Cos(fi * 456.0f + time) * 15.75f, ((float)Math.Sin(fi * 300.0f + time) * (float)Math.Cos(fi * 200.0f + time)) * 20.0f);
                s[i].radius = fi * 2.3f + 3.5f;
                float r = fi * 61.0f;
                float g = r + 0.25f;
                float b = g + 0.25f;
                r = (r - (float)Math.Floor(r)) * 0.8f + 0.2f;
                g = (g - (float)Math.Floor(g)) * 0.8f + 0.2f;
                b = (b - (float)Math.Floor(b)) * 0.8f + 0.2f;
                s[i].color = new vec4(r, g, b, 1.0f);
            }

            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 2, plane_buffer);
            var planes = (plane*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                0, 128 * sizeof(plane), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

            //for (i = 0; i < 1; i++)
            {
                planes[0].normal = new vec3(0.0f, 0.0f, -1.0f);
                planes[0].d = 30.0f;

                planes[1].normal = new vec3(0.0f, 0.0f, 1.0f);
                planes[1].d = 30.0f;

                planes[2].normal = new vec3(-1.0f, 0.0f, 0.0f);
                planes[2].d = 30.0f;

                planes[3].normal = new vec3(1.0f, 0.0f, 0.0f);
                planes[3].d = 30.0f;

                planes[4].normal = new vec3(0.0f, -1.0f, 0.0f);
                planes[4].d = 30.0f;

                planes[5].normal = new vec3(0.0f, 1.0f, 0.0f);
                planes[5].d = 30.0f;
            }

            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 3, light_buffer);
            light* l = (light*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER, 0, 128 * sizeof(light), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

            time *= 1.0f;

            for (i = 0; i < 128; i++) {
                float fi = 3.33f - (float)i; //  / 35.0f;
                l[i].position = new vec3((float)Math.Sin(fi * 2.0f - time) * 15.75f,
                    (float)Math.Cos(fi * 5.0f - time) * 5.75f,
                    ((float)Math.Sin(fi * 3.0f - time) * (float)Math.Cos(fi * 2.5f - time)) * 19.4f);
            }

            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            gl.glBindVertexArray(vao);
            gl.glViewport(0, 0, this.width, this.height);

            gl.glUseProgram(prepare_program);
            gl.glUniformMatrix4fv(uniforms.ray_lookat, 1, false, (float*)&view_matrix);
            gl.glUniform3fv(uniforms.ray_origin, 1, (float*)&view_position);
            gl.glUniform1f(uniforms.aspect, (float)this.height / (float)this.width);
            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, ray_fbo[0]);

            fixed (GLenum* p2 = draw_buffers) {
                gl.glDrawBuffers(draw_buffers.Length, p2);
            }

            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            gl.glUseProgram(trace_program);
            recurse(0, gl);

            gl.glUseProgram(blit_program);
            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);
            gl.glDrawBuffer(GL.GL_BACK);

            gl.glActiveTexture(GL.GL_TEXTURE0);
            switch (debug_mode) {
            case DEBUG_MODE.DEBUG_NONE:
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_composite);
            break;
            case DEBUG_MODE.DEBUG_REFLECTED:
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_reflected[debug_depth]);
            break;
            case DEBUG_MODE.DEBUG_REFRACTED:
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_refracted[debug_depth]);
            break;
            case DEBUG_MODE.DEBUG_REFLECTED_COLOR:
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_reflection_intensity[debug_depth]);
            break;
            case DEBUG_MODE.DEBUG_REFRACTED_COLOR:
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_refraction_intensity[debug_depth]);
            break;
            }
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            /*
            gl.glClearBufferfv(GL.GL_COLOR, 0, gray);
            gl.glClearBufferfv(GL.GL_DEPTH, 0, ones);


            gl.glBindVertexArray(vao);
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);
            */
        }

        void recurse(int depth, GL gl) {
            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, ray_fbo[depth + 1]);
            fixed (GLenum* p = draw_buffers) {
                gl.glDrawBuffers(draw_buffers.Length, p);
            }

            gl.glEnablei(GL.GL_BLEND, 0);
            gl.glBlendFunci(0, GL.GL_ONE, GL.GL_ONE);

            // static  float zeros[] = { 0.0f, 0.0f, 0.0f, 0.0f };
            // glClearBufferfv(GL.GL_COLOR, 0, zeros);

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_position[depth]);

            gl.glActiveTexture(GL.GL_TEXTURE1);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_reflected[depth]);

            gl.glActiveTexture(GL.GL_TEXTURE2);
            gl.glBindTexture(GL.GL_TEXTURE_2D, tex_reflection_intensity[depth]);

            // Render
            gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            if (depth != (max_depth - 1)) {
                recurse(depth + 1, gl);
            }
            //*/

            /*
            if (depth != 0)
            {
                gl.glBindTexture(GL.GL_TEXTURE_2D, tex_refracted[depth]);
                gl.glActiveTexture(GL.GL_TEXTURE2);
                gl.glBindTexture(GL.GL_TEXTURE_2D, tex_refraction_intensity[depth]);

                // Render
                gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

                if (depth != (max_depth - 1))
                {
                    recurse(depth + 1);
                }
            }
            //**/

            gl.glDisablei(GL.GL_BLEND, 0);
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
            case Keys.Add:
            max_depth++;
            if (max_depth > MAX_RECURSION_DEPTH)
                max_depth = MAX_RECURSION_DEPTH;
            break;
            case Keys.Subtract:
            max_depth--;
            if (max_depth < 1)
                max_depth = 1;
            break;
            case Keys.Q:
            debug_mode = DEBUG_MODE.DEBUG_NONE;
            break;
            case Keys.W:
            debug_mode = DEBUG_MODE.DEBUG_REFLECTED;
            break;
            case Keys.E:
            debug_mode = DEBUG_MODE.DEBUG_REFRACTED;
            break;
            case Keys.S:
            debug_mode = DEBUG_MODE.DEBUG_REFLECTED_COLOR;
            break;
            case Keys.D:
            debug_mode = DEBUG_MODE.DEBUG_REFRACTED_COLOR;
            break;
            case Keys.A:
            debug_depth++;
            if (debug_depth > MAX_RECURSION_DEPTH)
                debug_depth = MAX_RECURSION_DEPTH;
            break;
            case Keys.Z:
            debug_depth--;
            if (debug_depth < 0)
                debug_depth = 0;
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