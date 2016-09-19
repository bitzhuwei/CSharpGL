using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// opengl UI for Cursor
    /// </summary>
    public class UICursor : UIRenderer
    {
        /// <summary>
        /// crates default cursor.
        /// Note: put this as the last one of <see cref="UIRoot"/>'s children.
        /// </summary>
        /// <returns></returns>
        public static UICursor CreateDefault()
        {
            return new UICursor(new PointF(0.1f, 0.1f), new Size(25, 25));
        }

        /// <summary>
        /// opengl UI for Cursor.
        /// Note: put this as the last one of <see cref="UIRoot"/>'s children.
        /// </summary>
        /// <param name="focalPoint">in percentage(0.00 ~ 1.00).<paramref name="focalPoint"/>.X ranges from 0(left) to 1(right). <paramref name="focalPoint"/>.Y ranges from 0(bottom) to 1(top).</param>
        /// <param name="size"></param>
        /// <param name="cursorBitmap"></param>
        public UICursor(PointF focalPoint,
            Size size, string cursorBitmap = "")
            : base(AnchorStyles.Left | AnchorStyles.Top,
                    new Padding(0, 0, 0, 0), size, -Math.Max(size.Width, size.Height), Math.Max(size.Width, size.Height))
        {
            this.FocalPoint = focalPoint;
            TextureRenderer renderer = TextureRenderer.Create(cursorBitmap);
            renderer.SwitchList.Add(new BlendSwitch(BlendingSourceFactor.SourceAlpha, BlendingDestinationFactor.OneMinusSourceAlpha));
            this.Renderer = renderer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        protected override void DoRender(RenderEventArgs arg)
        {
            mat4 projection = this.GetOrthoProjection();
            mat4 view = glm.lookAt(new vec3(0, 0, 1), new vec3(0, 0, 0), new vec3(0, 1, 0));
            mat4 model = glm.scale(mat4.identity(), new vec3(this.Size.Width, this.Size.Height, 1));
            var renderer = this.Renderer as Renderer;
            renderer.SetUniform("mvp", projection * view * model);

            base.DoRender(arg);
        }

        /// <summary>
        /// in percentage(0.00 ~ 1.00). FocalPoint.X ranges from 0(left) to 1(right). FocalPoint.Y ranges from 0(bottom) to 1(top)
        /// </summary>
        [Category(strUIRenderer)]
        [Description("Focal point of cursor.")]
        public PointF FocalPoint { get; set; }

        /// <summary>
        /// update cursor's position before every rendering.
        /// </summary>
        /// <param name="mousePosition"></param>
        public void UpdatePosition(Point mousePosition)
        {
            Padding margin = this.Margin;
            margin.Left = mousePosition.X - (int)(this.FocalPoint.X * this.Size.Width);
            margin.Top = mousePosition.Y - (int)(this.FocalPoint.Y * this.Size.Height);
            this.Margin = margin;
        }
    }
}