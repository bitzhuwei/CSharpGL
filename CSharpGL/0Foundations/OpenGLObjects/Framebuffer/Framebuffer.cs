using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Create, update, use and delete a framebuffer object.
    /// </summary>
    public partial class Framebuffer : IDisposable
    {
        private static OpenGL.glGenFramebuffersEXT glGenFramebuffers;
        private static OpenGL.glBindFramebufferEXT glBindFramebuffer;
        private static OpenGL.glFramebufferTexture2DEXT glFramebufferTexture2D;
        private static OpenGL.glCheckFramebufferStatusEXT glCheckFramebufferStatus;
        private static OpenGL.glDeleteFramebuffersEXT glDeleteFramebuffers;
        private static OpenGL.glDrawBuffers glDrawBuffers;
        private static OpenGL.glFramebufferRenderbufferEXT glFramebufferRenderbuffer;
        private static OpenGL.glFramebufferParameteri glFramebufferParameteri;

        uint[] frameBuffer = new uint[1];
        /// <summary>
        /// Framebuffer Id.
        /// </summary>
        public uint Id { get { return frameBuffer[0]; } }

        /// <summary>
        /// Create an empty framebuffer object.
        /// </summary>
        public Framebuffer()
        {
            if (glGenFramebuffers == null)
            {
                glGenFramebuffers = OpenGL.GetDelegateFor<OpenGL.glGenFramebuffersEXT>();
                glBindFramebuffer = OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>();
                glFramebufferTexture2D = OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>();
                glCheckFramebufferStatus = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>();
                glDeleteFramebuffers = OpenGL.GetDelegateFor<OpenGL.glDeleteFramebuffersEXT>();
                glDrawBuffers = OpenGL.GetDelegateFor<OpenGL.glDrawBuffers>();
                glFramebufferRenderbuffer = OpenGL.GetDelegateFor<OpenGL.glFramebufferRenderbufferEXT>();
                glFramebufferParameteri = OpenGL.GetDelegateFor<OpenGL.glFramebufferParameteri>();
            }

            glGenFramebuffers(1, frameBuffer);
        }

        /// <summary>
        /// start to use this framebuffer.
        /// </summary>
        /// <param name="target"></param>
        public void Bind(FramebufferTarget target = FramebufferTarget.DrawRead)
        {
            glBindFramebuffer((uint)target, this.Id);
        }

        /// <summary>
        /// stop to use this framebuffer(and use default framebuffer).
        /// </summary>
        /// <param name="target"></param>
        public void Unbind(FramebufferTarget target = FramebufferTarget.DrawRead)
        {
            glBindFramebuffer((uint)target, 0);
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
        Draw = OpenGL.GL_DRAW_FRAMEBUFFER,
        /// <summary>
        /// used to read from(read only).
        /// </summary>
        Read = OpenGL.GL_READ_FRAMEBUFFER,
        /// <summary>
        /// both read/write.
        /// </summary>
        DrawRead = OpenGL.GL_FRAMEBUFFER,
    }
}
