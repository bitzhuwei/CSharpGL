using System;
using System.Drawing;

using System.Windows.Forms;

namespace CSharpGL
{
    /// <summary>
    /// layout controls in OpenGL canvas.
    /// </summary>
    public static class ILayoutHelper
    {
        /// <summary>
        /// Gets projection matrix for <see cref="ILayout&lt;T&gt;"/> to layout controls in OpenGL canvas.
        /// </summary>
        /// <param name="uiRenderer"></param>
        /// <returns></returns>
        public static mat4 GetOrthoProjection(this UIRenderer uiRenderer)
        {
            float halfWidth = uiRenderer.Size.Width / 2.0f;
            float halfHeight = uiRenderer.Size.Height / 2.0f;
            //float halfDepth = Math.Max(halfWidth, halfHeight);
            //halfDepth = Math.Max(halfDepth, Math.Abs(uiRenderer.zNear));
            //halfDepth = Math.Max(halfDepth, Math.Abs(uiRenderer.zFar));
            return glm.ortho(-halfWidth, halfWidth, -halfHeight, halfHeight,
                uiRenderer.zNear, uiRenderer.zFar);
        }

        /// <summary>
        /// layout controls in OpenGL canvas.
        /// <para>This coordinate system is as below.</para>
        /// <para>   /\ y</para>
        /// <para>   |</para>
        /// <para>   |</para>
        /// <para>   |</para>
        /// <para>   |</para>
        /// <para>   |</para>
        /// <para>   |-----------------&gt;x</para>
        /// <para>(0, 0)</para>
        /// </summary>
        /// <param name="node"></param>
        public static void Layout<T>(this ILayout<T> node) where T : ILayout<T>, ILayoutEvent
        {
            var layoutEvent = node.Self as ILayoutEvent;
            if (layoutEvent == null)
            {
                throw new Exception(string.Format(
                    "node.Self should not be null!"));
            }
            bool cancelTreeLayout = layoutEvent.DoBeforeLayout();

            ILayout<T> parent = node.Parent;
            if ((parent != null) && (!cancelTreeLayout))
            {
                NonRootNodeLayout(node, parent);
            }

            layoutEvent.DoAfterLayout();

            foreach (T item in node.Children)
            {
                item.Layout();
            }

            if (parent != null)
            {
                node.ParentLastSize = parent.Size;
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

        /// <summary>
        /// Gets <paramref name="currentNode"/>'s location and size according to its state and parent's information.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="parent"></param>
        private static void NonRootNodeLayout<T>(ILayout<T> currentNode, ILayout<T> parent) where T : ITreeNode<T>
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
                x = parent.Location.X + currentNode.Margin.Left;
            }
            else if ((currentNode.Anchor & leftRightAnchor) == AnchorStyles.Right)
            {
                x = parent.Location.X + parent.Size.Width - currentNode.Margin.Right - width;
            }
            else if ((currentNode.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                x = parent.Location.X + currentNode.Margin.Left;
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
                //y = currentNode.Margin.Bottom;
                y = parent.Location.Y + currentNode.Margin.Bottom;
            }
            else if ((currentNode.Anchor & topBottomAnchor) == AnchorStyles.Top)
            {
                //y = parent.Size.Height - height - currentNode.Margin.Top;
                y = parent.Location.Y + parent.Size.Height - currentNode.Margin.Top - height;
            }
            else if ((currentNode.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                //y = currentNode.Margin.Top + parent.Location.Y;
                y = parent.Location.Y + currentNode.Margin.Bottom;
            }
            else
            { throw new Exception("This should not happen!"); }

            currentNode.Location = new System.Drawing.Point(x, y);
            currentNode.Size = new Size(width, height);
        }
    }
}