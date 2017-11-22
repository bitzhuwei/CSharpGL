using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// Create, update, use and delete a framebuffer object.
    /// </summary>
    public partial class Framebuffer : IDisposable
    {
        private static GLDelegates.void_int_uintN glGenFramebuffers;
        private static GLDelegates.void_uint_uint glBindFramebuffer;
        /// <summary>
        /// void glFramebufferTexture(GLenum target​, GLenum attachment​, GLuint texture​, GLint level​);
        /// </summary>
        private static GLDelegates.void_uint_uint_uint_int glFramebufferTexture;
        ///// <summary>
        ///// void glFramebufferTexture1D(GLenum target​, GLenum attachment​, GLenum textarget​, GLuint texture​, GLint level​);
        ///// </summary>
        //private static GLDelegates.void_uint_uint_uint_uint_int glFramebufferTexture1D;
        ///// <summary>
        ///// void glFramebufferTexture2D(GLenum target​, GLenum attachment​, GLenum textarget​, GLuint texture​, GLint level​);
        ///// </summary>
        //private static GLDelegates.void_uint_uint_uint_uint_int glFramebufferTexture2D;
        ///// <summary>
        ///// void glFramebufferTexture3D(GLenum target​, GLenum attachment​, GLenum textarget​, GLuint texture​, GLint level​, GLint layer​);
        ///// </summary>
        //private static GLDelegates.void_uint_uint_uint_uint_int_int glFramebufferTexture3D;
        /// <summary>
        /// void glFramebufferTextureLayer(GLenum target​, GLenum attachment​, GLuint texture​, GLint level​, GLint layer​);
        /// </summary>
        private static GLDelegates.void_uint_uint_uint_int_int glFramebufferTextureLayer;
        private static GLDelegates.void_int_uintN glDrawBuffers;
        private static GLDelegates.void_uint glDrawBuffer;
        private static GLDelegates.void_uint glReadBuffer;
        private static GLDelegates.void_uint_uint_uint_uint glFramebufferRenderbuffer;
        private static GLDelegates.void_uint_uint_int glFramebufferParameteri;
        private static GLDelegates.uint_uint glCheckFramebufferStatus;
        private static GLDelegates.void_int_uintN glDeleteFramebuffers;

        private uint[] frameBufferId = new uint[1];

        /// <summary>
        /// Framebuffer Id.
        /// </summary>
        public uint Id { get { return frameBufferId[0]; } }

        /// <summary>
        /// 0 means no renderbuffer attached.
        /// </summary>
        public readonly int Width;

        /// <summary>
        /// 0 means no renderbuffer attached.
        /// </summary>
        public readonly int Height;

        /// <summary>
        /// 
        /// </summary>
        public static Framebuffer CurrentFramebuffer
        {
            get
            {
                if (Framebuffer.bindingStack.Count < 1)
                {
                    throw new Exception();
                }

                return Framebuffer.bindingStack.Peek();
            }
        }

        private static Stack<Framebuffer> bindingStack = new Stack<Framebuffer>();

        static Framebuffer()
        {
            glGenFramebuffers = GL.Instance.GetDelegateFor("glGenFramebuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindFramebuffer = GL.Instance.GetDelegateFor("glBindFramebuffer", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glFramebufferTexture = GL.Instance.GetDelegateFor("glFramebufferTexture", GLDelegates.typeof_void_uint_uint_uint_int) as GLDelegates.void_uint_uint_uint_int;
            //glFramebufferTexture1D = GL.Instance.GetDelegateFor("glFramebufferTexture1D", GLDelegates.typeof_void_uint_uint_uint_uint_int) as GLDelegates.void_uint_uint_uint_uint_int;
            //glFramebufferTexture2D = GL.Instance.GetDelegateFor("glFramebufferTexture2D", GLDelegates.typeof_void_uint_uint_uint_uint_int) as GLDelegates.void_uint_uint_uint_uint_int;
            //glFramebufferTexture3D = GL.Instance.GetDelegateFor("glFramebufferTexture3D", GLDelegates.typeof_void_uint_uint_uint_uint_int_int) as GLDelegates.void_uint_uint_uint_uint_int_int;
            glFramebufferTextureLayer = GL.Instance.GetDelegateFor("glFramebufferTextureLayer", GLDelegates.typeof_void_uint_uint_uint_int_int) as GLDelegates.void_uint_uint_uint_int_int;
            glDrawBuffers = GL.Instance.GetDelegateFor("glDrawBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glDrawBuffer = GL.Instance.GetDelegateFor("glDrawBuffer", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glReadBuffer = GL.Instance.GetDelegateFor("glReadBuffer", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            glFramebufferRenderbuffer = GL.Instance.GetDelegateFor("glFramebufferRenderbuffer", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
            glFramebufferParameteri = GL.Instance.GetDelegateFor("glFramebufferParameteri", GLDelegates.typeof_void_uint_uint_int) as GLDelegates.void_uint_uint_int;
            glCheckFramebufferStatus = GL.Instance.GetDelegateFor("glCheckFramebufferStatus", GLDelegates.typeof_uint_uint) as GLDelegates.uint_uint;
            glDeleteFramebuffers = GL.Instance.GetDelegateFor("glDeleteFramebuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;

            Framebuffer.maxColorAttachmentCount = Framebuffer.MaxColorAttachments();

            Framebuffer.bindingStack.Push(null);// default framebuffer with Id = 0.
        }

        /// <summary>
        /// Create an empty framebuffer object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Framebuffer(int width, int height)
        {
            glGenFramebuffers(1, frameBufferId);

            this.Width = width;
            this.Height = height;

            this.colorBuffers = new Renderbuffer[Framebuffer.maxColorAttachmentCount];
        }

        /// <summary>
        /// start to use this framebuffer.
        /// </summary>
        /// <param name="target"></param>
        public void Bind(FramebufferTarget target = FramebufferTarget.Framebuffer)
        {
            Framebuffer framebuffer = Framebuffer.bindingStack.Peek();
            if (framebuffer != this)
            {
                Framebuffer.bindingStack.Push(this);

                glBindFramebuffer((uint)target, this.Id);
            }
        }

        /// <summary>
        /// stop to use this framebuffer(and use last framebuffer).
        /// </summary>
        /// <param name="target"></param>
        public void Unbind(FramebufferTarget target = FramebufferTarget.Framebuffer)
        {
            Framebuffer framebuffer = Framebuffer.bindingStack.Pop();
            if (framebuffer != this) { throw new Exception("FrameBuffer Bind/Unbind not matching!"); }

            Framebuffer top = Framebuffer.bindingStack.Peek();
            if (top == null)
            {
                glBindFramebuffer((uint)target, 0);
            }
            else
            {
                glBindFramebuffer((uint)target, top.Id);
            }
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
}
