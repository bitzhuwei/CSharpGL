
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch03_pointsprites : _glGuide8code {

        public ch03_pointsprites(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }
        // Member variables
        float aspect;
        GLuint render_prog;
        GLuint vao;
        GLuint vbo;
        GLuint sprite_texture;

        GLint render_model_matrix_loc;
        GLint render_projection_matrix_loc;
        GLint texture_loc;

        const int POINT_COUNT = 4;

        public override void init(CSharpGL.GL gl) {
            byte[] data = targa_header.load_targa("03/ch03_pointsprites/sprite2.tga", out var format, out var width, out var height);

            var id = stackalloc GLuint[1];
            gl.glGenTextures(1, id); this.sprite_texture = id[0];
            gl.glBindTexture(GL.GL_TEXTURE_2D, sprite_texture);
            fixed (byte* p = data) {
                gl.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGBA, width, height, 0, format, GL.GL_UNSIGNED_BYTE, (IntPtr)p);
            }

            //delete[] data;

            gl.glGenerateMipmap(GL.GL_TEXTURE_2D);

            var vsCodeFile = "03/ch03_pointsprites/pointsprites.vs.glsl";
            var fsCodeFile = "03/ch03_pointsprites/pointsprites.fs.glsl";
            var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
            Debug.Assert(program != null); this.render_prog = program.programId; //this.program = program;
            gl.glUseProgram(this.render_prog);//this.program.Bind();

            // "model_matrix" is actually an array of 4 matrices
            render_model_matrix_loc = gl.glGetUniformLocation(render_prog, "model_matrix");
            render_projection_matrix_loc = gl.glGetUniformLocation(render_prog, "projection_matrix");
            texture_loc = gl.glGetUniformLocation(render_prog, "sprite_texture");

            // A single triangle
            //static vec4* vertex_positions;

            // Set up the vertex attributes
            gl.glGenVertexArrays(1, id); this.vao = id[0];
            gl.glBindVertexArray(this.vao);

            gl.glGenBuffers(1, id); this.vbo = id[0];
            gl.glBindBuffer(GL.GL_ARRAY_BUFFER, this.vbo);
            gl.glBufferData(GL.GL_ARRAY_BUFFER, POINT_COUNT * sizeof(vec4), IntPtr.Zero, GL.GL_STATIC_DRAW);

            var vertex_positions = (vec4*)gl.glMapBuffer(GL.GL_ARRAY_BUFFER, GL.GL_WRITE_ONLY);
            for (int n = 0; n < POINT_COUNT; n++) {
                vertex_positions[n] = new vec4(random_float() * 2.0f - 1.0f, random_float() * 2.0f - 1.0f, random_float() * 2.0f - 1.0f, 1.0f);
            }
            gl.glUnmapBuffer(GL.GL_ARRAY_BUFFER);

            gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            //gl.glVertexAttribPointer(1, 4, GL.GL_FLOAT, false, 0, (IntPtr)(sizeof(vec4) * POINT_COUNT));
            gl.glEnableVertexAttribArray(0);
            //gl.glEnableVertexAttribArray(1);

            //gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        static float q = 0.0f;
        static vec3 X = new(1.0f, 0.0f, 0.0f);
        static vec3 Y = new(0.0f, 1.0f, 0.0f);
        static vec3 Z = new(0.0f, 0.0f, 1.0f);
        mat4 projection_matrix;
        public override void display(CSharpGL.GL gl) {
            //float t = float(GetTickCount() & 0x1FFF) / float(0x1FFF);
            float t = q;// (float)(DateTime.Now.Ticks & 0x3FFF) / (float)(0x3FFF);
            q += 0.01f;

            // Setup
            gl.glEnable(GL.GL_CULL_FACE);
            gl.glDisable(GL.GL_DEPTH_TEST);

            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            // Activate simple shading program
            gl.glUseProgram(render_prog);

            // Set up the model and projection matrix
            mat4 projection_matrix = glm.frustum(-1.0f, 1.0f, -aspect, aspect, 1.0f, 8.0f);
            //mat4 projection_matrix = this.projection_matrix;
            gl.glUniformMatrix4fv(render_projection_matrix_loc, 1, false, (float*)&projection_matrix);

            gl.glEnable(GL.GL_BLEND);
            gl.glBlendFunc(GL.GL_ONE, GL.GL_ONE);
            gl.glEnable(GL.GL_PROGRAM_POINT_SIZE);
            gl.glEnable(GL.GL_POINT_SPRITE);
            gl.glPointSize(32.0f);

            // Draw Arrays...
            //model_matrix = glm.rotate(model_matrix, t * 720.0f, Z);
            //model_matrix = glm.rotate(model_matrix, t * 360.0f, Y);
            var model_matrix = glm.translate(new vec3(t, 0.0f, -2.0f));
            gl.glUniformMatrix4fv(render_model_matrix_loc, 1, false, (float*)&model_matrix);
            if (q > 2) { q = -2; }

            //samplerValue value = this.Value[i];
            gl.glActiveTexture(GL.GL_TEXTURE0);
            //OpenGL.BindTexture(GL.GL_TEXTURE_2D, this.value[i].TextureId);
            gl.glBindTexture(GL.GL_TEXTURE_2D, sprite_texture);
            // TODO: assign the first location or last? 20171117:maybe I should not create this type.
            //this.location = program.glUniform(varName, (int)value.TextureUnitIndex);
            gl.glUniform1i(texture_loc, 0);

            gl.glDrawArrays(GL.GL_POINTS, 0, POINT_COUNT);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            gl.glViewport(0, 0, width, height);

            aspect = (float)height / (float)width;
            var position = new vec3(-5, 4, 3) * 0.25f;
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


        public override Keys[] ValidKeys => [];
        public override MouseButtons[] ValidButtons => [];


        static uint seed = 0x13371337;
        static float random_float() {
            float res;
            uint tmp;

            seed *= 16807;

            tmp = seed ^ (seed >> 4) ^ (seed << 15);

            *((uint*)&res) = (tmp >> 9) | 0x3F800000;

            return (res - 1.0f);
        }

        ~ch03_pointsprites() {
            var gl = GL.Current; if (gl == null) return;

            gl.glUseProgram(0);
            gl.glDeleteProgram(render_prog);
            var id = this.vao;
            gl.glDeleteVertexArrays(1, &id);
            id = this.vbo;
            gl.glDeleteBuffers(1, &id);
        }
    }
}