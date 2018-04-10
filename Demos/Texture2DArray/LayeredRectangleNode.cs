using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Texture2DArray
{
    partial class LayeredRectangleNode : ModernNode, IRenderable
    {
        private Bitmap[] bitmaps;
        public static LayeredRectangleNode Create(Bitmap[] bitmaps)
        {
            var vs = new VertexShader(vertexCode);
            var fs = new FragmentShader(fragmentCode);
            var provider = new ShaderArray(vs, fs);
            var map = new PropertyMap();
            map.Add(inPosition, LayeredRectangleModel.strPosition);
            map.Add(inUV, LayeredRectangleModel.strUV);
            var builder = new RenderMethodBuilder(provider, map, new BlendFuncSwitch(BlendSrcFactor.SrcAlpha, BlendDestFactor.OneMinusSrcAlpha));
            var node = new LayeredRectangleNode(new LayeredRectangleModel(), builder);
            node.bitmaps = bitmaps;
            node.Initialize();

            return node;
        }

        private LayeredRectangleNode(LayeredRectangleModel model, params RenderMethodBuilder[] builders) :
            base(model, builders)
        {
            this.ModelSize = model.ModelSize;
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            var storage = new TexImageBitmaps(this.bitmaps);
            var texture = new Texture(storage,
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_REPEAT),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_LINEAR),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_LINEAR));
            texture.Initialize();
            this.RenderUnit.Methods[0].Program.SetUniform(tex, texture);
        }

        public int LayerIndex { get; set; }

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

            var method = this.RenderUnit.Methods[0]; // the only render unit in this node.
            ShaderProgram program = method.Program;

            ICamera camera = arg.Camera;
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();
            program.SetUniform(projectionMatrix, projection);
            program.SetUniform(viewMatrix, view);
            program.SetUniform(modelMatrix, model);
            //program.SetUniform(tex, texture);
            program.SetUniform(layerIndex, this.LayerIndex);

            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }
    }
}
