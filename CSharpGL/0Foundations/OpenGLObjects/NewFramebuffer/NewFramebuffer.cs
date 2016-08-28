using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Create, update and delete a framebuffer object.
    /// </summary>
    public partial class NewFramebuffer : IDisposable
    {
        private static OpenGL.glGenFramebuffersEXT glGenFramebuffers;
        private static OpenGL.glBindFramebufferEXT glBindFramebuffer;
        private static OpenGL.glFramebufferTexture2DEXT glFramebufferTexture2D;
        private static OpenGL.glCheckFramebufferStatusEXT glCheckFramebufferStatus;
        private static OpenGL.glDeleteFramebuffersEXT glDeleteFramebuffers;
        private static OpenGL.glDrawBuffers glDrawBuffers;

        /// <summary>
        /// Framebuffer Id.
        /// </summary>
        public uint Id { get; private set; }

        public NewFramebuffer()
        {
            if (glGenFramebuffers == null)
            {
                glGenFramebuffers = OpenGL.GetDelegateFor<OpenGL.glGenFramebuffersEXT>();
                glBindFramebuffer = OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>();
                glFramebufferTexture2D = OpenGL.GetDelegateFor<OpenGL.glFramebufferTexture2DEXT>();
                glCheckFramebufferStatus = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>();
                glDeleteFramebuffers = OpenGL.GetDelegateFor<OpenGL.glDeleteFramebuffersEXT>();
            }

            var frameBuffer = new uint[1];
            glGenFramebuffers(1, frameBuffer);
        }

    }
}
