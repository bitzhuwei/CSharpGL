using SharpFont;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// 实现在OpenGL窗口中的UI布局
    /// </summary>
    public static class ILayoutHelper
    {
        public static mat4 GetOrthoProjection(this ILayout uiRenderer)
        {
            float length = Math.Max(uiRenderer.Size.Width, uiRenderer.Size.Height) / 2;
            return glm.ortho(
                -uiRenderer.Size.Width / 2,
                uiRenderer.Size.Width / 2,
                -uiRenderer.Size.Height / 2,
                uiRenderer.Size.Height / 2,
                -length,
                length);
            //uiRenderer.zNear, uiRenderer.zFar);
        }

        /// <summary>
        /// 实现在OpenGL窗口中的UI布局
        /// </summary>
        /// <param name="uiRenderer"></param>
        internal static void Layout(this ILayout uiRenderer)
        {
            ILayout parent = uiRenderer.Parent;
            if (parent != null)
            {
                NonRootNodeLayout(uiRenderer, parent);
            }

            foreach (var item in uiRenderer.Children)
            {
                item.Layout();
            }

            if (parent != null)
            {
                uiRenderer.ParentLastSize = parent.Size;
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
                //width = currentNode.Size.Width + (parent.Size.Width - currentNode.ParentLastSize.Width);
                if (width < 0) { width = 0; }
            }
            else
            {
                width = currentNode.Size.Width;
            }

            if ((currentNode.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                height = parent.Size.Height - currentNode.Margin.Top - currentNode.Margin.Bottom;
                //height = currentNode.Size.Height + (parent.Size.Height - currentNode.ParentLastSize.Height);
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
                x = currentNode.Margin.Left + parent.Location.X;
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
                y = currentNode.Margin.Top + parent.Location.Y;
            }
            else
            { throw new Exception("This should not happen!"); }

            currentNode.Location = new System.Drawing.Point(x, y);
            currentNode.Size = new Size(width, height);
        }

    }
}
