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
        private static GLDelegates.void_uint_uint_uint_int glFramebufferTexture;
        //private static GLDelegates.void_uint_uint_uint_uint_int glFramebufferTexture2D;
        private static GLDelegates.void_int_uintN glDrawBuffers;
        private static GLDelegates.void_uint_uint_uint_uint glFramebufferRenderbuffer;
        private static GLDelegates.void_uint_uint_int glFramebufferParameteri;
        private static GLDelegates.uint_uint glCheckFramebufferStatus;
        private static GLDelegates.void_int_uintN glDeleteFramebuffers;

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
            //glFramebufferTexture2D = GL.Instance.GetDelegateFor("glFramebufferTexture2D", GLDelegates.typeof_void_uint_uint_uint_uint_int) as GLDelegates.void_uint_uint_uint_uint_int;
            glDrawBuffers = GL.Instance.GetDelegateFor("glDrawBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glFramebufferRenderbuffer = GL.Instance.GetDelegateFor("glFramebufferRenderbuffer", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
            glFramebufferParameteri = GL.Instance.GetDelegateFor("glFramebufferParameteri", GLDelegates.typeof_void_uint_uint_int) as GLDelegates.void_uint_uint_int;
            glCheckFramebufferStatus = GL.Instance.GetDelegateFor("glCheckFramebufferStatus", GLDelegates.typeof_uint_uint) as GLDelegates.uint_uint;
            glDeleteFramebuffers = GL.Instance.GetDelegateFor("glDeleteFramebuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;

            //Framebuffer.bindingStack.Push(null);// default framebuffer with Id = 0.
        }

        /// <summary>
        /// Create an empty framebuffer object.
        /// </summary>
        public Framebuffer()
        {
            glGenFramebuffers(1, frameBuffer);
        }

        /// <summary>
        /// start to use this framebuffer.
        /// </summary>
        /// <param name="target"></param>
        public void Bind(FramebufferTarget target = FramebufferTarget.Framebuffer)
        {
            Framebuffer.bindingStack.Push(this);

            glBindFramebuffer((uint)target, this.Id);
        }

        /// <summary>
        /// stop to use this framebuffer(and use default framebuffer).
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

    /// <summary>
    ///
    /// </summary>
    public enum FramebufferTarget : uint
    {
        /// <summary>
        /// used to draw(write only) something.
        /// </summary>
        DrawFramebuffer = GL.GL_DRAW_FRAMEBUFFER,

        /// <summary>
        /// used to read from(read only).
        /// </summary>
        ReadFramebuffer = GL.GL_READ_FRAMEBUFFER,

        /// <summary>
        /// both read/write.
        /// </summary>
        Framebuffer = GL.GL_FRAMEBUFFER,
    }
}