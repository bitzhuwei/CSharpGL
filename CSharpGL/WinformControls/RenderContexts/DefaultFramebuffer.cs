using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    partial class DefaultFramebuffer : IDisposable
    {
        private static OpenGL.glGenFramebuffersEXT glGenFramebuffersEXT;
        private static OpenGL.glBindFramebufferEXT glBindFramebufferEXT;
        private static OpenGL.glGenRenderbuffersEXT glGenRenderbuffersEXT;
        private static OpenGL.glBindRenderbufferEXT glBindRenderbufferEXT;
        private static OpenGL.glRenderbufferStorageEXT glRenderbufferStorageEXT;
        private static OpenGL.glFramebufferRenderbufferEXT glFramebufferRenderbufferEXT;
        private static OpenGL.glDeleteRenderbuffersEXT glDeleteRenderbuffersEXT;
        private static OpenGL.glDeleteFramebuffersEXT glDeleteFramebuffersEXT;

        private uint[] framebufferId = new uint[1];
        public uint FramebufferId { get { return this.framebufferId[0]; } }
        private uint[] colorRenderBufferId = new uint[1];
        public uint ColorRenderBufferId { get { return this.colorRenderBufferId[0]; } }
        private uint[] depthRenderBufferId = new uint[1];
        public uint DepthRenderBufferId { get { return this.depthRenderBufferId[0]; } }

        public DefaultFramebuffer()
        {
            if (glGenFramebuffersEXT == null)
            {
                glGenFramebuffersEXT = OpenGL.GetDelegateFor<OpenGL.glGenFramebuffersEXT>();
                glBindFramebufferEXT = OpenGL.GetDelegateFor<OpenGL.glBindFramebufferEXT>();
                glGenRenderbuffersEXT = OpenGL.GetDelegateFor<OpenGL.glGenRenderbuffersEXT>();
                glBindRenderbufferEXT = OpenGL.GetDelegateFor<OpenGL.glBindRenderbufferEXT>();
                glRenderbufferStorageEXT = OpenGL.GetDelegateFor<OpenGL.glRenderbufferStorageEXT>();
                glFramebufferRenderbufferEXT = OpenGL.GetDelegateFor<OpenGL.glFramebufferRenderbufferEXT>();
                glDeleteRenderbuffersEXT = OpenGL.GetDelegateFor<OpenGL.glDeleteRenderbuffersEXT>();
                glDeleteFramebuffersEXT = OpenGL.GetDelegateFor<OpenGL.glDeleteFramebuffersEXT>();
            }
        }
        internal void Create(int width, int height)
        {
            //  First, create the frame buffer and bind it.
            glGenFramebuffersEXT(1, this.framebufferId);
            glBindFramebufferEXT(OpenGL.GL_FRAMEBUFFER, this.framebufferId[0]);

            //	Create the color render buffer and bind it, then allocate storage for it.
            glGenRenderbuffersEXT(1, this.colorRenderBufferId);
            glBindRenderbufferEXT(OpenGL.GL_RENDERBUFFER, this.colorRenderBufferId[0]);
            glRenderbufferStorageEXT(OpenGL.GL_RENDERBUFFER, OpenGL.GL_RGBA, width, height);

            //	Create the depth render buffer and bind it, then allocate storage for it.
            glGenRenderbuffersEXT(1, this.depthRenderBufferId);
            glBindRenderbufferEXT(OpenGL.GL_RENDERBUFFER, this.depthRenderBufferId[0]);
            glRenderbufferStorageEXT(OpenGL.GL_RENDERBUFFER, OpenGL.GL_DEPTH_COMPONENT24, width, height);

            //  Set the render buffer for color and depth.
            glFramebufferRenderbufferEXT(OpenGL.GL_FRAMEBUFFER, OpenGL.GL_COLOR_ATTACHMENT0,
                OpenGL.GL_RENDERBUFFER, this.colorRenderBufferId[0]);
            glFramebufferRenderbufferEXT(OpenGL.GL_FRAMEBUFFER, OpenGL.GL_DEPTH_ATTACHMENT,
                OpenGL.GL_RENDERBUFFER, this.depthRenderBufferId[0]);
        }

    }
}
