using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A rectangle control that displays an image.
    /// </summary>
    public class CtrlButton : GLControl
    {
        /// <summary>
        /// 
        /// </summary>
        public CtrlButton()
        {
            this.Renderer = new CtrlButtonRenderer();
            this.Renderer.Initialize();
        }
    }
}
