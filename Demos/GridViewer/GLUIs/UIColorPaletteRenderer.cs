using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridViewer
{
    class UIColorPaletteRenderer : UIRenderer
    {

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

            var bar = new UIColorPaletteBarRenderer(
                System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                new System.Windows.Forms.Padding(50, 5, 50, 50),
                new System.Drawing.Size(size.Width - 100, size.Height - 10),
                zNear, zFar);
            this.Children.Add(bar);
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
