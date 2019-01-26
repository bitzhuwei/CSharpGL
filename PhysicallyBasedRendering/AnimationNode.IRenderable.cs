using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    partial class PBRNode
    {
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
            program.SetUniform("mvpMat", projectionMat * viewMat * modelMat);
            program.SetUniform("normalMat", glm.transpose(glm.inverse(viewMat * modelMat)));

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
