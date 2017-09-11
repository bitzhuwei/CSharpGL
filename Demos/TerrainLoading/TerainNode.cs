using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpGL;
using System.Drawing;
using System.ComponentModel;

namespace TerrainLoading
{
    partial class TerainNode : ModernNode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static TerainNode Create()
        {
            var model = new TerainModel();
            RenderUnitBuilder defaultBuilder;
            {
                var vs = new VertexShader(vert, "vVertex");
                var fs = new FragmentShader(frag);
                var provider = new ShaderArray(vs, fs);
                var map = new AttributeMap();
                defaultBuilder = new RenderUnitBuilder(provider, map, new PolygonModeState(PolygonMode.Line));
            }

            var node = new TerainNode(model, defaultBuilder);
            node.Initialize();

            return node;
        }

        private TerainNode(IBufferSource model, params RenderUnitBuilder[] builders)
            : base(model, builders)
        {
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            program.SetUniform("TERRAIN_SIZE", new ivec2(TerainModel.TERRAIN_WIDTH, TerainModel.TERRAIN_DEPTH));
            program.SetUniform("scale", (TerainModel.TERRAIN_WIDTH + TerainModel.TERRAIN_DEPTH) * 0.08f);

            var image = new Bitmap("heightmap512x512.png");
            this.UpdateHeightmap(image);
        }

        public override void RenderBeforeChildren(RenderEventArgs arg)
        {
            ICamera camera = arg.CameraStack.Peek();
            mat4 projection = camera.GetProjectionMatrix();
            mat4 view = camera.GetViewMatrix();
            mat4 model = this.GetModelMatrix();

            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            program.SetUniform("MVP", projection * view * model);
            unit.Render();
        }

        public override void RenderAfterChildren(RenderEventArgs arg)
        {
        }

        private Bitmap heightmap;
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

            var storage = new TexImage2D(TexImage2D.Target.Texture2D, 0, GL.GL_RED, image.Width, image.Height, 0, GL.GL_BGRA, GL.GL_UNSIGNED_BYTE, new ImageDataProvider(image));
            var heightMapTexture = new Texture(TextureTarget.Texture2D, storage,
                //new TexParameteri(TexParameter.PropertyName.TextureWrapR, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapS, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureWrapT, (int)GL.GL_CLAMP),
                new TexParameteri(TexParameter.PropertyName.TextureMinFilter, (int)GL.GL_NEAREST),
                new TexParameteri(TexParameter.PropertyName.TextureMagFilter, (int)GL.GL_NEAREST)
                );
            heightMapTexture.TextureUnitIndex = 0;
            heightMapTexture.Initialize();

            RenderUnit unit = this.RenderUnits[0];
            ShaderProgram program = unit.Program;
            program.SetUniform("heightMapTexture", heightMapTexture);

            this.heightTexture = heightMapTexture;
        }
    }
}
