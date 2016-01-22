using CSharpGL;
using GLM;
using CSharpGL.Objects;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using RedBook.Common;
using RedBook.Common.LightingExample;
using System;

namespace RedBook.Winforms.Demo
{
    class LightingExample : RendererBase
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

        public virtual void Reshape(int width, int height)
        {
            GL.Viewport(0, 0, width, height);
        }

        ShaderProgram shaderProgram;

        // Uniform locations
        //int mv_mat_loc;
        //int prj_mat_loc;
        //int col_amb_loc;
        //int col_diff_loc;
        //int col_spec_loc;

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
                    shaderProgram.Unbind();
                    shaderProgram.Delete();
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
            shaderProgram = new ShaderProgram();
            shaderProgram.Create(render_vs, render_fs, null);

            //mv_mat_loc = GL.GetUniformLocation(shaderProgram.ShaderProgramObject, "model_matrix");
            //prj_mat_loc = GL.GetUniformLocation(shaderProgram.ShaderProgramObject, "proj_matrix");
            //col_amb_loc = GL.GetUniformLocation(shaderProgram.ShaderProgramObject, "color_ambient");
            //col_diff_loc = GL.GetUniformLocation(shaderProgram.ShaderProgramObject, "color_diffuse");
            //col_spec_loc = GL.GetUniformLocation(shaderProgram.ShaderProgramObject, "color_specular");

            vboObject.LoadFromVBM(@"media\unit_torus.vbm", 0, 1, 2);
        }

        void LightingExample_AfterRendering(object sender, RenderEventArgs e)
        {
            this.shaderProgram.Unbind();
        }

        void LightingExample_BeforeRendering(object sender, RenderEventArgs e)
        {
            mat4 mv_matrix = e.Camera.GetViewMat4();
            mat4 prj_matrix = e.Camera.GetProjectionMat4();

            shaderProgram.Bind();
            shaderProgram.SetUniformMatrix4("proj_matrix", prj_matrix.to_array());
            shaderProgram.SetUniformMatrix4("model_matrix", mv_matrix.to_array());
        }

        protected override void DoRender(RenderEventArgs e)
        {
            LightingExample_BeforeRendering(this, e);
            vboObject.Render();
            LightingExample_AfterRendering(this, e);
        }

    }
}
