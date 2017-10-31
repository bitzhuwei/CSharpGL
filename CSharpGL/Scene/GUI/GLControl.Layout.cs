using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class GLControl
    {
        /// <summary>
        /// 获取或设置控件绑定到的容器的边缘并确定控件如何随其父级一起调整大小。
        /// </summary>
        [Category(strGLControl)]
        public GUIAnchorStyles Anchor { get; set; }

        /// <summary>
        /// 获取或设置控件之间的空间。
        /// </summary>
        [Category(strGLControl)]
        public GUIPadding Margin { get; set; }

        /// <summary>
        /// 相对于Parent左下角的位置(Left Down location)
        /// </summary>
        [Category(strGLControl)]
        public GUIPoint Location { get; set; }

        /// <summary>
        /// Stores width when <see cref="Anchor"/>.Left &amp; <see cref="Anchor"/>.Right is <see cref="Anchor"/>.None.
        /// <para> and height when <see cref="Anchor"/>.Top &amp; <see cref="Anchor"/>.Bottom is <see cref="Anchor"/>.None.</para>
        /// </summary>
        [Category(strGLControl)]
        public GUISize Size
        {
            get { return new GUISize(width, height); }
            set { this.width = value.Width; this.height = value.Height; }
        }

        private int width;
        /// <summary>
        /// Width of this control.
        /// </summary>
        [Category(strGLControl)]
        [Description("Width of this control.")]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;
        /// <summary>
        /// Height of this control.
        /// </summary>
        [Category(strGLControl)]
        [Description("Height of this control.")]
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// 上次更新之后，parent的Size属性值。
        /// </summary>
        private GUISize parentLastSize;

        /// <summary>
        ///
        /// </summary>
        [Category(strGLControl)]
        public int zNear { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Category(strGLControl)]
        public int zFar { get; set; }

        /// <summary>
        /// Do something before layout of this control and its children controls.
        /// </summary>
        [Category(strGLControl)]
        public event EventHandler<CancelEventArgs> BeforeLayout;
        /// <summary>
        /// Do something after layout of this control and its children controls.
        /// </summary>
        [Category(strGLControl)]
        public event EventHandler AfterLayout;

        private bool DoBeforeLayout()
        {
            bool result = false;

            var beforeLayout = this.BeforeLayout;
            if (beforeLayout != null)
            {
                var args = new CancelEventArgs();

                beforeLayout(this, args);

                result = args.Cancel;
            }

            return result;
        }

        private void DoAfterLayout()
        {
            var beforeLayout = this.AfterLayout;
            if (beforeLayout != null)
            {
                beforeLayout(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected int absLeft;
        /// <summary>
        /// 
        /// </summary>
        protected int absBottom;

        /// <summary>
        /// Layout for this control.
        /// </summary>
        public virtual void UpdateAbsoluteLocation()
        {
            GLControl parent = this.Parent;
            if (parent != null)
            {
                this.absLeft = parent.Margin.Left + this.Margin.Left;
                this.absBottom = parent.Margin.Bottom + this.Margin.Bottom;
            }
            else
            {
                this.absLeft = this.Margin.Left;
                this.absBottom = this.Margin.Bottom;
            }
        }

        /// <summary>
        /// layout controls in OpenGL canvas.(
        /// Updates absolute and relative (location and size) of specified node and its children nodes.
        /// <para>This coordinate system is shown as below.</para>
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
        public static void Layout(GLControl node)
        {
            if (node == null) { return; }

            var layoutEvent = node;
            bool cancelTreeLayout = layoutEvent.DoBeforeLayout();

            var parent = node.Parent;
            if ((parent != null) && (!cancelTreeLayout))
            {
                NonRootNodeLayout(node, parent);
            }

            layoutEvent.DoAfterLayout();

            node.UpdateAbsoluteLocation();

            foreach (var item in node.Children)
            {
                GLControl.Layout(item);
            }

            if (parent != null)
            {
                node.parentLastSize = parent.Size;
            }
        }

        /// <summary>
        /// leftRightAnchor = (AnchorStyles.Left | AnchorStyles.Right);
        /// </summary>
        private const GUIAnchorStyles leftRightAnchor = (GUIAnchorStyles.Left | GUIAnchorStyles.Right);

        /// <summary>
        /// topBottomAnchor = (AnchorStyles.Top | AnchorStyles.Bottom);
        /// </summary>
        private const GUIAnchorStyles topBottomAnchor = (GUIAnchorStyles.Top | GUIAnchorStyles.Bottom);

        /// <summary>
        /// Updates <paramref name="currentNode"/>'s location and size according to its state and parent's information.
        /// </summary>
        /// <param name="currentNode"></param>
        /// <param name="parent"></param>
        private static void NonRootNodeLayout(GLControl currentNode, GLControl parent)
        {
            int x, y, width, height;
            if ((currentNode.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                width = parent.Width - currentNode.Margin.Left - currentNode.Margin.Right;
                //width = currentNode.Size.Width + (parent.Size.Width - currentNode.ParentLastSize.Width);
                if (width < 0) { width = 0; }
            }
            else
            {
                width = currentNode.Width;
            }

            if ((currentNode.Anchor & topBottomAnchor) == topBottomAnchor)
            {
                height = parent.Height - currentNode.Margin.Top - currentNode.Margin.Bottom;
                //height = currentNode.Size.Height + (parent.Size.Height - currentNode.ParentLastSize.Height);
                if (height < 0) { height = 0; }
            }
            else
            {
                height = currentNode.Height;
            }

            if ((currentNode.Anchor & leftRightAnchor) == GUIAnchorStyles.None)
            {
                if (currentNode.Margin.Left == 0)
                {
                    x = 0;
                }
                else
                {
                    if (currentNode.Margin.Right == 0)
                    {
                        x = parent.width - width;
                    }
                    else
                    {
                        x = (int)(
                            (parent.Width - width)
                            * ((double)currentNode.Margin.Left / (double)(currentNode.Margin.Left + currentNode.Margin.Right)));
                    }
                }
            }
            else if ((currentNode.Anchor & leftRightAnchor) == GUIAnchorStyles.Left)
            {
                x = parent.Location.X + currentNode.Margin.Left;
            }
            else if ((currentNode.Anchor & leftRightAnchor) == GUIAnchorStyles.Right)
            {
                x = parent.Location.X + parent.Size.Width - currentNode.Margin.Right - width;
            }
            else if ((currentNode.Anchor & leftRightAnchor) == leftRightAnchor)
            {
                x = parent.Location.X + currentNode.Margin.Left;
            }
            else
            { throw new Exception("uiRenderer should not happen!"); }

            if ((currentNode.Anchor & topBottomAnchor) == GUIAnchorStyles.None)
            {
                if (currentNode.Margin.Bottom == 0)
                {
                    y = 0;
                }
                else
                {
                    if (currentNode.Margin.Top == 0)
                    {
                        y = parent.Height - height;
                    }
                    else
                    {
                        y = (int)(
                            (parent.Height - height)
                            * ((double)currentNode.Margin.Bottom / (double)(currentNode.Margin.Bottom + currentNode.Margin.Top)));
                    }
                }
            }
            else if ((currentNode.Anchor & topBottomAnchor) == GUIAnchorStyles.Bottom)
            {
                //y = currentNode.Margin.Bottom;
                y = parent.Location.Y + currentNode.Margin.Bottom;
            }
            else if ((currentNode.Anchor & topBottomAnchor) == GUIAnchorStyles.Top)
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

            currentNode.Location = new GUIPoint(x, y);
            currentNode.Size = new GUISize(width, height);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CancelEventArgs : EventArgs
    {
        /// <summary>
        /// 是否取消接下来对自己的布局操作。
        /// <para>Indicates whether to cancel the coming layout operation for this node.</para>
        /// </summary>
        public bool Cancel { get; set; }
    }
}
