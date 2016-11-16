using System;

namespace CSharpGL
{
    /// <summary>
    /// Create, update, use and delete a framebuffer object.
    /// </summary>
    public partial class Framebuffer : IDisposable
    {
        private static OpenGL.glBindFramebuffer glBindFramebuffer;
        private static OpenGL.glGenFramebuffers glGenFramebuffers;
        private static OpenGL.glFramebufferTexture2D glFramebufferTexture2D;

        //private static OpenGL.glDrawBuffers glDrawBuffers;
        private static OpenGL.glFramebufferRenderbuffer glFramebufferRenderbuffer;

        private static OpenGL.glFramebufferParameteri glFramebufferParameteri;
        private static OpenGL.glCheckFramebufferStatus glCheckFramebufferStatus;

        private uint[] frameBuffer = new uint[1];

        /// <summary>
        /// Framebuffer Id.
        /// </summary>
        public uint Id { get { return frameBuffer[0]; } }

        /// <summary>
        /// 0 means no renderbuffer attached.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// 0 means no renderbuffer attached.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Create an empty framebuffer object.
        /// </summary>
        public Framebuffer()
        {
            if (glGenFramebuffers == null)
            {
                glGenFramebuffers = OpenGL.GetDelegateFor<OpenGL.glGenFramebuffers>();
                glBindFramebuffer = OpenGL.GetDelegateFor<OpenGL.glBindFramebuffer>();
                glFramebufferTexture2D = OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2D>();
                //glDrawBuffers = OpenGL.GetDelegateFor<OpenGL.glDrawBuffers>();
                glFramebufferRenderbuffer = OpenGL.GetDelegateFor<OpenGL.glFramebufferRenderbuffer>();
                glFramebufferParameteri = OpenGL.GetDelegateFor<OpenGL.glFramebufferParameteri>();
                glCheckFramebufferStatus = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatus>();
            }

            glGenFramebuffers(1, frameBuffer);
        }

        /// <summary>
        /// start to use this framebuffer.
        /// </summary>
        /// <param name="target"></param>
        public void Bind(FramebufferTarget target = FramebufferTarget.Framebuffer)
        {
            glBindFramebuffer((uint)target, this.Id);
        }

        /// <summary>
        /// stop to use this framebuffer(and use default framebuffer).
        /// </summary>
        /// <param name="target"></param>
        public void Unbind(FramebufferTarget target = FramebufferTarget.Framebuffer)
        {
            glBindFramebuffer((uint)target, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("Framebuffer Id: {0}", this.Id);
        }
    }

    /// <summary>
    ///
    /// </summary>
    public enum FramebufferTarget : uint
    {
        /// <summary>
        /// used to draw(write only) something.
        /// </summary>
        DrawFramebuffer = OpenGL.GL_DRAW_FRAMEBUFFER,

        /// <summary>
        /// used to read from(read only).
        /// </summary>
        ReadFramebuffer = OpenGL.GL_READ_FRAMEBUFFER,

        /// <summary>
        /// both read/write.
        /// </summary>
        Framebuffer = OpenGL.GL_FRAMEBUFFER,
    }
}