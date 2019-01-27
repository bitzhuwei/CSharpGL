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

        private DateTime lastTime;
        private bool firstTime = true;

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            float interval = 0;
            if (firstTime)
            {
                var now = DateTime.Now;
                lastTime = now;
                firstTime = false;
            }
            else
            {
                var now = DateTime.Now;
                TimeSpan span = now.Subtract(lastTime);
                lastTime = now;
                interval = (float)span.TotalMilliseconds;
            }

            ICamera camera = arg.Camera;
            mat4 projectionMat = camera.GetProjectionMatrix();
            mat4 viewMat = camera.GetViewMatrix();
            mat4 modelMat = this.GetModelMatrix();

            {
                // 渲染灯光
                ShaderProgram program = this.pbrProgram;
                for (int i = 0; i < lightPositions.Length; i++)
                {
                    vec3 lightPos = lightPositions[i] + new vec3((float)Math.Sin(interval * 5.0) * 5.0f, 0.0f, 0.0f);
                    program.SetUniform(string.Format("lightPositions[{0}]", i), lightPositions[i]);
                    program.SetUniform(string.Format("lightColors[{0}]", i), lightColors[i]);
                }
                program.SetUniform("ViewMatrix", viewMat);
                program.SetUniform("ProjMatrix", projectionMat);
                program.SetUniform("cameraPos", camera.Position);
                this.irradianceMap.TextureUnitIndex = 0;
                this.prefliterMap.TextureUnitIndex = 1;
                this.brdfLUTTexture.TextureUnitIndex = 2;
                this.albedoMap.TextureUnitIndex = 3;
                this.normalMap.TextureUnitIndex = 4;
                this.metallicMap.TextureUnitIndex = 5;
                this.roughnessMap.TextureUnitIndex = 6;
                this.aoMap.TextureUnitIndex = 7;
                program.SetUniform("irradianceMap", this.irradianceMap);
                program.SetUniform("preflitterMap", this.prefliterMap);
                program.SetUniform("brdfLUT", this.brdfLUTTexture);
                program.SetUniform("albedoMap", this.albedoMap);
                program.SetUniform("normalMap", this.normalMap);
                program.SetUniform("metallicMap", this.metallicMap);
                program.SetUniform("roughnessMap", this.roughnessMap);
                program.SetUniform("aoMap", this.aoMap);

                int a = nrColumns / 2;
                int b = nrRows / 2;
                for (int i = 0; i < nrRows; ++i)
                {
                    for (int j = 0; j < nrColumns; ++j)
                    {
                        var modelMatrix = mat4.identity();
                        modelMatrix = glm.translate(modelMatrix, new vec3(
                            (float)(j - a) * spacing,
                            (float)(i - b) * spacing,
                            0.0f
                            ));
                        program.SetUniform("ModelMatrix", modelMatrix);
                        program.Bind();
                        renderSphere();
                        program.Unbind();
                    }
                }
            }
            {
                // 渲染天空盒子
                ShaderProgram program = this.backgroundProgram;
                program.SetUniform("ViewMatrix", viewMat);
                program.SetUniform("ProjMatrix", projectionMat);
                this.envCubeMap.TextureUnitIndex = 0;
                program.SetUniform("backgroundCubeMap", this.envCubeMap);
                program.Bind();
                renderCube();
                program.Unbind();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion
    }
}
