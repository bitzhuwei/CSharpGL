using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// <param name="bitmap">bitmap to be displayed.</param>
        /// <param name="autoDispose">auto dispose <paramref name="bitmap"/> after this object's initialization.</param>
        public CtrlImage(Bitmap bitmap, bool autoDispose = false)
        {
            this.Renderer = new CtrlImageRenderer(bitmap, autoDispose);
            this.Renderer.Initialize();
        }

    }
}
