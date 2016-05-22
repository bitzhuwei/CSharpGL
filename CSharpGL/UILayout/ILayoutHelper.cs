using SharpFont;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// 实现在OpenGL窗口中的UI布局
    /// </summary>
    public static class ILayoutHelper
    {
        /// <summary>
        /// 实现在OpenGL窗口中的UI布局
        /// </summary>
        /// <param name="uiRenderer"></param>
        public static void Layout(this ILayout uiRenderer)
        {
            if (uiRenderer.Container != null)
            {
                NonRootNodeLayout(uiRenderer, uiRenderer.Container);
            }

            foreach (var item in uiRenderer.Controls)
            {
                item.Layout();
            }
        }

        /// <summary>
        /// leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right); 
        /// </summary>
        private const AnchorStyles leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right);

        /// <summary>
        /// topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);
        /// </summary>
        private const AnchorStyles topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);

        private static void NonRootNodeLayout(ILayout currentNode, ILayout parent)
        {
            int x, y, width, height;
            if ((currentNode.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                width = parent.Size.Width - currentNode.Margin.Left - currentNode.Margin.Right;
                if (width < 0) { width = 0; }
            }
            else
            {
                width = currentNode.Size.Width;
            }

            if ((currentNode.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                height = parent.Size.Height - currentNode.Margin.Top - currentNode.Margin.Bottom;
                if (height < 0) { height = 0; }
            }
            else
            {
                height = currentNode.Size.Height;
            }

            if ((currentNode.Anchor & leftRightAnchor) == AnchorStyles.None)
            {
                x = (int)(
                    (parent.Size.Width - width)
                    * ((double)currentNode.Margin.Left / (double)(currentNode.Margin.Left + currentNode.Margin.Right)));
            }
            else if ((currentNode.Anchor & leftRightAnchor) == AnchorStyles.Left)
            {
                x = currentNode.Margin.Left;
            }
            else if ((currentNode.Anchor & leftRightAnchor) == AnchorStyles.Right)
            {
                x = parent.Size.Width - width - currentNode.Margin.Right;
            }
            else if ((currentNode.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                x = currentNode.Margin.Left;
            }
            else
            { throw new Exception("uiRenderer should not happen!"); }

            if ((currentNode.Anchor & topBottomAnchor) == AnchorStyles.None)
            {
                y = (int)(
                    (parent.Size.Height - height)
                    * ((double)currentNode.Margin.Bottom / (double)(currentNode.Margin.Bottom + currentNode.Margin.Top)));
            }
            else if ((currentNode.Anchor & topBottomAnchor) == AnchorStyles.Bottom)
            {
                y = currentNode.Margin.Bottom;
            }
            else if ((currentNode.Anchor & topBottomAnchor) == AnchorStyles.Top)
            {
                y = parent.Size.Height - height - currentNode.Margin.Top;
            }
            else if ((currentNode.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                y = currentNode.Margin.Bottom;
            }
            else
            { throw new Exception("uiRenderer should not happen!"); }

            currentNode.Location = new System.Drawing.Point(x, y);
            currentNode.Size = new Size(width, height);
        }

    }
}
