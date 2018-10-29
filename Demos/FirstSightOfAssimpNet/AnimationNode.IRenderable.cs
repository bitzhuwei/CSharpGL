using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    partial class AnimationNode
    {
        private vec3 diffuseColor = new vec3();
        public Color DiffuseColor
        {
            get { return this.diffuseColor.ToColor(); }
            set { this.diffuseColor = value.ToVec3(); }
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
        private double angle;

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
            program.SetUniform("diffuseColor", this.diffuseColor);
            {
                Texture tex = this.model.Texture;
                if (tex != null) { program.SetUniform("textureMap", tex); }
            }
            {
                angle += 0.01f;
                vec3 lightDirection = new vec3(
                    (float)Math.Cos(angle), (float)Math.Sin(angle), 1);
                program.SetUniform("lihtDirection", lightDirection);
            }
            if (this.model.container.aiScene.HasAnimations)
            {
                if (this.firstRun)
                {
                    lastTime = DateTime.Now;
                    this.firstRun = false;
                }

                DateTime now = DateTime.Now;
                float timeInSeconds = (float)(now.Subtract(this.lastTime).TotalSeconds);

                Assimp.Scene scene = this.model.container.aiScene;
                mat4[] boneMatrixes = scene.GetBoneMatrixes(timeInSeconds, this.model.container.GetAllBoneInfos());
                if (boneMatrixes != null)
                {
                    // default pose.
                    program.SetUniform("animation", false);
                    program.SetUniform("transparent", true);
                    this.polygonModeSwitch.On();
                    method.Render();
                    this.polygonModeSwitch.Off();

                    // animation pose.
                    program.SetUniform("animation", boneMatrixes != null);
                    program.SetUniform("transparent", false);
                    program.SetUniform("bones", boneMatrixes);
                    this.polygonModeSwitch.On();
                    method.Render();
                    this.polygonModeSwitch.Off();
                }
                else
                {
                    // no animation found.
                    program.SetUniform("animation", false);

                    this.polygonModeSwitch.On();
                    method.Render();
                    this.polygonModeSwitch.Off();
                }
            }
            else
            {
                program.SetUniform("animation", false);

                this.polygonModeSwitch.On();
                method.Render();
                this.polygonModeSwitch.Off();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
