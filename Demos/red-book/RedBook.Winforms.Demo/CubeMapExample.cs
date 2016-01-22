using CSharpGL;
using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using Picture.DDS;
using RedBook.Common;
using RedBook.Common.LightingExample;
using System;

namespace RedBook.Winforms.Demo
{
    class CubeMapExample : RendererBase
    {
        static string skybox_shader_vs =
            @"#version 330 core

layout (location = 0) in vec3 in_position;

out vec3 tex_coord;

uniform mat4 tc_rotate;

void main(void)
{
    gl_Position = tc_rotate * vec4(in_position, 1.0);
    tex_coord = in_position;
}";
        static string skybox_shader_fs =
            @"#version 330 core

in vec3 tex_coord;

layout (location = 0) out vec4 color;

uniform samplerCube tex;

void main(void)
{
    color = texture(tex, tex_coord);
}";
        static string object_shader_vs =
@"#version 330 core

layout (location = 0) in vec4 in_position;
layout (location = 1) in vec3 in_normal;

out vec3 vs_fs_normal;
out vec3 vs_fs_position;

uniform mat4 mat_mvp;
uniform mat4 mat_mv;

void main(void)
{
    gl_Position = mat_mvp * in_position;
    vs_fs_normal = mat3(mat_mv) * in_normal;
    vs_fs_position = (mat_mv * in_position).xyz;
}";

        static string object_shader_fs =
@"#version 330 core

in vec3 vs_fs_normal;
in vec3 vs_fs_position;

layout (location = 0) out vec4 color;

uniform samplerCube tex;

void main(void)
{
    vec3 tc =  reflect(vs_fs_position, normalize(vs_fs_normal));
    color = vec4(0.3, 0.2, 0.1, 1.0) + vec4(0.97, 0.83, 0.79, 0.0) * texture(tex, tc);
}";

        public virtual void Reshape(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }

        // Member variables
        float aspect;
        uint skybox_prog;
        uint object_prog;
        uint[] vao = new uint[1];

        uint[] cube_vbo = new uint[1];
        uint[] cube_element_buffer = new uint[1];

        uint tex;
        //Texture2D tex;
        int skybox_rotate_loc;

        int object_mat_mvp_loc;
        int object_mat_mv_loc;
        // Object to render
        VBObject vboObject = new VBObject();

        protected override void CleanManagedRes()
        {
            this.vboObject.Dispose();

            base.CleanManagedRes();
        }

        protected override void DoInitialize()
        {
            skybox_prog = GL.CreateProgram();
            ShaderHelper.vglAttachShaderSource(skybox_prog, ShaderType.VertexShader, skybox_shader_vs);
            ShaderHelper.vglAttachShaderSource(skybox_prog, ShaderType.FragmentShader, skybox_shader_fs);
            GL.LinkProgram(skybox_prog);

            object_prog = GL.CreateProgram();
            ShaderHelper.vglAttachShaderSource(object_prog, ShaderType.VertexShader, object_shader_vs);
            ShaderHelper.vglAttachShaderSource(object_prog, ShaderType.FragmentShader, object_shader_fs);
            GL.LinkProgram(object_prog);

            GL.GenBuffers(1, cube_vbo);
            GL.BindBuffer(BufferTarget.ArrayBuffer, cube_vbo[0]);
            var cube_vertices = new UnmanagedArray<vec3>(8);
            cube_vertices[0] = new vec3(-1.0f, -1.0f, -1.0f);
            cube_vertices[1] = new vec3(-1.0f, -1.0f, 1.0f);
            cube_vertices[2] = new vec3(-1.0f, 1.0f, -1.0f);
            cube_vertices[3] = new vec3(-1.0f, 1.0f, 1.0f);
            cube_vertices[4] = new vec3(1.0f, -1.0f, -1.0f);
            cube_vertices[5] = new vec3(1.0f, -1.0f, 1.0f);
            cube_vertices[6] = new vec3(1.0f, 1.0f, -1.0f);
            cube_vertices[7] = new vec3(1.0f, 1.0f, 1.0f);

            var cube_indices = new UnmanagedArray<ushort>(16);
            // First strip
            cube_indices[0] = 0;
            cube_indices[1] = 1;
            cube_indices[2] = 2;
            cube_indices[3] = 3;
            cube_indices[4] = 6;
            cube_indices[5] = 7;
            cube_indices[6] = 4;
            cube_indices[7] = 5;
            // Second strip
            cube_indices[8] = 2;
            cube_indices[9] = 6;
            cube_indices[10] = 0;
            cube_indices[11] = 4;
            cube_indices[12] = 1;
            cube_indices[13] = 5;
            cube_indices[14] = 3;
            cube_indices[15] = 7;

            GL.BufferData(BufferTarget.ArrayBuffer, cube_vertices, BufferUsage.StaticDraw);
            cube_vertices.Dispose();

            GL.GenVertexArrays(1, vao);
            GL.BindVertexArray(vao[0]);
            GL.VertexAttribPointer(0, 3, GL.GL_FLOAT, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(0);

            GL.GenBuffers(1, cube_element_buffer);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, cube_element_buffer[0]);
            GL.BufferData(BufferTarget.ElementArrayBuffer, cube_indices, BufferUsage.StaticDraw);
            cube_indices.Dispose();

            skybox_rotate_loc = GL.GetUniformLocation(skybox_prog, "tc_rotate");
            object_mat_mvp_loc = GL.GetUniformLocation(object_prog, "mat_mvp");
            object_mat_mv_loc = GL.GetUniformLocation(object_prog, "mat_mv");
            skyboxTexLocation = GL.GetUniformLocation(skybox_prog, "tex");
            objectTexLocation = GL.GetUniformLocation(object_prog, "tex");



            //tex = new Texture2D();
            //System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(@"media\TantolundenCube.png");
            //tex.Initialize(bmp);
            vglImageData data = new vglImageData();
            tex = vgl.vglLoadTexture(@"media\TantolundenCube.dds", 0, ref data);

            uint e = GL.GetError();

            vgl.vglUnloadImage(ref data);

            vboObject.LoadFromVBM(@"media\unit_torus.vbm", 0, 1, 2);

        }

