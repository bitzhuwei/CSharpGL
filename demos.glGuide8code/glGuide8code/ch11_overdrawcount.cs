
using CSharpGL;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace demos.glGuide8code {

    public unsafe class ch11_overdrawcount : _glGuide8code {
        ~ch11_overdrawcount() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public ch11_overdrawcount(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const float FRUSTUM_DEPTH = 2000.0f;
        const int MAX_FRAMEBUFFER_WIDTH = 2048;
        const int MAX_FRAMEBUFFER_HEIGHT = 2048;

        // Member variables
        float aspect;

        // Program to construct the linked list (renders the transparent objects)
        GLuint list_build_program;

        // Head pointer image and PBO for clearing it
        GLuint head_pointer_texture;
        GLuint head_pointer_clear_buffer;
        // Atomic counter buffer
        GLuint atomic_counter_buffer;
        // Linked list buffer
        GLuint linked_list_buffer;
        GLuint linked_list_texture;

        // Program to render the scene
        GLuint render_scene_prog;
        struct _render_scene_uniforms {
            public GLint aspect;
            public GLint time;
            public GLint model_matrix;
            public GLint view_matrix;
            public GLint projection_matrix;
        }
        _render_scene_uniforms render_scene_uniforms;

        // Program to resolve 
        GLuint resolve_program;

        // Full Screen Quad
        GLuint quad_vbo;
        GLuint quad_vao;

        GLint current_width;
        GLint current_height;

        VBObject vbObject = new VBObject();


        static GLfloat[] quad_verts = {
        -0.0f, -1.0f,
         1.0f, -1.0f,
        -0.0f,  1.0f,
         1.0f,  1.0f,
        };
        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "11/ch11_overdrawcount/overdraw_count.vert";
                var fsCodeFile = "11/ch11_overdrawcount/overdraw_count.frag";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.render_scene_prog = program.programId;
                gl.glUseProgram(this.render_scene_prog);

                render_scene_uniforms.model_matrix = gl.glGetUniformLocation(render_scene_prog, "model_matrix");
                render_scene_uniforms.view_matrix = gl.glGetUniformLocation(render_scene_prog, "view_matrix");
                render_scene_uniforms.projection_matrix = gl.glGetUniformLocation(render_scene_prog, "projection_matrix");
                render_scene_uniforms.aspect = gl.glGetUniformLocation(render_scene_prog, "aspect");
                render_scene_uniforms.time = gl.glGetUniformLocation(render_scene_prog, "time");
            }
            {
                var vsCodeFile = "11/ch11_doublewrite/blit.vert";
                var fsCodeFile = "11/ch11_doublewrite/blit.frag";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.resolve_program = program.programId;
                gl.glUseProgram(this.resolve_program);
            }
            {
                var id = stackalloc GLuint[1];
                // Create head pointer texture
                gl.glActiveTexture(GL.GL_TEXTURE0);
                gl.glGenTextures(1, id); head_pointer_texture = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, head_pointer_texture);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_NEAREST);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_NEAREST);
                gl.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_R32UI, MAX_FRAMEBUFFER_WIDTH, MAX_FRAMEBUFFER_HEIGHT, 0, GL.GL_RED_INTEGER, GL.GL_UNSIGNED_INT, IntPtr.Zero);
                gl.glBindTexture(GL.GL_TEXTURE_2D, 0);

                gl.glBindImageTexture(0, head_pointer_texture, 0, true, 0, GL.GL_READ_WRITE, GL.GL_R32UI);

                // Create buffer for clearing the head pointer texture
                gl.glGenBuffers(1, id); head_pointer_clear_buffer = id[0];
                gl.glBindBuffer(GL.GL_PIXEL_UNPACK_BUFFER, head_pointer_clear_buffer);
                gl.glBufferData(GL.GL_PIXEL_UNPACK_BUFFER, MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT * sizeof(GLuint), IntPtr.Zero, GL.GL_STATIC_DRAW);
                var data = (GLuint*)gl.glMapBuffer(GL.GL_PIXEL_UNPACK_BUFFER, GL.GL_WRITE_ONLY);
                //memset(data, 0x00, MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT * sizeof(GLuint));
                Unsafe.InitBlock((void*)data, 0, MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT * sizeof(GLuint));
                gl.glUnmapBuffer(GL.GL_PIXEL_UNPACK_BUFFER);

                // Create the atomic counter buffer
                gl.glGenBuffers(1, id); atomic_counter_buffer = id[0];
                gl.glBindBuffer(GL.GL_ATOMIC_COUNTER_BUFFER, atomic_counter_buffer);
                gl.glBufferData(GL.GL_ATOMIC_COUNTER_BUFFER, sizeof(GLuint), IntPtr.Zero, GL.GL_DYNAMIC_COPY);

                // Create the linked list storage buffer
                gl.glGenBuffers(1, id); linked_list_buffer = id[0];
                gl.glBindBuffer(GL.GL_TEXTURE_BUFFER, linked_list_buffer);
                gl.glBufferData(GL.GL_TEXTURE_BUFFER, MAX_FRAMEBUFFER_WIDTH * MAX_FRAMEBUFFER_HEIGHT * 3 * sizeof(vec4), IntPtr.Zero, GL.GL_DYNAMIC_COPY);
                gl.glBindBuffer(GL.GL_TEXTURE_BUFFER, 0);

                // Bind it to a texture (for use as a TBO)
                gl.glGenTextures(1, id); linked_list_texture = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_BUFFER, linked_list_texture);
                gl.glTexBuffer(GL.GL_TEXTURE_BUFFER, GL.GL_RGBA32UI, linked_list_buffer);
                gl.glBindTexture(GL.GL_TEXTURE_BUFFER, 0);

                gl.glBindImageTexture(1, linked_list_texture, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32UI);

                gl.glGenVertexArrays(1, id); quad_vao = id[0];
                gl.glBindVertexArray(quad_vao);


                gl.glGenBuffers(1, id); quad_vbo = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, quad_vbo);
                fixed (float* p = quad_verts) {
                    gl.glBufferData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * quad_verts.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
                gl.glVertexAttribPointer(0, 2, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glEnableVertexAttribArray(0);

                gl.glClearDepth(1.0f);

                //vbObject.LoadFromVBM("media/unit_pipe.vbm", 0, 1, 2);
                vbObject.LoadFromVBM("media/armadillo_low.vbm", 0, 1, 2);
            }
        }

        bool doubleWrite = true;
        static float q = 0;
        //static uint start_time = GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        public override void display(CSharpGL.GL gl) {
            //gl.glClear(GL.GL_COLOR_BUFFER_BIT);
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            float t = q; q += 0.001f;

            if (doubleWrite) {

                gl.glDisable(GL.GL_DEPTH_TEST);
                gl.glDisable(GL.GL_CULL_FACE);

                //gl.glClear(GL.GL_COLOR_BUFFER_BIT);

                // Reset atomic counter
                gl.glBindBufferBase(GL.GL_ATOMIC_COUNTER_BUFFER, 0, atomic_counter_buffer);
                var data = (GLuint*)gl.glMapBuffer(GL.GL_ATOMIC_COUNTER_BUFFER, GL.GL_WRITE_ONLY);
                data[0] = 0;
                gl.glUnmapBuffer(GL.GL_ATOMIC_COUNTER_BUFFER);

                // Clear head-pointer image
                gl.glBindBuffer(GL.GL_PIXEL_UNPACK_BUFFER, head_pointer_clear_buffer);
                gl.glBindTexture(GL.GL_TEXTURE_2D, head_pointer_texture);
                gl.glTexSubImage2D(GL.GL_TEXTURE_2D, 0, 0, 0, current_width, current_height, GL.GL_RED_INTEGER, GL.GL_UNSIGNED_INT, IntPtr.Zero);
                gl.glBindTexture(GL.GL_TEXTURE_2D, 0);

                // Bind head-pointer image for read-write
                gl.glBindImageTexture(0, head_pointer_texture, 0, false, 0, GL.GL_READ_WRITE, GL.GL_R32UI);

                // Bind linked-list buffer for write
                gl.glBindImageTexture(1, linked_list_texture, 0, false, 0, GL.GL_WRITE_ONLY, GL.GL_RGBA32UI);

                gl.glUseProgram(render_scene_prog);

                var model_matrix = glm.rotate(t * 275.0f, 1.0f, 0.0f, 0.0f)
                    * glm.rotate(t * 435.0f, 0.0f, 1.0f, 0.0f)
                    * glm.rotate(t * 360.0f, 0.0f, 0.0f, 1.0f);
                //model_matrix = glm.translate(model_matrix, 0.0f, 0.0f, -15.0f);
                //mat4 view_matrix = mat4.identity();
                mat4 view_matrix = glm.lookAt(new vec3(5, 1, 4) * 80.0f, new vec3(0, 0, 0), new vec3(0, 1, 0));
                //mat4 projection_matrix = vmath::frustum(-1.0f, 1.0f, aspect, -aspect, 1.0f, 40.f);
                mat4 projection_matrix = glm.perspective(60.0f / 180.0f * (float)Math.PI, aspect, 0.1f, 1000);

                gl.glUniformMatrix4fv(render_scene_uniforms.model_matrix, 1, false, (float*)&model_matrix);
                gl.glUniformMatrix4fv(render_scene_uniforms.view_matrix, 1, false, (float*)&view_matrix);
                gl.glUniformMatrix4fv(render_scene_uniforms.projection_matrix, 1, false, (float*)&projection_matrix);

                gl.glEnable(GL.GL_BLEND);
                gl.glBlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);

                vbObject.Render(0, 8 * 8 * 8);

                gl.glDisable(GL.GL_BLEND);

                gl.glBindVertexArray(quad_vao);
                gl.glUseProgram(resolve_program);
                gl.glDrawArrays(GL.GL_TRIANGLE_STRIP, 0, 4);

            }
            else {
                // Draw the object
                gl.glBindVertexArray(quad_vao);
                gl.glDrawArrays(GL.GL_TRIANGLE_FAN, 0, 4);
            }
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            aspect = (float)height / (float)width;
            current_width = width;
            current_height = height;
        }

        public override void mouse(MouseButtons button, MouseState state, int x, int y) {
        }

        public override void keyboard(CSharpGL.GL gl, Keys key, int x, int y) {
            switch (key) {
            case Keys.D:
            this.doubleWrite = !this.doubleWrite;
            this.mainForm.Invalidate();
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.D];
        public override MouseButtons[] ValidButtons => [];

    }
}