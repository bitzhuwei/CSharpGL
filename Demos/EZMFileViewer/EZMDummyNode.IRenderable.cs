using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace EZMFileViewer
{
    partial class EZMDummyNode
    {
        private vec3 color = new vec3();
        public Color Color
        {
            get { return this.color.ToColor(); }
            set
            {
                vec3 c = value.ToVec3();
                this.color = c;
                ModernRenderUnit unit = this.RenderUnit;
                RenderMethod method = unit.Methods[0];
                ShaderProgram program = method.Program;
                program.SetUniform("color", c);
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
            program.SetUniform("mvpMat", projectionMat * viewMat * modelMat);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
