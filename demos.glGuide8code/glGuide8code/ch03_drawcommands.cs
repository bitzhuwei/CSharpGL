
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch03_drawcommands : _glGuide8code, IDisposable {

        public ch03_drawcommands(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        // Member variables
        float aspect;
        GLuint render_prog;
        GLuint vao;
        GLuint vbo;
        GLuint ebo;

        GLint render_model_matrix_loc;
        GLint render_projection_matrix_loc;

        mat4 projection_matrix;
        public override void init(CSharpGL.GL gl) {
            var vsCodeFile = "03/ch03_primitive_restart/primitive_restart.vs.glsl";
            var fsCodeFile = "03/ch03_primitive_restart/primitive_restart.fs.glsl";
            var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
            Debug.Assert(program != null); this.render_prog = program.programId; //this.program = program;
            gl.glUseProgram(this.render_prog);//this.program.Bind();

            // "model_matrix" is actually an array of 4 matrices
            //render_model_matrix_loc = this.program.GetUniformLocation("model_matrix");
            render_model_matrix_loc = gl.glGetUniformLocation(render_prog, "model_matrix");
            //render_projection_matrix_loc = this.program.GetUniformLocation("projection_matrix");
            render_projection_matrix_loc = gl.glGetUniformLocation(render_prog, "projection_matrix");

            // Set up the element array buffer
            //this.ebo = vertex_indices.GenIndexBuffer(IndexBuffer.ElementType.UShort, GLBuffer.Usage.StaticDraw);
            {
                var buffer = stackalloc GLuint[1];
                gl.glGenBuffers(1, buffer); this.ebo = buffer[0];
                gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, ebo);
                fixed (ushort* p = vertex_indices) {
                    gl.glBufferData(GL.GL_ELEMENT_ARRAY_BUFFER,
                        sizeof(ushort) * vertex_indices.Length, (IntPtr)p, GL.GL_STATIC_DRAW);
                }
            }

            // Set up the vertex attributes
            var vao = stackalloc GLuint[1];
            gl.glGenVertexArrays(1, vao); this.vao = vao[0];
            gl.glBindVertexArray(vao[0]);

            var vbo = stackalloc GLuint[1];
            gl.glGenBuffers(1, vbo); this.vbo = vbo[0];
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, vbo[0]);
            gl.glBufferData(GL.GL_ARRAY_BUFFER,
                sizeof(float) * (vertex_positions.Length + vertex_colors.Length), IntPtr.Zero, GL.GL_STATIC_DRAW);
            fixed (float* p = vertex_positions) {
                gl.glBufferSubData(GL.GL_ARRAY_BUFFER,
                    0, sizeof(float) * vertex_positions.Length, (IntPtr)p);
            }
            fixed (float* p = vertex_colors) {
                gl.glBufferSubData(GL.GL_ARRAY_BUFFER,
                    sizeof(float) * vertex_positions.Length, sizeof(float) * vertex_colors.Length, (IntPtr)p);
            }
            gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            gl.glVertexAttribPointer(1, 4, GL.GL_FLOAT, false, 0,
                // Note: this is where made me crasy: it should be bytes, not elementCount.
                sizeof(float) * vertex_positions.Length);
            gl.glEnableVertexAttribArray(0);
            gl.glEnableVertexAttribArray(1);
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, 0);
            gl.glBindVertexArray(0);

            //gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }


        public override void display(CSharpGL.GL gl) {
            //float t = float(GetTickCount() & 0x1FFF) / float(0x1FFF);


            mat4 model_matrix;

            // Setup
            //gl.glEnable(GL.GL_CULL_FACE);
            //gl.glDisable(GL.GL_DEPTH_TEST);

            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            // Activate simple shading program
            gl.glUseProgram(render_prog);//this.program.Bind();

            // Set up the model and projection matrix
            mat4 projection_matrix = glm.frustum(-1.0f, 1.0f, -aspect, aspect, 1.0f, 500.0f);
            //mat4 projection_matrix = this.projection_matrix;
            gl.glUniformMatrix4fv(render_projection_matrix_loc, 1, false, (float*)&projection_matrix);
            //this.program.SetUniform("projection_matrix", projection_matrix);

            // Set up for a glDrawElements call
            gl.glBindVertexArray(vao);//this.vao.Bind();
            gl.glBindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, ebo);//this.ebo.Bind();

            // Draw Arrays...
            model_matrix = glm.translate(new vec3(-3.0f, 0.0f, -5.0f));
            //this.program.SetUniform("model_matrix", model_matrix);
            gl.glUniformMatrix4fv(render_model_matrix_loc, 1, false, (float*)&model_matrix);
            //this.program.PushUniforms();
            //this.vao.Draw();
            gl.glDrawArrays(GL.GL_TRIANGLES, 0, 3);

            // DrawElements
            model_matrix = glm.translate(new vec3(-1.0f, 0.0f, -5.0f));
            gl.glUniformMatrix4fv(render_model_matrix_loc, 1, false, (float*)&model_matrix);
            gl.glDrawElements(GL.GL_TRIANGLES, 3, GL.GL_UNSIGNED_SHORT, IntPtr.Zero);

            // DrawElementsBaseVertex
            model_matrix = glm.translate(new vec3(1.0f, 0.0f, -5.0f));
            gl.glUniformMatrix4fv(render_model_matrix_loc, 1, false, (float*)&model_matrix);
            gl.glDrawElementsBaseVertex(GL.GL_TRIANGLES, 3, GL.GL_UNSIGNED_SHORT, 0, 1);

            // DrawArraysInstanced
            model_matrix = glm.translate(new vec3(3.0f, 0.0f, -5.0f));
            gl.glUniformMatrix4fv(render_model_matrix_loc, 1, false, (float*)&model_matrix);
            gl.glDrawArraysInstanced(GL.GL_TRIANGLES, 0, 3, 1);

        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            aspect = (float)height / (float)width;
            var position = new vec3(-5, 4, 3);
            var camera = new Camera(position, new(0, 0, 0), new(0, 1, 0), CameraType.Perspective, width, height);
            this.projection_matrix = camera.GetProjectionMatrix() * camera.GetViewMatrix();
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

        public void Dispose() {
            var gl = GL.Current; if (gl == null) return;

            gl.glUseProgram(0);
            gl.glDeleteProgram(render_prog);//this.program.Dispose();
            var vao = this.vao;
            gl.glDeleteVertexArrays(1, &vao);//this.vao.Dispose();
            //this.vbo.Dispose();
            var vbo = this.vbo;
            gl.glDeleteBuffers(1, &vbo);
        }

        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];


        // A single triangle
        static readonly GLfloat[] vertex_positions =
        {
        -1.0f, -1.0f,  0.0f, 1.0f,
         1.0f, -1.0f,  0.0f, 1.0f,
        -1.0f,  1.0f,  0.0f, 1.0f,
        -1.0f, -1.0f,  0.0f, 1.0f,
        };

        // Color for each vertex
        static readonly GLfloat[] vertex_colors =
        {
        1.0f, 1.0f, 1.0f, 1.0f,
        1.0f, 1.0f, 0.0f, 1.0f,
        1.0f, 0.0f, 1.0f, 1.0f,
        0.0f, 1.0f, 1.0f, 1.0f
        };

        // Indices for the triangle strips
        static readonly GLushort[] vertex_indices = { 0, 1, 2 };
    }
}