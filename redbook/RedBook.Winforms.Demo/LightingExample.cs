using CSharpGL;
using CSharpGL.Maths;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using RedBook.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGL.Objects.Cameras;

namespace RedBook.Winforms.Demo
{
    class LightingExample : SceneElementBase, IDisposable
    {

        static string render_vs =
            @"#version 430 core

uniform mat4 model_matrix;
uniform mat4 proj_matrix;

layout (location = 0) in vec4 position;
layout (location = 1) in vec3 normal;

out vec3 vs_worldpos;
out vec3 vs_normal;

void main(void)
{
    vec4 position = proj_matrix * model_matrix * position;
    gl_Position = position;
    vs_worldpos = position.xyz;
    vs_normal = mat3(model_matrix) * normal;
}";

        static string render_fs =
            @"#version 430 core

layout (location = 0) out vec4 color;

in vec3 vs_worldpos;
in vec3 vs_normal;

uniform vec4 color_ambient = vec4(0.1, 0.2, 0.5, 1.0);
uniform vec4 color_diffuse = vec4(0.2, 0.3, 0.6, 1.0);
uniform vec4 color_specular = vec4(0.0); // vec4(1.0, 1.0, 1.0, 1.0);
uniform float shininess = 77.0f;

uniform vec3 light_position = vec3(12.0f, 32.0f, 560.0f);

void main(void)
{
    vec3 light_direction = normalize(light_position - vs_worldpos);
    vec3 normal = normalize(vs_normal);
    vec3 half_vector = normalize(light_direction + normalize(vs_worldpos));
    float diffuse = max(0.0, dot(normal, light_direction));
    float specular = pow(max(0.0, dot(vs_normal, half_vector)), shininess);
    color = color_ambient + diffuse * color_diffuse + specular * color_specular;
}";

        //// Override functions from base class
        //public virtual void Initialize(string title)
        //{
        //    // Now create a simple program to visualize the result
        //    render_prog = new ShaderProgram();
        //    render_prog.Create(render_vs, render_fs, null);
        //    render_prog.AssertValid();

        //    mv_mat_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "model_matrix");
        //    prj_mat_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "proj_matrix");
        //    col_amb_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "color_ambient");
        //    col_diff_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "color_diffuse");
        //    col_spec_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "color_specular");

        //    vboObject.LoadFromVBM(@"media\unit_torus.vbm", 0, 1, 2);
        //}

        //public virtual void Display(bool auto_redraw)
        //{
        //    float time = 0.5f; // float(GetTickCount() & 0xFFFF) / float(0xFFFF);

        //    mat4 mv_matrix = glm.translate(mat4.identity(), new vec3(0.0f, 0.0f, -4.0f)) *
        //                            glm.rotate(mat4.identity(), 987.0f * time * 3.14159f, new vec3(0.0f, 0.0f, 1.0f)) *
        //                            glm.rotate(mat4.identity(), 1234.0f * time * 3.14159f, new vec3(1.0f, 0.0f, 0.0f));
        //    mat4 prj_matrix = glm.perspective(60.0f, 1.333f, 0.1f, 1000.0f);

        //    //glUseProgram(render_prog);
        //    render_prog.Bind();

        //    GL.UniformMatrix4(mv_mat_loc, 1, false, mv_matrix.to_array());
        //    GL.UniformMatrix4(prj_mat_loc, 1, false, prj_matrix.to_array());

        //    // Clear, select the rendering program and draw a full screen quad
        //    GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
        //    GL.CullFace(GL.GL_BACK);
        //    GL.Enable(GL.GL_CULL_FACE);
        //    GL.Enable(GL.GL_DEPTH_TEST);
        //    GL.DepthFunc(GL.GL_LEQUAL);

        //    vboObject.Render();

        //}
        //public virtual void Finalize()
        //{
        //    render_prog.Unbind();
        //    render_prog.Delete();
        //    GL.DeleteTextures(1, output_image);
        //}

        public virtual void Reshape(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }

        // Texture for compute shader to write into
        uint[] output_image = new uint[1];

        // Program, vao and vbo to render a full screen quad
        //uint  render_prog;
        ShaderProgram render_prog;

        // Uniform locations
        int mv_mat_loc;
        int prj_mat_loc;
        int col_amb_loc;
        int col_diff_loc;
        int col_spec_loc;

        // Object to render
        VBObject vboObject = new VBObject();


        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~LightingExample()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        protected virtual void Dispose(bool disposing)
        {

            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // TODO: Dispose managed resources.
                    render_prog.Unbind();
                    render_prog.Delete();
                    GL.DeleteTextures(1, output_image);
                    this.vboObject.Dispose();
                } // end if

                // TODO: Dispose unmanaged resources.
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        protected override void DoInitialize()
        {
            // Now create a simple program to visualize the result
            render_prog = new ShaderProgram();
            render_prog.Create(render_vs, render_fs, null);
            render_prog.AssertValid();

            mv_mat_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "model_matrix");
            prj_mat_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "proj_matrix");
            col_amb_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "color_ambient");
            col_diff_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "color_diffuse");
            col_spec_loc = GL.GetUniformLocation(render_prog.ShaderProgramObject, "color_specular");

            vboObject.LoadFromVBM(@"media\unit_torus.vbm", 0, 1, 2);
        }

        protected override void DoRender(RenderEventArgs e)
        {
            //float time = 0.5f; // float(GetTickCount() & 0xFFFF) / float(0xFFFF);

            //mat4 mv_matrix = glm.translate(mat4.identity(), new vec3(0.0f, 0.0f, -4.0f)) *
            //                        glm.rotate(mat4.identity(), 987.0f * time * 3.14159f, new vec3(0.0f, 0.0f, 1.0f)) *
            //                        glm.rotate(mat4.identity(), 1234.0f * time * 3.14159f, new vec3(1.0f, 0.0f, 0.0f));
            //mat4 prj_matrix = glm.perspective(60.0f, 1.333f, 0.1f, 1000.0f);
            mat4 mv_matrix = e.Camera.GetProjectionMat4();
            mat4 prj_matrix = e.Camera.GetProjectionMat4();

            //glUseProgram(render_prog);
            render_prog.Bind();

            GL.UniformMatrix4(mv_mat_loc, 1, false, mv_matrix.to_array());
            GL.UniformMatrix4(prj_mat_loc, 1, false, prj_matrix.to_array());

            // Clear, select the rendering program and draw a full screen quad
            GL.Clear(GL.GL_COLOR_BUFFER_BIT | GL.GL_DEPTH_BUFFER_BIT);
            GL.CullFace(GL.GL_BACK);
            GL.Enable(GL.GL_CULL_FACE);
            GL.Enable(GL.GL_DEPTH_TEST);
            GL.DepthFunc(GL.GL_LEQUAL);

            vboObject.Render();
        }
    }
}
