using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FirstSightOfAssimpNet
{
    partial class NodePointNode
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
            if (this.firstRun)
            {
                lastTime = DateTime.Now;
                this.firstRun = false;
            }

            DateTime now = DateTime.Now;
            float timeInSeconds = (float)(now.Subtract(this.lastTime).TotalSeconds);
            //this.lastTime = now;

            Assimp.Scene scene = this.nodePointModel.scene;
            Assimp.Matrix4x4 transform = scene.RootNode.Transform;
            transform.Inverse();
            //mat4[] boneMatrixes = scene.GetBoneMatrixes(timeInSeconds, transform.ToMat4(), this.nodePointModel.container.GetAllBones());
            mat4[] boneMatrixes = null;
            program.SetUniform("animation", boneMatrixes != null);
            if (boneMatrixes != null)
            {
                program.SetUniform("bones", boneMatrixes);
            }

            GL.Instance.Enable(GL.GL_VERTEX_PROGRAM_POINT_SIZE);
            GL.Instance.Clear(GL.GL_DEPTH_BUFFER_BIT); // push this node to top front.
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
