using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace PointLight.NoShadow
{
    partial class PointLightNoShadowNode : ModernNode, IBlinnPhong
    {
        public static PointLightNoShadowNode Create(IBufferSource model, string position, string normal, vec3 size)
        {
            RenderMethodBuilder ambientBuilder, blinnPhongBuilder;
            {
                var vs = new VertexShader(ambientVert);
                var fs = new FragmentShader(ambientFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                ambientBuilder = new RenderMethodBuilder(array, map);
            }
            {
                var vs = new VertexShader(blinnPhongVert);
                var fs = new FragmentShader(blinnPhongFrag);
                var array = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                map.Add("inPosition", position);
                map.Add("inNormal", normal);
                blinnPhongBuilder = new RenderMethodBuilder(array, map);
            }

            var node = new PointLightNoShadowNode(model, ambientBuilder, blinnPhongBuilder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private PointLightNoShadowNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.DiffuseColor = new vec3(1, 1, 1);
            this.Shiness = 8;
            this.BlinnPhong = true;
        }

        #region IBlinnPhong 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        public ThreeFlags EnableRendering { get { return this.enableRendering; } set { this.enableRendering = value; } }

        public void RenderAmbientColor(BlinnPhongAmbientEventArgs arg)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("ambientColor", arg.Ambient);

            method.Render();
        }

        public void RenderBeforeChildren(RenderEventArgs arg, LightBase light)
        {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[1];
            ShaderProgram program = method.Program;
            program.SetUniform("projectionMat", projection);
            program.SetUniform("viewMat", view);
            program.SetUniform("modelMat", model);
            program.SetUniform("normalMat", glm.transpose(glm.inverse(model)));
            program.SetUniform("diffuseColor", this.DiffuseColor);
            program.SetUniform("lightPos", light.Position);
            program.SetUniform("shiness", this.Shiness);
            program.SetUniform("lightColor", light.Color);
            program.SetUniform("blinn", this.BlinnPhong);
            program.SetUniform("eyePos", camera.Position); // camera's position in world space.

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg, LightBase light)
        {
        }

        #endregion

        public vec3 DiffuseColor { get; set; }

        public float Shiness { get; set; }

        public bool BlinnPhong { get; set; }
    }
}
