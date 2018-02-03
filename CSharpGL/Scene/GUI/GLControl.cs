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
        public GLControl(GUIAnchorStyles anchor)
        {
            this.Id = idCounter++;
            this.Children = new GLControlChildren(this);

            this.Anchor = anchor;
        }
    }
}
