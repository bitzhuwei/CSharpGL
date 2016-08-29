using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class Framebuffer
    {
        /// <summary>
        /// Sets the size of an empty framebuffer.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="samples">how many samples?</param>
        public void SetParameter(int width, int height, int samples)
        {
            glFramebufferParameteri(OpenGL.GL_DRAW_FRAMEBUFFER, OpenGL.GL_FRAMEBUFFER_DEFAULT_WIDTH, 512);
            glFramebufferParameteri(OpenGL.GL_DRAW_FRAMEBUFFER, OpenGL.GL_FRAMEBUFFER_DEFAULT_HEIGHT, 512);
            glFramebufferParameteri(OpenGL.GL_DRAW_FRAMEBUFFER, OpenGL.GL_FRAMEBUFFER_DEFAULT_SAMPLES, 4);
        }
    }
}
