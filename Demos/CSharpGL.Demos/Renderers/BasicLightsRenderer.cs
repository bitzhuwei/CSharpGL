using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpGL.Demos
{
    class BasicLightsRenderer : PickableRenderer
    {
        public vec3 AmbientLight { get; set; }
        public static BasicLightsRenderer Create()
        {
            IBufferable model = new Teapot();
            var shaderCodes = new ShaderCode[2];
            shaderCodes[0] = new ShaderCode(File.ReadAllText(@"shaders\BasicLight\BasicLight.vert"), ShaderType.VertexShader);
            shaderCodes[1] = new ShaderCode(File.ReadAllText(@"shaders\BasicLight\BasicLight.frag"), ShaderType.FragmentShader);
            var map = new AttributeMap();
            map.Add("inPosition", Teapot.strPosition);
            map.Add("inColor", Teapot.strColor);

            var renderer = new BasicLightsRenderer(model, shaderCodes, map, Teapot.strPosition);
            return renderer;
        }

        private BasicLightsRenderer(IBufferable model, ShaderCode[] shaderCodes,
            AttributeMap attributeMap, string positionNameInIBufferable,
            params GLState[] switches)
            : base(model, shaderCodes, attributeMap, positionNameInIBufferable, switches)
        {
            this.AmbientLight = new vec3(0.5f, 0.5f, 0.5f);
        }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.SetUniform("ambientLight", this.AmbientLight);
            mat4 projection = arg.Camera.GetProjectionMatrix();
            mat4 view = arg.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix().Value;
            this.SetUniform("mvpMatrix", projection * view * model);

            base.DoRender(arg);
        }
    }
}
