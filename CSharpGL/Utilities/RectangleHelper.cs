using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public static class RectangleHelper
    {
        public static vec4 ToViewport(this Rectangle rect)
        {
            return new vec4(rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
}
