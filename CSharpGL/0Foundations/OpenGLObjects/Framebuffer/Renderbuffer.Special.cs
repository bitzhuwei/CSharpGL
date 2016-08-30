using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Create, update, use and delete a framebuffer object.
    /// </summary>
    public partial class Renderbuffer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Renderbuffer GetDepthbuffer(int width, int height)
        {
            var renderbuffer = new Renderbuffer(width, height, OpenGL.GL_DEPTH_COMPONENT24, RenderbufferType.DepthBuffer);

            return renderbuffer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Renderbuffer GetColorbuffer(int width, int height)
        {
            var renderbuffer = new Renderbuffer(width, height, OpenGL.GL_RGBA, RenderbufferType.ColorBuffer);

            return renderbuffer;
        }
    }
}
