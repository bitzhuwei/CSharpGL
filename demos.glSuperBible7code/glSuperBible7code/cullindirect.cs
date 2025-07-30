
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class cullindirect : _glSuperBible7code {
        ~cullindirect() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public cullindirect(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        text_overlay overlay = new text_overlay();
        const int CANDIDATE_COUNT = 1024;

        struct _programs {
            public GLuint cull;
            public GLuint draw;
        }
        _programs programs;
        struct _buffers {
            public GLuint parameters;
            public GLuint drawCandidates;
            public GLuint drawCommands;
            public GLuint modelMatrices;
            public GLuint transforms;
        }
        _buffers buffers;
        byte* mapped_buffer;

        float fps;
        sb7object sb7Obj = new sb7object();
        GLuint texture;

        struct CandidateDraw {
            public vec3 sphereCenter;
            public float sphereRadius;
            public uint firstVertex;
            public uint vertexCount;
            public uint noUse;// 32;
            public uint noUse2;// 32;
        };

        struct DrawArraysIndirectCommand {
            public GLuint vertexCount;
            public GLuint instanceCount;
            public GLuint firstVertex;
            public GLuint baseInstance;
        };

        struct TransformBuffer {
            public mat4 view_matrix;
            public mat4 proj_matrix;
            public mat4 view_proj_matrix;
        };
        public override void init(CSharpGL.GL gl) {
            {
                var csCodeFile = "media/shaders/cullindirect.comp";
                var programObj = Utility.LoadShaders((csCodeFile, Shader.Kind.comp));
                Debug.Assert(programObj != null); this.programs.cull = programObj.programId;
                gl.glUseProgram(this.programs.cull);

            }
            {
                var vsCodeFile = "media/shaders/cullindirect.vert";
                var fsCodeFile = "media/shaders/cullindirect.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.programs.draw = programObj.programId;
                gl.glUseProgram(this.programs.draw);

            }
            {
                sb7Obj.load("media/objects/asteroids.sbm");
                var id = stackalloc GLuint[1];
                gl.glGenBuffers(1, id); buffers.parameters = id[0];
                gl.glBindBuffer(0x80EE/*GL_PARAMETER_BUFFER_ARB*/, buffers.parameters);
                gl.glBufferStorage(0x80EE/*GL_PARAMETER_BUFFER_ARB*/, 256, 0, 0);

                gl.glGenBuffers(1, id); buffers.drawCandidates = id[0];
                gl.glBindBuffer(GL.GL_SHADER_STORAGE_BUFFER, buffers.drawCandidates);

                var pDraws = new CandidateDraw[CANDIDATE_COUNT];
                var first = stackalloc GLuint[1]; var count = stackalloc GLuint[1];
                for (uint i = 0; i < CANDIDATE_COUNT; i++) {
                    var index = i % sb7Obj.get_sub_object_count();
                    sb7Obj.get_sub_object_info(index, first, count);
                    pDraws[i].sphereCenter = new vec3(0.0f);
                    pDraws[i].sphereRadius = 4.0f;
                    pDraws[i].firstVertex = first[0];
                    pDraws[i].vertexCount = count[0];
                }
                fixed (CandidateDraw* p = pDraws) {
                    gl.glBufferStorage(GL.GL_SHADER_STORAGE_BUFFER, CANDIDATE_COUNT * sizeof(CandidateDraw), (IntPtr)p, 0);
                }

                gl.glGenBuffers(1, id); buffers.drawCommands = id[0];
                gl.glBindBuffer(GL.GL_SHADER_STORAGE_BUFFER, buffers.drawCommands);
                gl.glBufferStorage(GL.GL_SHADER_STORAGE_BUFFER, CANDIDATE_COUNT * sizeof(DrawArraysIndirectCommand), 0, GL.GL_MAP_READ_BIT);

                gl.glGenBuffers(1, id); buffers.modelMatrices = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, buffers.modelMatrices);
                gl.glBufferStorage(GL.GL_UNIFORM_BUFFER, 1024 * sizeof(mat4), 0, GL.GL_MAP_WRITE_BIT);

                gl.glGenBuffers(1, id); buffers.transforms = id[0];
                gl.glBindBuffer(GL.GL_UNIFORM_BUFFER, buffers.transforms);
                gl.glBufferStorage(GL.GL_UNIFORM_BUFFER, sizeof(TransformBuffer), 0, GL.GL_MAP_WRITE_BIT);

                overlay.init(128, 50);

                texture = sb7ktx.load("media/textures/rocks.ktx");
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
        static GLfloat[] farplane = { 1.0f };
        float lastTime = 0.0f;
        int frames = 0;
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            var proj_matrix = this.proj_matrix;
            float nowTime = time;
            time += 0.01f;

            // Bind and clear atomic counter
            gl.glBindBufferBase(GL.GL_ATOMIC_COUNTER_BUFFER, 0, buffers.parameters);
            gl.glClearBufferSubData(GL.GL_ATOMIC_COUNTER_BUFFER, GL.GL_R32UI, 0,
                sizeof(GLuint), GL.GL_RED_INTEGER, GL.GL_UNSIGNED_INT, 0);

            // Bind shader storage buffers
            gl.glBindBufferBase(GL.GL_SHADER_STORAGE_BUFFER, 0, buffers.drawCandidates);
            gl.glBindBufferBase(GL.GL_SHADER_STORAGE_BUFFER, 1, buffers.drawCommands);

            // Bind model matrix UBO and fill with data
            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 0, buffers.modelMatrices);
            var pModelMatrix = (mat4*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER,
               0, 1024 * sizeof(mat4), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            for (var i = 0; i < 1024; i++) {
                float f = (float)(i) / 127.0f + nowTime * 0.025f;
                float g = (float)(i) / 127.0f;
                var axis = new vec3((float)Math.Sin(g * 35.0f), (float)Math.Cos(g * 75.0f), (float)Math.Cos(g * 39.0f));
                axis = axis.normalize();
                var rotate_ = glm.rotate(nowTime * 140.0f, axis);
                var position = new vec3(
                        (float)Math.Sin(f * 3.0f),
                        (float)Math.Cos(f * 5.0f),
                        (float)Math.Cos(f * 9.0f));
                position = 70.0f * position;
                var translate_ = glm.translate(position);
                var model_matrix = translate_ * rotate_;
                //var model_matrix = glm.translate(rotate_, position);
                //{
                //    var conn = glm.translate(rotate_, position);
                //    if (model_matrix != conn) {
                //        for (int index = 0; index < 4; index++) {
                //            var left = model_matrix[index]; var right = conn[index];
                //            if (Math.Abs(left.x - right.x) > 0.01) { Console.WriteLine("error"); }
                //            if (Math.Abs(left.y - right.y) > 0.01) { Console.WriteLine("error"); }
                //            if (Math.Abs(left.z - right.z) > 0.01) { Console.WriteLine("error"); }
                //            if (Math.Abs(left.w - right.w) > 0.01) { Console.WriteLine("error"); }
                //        }
                //    }
                //}
                pModelMatrix[i] = model_matrix;
            }
            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            // Bind view + projection matrix UBO and fill
            gl.glBindBufferBase(GL.GL_UNIFORM_BUFFER, 1, buffers.transforms);
            TransformBuffer* pTransforms = (TransformBuffer*)gl.glMapBufferRange(GL.GL_UNIFORM_BUFFER, 0, sizeof(TransformBuffer), GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);

            float t = nowTime * 0.1f;

            mat4 view_matrix = glm.lookAt(
                new vec3(150.0f * (float)Math.Cos(t), 0.0f, 150.0f * (float)Math.Sin(t)),
                new vec3(0.0f, 0.0f, 0.0f),
                new vec3(0.0f, 1.0f, 0.0f));

            pTransforms->view_matrix = view_matrix;
            pTransforms->proj_matrix = proj_matrix;
            pTransforms->view_proj_matrix = proj_matrix * view_matrix;

            gl.glUnmapBuffer(GL.GL_UNIFORM_BUFFER);

            // Bind the culling compute shader and dispatch it
            gl.glUseProgram(programs.cull);
            gl.glDispatchCompute(CANDIDATE_COUNT / 16, 1, 1);

            // Barrier
            gl.glMemoryBarrier(GL.GL_COMMAND_BARRIER_BIT);

            // Get ready to render
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glEnable(GL.GL_CULL_FACE);

            gl.glBindVertexArray(sb7Obj.get_vao());

            gl.glActiveTexture(GL.GL_TEXTURE0);
            gl.glBindTexture(GL.GL_TEXTURE_2D, texture);

            // Bind indirect command buffer and parameter buffer
            gl.glBindBuffer(0x8F3F/*GL_DRAW_INDIRECT_BUFFER*/, buffers.drawCommands);
            gl.glBindBuffer(0x80EE/*GL_PARAMETER_BUFFER_ARB*/, buffers.parameters);

            gl.glUseProgram(programs.draw);

            // Draw
            gl.glMultiDrawArraysIndirectCountARB(GL.GL_TRIANGLES, 0, 0, CANDIDATE_COUNT, 0);

            // Update overlay
            if (nowTime > (lastTime + 0.25f)) {
                fps = (float)frames / (nowTime - lastTime);
                frames = 0;
                lastTime = nowTime;
            }
            gl.glDisable(GL.GL_CULL_FACE);
            updateOverlay();

            frames++;
        }

        void updateOverlay() {
            var buffer = $"frames: {frames}";

            //char buffer[256];

            overlay.clear();
            //sprintf(buffer, "%2.2fms / frame (%4.2f FPS)", 1000.0f / fps, fps);
            overlay.drawText(buffer, 0, 0);
            overlay.draw();
        }

        mat4 proj_matrix;
        public override void reshape(CSharpGL.GL gl, int width, int height) {
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