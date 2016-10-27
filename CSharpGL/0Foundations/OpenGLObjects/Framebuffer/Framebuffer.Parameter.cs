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
            //if (glFramebufferParameteri != null)
            {
                glFramebufferParameteri(OpenGL.GL_DRAW_FRAMEBUFFER, OpenGL.GL_FRAMEBUFFER_DEFAULT_WIDTH, width);//512
                glFramebufferParameteri(OpenGL.GL_DRAW_FRAMEBUFFER, OpenGL.GL_FRAMEBUFFER_DEFAULT_HEIGHT, height);//512
                glFramebufferParameteri(OpenGL.GL_DRAW_FRAMEBUFFER, OpenGL.GL_FRAMEBUFFER_DEFAULT_SAMPLES, samples);//4
            }
        }
    }
}