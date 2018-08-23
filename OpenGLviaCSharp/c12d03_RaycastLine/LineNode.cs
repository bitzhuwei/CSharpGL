using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c12d03_RaycastLine
{
    // Y
    // ^
    // |
    // |
    // 1--------------------0
    // |      .             |
    // |      |             |
    // |                    |
    // |    .               |
    // |   .                |
    // |  .                 |
    // | .                  |
    // 2--------------------3 --> X
    //
    /// <summary>
    /// Render rectangle with texture in modern opengl.
    /// </summary>
    public class LineNode : ModernNode, IRenderable
    {
        private const string inPosition = "inPosition";
        private const string projectionMatrix = "projectionMatrix";
        private const string viewMatrix = "viewMatrix";
        private const string modelMatrix = "modelMatrix";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";

uniform mat4 " + projectionMatrix + @";
uniform mat4 " + viewMatrix + @";
uniform mat4 " + modelMatrix + @";

void main(void) {
	gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(inPosition, 1.0);
}
";
        private const string fragmentCode =
            @"#version 330 core

uniform vec4 color = vec4(1, 0, 0, 1);

out vec4 outColor;

void main(void) {
    outColor = color;
}
";

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static LineNode Create(vec3 direction)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, LineModel.strPosition);
            var lineWidthSwitch = new LineWidthSwitch(10);
            var builder = new RenderMethodBuilder(provider, map, lineWidthSwitch);
            var node = new LineNode(new LineModel(direction), builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private LineNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

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

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

    }

}
