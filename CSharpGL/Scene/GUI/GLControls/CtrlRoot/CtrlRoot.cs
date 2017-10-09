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
        /// <param name="canvas"></param>
        public abstract void Bind(IGLCanvas canvas);

        /// <summary>
        /// 
        /// </summary>
        public abstract void Unbind();

    }
}
