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
    public abstract partial class GLControl : IGUIRenderable, IDisposable
    {
        internal GLControl parent;
        /// <summary>
        /// Parent control.
        /// </summary>
        [Category(strGLControl)]
        [Description("Parent control. This node inherits parent's layout properties.")]
        public GLControl Parent
        {
            get { return this.parent; }
            set
            {
                GLControl old = this.parent;
                if (old != value)
                {
                    this.parent = value;

                    if (value == null) // parent != null
                    {
                        old.Children.Remove(this);
                    }
                    else // value != null && parent == null
                    {
                        value.Children.Add(this);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Category(strGLControl)]
        [Description("Children Nodes. Inherits this node's IWorldSpace properties.")]
        public GLControlChildren Children { get; private set; }

        ///// <summary>
        ///// Left distance to parent control.
        ///// </summary>
        //[Category(strGLControl)]
        //public int Left { get; set; }

        ///// <summary>
        ///// Bottom distance to parent control.
        ///// </summary>
        //[Category(strGLControl)]
        //public int Bottom { get; set; }

        /// <summary>
        /// Width of this control.
        /// </summary>
        [Category(strGLControl)]
        public int Width { get; set; }

        /// <summary>
        /// Height of this control.
        /// </summary>
        [Category(strGLControl)]
        public int Height { get; set; }

        private const string strGLControl = "GLControl";

        /// <summary>
        /// 为便于调试而设置的ID值，没有应用意义。
        /// <para>for debugging purpose only.</para>
        /// </summary>
        [Category(strGLControl)]
        [Description("为便于调试而设置的ID值，没有应用意义。(for debugging purpose only.)")]
        public int Id { get; private set; }

        private static int idCounter = 0;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0}]: [{1}]", this.Id, this.GetType().Name);
        }

        /// <summary>
        /// 用OpenGL初始化和渲染一个模型。
        /// <para>Initialize and render something with OpenGL.</para>
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="margin"></param>
        public GLControl(GUIAnchorStyles anchor, GUIPadding margin)
        {
            this.Id = idCounter++;
            this.Children = new GLControlChildren(this);

            this.Anchor = anchor;
            this.Margin = margin;
        }
    }
}
