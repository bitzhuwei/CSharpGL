using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Render a PLY model in modern opengl.
    /// </summary>
    public class PLYRenderer : PickableRenderer
    {
        private const string inPosition = "inPosition";
        private const string inColor = "inColor";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string passColor = "passColor";
        private const string vertexCode =
            @"#version 150 core

in vec3 " + inPosition + @";

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";

out vec3 passColor;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
    vec3 color = normalize(inPosition);
    if (color.x < 0) { color.x = -color.x / 2.0; }
    if (color.y < 0) { color.y = -color.y / 2.0; }
    if (color.z < 0) { color.z = -color.z / 2.0; }
    passColor = color;
}
";
        private const string fragmentCode =
            @"#version 150 core

in vec3 passColor;

uniform bool renderWireframe = false;

out vec4 out_Color;

void main(void) {
    if (renderWireframe)
    {
	    out_Color = vec4(1.0, 1.0, 1.0, 1.0);
    }
    else
    {
	    out_Color = vec4(passColor, 1.0);
    }
}
";

        /// <summary>
        /// Render a PLY model in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static PLYRenderer Create()
        {
            var vertexShader = new VertexShader(vertexCode, inPosition);
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add(inPosition, PLY.strPosition);
            //map.Add(inColor, PLY.strColor);
            var renderer = new PLYRenderer(new PLY(), provider, map);
            renderer.Initialize();

            return renderer;
        }

        private PLYRenderer(PLY model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, inPosition, switches)
        {
            vec3 size = model.ModelSize;
            this.ModelSize = size;
            const float factor = 12.0f;
            float average = (size.x + size.y + size.z) / 3.0f;
            this.Scale = new vec3(factor / average, factor / average, factor / average);
        }

        #region IRenderable 成员


        /// <summary>
        /// 
        /// </summary>
        public bool RenderWireframe { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool RenderBody { get; set; }

        private PolygonModeState polygonMode = new PolygonModeState(PolygonMode.Line);
        private GLState polygonOffsetState = new PolygonOffsetFillState();

        protected override void DoRender(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            this.SetUniform(projectionMatrix, projection);
            this.SetUniform(viewMatrix, view);
            this.SetUniform(modelMatrix, model);

            if (this.RenderWireframe)
            {
                // render wireframe.
                this.SetUniform("renderWireframe", true);
                polygonMode.On();
                polygonOffsetState.On();
                base.DoRender(arg);
                polygonOffsetState.Off();
                polygonMode.Off();
            }

            if (this.RenderBody)
            {
                // render solid body.
                this.SetUniform("renderWireframe", false);
                base.DoRender(arg);
            }
        }

        #endregion

    }

}
