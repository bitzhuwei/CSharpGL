using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    partial class FullScreenNode : ModernNode
    {
        private ITextureSource textureSource;
        private Texture texture;

        public static FullScreenNode Create(ITextureSource textureSource)
        {
            var model = new FullScreenModel();
            var map = new AttributeMap();
            var vs = new VertexShader(secondPassVert);
            var fs = new FragmentShader(secondPassFrag);
            var array = new ShaderArray(vs, fs);
            var secondPassBuilder = new RenderMethodBuilder(array, map);
            var node = new FullScreenNode(model, secondPassBuilder);
            node.textureSource = textureSource;
            node.Initialize();

            return node;
        }

        private FullScreenNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders) { }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            this.texture = this.textureSource.BindingTexture;
            var method = this.RenderUnit.Methods[0];
            var program = method.Program;
            program.SetUniform("colorSampler", this.texture);
        }
        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            if (!this.IsInitialized) { this.Initialize(); }

            var method = this.RenderUnit.Methods[0];
            var program = method.Program;
            if (this.texture != this.textureSource.BindingTexture)
            {
                this.texture = this.textureSource.BindingTexture;
                program.SetUniform("colorSampler", this.texture);
            }

            method.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
