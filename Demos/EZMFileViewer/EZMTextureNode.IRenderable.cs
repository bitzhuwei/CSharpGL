using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class EZMTextureNode
    {
        private bool useBones = true;
        public bool UseBones
        {
            get { return this.useBones; }
            set
            {
                this.useBones = value;
                ModernRenderUnit unit = this.RenderUnit;
                RenderMethod method = unit.Methods[0];
                ShaderProgram program = method.Program;
                program.SetUniform("useBones", value);
            }
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }


        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();

            ModernRenderUnit unit = this.RenderUnit;
            RenderMethod method = unit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("projectionMat", projectionMat);
            program.SetUniform("mvMat", viewMat * modelMat);
            program.SetUniform("normalMat", glm.transpose(glm.inverse(viewMat * modelMat)));
            mat4[] boneMatrixes = this.textureModel.BoneMatrixes;
            if (boneMatrixes != null) { program.SetUniform("bones", boneMatrixes); }
            Texture tex = this.textureModel.Texture;
            if (tex != null) { program.SetUniform("textureMap", tex); }
            program.SetUniform("useDefault", tex != null ? 0.0f : 1.0f);
            program.SetUniform("light_position", new vec3(1, 1, 1) * 10);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
