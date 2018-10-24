using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    partial class BoneNode
    {
        private vec3 diffuseColor = new vec3();
        public Color DiffuseColor
        {
            get { return this.diffuseColor.ToColor(); }
            set
            {
                vec3 c = value.ToVec3();
                this.diffuseColor = c;
                ModernRenderUnit unit = this.RenderUnit;
                RenderMethod method = unit.Methods[0];
                ShaderProgram program = method.Program;
                program.SetUniform("diffuseColor", c);
            }
        }

        public PolygonMode PolygonMode
        {
            get { return this.polygonModeSwitch.Mode; }
            set { this.polygonModeSwitch.Mode = value; }
        }

        private PolygonModeSwitch polygonModeSwitch = new PolygonModeSwitch(PolygonMode.Fill);

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        private bool firstRun = true;
        private DateTime lastTime;

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
            program.SetUniform("normalMat", glm.transpose(glm.inverse(modelMat)));
            {
                if (this.firstRun)
                {
                    lastTime = DateTime.Now;
                    this.firstRun = false;
                }

                DateTime now = DateTime.Now;
                float timeInSeconds = (float)(now.Subtract(this.lastTime).TotalSeconds);
                //this.lastTime = now;

                mat4[] boneMatrixes = this.boneModel.GetBoneMatrixes(timeInSeconds);
                if (boneMatrixes != null) { program.SetUniform("bones", boneMatrixes); }
                program.SetUniform("animation", boneMatrixes != null);
            }
            Texture tex = this.boneModel.Texture;
            if (tex != null) { program.SetUniform("textureMap", tex); }
            this.polygonModeSwitch.On();
            method.Render();
            this.polygonModeSwitch.Off();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
