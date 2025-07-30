
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static demos.glSuperBible7code.csflocking;

namespace demos.glSuperBible7code {

    public unsafe class indirectmaterial : _glSuperBible7code {
        ~indirectmaterial() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public indirectmaterial(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint render_program;

        sb7object sb7Obj = new sb7object();
        text_overlay overlay = new text_overlay();

        GLuint frame_uniforms_buffer;
        GLuint transform_buffer;
        GLuint indirect_draw_buffer;
        GLuint material_buffer;

        struct _uniforms {
            GLint time;
            GLint view_matrix;
            GLint proj_matrix;
            GLint viewproj_matrix;
        }
        _uniforms uniforms;

        const int NUM_MATERIALS = 100, NUM_DRAWS = 16384;

        uint frame_count;
        uint draws_per_frame = NUM_DRAWS;

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/indirectmaterial.vert";
                var fsCodeFile = "media/shaders/indirectmaterial.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.render_program = programObj.programId;
                gl.glUseProgram(this.render_program);

            }
            {
                sb7Obj.load("media/objects/asteroids.sbm");

                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); indirect_draw_buffer = id[0];
                gl.glBindBuffer(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/, indirect_draw_buffer);
                gl.glBufferStorage(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/,
                    NUM_DRAWS * sizeof(DrawArraysIndirectCommand), 0, GL.GL_MAP_WRITE_BIT);

                var cmd = (DrawArraysIndirectCommand*)gl.glMapBufferRange(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/,
                        0, NUM_DRAWS * sizeof(DrawArraysIndirectCommand),
                        GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
                var num_objects = sb7Obj.get_sub_object_count();
                for (uint i = 0; i < NUM_DRAWS; i++) {
                    sb7Obj.get_sub_object_info(i % num_objects, &cmd[i].first, &cmd[i].count);
                    cmd[i].primCount = 1;
                    cmd[i].baseInstance = i % NUM_MATERIALS;
                }
                gl.glUnmapBuffer(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/);

                gl.glGenBuffers(1, id); transform_buffer = id[0];
                // glBindBuffer(GL.GL_UNIFORM_BUFFER, transform_buffer);
                // glBufferStorage(GL.GL_UNIFORM_BUFFER, NUM_DRAWS * sizeof(mat4), 0, GL.GL_MAP_WRITE_BIT);
                gl.glBindBuffer(GL.GL_SHADER_STORAGE_BUFFER, transform_buffer);
                gl.glBufferStorage(GL.GL_SHADER_STORAGE_BUFFER, NUM_DRAWS * sizeof(mat4), 0, GL.GL_MAP_WRITE_BIT);

                gl.glGenBuffers(1, id); frame_uniforms_buffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, frame_uniforms_buffer);
                gl.glBufferStorage(GL.GL_UNIFORM_BUFFER, sizeof(FrameUniforms), 0, GL.GL_MAP_WRITE_BIT);

                gl.glGenBuffers(1, id); material_buffer = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, material_buffer);
                gl.glBufferStorage(GL.GL_UNIFORM_BUFFER, NUM_MATERIALS * sizeof(MaterialProperties), 0, GL.GL_MAP_WRITE_BIT);

                MaterialProperties* pMaterial = (MaterialProperties*)
                    gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
                        0,
                        NUM_MATERIALS * sizeof(MaterialProperties),
                        GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

                for (var i = 0; i < NUM_MATERIALS; i++) {
                    float f = (float)i / (float)(NUM_MATERIALS);
                    pMaterial[i].ambient = (new vec4((float)Math.Sin(f * 3.7f), (float)Math.Sin(f * 5.7f + 3.0f), (float)Math.Sin(f * 4.3f + 2.0f), 1.0f) + new vec4(1.0f, 1.0f, 2.0f, 0.0f)) * 0.1f;
                    pMaterial[i].diffuse = (new vec4((float)Math.Sin(f * 9.9f + 6.0f), (float)Math.Sin(f * 3.1f + 2.5f), (float)Math.Sin(f * 7.2f + 9.0f), 1.0f) + new vec4(1.0f, 2.0f, 2.0f, 0.0f)) * 0.4f;
                    pMaterial[i].specular = (new vec3((float)Math.Sin(f * 1.6f + 4.0f), (float)Math.Sin(f * 0.8f + 2.7f), (float)Math.Sin(f * 5.2f + 8.0f)) + new vec3(19.0f, 19.0f, 19.0f)) * 0.6f;
                    pMaterial[i].specular_power = 200.0f + (float)Math.Sin(f) * 50.0f;
                }

                gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

