using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;

namespace DeferredShading
{
    partial class FullScreenNode : ModernNode, IRenderable
    {
        private ITextureSource textureSource;
        private Texture texture;

        public static FullScreenNode Create(ITextureSource textureSource)
        {
            var model = new FullScreenModel();
            var map = new PropertyMap();
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

            var method = this.RenderUnit.Methods[0];
            var program = method.Program;
            if (this.texture != this.textureSource.BindingTexture)
            {
                this.texture = this.textureSource.BindingTexture;
                if (this.texture != null)
                {
                    program.SetUniform("colorSampler", this.texture);
                }
            }

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
