using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace RenderToTexture
{
    /// <summary>
    /// Render a teapot in modern opengl.
    /// </summary>
    public class MultiTargetTeapotNode : PickableNode, IRenderable
    {
        private const string inPosition = "inPosition";
        private const string inColor = "inColor";
        private const string projectionMat = "projectionMat";
        private const string viewMat = "viewMat";
        private const string modelMat = "modelMat";
        private const string passColor = "passColor";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";
in vec3 " + inColor + @";

uniform mat4 " + projectionMat + @";
uniform mat4 " + viewMat + @";
uniform mat4 " + modelMat + @";

out vec3 passColor;

void main(void) {
	gl_Position = projectionMat * viewMat * modelMat * vec4(inPosition, 1.0);
    passColor = inColor;
}
";
        //if (inColor.x >= 0) { color.x = inColor.x; } else { color.x = -inColor.x / 2.0; }
        //if (inColor.y >= 0) { color.y = inColor.y; } else { color.y = -inColor.y / 2.0; }
        //if (inColor.z >= 0) { color.z = inColor.z; } else { color.z = -inColor.z / 2.0; }
        private const string fragmentCode =
            @"#version 330 core

in vec3 passColor;
uniform bool renderWireframe = false;

layout(location = 0) out vec4 outColor;
layout(location = 1) out vec4 outRed;
layout(location = 2) out vec4 outGreen;
layout(location = 3) out vec4 outBlue;

void main(void) {
    if (renderWireframe)
    {
	    outColor = vec4(1.0, 1.0, 1.0, 1.0);
	    outRed = vec4(1.0, 0.0, 0.0, 1.0);
	    outGreen = vec4(0.0, 1.0, 0.0, 1.0);
	    outBlue = vec4(0.0, 0.0, 1.0, 1.0);
    }
    else
    {
	    outColor = vec4(passColor, 1.0);
	    outRed = vec4(passColor.x, 0.0, 0.0, 1.0);
	    outGreen = vec4(0.0, passColor.y, 0.0, 1.0);
	    outBlue = vec4(0.0, 0.0, passColor.z, 1.0);
    }
}
";

        /// <summary>
        /// Render a teapot in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static MultiTargetTeapotNode Create(bool adjacent = false)
        {
            IBufferSource model; vec3 size;
            if (adjacent)
            {
                var m = new AdjacentTeapot(); size = m.GetModelSize(); model = m;
            }
            else
            {
                var m = new Teapot(); size = m.GetModelSize(); model = m;
            }
            string position = adjacent ? AdjacentTeapot.strPosition : Teapot.strPosition;
            string color = adjacent ? AdjacentTeapot.strColor : Teapot.strColor;

            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, position);
            map.Add(inColor, color);
            var builder = new RenderMethodBuilder(provider, map);
            var node = new MultiTargetTeapotNode(model, position, builder);
            node.Initialize();
            node.ModelSize = size;

            return node;
        }

        private MultiTargetTeapotNode(IBufferSource model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders)
        {
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

        private PolygonModeSwitch polygonMode = new PolygonModeSwitch(PolygonMode.Line);
        private GLSwitch polygonOffsetState = new PolygonOffsetFillSwitch();

        /// <summary>
        /// for debugging.
        /// </summary>
        public float RotateSpeed { get; set; }

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;
        /// <summary>
        /// Render before/after children? Render children? 
        /// RenderAction cares about this property. Other actions, maybe, maybe not, your choice.
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return this.enableRendering; }
            set { this.enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            this.RotationAngle += this.RotateSpeed;

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform(projectionMat, projection);
            program.SetUniform(viewMat, view);
            program.SetUniform(modelMat, model);

            if (this.RenderWireframe)
            {
                // render wireframe.
                program.SetUniform("renderWireframe", true);
                polygonMode.On();
                polygonOffsetState.On();
                method.Render();
                polygonOffsetState.Off();
                polygonMode.Off();
            }

            if (this.RenderBody)
            {
                // render solid body.
                program.SetUniform("renderWireframe", false);
                method.Render();
            }
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        #endregion

        public override void RenderForPicking(PickingEventArgs arg)
        {
            if (this.RenderWireframe || this.RenderBody)
            {
                base.RenderForPicking(arg);
            }
        }

    }

}