                gl.glBindVertexArray(sb7Obj.get_vao());

                gl.glEnable(GL.GL_DEPTH_TEST);
                gl.glDepthFunc(GL.GL_LEQUAL);

                gl.glEnable(GL.GL_CULL_FACE);

                overlay.init(80, 50);
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

            mat4 view_matrix = glm.lookAt(
                new vec3(30.0f * (float)Math.Cos(currentTime * 0.023f), 30.0f * (float)Math.Cos(currentTime * 0.023f), 30.0f * (float)Math.Sin(currentTime * 0.037f) - 200.0f),
                new vec3(0.0f, 0.0f, 0.0f),
                (new vec3(0.1f - (float)Math.Cos(currentTime * 0.1f) * 0.3f, 1.0f, 0.0f)).normalize());

            //gl.glViewport(0, 0, this.width, this.height);
            //gl.glClearBufferfv(GL.GL_COLOR, 0, sb7::color::Black);
            //gl.glClearBufferfv(GL.GL_DEPTH, 0, sb7::color::White);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, frame_uniforms_buffer);
            FrameUniforms* pUniforms = (FrameUniforms*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER, 0, sizeof(FrameUniforms), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            pUniforms->proj_matrix = proj_matrix;
            pUniforms->view_matrix = view_matrix;
            pUniforms->viewproj_matrix = view_matrix * proj_matrix;
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            mat4* pModelMatrices = (mat4*)gl.glMapBufferRange(GL.GL_SHADER_STORAGE_BUFFER, 0, NUM_DRAWS * sizeof(mat4), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

            gl.glBindBufferBase(GL.GL_SHADER_STORAGE_BUFFER, 0, transform_buffer);

            float f = currentTime * 0.1f;
            for (var i = 0; i < draws_per_frame; i++) {
                mat4 m = glm.translate((float)Math.Sin(f * 7.3f) * 70.0f, (float)Math.Sin(f * 3.7f + 2.0f) * 70.0f, (float)Math.Sin(f * 2.9f + 8.0f) * 70.0f) *
                    glm.rotate(f * 330.0f, f * 490.0f, f * 250.0f);
                pModelMatrices[i] = m;
                f += 3.1f;
            }

            gl.glUnmapBuffer(GL.GL_SHADER_STORAGE_BUFFER);

            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 2, material_buffer);

            gl.glUseProgram(render_program);
            gl.glBindVertexArray(sb7Obj.get_vao());
            gl.glMultiDrawArraysIndirect(GL.GL_TRIANGLES, 0, (int)draws_per_frame, 0);

            frame_count++;

            gl.glDisable(GL.GL_DEPTH_TEST);
            gl.glDisable(GL.GL_CULL_FACE);
            updateOverlay(currentTime);
            gl.glEnable(GL.GL_CULL_FACE);
            gl.glEnable(GL.GL_DEPTH_TEST);
        }
        static uint frames = 1;
        static float deltaTime = 0.1f;
        static float lastTime = 0.0f;
        static uint last_frames;
        void updateOverlay(float currentTime) {
            overlay.clear();
            var buffer = $"Time = {currentTime}";
            overlay.drawText($"Time = {currentTime}", 0, 0);
            overlay.drawText($"Frames rendered = {frame_count}", 0, 1);

            if (currentTime >= (lastTime + 1.0f)) {
                frames = frame_count - last_frames;
                deltaTime = currentTime - lastTime;
                last_frames = frame_count;
                lastTime = currentTime;
            }

            overlay.drawText($"Frame time = {1000.0f * deltaTime / (float)frames} {(float)frames / deltaTime}", 0, 2);
            overlay.drawText($"{draws_per_frame} draws / frame ({(float)(draws_per_frame * frames) / deltaTime} draws / second)", 0, 3);

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
            case Keys.A:
            draws_per_frame += 512;
            if (draws_per_frame > NUM_DRAWS) {
                draws_per_frame = NUM_DRAWS;
            }
            break;
            case Keys.Z:
            draws_per_frame -= 512;
            if (draws_per_frame < 0) {
                draws_per_frame = 0;
            }
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.A, Keys.Z];
        public override MouseButtons[] ValidButtons => [];



        struct DrawArraysIndirectCommand {
            public GLuint count;
            public GLuint primCount;
            public GLuint first;
            public GLuint baseInstance;
        };

        struct MaterialProperties {
            public vec4 ambient;
            public vec4 diffuse;
            public vec3 specular;
            public float specular_power;
        };

        struct FrameUniforms {
            public mat4 view_matrix;
            public mat4 proj_matrix;
            public mat4 viewproj_matrix;
        };
    }
}