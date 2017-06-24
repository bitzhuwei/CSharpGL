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
        private const string inPosition = "inPosition";
        private const string inColor = "inColor";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string passColor = "passColor";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";
in vec3 " + inColor + @";

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";

out vec3 passColor;

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
    vec3 color;
    if (inColor.x >= 0) { color.x = inColor.x; } else { color.x = -inColor.x / 3.0; }
    if (inColor.y >= 0) { color.y = inColor.y; } else { color.y = -inColor.y / 3.0; }
    if (inColor.z >= 0) { color.z = inColor.z; } else { color.z = -inColor.z / 3.0; }
	passColor = color;
}
";
        //if (inColor.x >= 0) { color.x = inColor.x; } else { color.x = -inColor.x / 2.0; }
        //if (inColor.y >= 0) { color.y = inColor.y; } else { color.y = -inColor.y / 2.0; }
        //if (inColor.z >= 0) { color.z = inColor.z; } else { color.z = -inColor.z / 2.0; }
        private const string fragmentCode =
            @"#version 330 core

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
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static TeapotRenderer Create()
        {
            var vertexShader = new VertexShader(vertexCode, inPosition, inColor);
            var fragmentShader = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vertexShader, fragmentShader);
            var map = new AttributeMap();
            map.Add(inPosition, Teapot.strPosition);
            map.Add(inColor, Teapot.strColor);
            var renderer = new TeapotRenderer(new Teapot(), provider, map);
            renderer.Initialize();

            return renderer;
        }

        private TeapotRenderer(Teapot model, IShaderProgramProvider shaderProgramProvider,
            AttributeMap attributeMap, params GLState[] switches)
            : base(model, shaderProgramProvider, attributeMap, inPosition, switches)
        {
            this.ModelSize = model.GetModelSize();
            this.RenderWireframe = true;
            this.RenderBody = true;
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

        /// <summary>
        /// for debugging.
        /// </summary>
        public float RotateSpeed { get; set; }

        protected override void DoRender(RenderEventArgs arg)
        {
            this.RotationAngle += this.RotateSpeed;

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

        public override void RenderForPicking(PickEventArgs arg)
        {
            if (this.RenderWireframe || this.RenderBody)
            {
                base.RenderForPicking(arg);
            }
        }
    }

}
