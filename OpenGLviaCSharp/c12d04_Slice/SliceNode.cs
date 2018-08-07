using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c12d04_Slice
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
    public class SliceNode : PickableNode, IRenderable
    {
        private const string inPosition = "inPosition";
        private const string mvpMatrix = "mvpMatrix";
        private const string vertexCode =
            @"#version 330 core

in vec3 " + inPosition + @";

uniform mat4 " + mvpMatrix + @";

void main(void) {
	gl_Position = mvpMatrix * vec4(inPosition, 1.0);
}
";
        private const string fragmentCode =
            @"#version 330 core

out vec4 out_Color;

void main(void) {
    if (int(gl_FragCoord.x + gl_FragCoord.y) % 2 == 1) discard;

    out_Color = vec4(1, 1, 1, 1) * 0.5;
}
";

        /// <summary>
        /// Render propeller in modern opengl.
        /// </summary>
        /// <returns></returns>
        public static SliceNode Create()
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, RectangleModel.strPosition);
            var builder = new RenderMethodBuilder(provider, map);
            var node = new SliceNode(new RectangleModel(), RectangleModel.strPosition, builder);
            node.Initialize();

            return node;
        }

        /// <summary>
        /// Render propeller in legacy opengl.
        /// </summary>
        private SliceNode(RectangleModel model, string positionNameInIBufferable, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferable, builders)
        {
            this.ModelSize = model.ModelSize;
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
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;

            program.SetUniform(mvpMatrix, projection * view * model);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

    }

}
