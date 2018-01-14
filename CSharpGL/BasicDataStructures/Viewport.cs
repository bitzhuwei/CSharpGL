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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3}", this.x, this.y, this.width, this.height);
        }

        /// <summary>
        /// Gets current viewport.
        /// </summary>
        /// <returns></returns>
        public static Viewport GetCurrent()
        {
            var viewport = new int[4];
            GL.Instance.GetIntegerv(GL.GL_VIEWPORT, viewport);
            return new Viewport(viewport[0], viewport[1], viewport[2], viewport[3]);
        }
    }
}
