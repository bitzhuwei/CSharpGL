using CSharpGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace c06d00_TextureArray {
    partial class RectangleNode : ModernNode, IRenderable {
        private Texture texture;
        public static RectangleNode Create(Texture texture) {
            var model = new RectangleModel();
            var program = GLProgram.Create(vert, frag); Debug.Assert(program != null);
            var map = new AttributeMap();
            map.Add("inPosition", RectangleModel.strPositoin);
            map.Add("inUV", RectangleModel.strUV);
            var builder = new RenderMethodBuilder(program, map, new BlendSwitch(BlendEquationMode.Add, BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha));
            var node = new RectangleNode(model, builder);
            node.SetTexture(texture);
            node.Initialize();

            return node;
        }

        private void SetTexture(Texture texture) {
            this.texture = texture;
        }

        private static int idCounter = 0;
        private readonly int nodeId;
        private RectangleNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) {
            this.nodeId = idCounter++;
        }

        #region IRenderable 成员

        public ThreeFlags EnableRendering {
            get { return ThreeFlags.BeforeChildren | ThreeFlags.AfterChildren | ThreeFlags.Children; }
            set { /* nothing need to do. */ }
        }

        public unsafe void RenderBeforeChildren(RenderEventArgs arg) {
            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderMethod method = this.RenderUnit.Methods[0];
            GLProgram program = method.Program;
            program.SetUniform("mvpMat", projection * view * model);
            program.SetUniform("tex", texture);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg) {
            // nothing to do.
        }

        #endregion
    }
}
