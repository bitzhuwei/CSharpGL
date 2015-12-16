using CSharpGL.Objects.Shaders;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos.VolumeRendering
{
    public class DemoVolumeRendering01 : SceneElementBase, IMVP
    {
        /// <summary>
        /// shader program
        /// </summary>
        public ShaderProgram shaderProgram;
        const string strin_Position = "in_Position";
        const string strin_uv = "in_uv";
        public const string strMVP = "MVP";

        protected void InitializeShader(out ShaderProgram shaderProgram)
        {
            var vertexShaderSource = ManifestResourceLoader.LoadTextFile(@"VolumeRendering.DemoVolumeRendering01.vert");
            var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(@"VolumeRendering.DemoVolumeRendering01.frag");

            shaderProgram = new ShaderProgram();
            shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);

            shaderProgram.AssertValid();
        }

        protected override void DoInitialize()
        {
            InitializeShader(out shaderProgram);

            //base.BeforeRendering += IMVPHelper.Getelement_BeforeRendering();
            //base.AfterRendering += IMVPHelper.Getelement_AfterRendering();
        }

        protected override void DoRender(RenderEventArgs e)
        {
        }

        void IMVP.SetShaderProgram(mat4 mvp)
        {
            //this.tex.Bind();

            IMVPHelper.SetMVP(this, mvp);
        }


        void IMVP.ResetShaderProgram()
        {
            IMVPHelper.ResetMVP(this);

            //this.tex.Unbind();
        }


        ShaderProgram IMVP.GetShaderProgram()
        {
            return this.shaderProgram;
        }

    }
}
