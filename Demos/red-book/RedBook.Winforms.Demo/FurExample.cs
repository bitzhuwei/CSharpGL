using CSharpGL;
using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using RedBook.Common;
using RedBook.Common.FurExample;
using System;

namespace RedBook.Winforms.Demo
{
    class FurExample : SceneElementBase
    {
        // Member variables
        uint fur_prog;
        uint[] fur_texture = new uint[1];
        //Texture2D furTexture;

        int fur_model_matrix_pos;
        int fur_projection_matrix_pos;
        int base_model_matrix_pos;
        int base_projection_matrix_pos;

        #region shader sources

        const string basicVertexShader =
        @"#version 410

layout (location = 0) in vec4 position_in;
layout (location = 1) in vec3 normal_in;
layout (location = 2) in vec2 texcoord_in;

uniform mat4 model_matrix;
uniform mat4 projection_matrix;

out VS_FS_VERTEX
{
    vec3 normal;
} vertex_out;

void main(void)
{
    vertex_out.normal = normal_in;
    gl_Position = projection_matrix * (model_matrix * position_in);
}";

        const string basicFragmentShader =
@"#version 410

layout (location = 0) out vec4 color;

in VS_FS_VERTEX
{
    vec3 normal;
} vertex_in;

void main(void)
{
    vec3 normal = vertex_in.normal;
    color = vec4(0.2, 0.1, 0.5, 1.0) * (0.2 + pow(abs(normal.z), 4.0)) + vec4(0.8, 0.8, 0.8, 0.0) * pow(abs(normal.z), 137.0);
}";

        const string furVertexShader =
@"#version 410

layout (location = 0) in vec4 position_in;
layout (location = 1) in vec3 normal_in;
layout (location = 2) in vec2 texcoord_in;

out VS_GS_VERTEX
{
    vec3 normal;
    vec2 tex_coord;
} vertex_out;

void main(void)
{
    vertex_out.normal = normal_in;
    vertex_out.tex_coord = texcoord_in;
    gl_Position = position_in;
}";

        const string furGeometryShader =
@"#version 410

layout (triangles) in;
layout (triangle_strip, max_vertices = 240) out;

uniform mat4 model_matrix;
uniform mat4 projection_matrix;

uniform int fur_layers = 30;
uniform float fur_depth = 5.0;

in VS_GS_VERTEX
{
    vec3 normal;
    vec2 tex_coord;
} vertex_in[];

out GS_FS_VERTEX
{
    vec3 normal;
    vec2 tex_coord;
    flat float fur_strength;
} vertex_out;

void main(void)
{
    int i, layer;
    float disp_delta = 1.0 / float(fur_layers);
    float d = 0.0;
    vec4 position;

    for (layer = 0; layer < fur_layers; layer++)
    {
        for (i = 0; i < gl_in.length(); i++) {
            vec3 n = vertex_in[i].normal;
            vertex_out.normal = n;
            vertex_out.tex_coord = vertex_in[i].tex_coord;
            vertex_out.fur_strength = 1.0 - d;
            position = gl_in[i].gl_Position + vec4(n * d * fur_depth, 0.0);
            gl_Position = projection_matrix * (model_matrix * position);
            EmitVertex();
        }
        d += disp_delta;
        EndPrimitive();
    }
}";

        const string furFragmentShader =
            @"#version 410

layout (location = 0) out vec4 color;

uniform sampler2D fur_texture;
uniform vec4 fur_color = vec4(0.8, 0.8, 0.9, 1.0);

in GS_FS_VERTEX
{
    vec3 normal;
    vec2 tex_coord;
    flat float fur_strength;
} fragment_in;

void main(void)
{
    vec4 rgba = texture(fur_texture, fragment_in.tex_coord);
    float t = rgba.a;
    t *= fragment_in.fur_strength;
    color = fur_color * vec4(1.0, 1.0, 1.0, t);
}";

        #endregion shader sources

        public virtual void Reshape(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }

        ShaderProgram basicShaderProgram;

        // Uniform locations
        //int mv_mat_loc;
        //int prj_mat_loc;
        //int col_amb_loc;
        //int col_diff_loc;
        //int col_spec_loc;

        // Object to render
        VBObject vboObject = new VBObject();


        protected override void CleanManagedRes()
        {
            basicShaderProgram.Unbind();
            basicShaderProgram.Delete();
            this.vboObject.Dispose();

            base.CleanManagedRes();
        }

