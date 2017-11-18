using System;
namespace CSharpGL
{
    public partial class Framebuffer
    {
        /// <summary>
        /// Sets the size of an empty framebuffer.
        /// These parameters only take effect when no image is attached to this framebuffer object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="samples">how many samples?</param>
        public void SetParameter(int width, int height, int samples)
        {
            if (glFramebufferParameteri == null) { throw new Exception(string.Format("{0} is not supported on this platform!", glFramebufferParameteri)); }

            //if (glFramebufferParameteri != null)
            {
                glFramebufferParameteri(GL.GL_DRAW_FRAMEBUFFER, GL.GL_FRAMEBUFFER_DEFAULT_WIDTH, width);//512
                glFramebufferParameteri(GL.GL_DRAW_FRAMEBUFFER, GL.GL_FRAMEBUFFER_DEFAULT_HEIGHT, height);//512
                glFramebufferParameteri(GL.GL_DRAW_FRAMEBUFFER, GL.GL_FRAMEBUFFER_DEFAULT_SAMPLES, samples);//4
            }
        }
    }
}