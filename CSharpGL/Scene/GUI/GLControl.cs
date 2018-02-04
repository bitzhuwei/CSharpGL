using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Control(widget) in OpenGL window.
    /// </summary>
    public abstract partial class GLControl : IGUIRenderable//, IDisposable
    {
        private const string strGLControl = "GLControl";
        private static int idCounter = 0;

        /// <summary>
        /// distance to parent's left border.
        /// </summary>
        private int left;

        /// <summary>
        /// this control's width.
        /// </summary>
        private int width;

        /// <summary>
        /// distance to parent's bottom border.
        /// </summary>
        private int bottom;

        /// <summary>
        /// distance to parent's right border.
        /// </summary>
        protected int right;

        /// <summary>
        /// distance to parent's top border.
        /// </summary>
        protected int top;

        /// <summary>
        /// this control's height.
        /// </summary>
        private int height;

        /// <summary>
        /// distance to root control's left border.
        /// </summary>
        protected int absLeft;

        /// <summary>
        /// distance to root control's bottom border.
        /// </summary>
        protected int absBottom;

        //private static readonly GUIAnchorStyles noneAnchor = GUIAnchorStyles.None;
        private static readonly GUIAnchorStyles leftAnchor = GUIAnchorStyles.Left;
        private static readonly GUIAnchorStyles rightAnchor = GUIAnchorStyles.Right;
        private static readonly GUIAnchorStyles bottomAnchor = GUIAnchorStyles.Bottom;
        private static readonly GUIAnchorStyles topAnchor = GUIAnchorStyles.Top;
        private static readonly GUIAnchorStyles leftRightAnchor = GUIAnchorStyles.Left | GUIAnchorStyles.Right;
        private static readonly GUIAnchorStyles bottomTopAnchor = GUIAnchorStyles.Bottom | GUIAnchorStyles.Top;

        /// <summary>
        /// 用OpenGL初始化和渲染一个模型。
        /// <para>Initialize and render something with OpenGL.</para>
        /// </summary>
        /// <param name="anchor"></param>
        public GLControl(GUIAnchorStyles anchor)
        {
            this.Id = idCounter++;
            this.Children = new GLControlChildren(this);

            this.Anchor = anchor;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0}]: [{1}]", this.Id, this.GetType().Name);
        }

    }
}