        protected override void DoInitialize()
        {
            // Now create a simple program to visualize the result
            basicShaderProgram = new ShaderProgram();
            basicShaderProgram.Create(basicVertexShader, basicFragmentShader, null);

            base_model_matrix_pos = GL.GetUniformLocation(basicShaderProgram.ShaderProgramObject, "model_matrix");
            base_projection_matrix_pos = GL.GetUniformLocation(basicShaderProgram.ShaderProgramObject, "projection_matrix");

            fur_prog = GL.CreateProgram();
            ShaderHelper.vglAttachShaderSource(fur_prog, ShaderType.VertexShader, furVertexShader);
            ShaderHelper.vglAttachShaderSource(fur_prog, ShaderType.GeometryShader, furGeometryShader);
            ShaderHelper.vglAttachShaderSource(fur_prog, ShaderType.FragmentShader, furFragmentShader);
            GL.LinkProgram(fur_prog);
            GL.UseProgram(fur_prog);
            fur_model_matrix_pos = GL.GetUniformLocation(fur_prog, "model_matrix");
            fur_projection_matrix_pos = GL.GetUniformLocation(fur_prog, "projection_matrix");

            GL.GenTextures(1, fur_texture);
            UnmanagedArray<byte> tex = new UnmanagedArray<byte>(1024 * 1024 * 4);
            Random random = new Random();
            for (int n = 0; n < 256; n++)
            {
                for (int m = 0; m < 1270; m++)
                {
                    int x = random.Next() & 0x3FF;
                    int y = random.Next() & 0x3FF;
                    tex[(y * 1024 + x) * 4 + 0] = (byte)((random.Next() & 0x3F) + 0xC0);
                    tex[(y * 1024 + x) * 4 + 1] = (byte)((random.Next() & 0x3F) + 0xC0);
                    tex[(y * 1024 + x) * 4 + 2] = (byte)((random.Next() & 0x3F) + 0xC0);
                    tex[(y * 1024 + x) * 4 + 3] = (byte)(n);
                    //tex[(y * 1024 + x) * 4 + 0] = (byte)(random.Next());
                    //tex[(y * 1024 + x) * 4 + 1] = (byte)(random.Next());
                    //tex[(y * 1024 + x) * 4 + 2] = (byte)(random.Next());
                    //tex[(y * 1024 + x) * 4 + 3] = (byte)(random.Next());
                }
            }
            GL.BindTexture(GL.GL_TEXTURE_2D, fur_texture[0]);
            GL.TexImage2D(TexImage2DTargets.Texture2D, 0, TexImage2DFormats.RGBA, 1024, 1024, 0, TexImage2DFormats.RGBA, TexImage2DTypes.UnsignedByte, tex.Header);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, (int)GL.GL_LINEAR);
            GL.TexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MAG_FILTER, (int)GL.GL_LINEAR);
            tex.Dispose();

            vboObject.LoadFromVBM(@"media\ninja.vbm", 0, 1, 2);

        }

        void LightingExample_AfterRendering(object sender, RenderEventArgs e)
        {
            //this.basicShaderProgram.Unbind();
            GL.UseProgram(0);
        }

        void LightingExample_BeforeRendering(object sender, RenderEventArgs e)
        {
            
        }

        public float translateX = 0;
        public float translateY = -81;
        protected override void DoRender(RenderEventArgs e)
        {
            LightingExample_BeforeRendering(this, e);

            mat4 mv_matrix = e.Camera.GetViewMat4();
            mat4 prj_matrix = e.Camera.GetProjectionMat4();
            prj_matrix = glm.translate(prj_matrix, new vec3(translateX, translateY, 0));

            basicShaderProgram.Bind();
            basicShaderProgram.SetUniformMatrix4("projection_matrix", prj_matrix.to_array());
            basicShaderProgram.SetUniformMatrix4("model_matrix", mv_matrix.to_array());
            //GL.UniformMatrix4(base_model_matrix_pos, 1, false, mv_matrix.to_array());
            //GL.UniformMatrix4(base_projection_matrix_pos, 1, false, prj_matrix.to_array());

            GL.Disable(GL.GL_BLEND);
            GL.Enable(GL.GL_CULL_FACE);
            GL.CullFace(GL.GL_FRONT);
            GL.Enable(GL.GL_DEPTH_TEST);
            GL.DepthFunc(GL.GL_LEQUAL);

            vboObject.Render();

            basicShaderProgram.Unbind();

            GL.BindTexture(GL.GL_TEXTURE_2D, this.fur_texture[0]);
            //this.furTexture.Bind();

            GL.UseProgram(fur_prog);
            GL.UniformMatrix4(fur_model_matrix_pos, 1, false, mv_matrix.to_array());
            GL.UniformMatrix4(fur_projection_matrix_pos, 1, false, prj_matrix.to_array());
            var fur_textureLocation = GL.GetUniformLocation(fur_prog, "fur_texture");
            GL.Uniform1(fur_textureLocation, (float)(this.fur_texture[0]));
            //int fur_textureLocation = GL.GetUniformLocation(fur_prog, "fur_texture");
            //GL.Uniform1(fur_textureLocation, (float)this.furTexture.Name);

            GL.Enable(GL.GL_BLEND);
            GL.BlendFunc(GL.GL_SRC_ALPHA, GL.GL_ONE_MINUS_SRC_ALPHA);

            GL.DepthMask((byte)GL.GL_FALSE);

            vboObject.Render();

            GL.DepthMask((byte)GL.GL_TRUE);
            GL.Disable(GL.GL_BLEND);

            LightingExample_AfterRendering(this, e);
        }

    }
}
