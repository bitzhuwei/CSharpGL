using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    /// <summary>
    /// color palette.
    /// 在窗口固定位置显示的色标。
    /// 本类型只圈定了一个矩形范围。
    /// </summary>
    class UIColorPaletteRenderer : UIRenderer
    {
        List<UIText> labelList = new List<UIText>();
        const int marginLeft = 50;
        const int marginRight = 50;
        private int maxMarkerCount;
        /// <summary>
        /// renders a color palette bar with 1-D texture and its coordiante(float).
        /// </summary>
        private UIColorPaletteBarRenderer colorPaletteBar;
        /// <summary>
        /// renders a color palette bar with direct color(vec3).
        /// Compare this with colorPaletteBar to check if there's difference.
        /// </summary>
        private UIColorPaletteBarRenderer colorPaletteBar2;

        /// <summary>
        /// Shows color palette bar rendered with direct color(vec3).
        /// </summary>
        [Description("Shows color palette bar rendered with direct color(vec3).")]
        public bool ShowColorBar
        {
            get
            {
                if (this.colorPaletteBar2 == null) { return false; }

                return this.colorPaletteBar2.Enabled;
            }
            set
            {
                RendererBase renderer = this.colorPaletteBar2;
                if (renderer != null) { renderer.Enabled = value; }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIColorPaletteRenderer(int maxMarkerCount,
            CodedColor[] codedColors,
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            this.maxMarkerCount = maxMarkerCount;
            this.SwitchList.Add(new ClearColorSwitch());

            {
                var bar = new UIColorPaletteBarRenderer(maxMarkerCount, codedColors, QuadStripRenderer.ColorType.Texture,
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                new System.Windows.Forms.Padding(marginLeft, 1, marginRight, 0),
                new System.Drawing.Size(size.Width - 100, size.Height / 3),
                zNear, zFar);
                //this.SwitchList.Add(new ClearColorSwitch(Color.Blue));
                this.colorPaletteBar = bar;
                this.Children.Add(bar);
            }
            {
                var bar = new UIColorPaletteBarRenderer(maxMarkerCount, codedColors, QuadStripRenderer.ColorType.Color,
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                new System.Windows.Forms.Padding(marginLeft, 1 + size.Height / 3 + 1, marginRight, 0),
                new System.Drawing.Size(size.Width - 100, size.Height / 3),
                zNear, zFar);
                //this.SwitchList.Add(new ClearColorSwitch(Color.Blue));
                this.colorPaletteBar2 = bar;
                this.Children.Add(bar);
                bar.Enabled = false;
            }
            {
                var markers = new UIColorPaletteMarkersRenderer(maxMarkerCount,
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                new System.Windows.Forms.Padding(marginLeft, 10, marginRight, 50),
                new System.Drawing.Size(size.Width - marginLeft - marginRight, size.Height / 3),
                zNear, zFar);
                //markers.SwitchList.Add(new ClearColorSwitch(Color.Red));
                this.Children.Add(markers);
            }
            {
                int length = maxMarkerCount;
                var font = new Font("Arial", 32);
                for (int i = 0; i < length; i++)
                {
                    const int width = 100;
                    float distance = marginLeft;
                    distance += 2.0f * (float)i / (float)length * (float)(this.Size.Width - marginLeft - marginRight);
                    distance -= width / 2;
                    var label = new UIText(
                        System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Bottom,
                        new System.Windows.Forms.Padding((int)distance, 0, 0, 0),
                        new System.Drawing.Size(width, size.Height / 2), zNear, zFar,
                        font.GetFontBitmap("0123456789.eE+-").GetFontTexture(), 100);
                    label.Initialize();
                    //label.SwitchList.Add(new ClearColorSwitch(Color.Green));
                    label.Text = ((float)i).ToShortString();
                    label.BeforeLayout += label_beforeLayout;
                    this.Children.Add(label);
                    this.labelList.Add(label);
                }
            }
        }

        /// <summary>
        /// adjust label's margin in order to get perfect position after Layout().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void label_beforeLayout(object sender, EventArgs e)
        {
            int length = this.labelList.Count - 1;
            var label = sender as UIText;
            int index = this.labelList.IndexOf(label);
            float distance = marginLeft;
            distance += (float)index / (float)length * (float)(this.Size.Width - marginLeft - marginRight);
            distance -= label.Size.Width / 2;
            System.Windows.Forms.Padding padding = label.Margin;
            padding.Left = (int)distance;
            label.Margin = padding;
        }

        public bool UpdateBar(Bitmap bitmap)
        {
            UIColorPaletteBarRenderer bar = this.colorPaletteBar;
            if (bar != null)
            { return this.colorPaletteBar.UpdateTexture(bitmap); }
            else
            { return false; }
        }

    }
}
