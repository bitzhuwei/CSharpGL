using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// 像Winform窗口里的控件一样的控件。
    /// </summary>
    public partial class GLControl
    {

        /// <summary>
        /// 相对于<see cref="Container"/>左下角的位置(Left Down location)
        /// </summary>
        protected System.Drawing.Point realLocation = new System.Drawing.Point();
        /// <summary>
        /// 实际大小
        /// </summary>
        protected System.Drawing.Size realSize = new System.Drawing.Size();

        public GLControl(
            System.Windows.Forms.AnchorStyles anchor, System.Windows.Forms.Padding margin,
            System.Drawing.Size size, int zNear, int zFar)
        {
            this.Anchor = anchor; this.Margin = margin;
            this.Size = size; this.zNear = zNear; this.zFar = zFar;
            this.realSize = size;
        }


        public virtual void Layout()
        {
            if (this.Container == null)
            {
                RootNodeLayout();
            }
            else
            {
                NonRootNodeLayout(this.Container);
            }
        }


        /// <summary>
        /// leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right); 
        /// </summary>
        protected const AnchorStyles leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right);

        /// <summary>
        /// topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);
        /// </summary>
        protected const AnchorStyles topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);

        protected void NonRootNodeLayout(GLContainer container)
        {
            int x, y, width, height;
            if ((this.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                width = container.realSize.Width - this.Margin.Left - this.Margin.Right;
                if (width < 0) { width = 0; }
            }
            else
            {
                width = this.Size.Width;
            }

            if ((this.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                height = container.realSize.Height - this.Margin.Top - this.Margin.Bottom;
                if (height < 0) { height = 0; }
            }
            else
            {
                height = this.Size.Height;
            }

            if ((this.Anchor & leftRightAnchor) == AnchorStyles.None)
            {
                x = (int)(
                    (container.realSize.Width - width)
                    * ((double)this.Margin.Left / (double)(this.Margin.Left + this.Margin.Right)));
            }
            else if ((this.Anchor & leftRightAnchor) == AnchorStyles.Left)
            {
                x = this.Margin.Left;
            }
            else if ((this.Anchor & leftRightAnchor) == AnchorStyles.Right)
            {
                x = container.realSize.Width - width - this.Margin.Right;
            }
            else if ((Anchor & leftRightAnchor) == leftRightAnchor)
            {
                x = this.Margin.Left;
            }
            else
            { throw new Exception("This should not happen!"); }

            if ((this.Anchor & topBottomAnchor) == AnchorStyles.None)
            {
                y = (int)(
                    (container.realSize.Height - height)
                    * ((double)this.Margin.Bottom / (double)(this.Margin.Bottom + this.Margin.Top)));
            }
            else if ((this.Anchor & topBottomAnchor) == AnchorStyles.Bottom)
            {
                y = this.Margin.Bottom;
            }
            else if ((this.Anchor & topBottomAnchor) == AnchorStyles.Top)
            {
                y = container.realSize.Height - height - this.Margin.Top;
            }
            else if ((Anchor & topBottomAnchor) == topBottomAnchor)
            {
                y = this.Margin.Bottom;
            }
            else
            { throw new Exception("This should not happen!"); }

            this.realLocation.X = x;
            this.realLocation.Y = y;
            this.realSize.Width = width;
            this.realSize.Height = height;
        }

        protected void RootNodeLayout()
        {
            this.realLocation = new System.Drawing.Point(0, 0);
            this.realSize = this.Size;
        }


    }
}
