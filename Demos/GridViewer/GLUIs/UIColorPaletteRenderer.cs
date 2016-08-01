using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    class UIColorPaletteRenderer : UIRenderer
    {
        List<UIText> labelList = new List<UIText>();
        const int marginLeft = 50;
        const int marginRight = 50;
        /// <summary>
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        /// <param name="size"></param>
        /// <param name="zNear"></param>
        /// <param name="zFar"></param>
        public UIColorPaletteRenderer(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
            : base(anchor, margin, size, zNear, zFar)
        {
            this.Name = this.GetType().Name;
            this.SwitchList.Add(new ClearColorSwitch());

            {
                var bar = new UIColorPaletteBarRenderer(
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                new System.Windows.Forms.Padding(marginLeft, 1, marginRight, 0),
                new System.Drawing.Size(size.Width - 100, size.Height / 3),
                zNear, zFar);
                this.Children.Add(bar);
            }
            {
                var markers = new UIColorPaletteMarkersRenderer(
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                new System.Windows.Forms.Padding(marginLeft + 10, 10, marginRight + 10, 50),
                new System.Drawing.Size(size.Width - marginLeft - marginRight, size.Height / 3),
                zNear, zFar);
                this.Children.Add(markers);
            }
            {
                var font = new Font("Arial", 32);
                int length = 5;
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
                    label.Text = ((float)i).ToShortString();
                    label.beforeLayout += label_beforeLayout;
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

        protected override void DoInitialize()
        {
            base.DoInitialize();

            foreach (var item in this.Children)
            {
                item.Initialize();
            }
        }

        protected override void DoRender(RenderEventArg arg)
        {
            base.DoRender(arg);
        }
    }
}
