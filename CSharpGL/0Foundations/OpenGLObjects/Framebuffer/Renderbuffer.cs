using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// Create, update, use and delete a renderbuffer object.
    /// </summary>
    public partial class Renderbuffer
    {
        private static OpenGL.glGenRenderbuffersEXT glGenRenderbuffers;
        private static OpenGL.glBindRenderbufferEXT glBindRenderbuffer;
        private static OpenGL.glRenderbufferStorageEXT glRenderbufferStorage;

        uint[] renderbuffer = new uint[1];
        /// <summary>
        /// Framebuffer Id.
        /// </summary>
        public uint Id { get { return renderbuffer[0]; } }

        /// <summary>
        /// Create, update, use and delete a renderbuffer object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalformat"></param>
        /// <param name="bufferType"></param>
        public Renderbuffer(int width, int height, uint internalformat, RenderbufferType bufferType)
        {
            if (glGenRenderbuffers == null)
            {
                glGenRenderbuffers = OpenGL.GetDelegateFor<OpenGL.glGenRenderbuffersEXT>();
                glBindRenderbuffer = OpenGL.GetDelegateFor<OpenGL.glBindRenderbufferEXT>();
                glRenderbufferStorage = OpenGL.GetDelegateFor<OpenGL.glRenderbufferStorageEXT>();
            }

            this.Width = width;
            this.Height = height;
            this.BufferType = bufferType;

            glGenRenderbuffers(1, renderbuffer);
            glBindRenderbuffer(OpenGL.GL_RENDERBUFFER, renderbuffer[0]);
            glRenderbufferStorage(OpenGL.GL_RENDERBUFFER,
                internalformat,// TODO: add comment about OpenGL.GL_DEPTH24_STENCIL8, OpenGL.GL_RGBA,
                width, height);
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
        public RenderbufferType BufferType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: [w:{1}, h:{2}]", this.GetType().Name, this.Width, this.Height);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum RenderbufferType
    {
        /// <summary>
        /// 
        /// </summary>
        DepthBuffer,
        /// <summary>
        /// 
        /// </summary>
        ColorBuffer,
    }
}
