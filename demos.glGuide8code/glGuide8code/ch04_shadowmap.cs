
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace demos.glGuide8code {

    public unsafe class ch04_shadowmap : _glGuide8code {
        ~ch04_shadowmap() {
            var gl = GL.Current; if (gl == null) return;

            gl.glUseProgram(0);
            gl.glDeleteProgram(render_light_prog);
            gl.glDeleteProgram(render_scene_prog);
            var id = ground_vbo;
            gl.glDeleteBuffers(1, &id);
            id = ground_vao;
            gl.glDeleteVertexArrays(1, &id);
        }

        public ch04_shadowmap(Form mainForm, int width, int height, GL gl)
            : base(mainForm, width, height, gl) { }

        const float FRUSTUM_DEPTH = 800.0f;
        const int DEPTH_TEXTURE_SIZE = 2048;
        // Member variables
        float aspect;

        // Program to render from the light's position
        GLuint render_light_prog;
        struct _render_light_uniforms {
            public GLint model_view_projection_matrix;
        }
        _render_light_uniforms render_light_uniforms;

        // FBO to render depth with
        GLuint depth_fbo;
        GLuint depth_texture;

        // Program to render the scene from the viewer's position
        GLuint render_scene_prog;
        struct _render_scene_uniforms {
            public GLint model_matrix;
            public GLint view_matrix;
            public GLint projection_matrix;
            public GLint shadow_matrix;
            public GLint light_position;
            public GLint material_ambient;
            public GLint material_diffuse;
            public GLint material_specular;
            public GLint material_specular_power;
        }
        _render_scene_uniforms render_scene_uniforms;

        // Ground plane
        GLuint ground_vbo;
        GLuint ground_vao;

        VBObject vbObject = new VBObject();

        GLint current_width;
        GLint current_height;

        const int INSTANCE_COUNT = 100;
        static float[] ground_vertices =
                        {
        -500.0f, -50.0f, -500.0f, 1.0f,
        -500.0f, -50.0f,  500.0f, 1.0f,
         500.0f, -50.0f,  500.0f, 1.0f,
         500.0f, -50.0f, -500.0f, 1.0f,
        };

        static float[] ground_normals =
        {
        0.0f, 1.0f, 0.0f,
        0.0f, 1.0f, 0.0f,
        0.0f, 1.0f, 0.0f,
        0.0f, 1.0f, 0.0f
        };

        public override void init(CSharpGL.GL gl) {
            {
                var vsCodeFile = "04/ch04_shadowmap/shadowmap_shadow.vs.glsl";
                var fsCodeFile = "04/ch04_shadowmap/shadowmap_shadow.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.render_light_prog = program.programId;
                gl.glUseProgram(this.render_light_prog);

                // Get the location of the projetion_matrix uniform
                render_light_uniforms.model_view_projection_matrix = gl.glGetUniformLocation(render_light_prog, "model_view_projection_matrix");
            }
            {
                var vsCodeFile = "04/ch04_shadowmap/shadowmap_scene.vs.glsl";
                var fsCodeFile = "04/ch04_shadowmap/shadowmap_scene.fs.glsl";
                var program = Utility.LoadShaders(vsCodeFile, fsCodeFile);
                Debug.Assert(program != null); this.render_scene_prog = program.programId;
                gl.glUseProgram(this.render_scene_prog);


                // Get the locations of all the uniforms in the program
                render_scene_uniforms.model_matrix = gl.glGetUniformLocation(render_scene_prog, "model_matrix");
                render_scene_uniforms.view_matrix = gl.glGetUniformLocation(render_scene_prog, "view_matrix");
                render_scene_uniforms.projection_matrix = gl.glGetUniformLocation(render_scene_prog, "projection_matrix");
                render_scene_uniforms.shadow_matrix = gl.glGetUniformLocation(render_scene_prog, "shadow_matrix");
                render_scene_uniforms.light_position = gl.glGetUniformLocation(render_scene_prog, "light_position");
                render_scene_uniforms.material_ambient = gl.glGetUniformLocation(render_scene_prog, "material_ambient");
                render_scene_uniforms.material_diffuse = gl.glGetUniformLocation(render_scene_prog, "material_diffuse");
                render_scene_uniforms.material_specular = gl.glGetUniformLocation(render_scene_prog, "material_specular");
                render_scene_uniforms.material_specular_power = gl.glGetUniformLocation(render_scene_prog, "material_specular_power");

                // Set the depth texture uniform to unit 0
                gl.glUseProgram(render_scene_prog);
                var loc = gl.glGetUniformLocation(render_scene_prog, "depth_texture");
                gl.glUniform1i(loc, 0);
            }
            {
                // Create a depth texture
                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); depth_texture = id[0];
                gl.glBindTexture(GL.GL_TEXTURE_2D, depth_texture);
                gl.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_DEPTH_COMPONENT32,
                    DEPTH_TEXTURE_SIZE, DEPTH_TEXTURE_SIZE, 0, GL.GL_DEPTH_COMPONENT, GL.GL_FLOAT, IntPtr.Zero);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_COMPARE_MODE, (int)GL.GL_COMPARE_REF_TO_TEXTURE);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_COMPARE_FUNC, (int)GL.GL_LEQUAL);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_S, (int)GL.GL_CLAMP_TO_EDGE);
                gl.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_WRAP_T, (int)GL.GL_CLAMP_TO_EDGE);
                gl.glBindTexture(GL.GL_TEXTURE_2D, 0);

                // Create FBO to render depth into
                gl.glGenFramebuffers(1, id); depth_fbo = id[0];
                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, depth_fbo);
                gl.glFramebufferTexture(GL.GL_FRAMEBUFFER, GL.GL_DEPTH_STENCIL_ATTACHMENT, depth_texture, 0);
                gl.glDrawBuffer(GL.GL_NONE);

                gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);

                // Upload geometry for the ground plane

                gl.glGenVertexArrays(1, id); ground_vao = id[0];
                gl.glGenBuffers(1, id); ground_vbo = id[0];
                gl.glBindVertexArray(ground_vao);
                gl.glBindBuffer(GL.GL_ARRAY_BUFFER, ground_vbo);
                gl.glBufferData(GL.GL_ARRAY_BUFFER,
                    sizeof(float) * (ground_vertices.Length + ground_normals.Length), IntPtr.Zero, GL.GL_STATIC_DRAW);
                fixed (float* p = ground_vertices) {
                    gl.glBufferSubData(GL.GL_ARRAY_BUFFER,
                        0, sizeof(float) * ground_vertices.Length, (IntPtr)p);
                }
                fixed (float* p = ground_normals) {
                    gl.glBufferSubData(GL.GL_ARRAY_BUFFER,
                        sizeof(float) * ground_vertices.Length, sizeof(float) * ground_normals.Length, (IntPtr)p);
                }

                gl.glVertexAttribPointer(0, 4, GL.GL_FLOAT, false, 0, IntPtr.Zero);
                gl.glVertexAttribPointer(1, 3, GL.GL_FLOAT, false, 0, (IntPtr)(sizeof(float) * ground_vertices.Length));
                gl.glEnableVertexAttribArray(0);
                gl.glEnableVertexAttribArray(1);

                // Load the VBObject
                vbObject.LoadFromVBM("media/armadillo_low.vbm", 0, 1, 2);
            }
        }

        static readonly vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static readonly vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static readonly vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        float q = 0.0f;
        static readonly mat4 scale_bias_matrix = new mat4(
              new vec4(0.5f, 0.0f, 0.0f, 0.0f),
              new vec4(0.0f, 0.5f, 0.0f, 0.0f),
              new vec4(0.0f, 0.0f, 0.5f, 0.0f),
              new vec4(0.5f, 0.5f, 0.5f, 1.0f));
        public override void display(CSharpGL.GL gl) {
            gl.glClear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            //float t = float(GetTickCount() & 0xFFFF) / float(0xFFFF);
            var t = q; q += 0.01f;

            var light_position = new vec3(
                (float)Math.Sin(t * 6.0f * 3.141592f) * 300.0f,
                200.0f,
                (float)Math.Cos(t * 4.0f * 3.141592f) * 100.0f + 250.0f);

            // Setup
            gl.glEnable(GL.GL_CULL_FACE);
            gl.glEnable(GL.GL_DEPTH_TEST);
            gl.glDepthFunc(GL.GL_LEQUAL);

            // Matrices for rendering the scene
            mat4 scene_model_matrix = glm.rotate(t * 720.0f, Y);
            mat4 scene_view_matrix = glm.translate(0.0f, 0.0f, -300.0f);
            mat4 scene_projection_matrix = glm.frustum(-1.0f, 1.0f, -aspect, aspect, 1.0f, FRUSTUM_DEPTH);

            // Matrices used when rendering from the light's position
            mat4 light_view_matrix = glm.lookAt(light_position, new vec3(0.0f), Y);
            mat4 light_projection_matrix = glm.frustum(-1.0f, 1.0f, -1.0f, 1.0f, 1.0f, FRUSTUM_DEPTH);

            // Now we render from the light's position into the depth buffer.
            // Select the appropriate program
            gl.glUseProgram(render_light_prog);
            {
                var mat = light_projection_matrix * light_view_matrix * scene_model_matrix;
                gl.glUniformMatrix4fv(render_light_uniforms.model_view_projection_matrix, 1, false, (float*)&mat);
            }

            // Bind the 'depth only' FBO and set the viewport to the size of the depth texture
            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, depth_fbo);
            gl.glViewport(0, 0, DEPTH_TEXTURE_SIZE, DEPTH_TEXTURE_SIZE);

            // Clear
            gl.glClearDepth(1.0f);
            gl.glClear(GL.GL_DEPTH_BUFFER_BIT);

            // Enable polygon offset to resolve depth-fighting isuses
            gl.glEnable(GL.GL_POLYGON_OFFSET_FILL);
            gl.glPolygonOffset(2.0f, 4.0f);
            // Draw from the light's point of view
            DrawScene(gl, true);
            gl.glDisable(GL.GL_POLYGON_OFFSET_FILL);

            // Restore the default framebuffer and field of view
            gl.glBindFramebuffer(GL.GL_FRAMEBUFFER, 0);
            gl.glViewport(0, 0, current_width, current_height);

            // Now render from the viewer's position
            gl.glUseProgram(render_scene_prog);
            gl.glClear(GL.GL_DEPTH_BUFFER_BIT | GL.GL_COLOR_BUFFER_BIT);

            // Setup all the matrices
            gl.glUniformMatrix4fv(render_scene_uniforms.model_matrix, 1, false, (float*)&scene_model_matrix);
            gl.glUniformMatrix4fv(render_scene_uniforms.view_matrix, 1, false, (float*)&scene_view_matrix);
            gl.glUniformMatrix4fv(render_scene_uniforms.projection_matrix, 1, false, (float*)&scene_projection_matrix);
            {
                var mat = scale_bias_matrix * light_projection_matrix * light_view_matrix;
                gl.glUniformMatrix4fv(render_scene_uniforms.shadow_matrix, 1, false, (float*)&mat);
            }
            gl.glUniform3fv(render_scene_uniforms.light_position, 1, (float*)&light_position);

            // Bind the depth texture
            gl.glBindTexture(GL.GL_TEXTURE_2D, depth_texture);
            gl.glGenerateMipmap(GL.GL_TEXTURE_2D);

            // Draw
            DrawScene(gl, false);
        }

        void DrawScene(GL gl, bool depth_only) {
            // Set material properties for the VBObject
            if (!depth_only) {
                vec3 color = new vec3(0.1f, 0.0f, 0.2f);
                gl.glUniform3fv(render_scene_uniforms.material_ambient, 1, (float*)&color);
                color = new vec3(0.3f, 0.2f, 0.8f);
                gl.glUniform3fv(render_scene_uniforms.material_diffuse, 1, (float*)&color);
                color = new vec3(1.0f, 1.0f, 1.0f);
                gl.glUniform3fv(render_scene_uniforms.material_specular, 1, (float*)&color);
                gl.glUniform1f(render_scene_uniforms.material_specular_power, 25.0f);
            }

            // Draw the vbObject
            vbObject.Render();

            // Set material properties for the ground
            if (!depth_only) {
                vec3 color = new vec3(0.1f, 0.1f, 0.1f);
                gl.glUniform3fv(render_scene_uniforms.material_ambient, 1, (float*)&color);
                color = new vec3(0.1f, 0.5f, 0.1f);
                gl.glUniform3fv(render_scene_uniforms.material_diffuse, 1, (float*)&color);
                color = new vec3(0.1f, 0.1f, 0.1f);
                gl.glUniform3fv(render_scene_uniforms.material_specular, 1, (float*)&color);
                gl.glUniform1f(render_scene_uniforms.material_specular_power, 3.0f);
            }

            // Draw the ground
            gl.glBindVertexArray(ground_vao);
            gl.glDrawArrays(GL.GL_TRIANGLE_FAN, 0, 4);
            gl.glBindVertexArray(0);
        }

        public override void reshape(CSharpGL.GL gl, int width, int height) {
            //gl.glViewport(0, 0, width, height);

            //aspect = (float)height / (float)width;
            current_width = width;
            current_height = height;

            aspect = (float)height / (float)width;
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