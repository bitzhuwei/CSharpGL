using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Root control in control tree.
    /// </summary>
    public abstract class CtrlRoot : GLControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public CtrlRoot(int width, int height)
            : base(GUIAnchorStyles.Left | GUIAnchorStyles.Bottom | GUIAnchorStyles.Right | GUIAnchorStyles.Top, new GUIPadding(0, 0, 0, 0))
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canvas"></param>
        public abstract void Bind(IGLCanvas canvas);

        /// <summary>
        /// 
        /// </summary>
        public abstract void Unbind();

    }
}
