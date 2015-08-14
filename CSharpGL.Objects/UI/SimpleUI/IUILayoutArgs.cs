using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL.Objects.UI.SimpleUI
{
    /// <summary>
    /// pass viewport and UI's rect information.
    /// </summary>
    internal class IUILayoutArgs
    {
        /// <summary>
        /// viewport's width.
        /// </summary>
        public int viewWidth;

        /// <summary>
        /// viewport's height.
        /// </summary>
        public int viewHeight;

        /// <summary>
        /// UI's width in viewport.
        /// </summary>
        public int UIWidth;

        /// <summary>
        /// UI's height in viewHeight.
        /// </summary>
        public int UIHeight;

        /// <summary>
        /// left in gl.Ortho(left, right, bottom, top, zNear, zFar);
        /// </summary>
        public double left;

        /// <summary>
        /// bottom in gl.Ortho(left, right, bottom, top, zNear, zFar);
        /// </summary>
        public double bottom;

        /// <summary>
        /// right in gl.Ortho(left, right, bottom, top, zNear, zFar);
        /// </summary>
        public double right { get { return left + viewWidth; } }

        /// <summary>
        /// top in gl.Ortho(left, right, bottom, top, zNear, zFar);
        /// </summary>
        public double top { get { return bottom + viewHeight; } }

        public override string ToString()
        {
            return string.Format("viewport:{0}, {1}, UI: {2}, {3}, ortho: {4}, {5}, {6}, {7}",
                viewWidth, viewHeight, UIWidth, UIHeight, left, right, bottom, top);
        }
    }
}
