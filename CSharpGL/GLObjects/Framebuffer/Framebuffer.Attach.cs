using System;
using System.Collections.Generic;

namespace CSharpGL
{
    public partial class Framebuffer
    {
        private static readonly uint[] attachment_id =
        {
			GL.GL_COLOR_ATTACHMENT0,
			GL.GL_COLOR_ATTACHMENT1,
			GL.GL_COLOR_ATTACHMENT2,
			GL.GL_COLOR_ATTACHMENT3,
			GL.GL_COLOR_ATTACHMENT4,
			GL.GL_COLOR_ATTACHMENT5,
			GL.GL_COLOR_ATTACHMENT6,
			GL.GL_COLOR_ATTACHMENT7,
			GL.GL_COLOR_ATTACHMENT8,
			GL.GL_COLOR_ATTACHMENT9,
			GL.GL_COLOR_ATTACHMENT10,
			GL.GL_COLOR_ATTACHMENT11,
			GL.GL_COLOR_ATTACHMENT12,
			GL.GL_COLOR_ATTACHMENT13,
			GL.GL_COLOR_ATTACHMENT14,
			GL.GL_COLOR_ATTACHMENT15,
        };

        private List<Renderbuffer> colorBufferList = new List<Renderbuffer>();
        private Renderbuffer depthBuffer;
        private int nextColorAttachmentIndex = 0;

        /// <summary>
        /// et the list of draw buffers.
        /// </summary>
        /// <param name="drawBuffers">GL.GL_COLOR_ATTACHMENT0 + [0, 15] etc.</param>
        public void SetDrawBuffers(params uint[] drawBuffers)
        {
            glDrawBuffers(drawBuffers.Length, drawBuffers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="drawBuffer">GL.GL_COLOR_ATTACHMENT0 + [0, 15] etc.</param>
        public void SetDrawBuffer(uint drawBuffer)
        {
            glDrawBuffer(drawBuffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readBuffer">GL.GL_COLOR_ATTACHMENT0 + [0, 15] etc.</param>
        public void SetReadBuffer(uint readBuffer)
        {
            glReadBuffer(readBuffer);
        }
        //  TODO: We should be able to just use the code below - however we
        //  get invalid dimension issues at the moment, so recreate for now.
        ///// <summary>
        ///// resize this framebuffer.
        ///// </summary>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public void Resize(int width, int height)
        //{
        //    //glBindRenderbuffer(GL.GL_RENDERBUFFER, colourRenderBufferId);
        //    //glRenderbufferStorage(GL.GL_RENDERBUFFER, GL.GL_RGBA, width, height);
        //    //glBindRenderbuffer(GL.GL_RENDERBUFFER, depthRenderBufferId);
        //    //glRenderbufferStorage(GL.GL_RENDERBUFFER, GL.GL_DEPTH_ATTACHMENT, width, height);
        //    //var complete = OpenGL.GetDelegateFor<OpenGL.glCheckFramebufferStatusEXT>()(GL.GL_FRAMEBUFFER);
        //    this.depthBuffer.Resize(GL.GL_DEPTH_ATTACHMENT, width, height);
        //    faoreach (var item in this.colorBufferList)
        //    {
        //        item.Resize(GL.GL_RGBA, width, height);
        //    }
        //    this.CheckCompleteness();
        //}
    }
}
