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
    class UIColorPaletteColoredBarRenderer : UIRenderer
    {

        private CodedColor[] codedColors;

        /// <summary>
        /// 彩色的色标带。
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIColorPaletteColoredBarRenderer(
            int maxMarkerCount,
            CodedColor[] codedColors,
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            this.codedColors = codedColors;

            var model = new QuadStripColoredModel(maxMarkerCount, codedColors.GetBitmap(1024));
            this.Renderer = QuadStripColoredRenderer.Create(model);
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

        //public void UpdateCodedColor(CodedColor[] codedColors)
        //{
        //    var renderer = this.Renderer as QuadStripColoredRenderer;
        //    if (renderer != null)
        //    {
        //        renderer.UpdateCodedColor(codedColors);
        //    }
        //}
        public void UpdateColorBar(Bitmap bitmap)
        {
            var renderer = this.Renderer as QuadStripColoredRenderer;
            if (renderer != null)
            {
                renderer.UpdateColorBar(bitmap);
            }
        }
    }
}
