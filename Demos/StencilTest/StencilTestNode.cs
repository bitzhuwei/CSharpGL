using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace StencilTest
{
    partial class StencilTestNode : ModernNode
    {
        public static StencilTestNode Create()
        {
            var model = new StencilTestModel();
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new AttributeMap();
            map.Add(inPosition, StencilTestModel.strPosition);
            var builder = new RenderMethodBuilder(provider, map);
            var node = new StencilTestNode(model, builder);
            node.Initialize();

            return node;
        }

        private StencilTestNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
            this.Color = new vec4(1, 1, 1, 1);
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);
            program.SetUniform(color, this.Color);

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        public vec4 Color { get; set; }
    }
}