        static uint start_time = TimerHelper.GetTickCount();
        static vec3 X = new vec3(1.0f, 0.0f, 0.0f);
        static vec3 Y = new vec3(0.0f, 1.0f, 0.0f);
        static vec3 Z = new vec3(0.0f, 0.0f, 1.0f);
        static float factor = 0x3FFF;
        private int skyboxTexLocation;
        private int objectTexLocation;

        protected override void DoRender(RenderEventArgs e)
        {
            float t = (float)((TimerHelper.GetTickCount() - start_time)) / factor;

            mat4 tc_matrix = mat4.identity();

            GL.ClearColor(0.0f, 0.25f, 0.3f, 1.0f);
            GL.ClearDepth(1.0f);
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);

            GL.Enable(GL.GL_DEPTH_TEST);
            GL.DepthFunc(GL.GL_LEQUAL);
            GL.Disable(GL.GL_CULL_FACE);

            {
                GL.UseProgram(skybox_prog);
                GL.Enable(GL.GL_TEXTURE_CUBE_MAP_SEAMLESS);

                //GL.Uniform1(skyboxTexLocation, (float)tex.Name);
                GL.Uniform1(skyboxTexLocation, tex);
                int[] viewport = new int[4];
                GL.GetInteger(GetTarget.Viewport, viewport);
                aspect = (float)viewport[2] / (float)viewport[3];
                //tc_matrix = glm.perspective((float)(35.0f * Math.PI / 180.0f), aspect, 0.1f, 100.0f) * tc_matrix;
                tc_matrix = e.Camera.GetProjectionMat4() * e.Camera.GetViewMat4();

                GL.UniformMatrix4(skybox_rotate_loc, 1, false, tc_matrix.to_array());
                GL.BindVertexArray(vao[0]);
                GL.BindBuffer(GL.GL_ELEMENT_ARRAY_BUFFER, cube_element_buffer[0]);

                GL.DrawElements(GL.GL_TRIANGLE_STRIP, 8, GL.GL_UNSIGNED_SHORT, IntPtr.Zero);
                GL.DrawElements(GL.GL_TRIANGLE_STRIP, 8, GL.GL_UNSIGNED_SHORT, new IntPtr(8 * sizeof(ushort)));
            }
            {
                GL.UseProgram(object_prog);

                GL.Uniform1(objectTexLocation, tex);

                //tc_matrix = glm.translate(mat4.identity(), new vec3(0, 0, -4))
                //    * glm.rotate(3 * t, Y)
                //    * glm.rotate(3 * t, Z);
                const float scale = 0.01f;
                tc_matrix = e.Camera.GetViewMat4() * glm.scale(mat4.identity(), new vec3(scale, scale, scale));

                GL.UniformMatrix4(object_mat_mv_loc, 1, false, tc_matrix.to_array());

                //tc_matrix = glm.perspective(35.0f, 1.0f / aspect, 0.1f, 100.0f) * tc_matrix;
                tc_matrix = e.Camera.GetProjectionMat4() * tc_matrix;
                GL.UniformMatrix4(object_mat_mvp_loc, 1, false, tc_matrix.to_array());

                GL.Clear(GL.GL_DEPTH_BUFFER_BIT);

                vboObject.Render();
            }
        }

    }
}
