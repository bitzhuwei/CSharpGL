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
        private static OpenGL.glGenRenderbuffersEXT glGenRenderbuffers;
        private static OpenGL.glBindRenderbufferEXT glBindRenderbuffer;
        private static OpenGL.glRenderbufferStorageEXT glRenderbufferStorage;
        private static OpenGL.glDeleteRenderbuffersEXT glDeleteRenderbuffers;

        uint[] renderbuffer = new uint[1];
        /// <summary>
        /// Framebuffer Id.
        /// </summary>
        public uint Id { get { return renderbuffer[0]; } }

        /// <summary>
        /// Create, update, use and delete a framebuffer object.
        /// </summary>
        public Renderbuffer(int width, int height)
        {
            if (glGenRenderbuffers == null)
            {
                glGenRenderbuffers = OpenGL.GetDelegateFor<OpenGL.glGenRenderbuffersEXT>();
                glBindRenderbuffer = OpenGL.GetDelegateFor<OpenGL.glBindRenderbufferEXT>();
                glRenderbufferStorage = OpenGL.GetDelegateFor<OpenGL.glRenderbufferStorageEXT>();
                glDeleteRenderbuffers = OpenGL.GetDelegateFor<OpenGL.glDeleteRenderbuffersEXT>();
            }

            this.Width = width;
            this.Height = height;

            glGenRenderbuffers(1, renderbuffer);
            glBindRenderbuffer(OpenGL.GL_RENDERBUFFER, renderbuffer[0]);
            glRenderbufferStorage(OpenGL.GL_RENDERBUFFER, OpenGL.GL_DEPTH24_STENCIL8, width, height);
        }

        /// <summary>
        /// 
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: [w:{1}, h:{2}]", this.GetType().Name, this.Width, this.Height);
        }
    }
}
