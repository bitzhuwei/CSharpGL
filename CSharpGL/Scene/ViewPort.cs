using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ViewPort : ILayout<ViewPort>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="camera"></param>
        public ViewPort(Rectangle rect, ICamera camera)
        {
            this.Rect = rect;
            this.Camera = camera;
        }

        /// <summary>
        /// 
        /// </summary>
        public Rectangle Rect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICamera Camera { get; private set; }

    }
}
