using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render propeller in modern opengl.
    /// </summary>
    public class TeapotRenderer : PickableRenderer
    {

        private const string vertexCode =
            @"#version 150 core

in vec3 inPosition;
in vec3 inColor;

uniform mat4 projectionMatrix;
uniform mat4 viewMatrix;
uniform mat4 modelMatrix;

out vec3 passColor;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
	passColor = inColor;
}
";
        private const string fragmentCode =
            @"#version 150 core

in vec3 passColor;

out vec4 out_Color;

void main(void) {
	out_Color = vec4(passColor, 1.0);
}
";

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static TeapotRenderer Create()
        {
            var vertexShader = new VertexShader(vertexCode, "inPositoin", "inColor");
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add("inPosition", Teapot.strPosition);
            map.Add("inColor", Teapot.strColor);
            var renderer = new TeapotRenderer(new Teapot(), provider, map);
            renderer.Initialize();

            return renderer;
        }

        private TeapotRenderer(Teapot model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, "inPosition", switches)
        {
            this.ModelSize = model.GetModelSize();
        }

        #region IRenderable 成员

        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = arg.Scene.Camera.GetProjectionMatrix();
            mat4 view = arg.Scene.Camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform("projectionMatrix", projection);
            this.SetUniform("viewMatrix", view);
            this.SetUniform("modelMatrix", model);

            base.DoRender(arg);
        }

        #endregion

    }

}
