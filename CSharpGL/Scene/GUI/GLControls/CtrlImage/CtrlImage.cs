using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// A rectangle control that displays an image.
    /// </summary>
    public class CtrlImage : GLControl
    {
        /// <summary>
        /// 
        /// </summary>
        public CtrlImage()
        {
            this.Renderer = new CtrlImageRenderer();
        }
    }
}
