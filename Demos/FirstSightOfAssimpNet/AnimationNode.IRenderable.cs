﻿using CSharpGL;
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

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;

        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        private bool firstRun = true;
        private DateTime lastTime;

        private bool defaultPose = true;

        public bool DefaultPose
        {
            get { return defaultPose; }
            set { defaultPose = value; }
        }

        public int AnimationIndex { get; set; }

        public int AnimationCount { get { return this.model.container.aiScene.AnimationCount; } }

        public AssimpSceneContainer Container { get { return this.model.container; } }

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
            program.SetUniform("diffuseColor", this.diffuseColor);
            {
                Texture tex = this.model.Texture;
                if (tex != null) { program.SetUniform("textureMap", tex); }
                program.SetUniform("textureExists", tex != null);
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
                mat4[] boneMatrixes = scene.GetBoneMatrixes(timeInSeconds, this.model.container.GetAllBoneInfos(), this.AnimationIndex);
                if (boneMatrixes != null)
                {
                    // default pose.
                    if (this.defaultPose)
                    {
                        program.SetUniform("animation", false);
                        program.SetUniform("transparent", true);
                        method.Render();
                    }

                    // animation pose.
                    program.SetUniform("animation", boneMatrixes != null);
                    program.SetUniform("transparent", false);
                    program.SetUniform("bones", boneMatrixes);
                    method.Render();
                }
                else
                {
                    // no animation found.
                    program.SetUniform("animation", false);

                    method.Render();
                }
            }
            else
            {
                program.SetUniform("animation", false);

                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
