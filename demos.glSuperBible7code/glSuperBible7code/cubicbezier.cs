
using CSharpGL;
using demos.glSuperBible7code;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glSuperBible7code {

    public unsafe class cubicbezier : _glSuperBible7code {
        ~cubicbezier() {
            var gl = GL.Current; if (gl == null) return;

            //gl.glUseProgram(0);
            //gl.glDeleteProgram(update_prog);
            //fixed (GLuint* p = vao) {
            //    gl.glDeleteVertexArrays(2, p);
            //}
            //var id = ground_vbo;
            //gl.glDeleteBuffers(1, &id);
        }
        public cubicbezier(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        GLuint tess_program;
        GLuint draw_cp_program;
        GLuint patch_vao;
        GLuint patch_buffer;
        GLuint cage_indices;
        vec3[] patch_data = new vec3[16];

        bool show_points;
        bool show_cage;
        bool wireframe;
        bool paused;


        struct _uniforms {
            public struct _patch {
                public int mv_matrix;
                public int proj_matrix;
                public int mvp;
            }
            public _patch patch;
            public struct _control_point {
                public int draw_color;
                public int mvp;
            }
            public _control_point control_point;
        }
        _uniforms uniforms;

        text_overlay overlay = new text_overlay();

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "media/shaders/cubicbezier.vert";
                var tcCodeFile = "media/shaders/cubicbezier.tesc";
                var teCodeFile = "media/shaders/cubicbezier.tese";
                var fsCodeFile = "media/shaders/cubicbezier.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, tcCodeFile, teCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.tess_program = programObj.programId;
                gl.glUseProgram(this.tess_program);

                uniforms.patch.mv_matrix = gl.glGetUniformLocation(tess_program, "mv_matrix");
                uniforms.patch.proj_matrix = gl.glGetUniformLocation(tess_program, "proj_matrix");
                uniforms.patch.mvp = gl.glGetUniformLocation(tess_program, "mvp");
            }
            {
                var vsCodeFile = "media/shaders/cubicbezier.draw-control-points.vert";
                var fsCodeFile = "media/shaders/cubicbezier.draw-control-points.frag";
                var programObj = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(programObj != null); this.draw_cp_program = programObj.programId;
                gl.glUseProgram(this.draw_cp_program);
                uniforms.control_point.draw_color = gl.glGetUniformLocation(draw_cp_program, "draw_color");
                uniforms.control_point.mvp = gl.glGetUniformLocation(draw_cp_program, "mvp");
            }
            {
                var id = stackalloc GLuint[1];
                gl.glGenVertexArrays(1, id); patch_vao = id[0];
                gl.glBindVertexArray(patch_vao);

                gl.glGenBuffers(1, id); patch_buffer = id[0];
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, patch_buffer);
                gl.glBufferData(GL.GL_ARRAY_BUFFER, sizeof(vec3) * patch_data.Length, 0, GL.GL_DYNAMIC_DRAW);
                gl.glVertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, 0);
                gl.glEnableVertexAttribArray(0);

                gl.glGenBuffers(1, id); cage_indices = id[0];
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, cage_indices);
                fixed (GLushort* p = indices) {
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(GLushort) * indices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }

                overlay.init(80, 50);
                overlay.clear();
                overlay.drawText("W: Toggle wireframe", 0, 0);
                overlay.drawText("C: Toggle control cage", 0, 1);
                overlay.drawText("X: Toggle control points", 0, 2);
                overlay.drawText("P: Pause", 0, 3);
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
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            time += 0.01f;

            var proj_matrix = this.proj_matrix;


            gl.glEnable(GL.GL_DEPTH_TEST);

            var p = (vec3*)gl.glMapBufferRange(GL.GL_ARRAY_BUFFER,
                0, sizeof(vec3) * patch_data.Length, GL.GL_MAP_WRITE_BIT | GL.GL_MAP_INVALIDATE_BUFFER_BIT);
            fixed (float* src = patch_initializer) {
                Utility.memcpy((byte*)p, (byte*)src, sizeof(float) * patch_initializer.Length);
            }
            for (var i = 0; i < 16; i++) {
                float fi = (float)i / 16.0f;
                p[i][2] = (float)Math.Sin(time * (0.2f + fi * 0.3f));
            }
            gl.glUnmapBuffer(GL.GL_ARRAY_BUFFER);

            gl.glBindVertexArray(patch_vao);

            gl.glUseProgram(tess_program);

            //vmath::mat4 mv_matrix = vmath::translate(0.0f, 0.0f, -4.0f) *
            //     vmath::rotate(t * 10.0f, 0.0f, 1.0f, 0.0f) *
            //     vmath::rotate(t * 17.0f, 1.0f, 0.0f, 0.0f);
            var position = glm.rotate(time * 10, new vec3(0, 1, 0)) * new vec4(5, 1, 4, 1);
            var mv_matrix = glm.lookAt(new vec3(position), new vec3(0, 0, 0), new vec3(0, 1, 0));

            gl.glUniformMatrix4fv(uniforms.patch.mv_matrix, 1, false, (float*)&mv_matrix);
            gl.glUniformMatrix4fv(uniforms.patch.proj_matrix, 1, false, (float*)&proj_matrix);
            var mvp = proj_matrix * mv_matrix;
            gl.glUniformMatrix4fv(uniforms.patch.mvp, 1, false, (float*)&mvp);

            if (wireframe) {
                gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_LINE);
            }
            else {
                gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_FILL);
            }

            gl.glPatchParameteri(GL.GL_PATCH_VERTICES, 16);
            gl.glDrawArrays(GL.GL_PATCHES, 0, 16);

            gl.glUseProgram(draw_cp_program);
            gl.glUniformMatrix4fv(uniforms.control_point.mvp, 1, false, (float*)&mvp);

            if (show_points) {
                gl.glPointSize(9.0f);
                var v = new vec4(0.2f, 0.7f, 0.9f, 1.0f);
                gl.glUniform4fv(uniforms.control_point.draw_color, 1, (float*)&v);
                gl.glDrawArrays(GL.GL_POINTS, 0, 16);
            }

            if (show_cage) {
                var v = new vec4(0.7f, 0.9f, 0.2f, 1.0f);
                gl.glUniform4fv(uniforms.control_point.draw_color, 1, (float*)&v);
                gl.glDrawElements(GL.GL_LINES, 48, GL.GL_UNSIGNED_SHORT, 0);
            }

            gl.glPolygonMode(GL.GL_FRONT_AND_BACK, GL.GL_FILL);
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
            case Keys.C:
            show_cage = !show_cage;
            break;
            case Keys.X:
            show_points = !show_points;
            break;
            case Keys.W:
            wireframe = !wireframe;
            break;
            case Keys.P:
            paused = !paused;
            break;
            case Keys.Escape:// 27:
            //exit(0);
            this.mainForm.Close();
            break;
            }
        }


        public override Keys[] ValidKeys => [Keys.C, Keys.X, Keys.W, Keys.P];
        public override MouseButtons[] ValidButtons => [];


        static GLushort[] indices =
        {
        0, 1, 1, 2, 2, 3,
        4, 5, 5, 6, 6, 7,
        8, 9, 9, 10, 10, 11,
        12, 13, 13, 14, 14, 15,

        0, 4, 4, 8, 8, 12,
        1, 5, 5, 9, 9, 13,
        2, 6, 6, 10, 10, 14,
        3, 7, 7, 11, 11, 15
        };


        static float[] patch_initializer =
        {
        -1.0f,  -1.0f,  0.0f,
        -0.33f, -1.0f,  0.0f,
         0.33f, -1.0f,  0.0f,
         1.0f,  -1.0f,  0.0f,

        -1.0f,  -0.33f, 0.0f,
        -0.33f, -0.33f, 0.0f,
         0.33f, -0.33f, 0.0f,
         1.0f,  -0.33f, 0.0f,

        -1.0f,   0.33f, 0.0f,
        -0.33f,  0.33f, 0.0f,
         0.33f,  0.33f, 0.0f,
         1.0f,   0.33f, 0.0f,

        -1.0f,   1.0f,  0.0f,
        -0.33f,  1.0f,  0.0f,
         0.33f,  1.0f,  0.0f,
         1.0f,   1.0f,  0.0f,
    };
    }
}