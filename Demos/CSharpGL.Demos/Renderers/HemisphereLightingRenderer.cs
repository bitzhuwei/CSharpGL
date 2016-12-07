using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class HemisphereLightingRenderer : PickableRenderer
    {
        public vec3 LightPosition { get; set; }
        public vec3 SkyColor { get; set; }
        public vec3 GroundColor { get; set; }

        public static HemisphereLightingRenderer Create()
        {
            var model = new Teapot();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\HemisphereLighting\HemisphereLighting.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\HemisphereLighting\HemisphereLighting.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("inPosition", Teapot.strPosition);
            map.Add("inNormal", Teapot.strNormal);

            var renderer = new HemisphereLightingRenderer(model, shaderCodes, map, Teapot.strPosition);
            renderer.ModelSize = model.Size;
            return renderer;
        }

        private HemisphereLightingRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {
            this.LightPosition = new vec3(0, 2, 0);
            this.SkyColor = new vec3(1, 0, 0);
            this.GroundColor = new vec3(0, 1, 0);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("LightPosition", this.LightPosition);
            this.SetUniform("SkyColor", this.SkyColor.normalize());
            this.SetUniform("GroundColor", this.GroundColor.normalize());

            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix().Value;
            this.SetUniform("projection", projection);
            this.SetUniform("view", view);
            this.SetUniform("model", model);
            this.SetUniform("NormalMatrix", glm.transpose(glm.inverse(model)).to_mat3());

            base.DoRender(arg);
        }
    }
}
