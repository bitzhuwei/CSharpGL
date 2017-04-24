using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class RectangleHelper
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        public static vec4 ToViewport(this Rectangle rect)
        {
            return new vec4(rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
}