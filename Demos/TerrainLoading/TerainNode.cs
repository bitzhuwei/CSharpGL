using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.ComponentModel;

namespace TerrainLoading
{
    partial class TerainNode : ModernNode, IRenderable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TerainNode Create()
        {
            var model = new TerainModel();
            RenderMethodBuilder defaultBuilder;
            {
                var vs = new VertexShader(vert);
                var fs = new FragmentShader(frag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                defaultBuilder = new RenderMethodBuilder(provider, map, new PolygonModeState(PolygonMode.Line));
            }

            var node = new TerainNode(model, defaultBuilder);
            node.Initialize();

            return node;
        }

        private TerainNode(IBufferSource model, params RenderMethodBuilder[] builders)
            : base(model, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("TERRAIN_SIZE", new ivec2(TerainModel.TERRAIN_WIDTH, TerainModel.TERRAIN_DEPTH));
            program.SetUniform("scale", (TerainModel.TERRAIN_WIDTH + TerainModel.TERRAIN_DEPTH) * 0.08f);

            string folder = System.Windows.Forms.Application.StartupPath;
            var image = new Bitmap(System.IO.Path.Combine(folder, "heightmap512x512.png"));
            this.UpdateHeightmap(image);
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

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("MVP", projection * view * model);
            method.Render();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        private Texture heightTexture;

        /// <summary>
        /// Load a user defined heightmap
        /// </summary>
        /// <param name="image"></param>
        public void UpdateHeightmap(Bitmap image)
        {
            if (this.heightTexture != null)
            {
                this.heightTexture.Dispose();
            }

            var storage = new TexImageBitmap(image, GL.GL_RED);
            var heightMapTexture = new Texture(storage,
                //new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST)
                );
            heightMapTexture.TextureUnitIndex = 0;
            heightMapTexture.Initialize();

            RenderMethod method = this.RenderUnit.Methods[0];
            ShaderProgram program = method.Program;
            program.SetUniform("heightMapTexture", heightMapTexture);

            this.heightTexture = heightMapTexture;
        }
    }
}
