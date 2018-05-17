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
    public abstract partial class CtrlRoot : GLControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public CtrlRoot(int width, int height)
            : base(GUIAnchorStyles.Left | GUIAnchorStyles.Bottom | GUIAnchorStyles.Right | GUIAnchorStyles.Top)
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
