using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    partial class FullScreenNode : ModernNode
    {
        /// <summary>
        /// texture embeded in framebuffer.
        /// </summary>
        private Texture texture;

        public static FullScreenNode Create(Texture texture)
        {
            var model = new FullScreenModel();
            var map = new AttributeMap();
            var vs = new VertexShader(secondPassVert);
            var fs = new FragmentShader(secondPassFrag);
            var array = new ShaderArray(vs, fs);
            var secondPassBuilder = new RenderMethodBuilder(array, map);
            var node = new FullScreenNode(model, secondPassBuilder);
            node.texture = texture;
            node.Initialize();

            return node;
        }

        private FullScreenNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var method = this.RenderUnit.Methods[0];
            var program = method.Program;
            program.SetUniform("colorSampler", this.texture);
        }
        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            var method = this.RenderUnit.Methods[0];

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
