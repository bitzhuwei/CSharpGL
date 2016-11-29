using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class DirectonalLightRenderer : PickableRenderer
    {
        public vec3 AmbientLightColor { get; set; }
        public vec3 DirectionalLightDirection { get; set; }
        public vec3 DirectionalLightColor { get; set; }
        //public vec3 HalfVector { get; set; }
        public float Shininess { get; set; }
        public float Strength { get; set; }

        public static DirectonalLightRenderer Create()
        {
            var model = new Teapot();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\DirectionalLight\DirectionalLight.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\DirectionalLight\DirectionalLight.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("inPosition", Teapot.strPosition);
            map.Add("inColor", Teapot.strColor);
            map.Add("inNormal", Teapot.strNormal);

            var renderer = new DirectonalLightRenderer(model, shaderCodes, map, Teapot.strPosition);
            renderer.ModelSize = model.Size;
            return renderer;
        }

        private DirectonalLightRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {
            this.AmbientLightColor = new vec3(0.2f);
            this.DirectionalLightDirection = new vec3(1);
            this.DirectionalLightColor = new vec3(1);
            //this.HalfVector = new vec3(1);
            this.Shininess = 10.0f;
            this.Strength = 1.0f;
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("ambientLight", this.AmbientLightColor);
            this.SetUniform("directionalLightColor", this.DirectionalLightColor);
            this.SetUniform("directionalLightDirection", this.DirectionalLightDirection.normalize());
            this.SetUniform("halfVector", this.DirectionalLightDirection.normalize());
            //this.SetUniform("halfVector", this.HalfVector.normalize());
            this.SetUniform("shininess", this.Shininess);
            this.SetUniform("strength", this.Strength);

            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix().Value;
            this.SetUniform("mvpMatrix", projection * view * model);
            this.SetUniform("normalMatrix", glm.transpose(glm.inverse(model)).to_mat3());

            base.DoRender(arg);
        }
    }
}
