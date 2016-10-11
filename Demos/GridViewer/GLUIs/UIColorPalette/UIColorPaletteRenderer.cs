using CSharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace GridViewer
{
    /// <summary>
    /// color palette.
    /// 在窗口固定位置显示的色标。
    /// 本类型只圈定了一个矩形范围。
    /// </summary>
    public class UIColorPaletteRenderer : UIRenderer
    {
        private List<UIText> labelList = new List<UIText>();
        private const int marginLeft = 50;
        private const int marginRight = 50;
        private int maxMarkerCount;

        /// <summary>
        /// renders a color palette bar with 1-D texture and its coordiante(float).
        /// </summary>
        private UIColorPaletteBarRenderer colorPaletteBar;

        /// <summary>
        /// renders a color palette bar with direct color(vec3).
        /// Compare this with colorPaletteBar to check if there's difference.
        /// </summary>
        private UIColorPaletteColoredBarRenderer colorPaletteBar2;

        private UIColorPaletteMarkersRenderer markers;

        /// <summary>
        /// current marker's count.
        /// </summary>
        private int currentMarkersCount;

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
            this.currentMarkersCount = maxMarkerCount;

            //// display this UI control's area.
            //this.SwitchList.Add(new ClearColorSwitch());

            // color bar using texture.
            {
                var bar = new UIColorPaletteBarRenderer(
                    codedColors,
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                new System.Windows.Forms.Padding(marginLeft, 1, marginRight, 0),
                new System.Drawing.Size(size.Width - marginLeft - marginRight, size.Height / 3),
                zNear, zFar);
                //this.SwitchList.Add(new ClearColorSwitch(Color.Blue));
                this.LayoutManager.Children.Add(bar.LayoutManager);
                this.colorPaletteBar = bar;
            }
            // color bar using vec3 color(hidden as default state)
            // just to compare with color bar using texture.
            {
                var bar = new UIColorPaletteColoredBarRenderer(
                        maxMarkerCount, codedColors,
                    System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                    new System.Windows.Forms.Padding(marginLeft, 1 + size.Height / 3, marginRight, 0),
                    new System.Drawing.Size(size.Width - marginLeft - marginRight, size.Height / 3),
                    zNear, zFar);
                //this.SwitchList.Add(new ClearColorSwitch(Color.Blue));
                this.LayoutManager.Children.Add(bar.LayoutManager);
                this.colorPaletteBar2 = bar;
                bar.Enabled = false;
            }
            // white vertical lines.
            {
                var markers = new UIColorPaletteMarkersRenderer(maxMarkerCount,
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                new System.Windows.Forms.Padding(marginLeft, 1, marginRight, 0),
                new System.Drawing.Size(size.Width - marginLeft - marginRight, size.Height / 2),
                zNear, zFar);
                //markers.SwitchList.Add(new ClearColorSwitch(Color.Red));
                this.LayoutManager.Children.Add(markers.LayoutManager);
                this.markers = markers;
            }
            // labels that display values(float values)
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
                    this.LayoutManager.Children.Add(label.LayoutManager);
                    this.labelList.Add(label);
                }
                this.currentMarkersCount = 2;
            }
        }

        protected override void DoInitialize()
        {
            base.DoInitialize();

            foreach (var item in this.LayoutManager.Children)
            {
                item.Owner.Initialize();
            }

            this.SetCodedColor(-100, 100, 200);
        }

        /// <summary>
        /// adjust label's margin in order to get perfect position after Layout().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_beforeLayout(object sender, EventArgs e)
        {
            int count = currentMarkersCount - 1;
            var label = sender as UIText;
            int index = this.labelList.IndexOf(label);
            float distance = marginLeft;
            distance += (float)index / (float)count * (float)(this.Size.Width - marginLeft - marginRight);
            distance -= label.Size.Width / 2;
            System.Windows.Forms.Padding padding = label.Margin;
            padding.Left = (int)distance;
            label.Margin = padding;
        }

        public void UpdateBar(Bitmap bitmap)
        {
            this.colorPaletteBar.UpdateTexture(bitmap);
            this.colorPaletteBar2.UpdateColorBar(bitmap);
        }

        //public int Update { get { return 0; } set { this.SetCodedColor(CodedColor.GetDefault()); } }
        public int Update { get { return 0; } set { this.SetCodedColor(0, 100, 11); } }

        //public void SetCodedColor(CodedColor[] codedColors)
        //{
        //    {
        //        Bitmap bitmap = codedColors.GetBitmap(bitmapWidth);
        //        this.colorPaletteBar.UpdateTexture(bitmap);
        //        //this.colorPaletteBar2.UpdateTexture(bitmap);
        //        bitmap.Dispose();
        //    }
        //    {
        //        this.colorPaletteBar.UpdateCodedColor(codedColors);
        //        this.colorPaletteBar2.UpdateCodedColor(codedColors);
        //        //this.markers.UpdateCodedColors(codedColors);
        //    }
        //}

        public const int bitmapWidth = 1024;

        public void SetCodedColor(double axisMin, double axisMax, double step)
        {
            // update markers(white vertical lines).
            {
                this.markers.UpdateCodedColors(axisMin, axisMax, step);
            }
            // update labels.
            {
                int labelCount = (int)((axisMax - axisMin) / step) + 1;
                // valid labels.
                for (int i = 0; i < labelCount - 1; i++)
                {
                    this.labelList[i].Enabled = true;
                    this.labelList[i].Text = string.Format("{0}", axisMin + step * i);
                }
                // last valid label.
                {
                    int i = labelCount - 1;
                    this.labelList[i].Enabled = true;
                    this.labelList[i].Text = string.Format("{0}", axisMax);
                }
                // invalid labels.
                for (int i = labelCount; i < this.maxMarkerCount; i++)
                {
                    this.labelList[i].Enabled = false;
                }
                this.currentMarkersCount = labelCount;
            }
        }

        /// <summary>
        /// sampler for color palette.
        /// </summary>
        public Texture Sampler { get { return this.colorPaletteBar.Sampler; } }
    }
}