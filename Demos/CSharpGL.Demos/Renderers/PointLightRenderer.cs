using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class PointLightRenderer : PickableRenderer
    {
        public vec3 Ambient { get; set; }
        public vec3 LightPosition { get; set; }
        public vec3 LightColor { get; set; }
        //public vec3 HalfVector { get; set; }
        public float Shininess { get; set; }
        public float Strength { get; set; }
        public float ConstantAttenuation { get; set; }
        public float LinearAttenuation { get; set; }
        public float QuadraticAttenuation { get; set; }

        public static PointLightRenderer Create()
        {
            var model = new Teapot();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\PointLight\PointLight.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\PointLight\PointLight.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("inPosition", Teapot.strPosition);
            map.Add("inColor", Teapot.strColor);
            map.Add("inNormal", Teapot.strNormal);

            var renderer = new PointLightRenderer(model, shaderCodes, map, Teapot.strPosition);
            renderer.ModelSize = model.Size;
            return renderer;
        }

        private PointLightRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {
            this.Ambient = new vec3(0.2f);
            this.LightPosition = new vec3(400);
            this.LightColor = new vec3(1);
            //this.HalfVector = new vec3(1);
            this.Shininess = 10.0f;
            this.Strength = 1.0f;
            this.ConstantAttenuation = 0.2f;
            this.LinearAttenuation = 0.0f;
            this.QuadraticAttenuation = 0.0f;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("ambient", this.Ambient);
            this.SetUniform("lightColor", this.LightColor);
            this.SetUniform("lightPosition", this.LightPosition.normalize());
            //this.SetUniform("halfVector", this.HalfVector.normalize());
            this.SetUniform("shininess", this.Shininess);
            this.SetUniform("strength", this.Strength);
            this.SetUniform("constantAttenuation", this.ConstantAttenuation);
            this.SetUniform("linearAttenuation", this.LinearAttenuation);
            this.SetUniform("quadraticAttenuation", this.QuadraticAttenuation);

            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix().Value;
            this.SetUniform("eyeDirection", arg.Camera.GetFront());
            this.SetUniform("projection", projection);
            this.SetUniform("view", view);
            this.SetUniform("model", model);
            this.SetUniform("normalMatrix", glm.transpose(glm.inverse(model)).to_mat3());

            base.DoRender(arg);
        }
    }
}
