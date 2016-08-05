using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    /// <summary>
    /// 彩色的色标带。
    /// </summary>
    class UIColorPaletteBarRenderer : UIRenderer
    {

        private sampler1D colorPaletteBarSampler;
        private QuadStripRenderer.ColorType colorType;

        public sampler1D ColorPaletteBarSampler
        {
            get { return colorPaletteBarSampler; }
        }

        private CodedColor[] codedColors;

        /// <summary>
        /// 彩色的色标带。
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIColorPaletteBarRenderer(int maxMarkerCount,
            CodedColor[] codedColors, GridViewer.QuadStripRenderer.ColorType colorType,
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            this.codedColors = codedColors;
            this.colorType = colorType;

            if (colorType == QuadStripRenderer.ColorType.Color)
            {
                Bitmap bitmap = codedColors.GetBitmap(1024);
                var model = new QuadStripModel(maxMarkerCount - 1, bitmap);
                this.Renderer = QuadStripRenderer.Create(model, colorType);
            }
            else if (colorType == QuadStripRenderer.ColorType.Texture)
            {
                var model = new QuadStripModel(maxMarkerCount - 1);
                this.Renderer = QuadStripRenderer.Create(model, colorType);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            if (this.colorType == QuadStripRenderer.ColorType.Texture)
            {
                var texture = new sampler1D();
                Bitmap bitmap = this.codedColors.GetBitmap(1024);
                this.codedColors = null;
                texture.Initialize(bitmap);
                this.colorPaletteBarSampler = texture;
                bitmap.Dispose();
                var renderer = this.Renderer as Renderer;
                renderer.SetUniform("codedColorSampler", new samplerValue(BindTextureTarget.Texture1D,
                    texture.Id, OpenGL.GL_TEXTURE0));
            }
            else if (this.colorType == QuadStripRenderer.ColorType.Color)
            { }
            else
            { throw new NotImplementedException(); }
        }

        protected override void DoRender(RenderEventArg arg)
        {
            mat4 projection = this.GetOrthoProjection();
            mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            float length = this.Size.Height;
            mat4 model = glm.scale(mat4.identity(), new vec3(this.Size.Width - 1, this.Size.Height - 1, 1));// '-1' to make sure lines shows up.
            var renderer = this.Renderer as Renderer;
            renderer.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }

        public bool UpdateTexture(Bitmap bitmap)
        {
            if (this.colorType == QuadStripRenderer.ColorType.Texture)
            {
                var textureUpdater = new TextureUpdater(this.colorPaletteBarSampler.Id);

                return textureUpdater.UpdateTexture(bitmap);
            }
            else if (this.colorType == QuadStripRenderer.ColorType.Color)
            { return false; }
            else
            { throw new NotImplementedException(); }
        }

        public void UpdateCodedColor(CodedColor[] codedColors)
        {
            var renderer = this.Renderer as QuadStripRenderer;
            if (renderer != null)
            {
                renderer.UpdateCodedColor(codedColors);
            }
        }
    }
}
