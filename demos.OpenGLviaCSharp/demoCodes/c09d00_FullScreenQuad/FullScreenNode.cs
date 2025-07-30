using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CSharpGL;

namespace c09d00_FullScreenQuad {
    partial class FullScreenNode : PickableNode, IRenderable {
        public static FullScreenNode Create(Texture texture) {
            var model = new FullScreenModel();
            var program = GLProgram.Create(vertexCode, fragmentCode); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", FullScreenModel.strPosition);
            map.Add("inUV", FullScreenModel.strUV);
            var builder = new RenderMethodBuilder(program, map);

            var node = new FullScreenNode(model, FullScreenModel.strPosition, builder);
            node.texture = texture;
            node.Initialize();

            return node;
        }

        private Texture texture;

        private FullScreenNode(IBufferSource model, string positionNameInIBufferSource, params RenderMethodBuilder[] builders)
            : base(model, positionNameInIBufferSource, builders) {
            this.EnableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children;
        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering { get; set; }

        public void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            var method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("tex", this.texture);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
        }

        #endregion
    }

}
