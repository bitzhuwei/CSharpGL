using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class Viewport
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly int x;
        /// <summary>
        /// 
        /// </summary>
        public readonly int y;
        /// <summary>
        /// 
        /// </summary>
        public readonly int width;
        /// <summary>
        /// 
        /// </summary>
        public readonly int height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Viewport(int x, int y, int width, int height)
        {
            this.height //     |
                =       //     |
                height; // { (x,y) } -------------------------
            { this.x = x; this.y = y; } this.width = width;
        }
    }
}
