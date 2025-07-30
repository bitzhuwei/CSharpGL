using System;
using System.Collections.Generic;

namespace CSharpGL {
    /// <summary>
    /// Create, update, use and delete a framebuffer object.
    /// </summary>
    public unsafe partial class Framebuffer : IDisposable {
        //private static GLDelegates.void_int_uintN glGenFramebuffers;
        //private static GLDelegates.void_uint_uint glBindFramebuffer;
        ///// <summary>
        ///// void glFramebufferTexture(GLenum target​, GLenum attachment​, GLuint texture​, GLint level​);
        ///// </summary>
        //private static GLDelegates.void_uint_uint_uint_int glFramebufferTexture;
        /////// <summary>
        /////// void glFramebufferTexture1D(GLenum target​, GLenum attachment​, GLenum textarget​, GLuint texture​, GLint level​);
        /////// </summary>
        ////private static GLDelegates.void_uint_uint_uint_uint_int glFramebufferTexture1D;
        /////// <summary>
        /////// void glFramebufferTexture2D(GLenum target​, GLenum attachment​, GLenum textarget​, GLuint texture​, GLint level​);
        //private static GLDelegates.void_uint_uint_uint_uint_int glFramebufferTexture2D;
        /////// void glFramebufferTexture3D(GLenum target​, GLenum attachment​, GLenum textarget​, GLuint texture​, GLint level​, GLint layer​);
        /////// </summary>
        ////private static GLDelegates.void_uint_uint_uint_uint_int_int glFramebufferTexture3D;
        ///// <summary>
        ///// void glFramebufferTextureLayer(GLenum target​, GLenum attachment​, GLuint texture​, GLint level​, GLint layer​);
        ///// </summary>
        //private static GLDelegates.void_uint_uint_uint_int_int glFramebufferTextureLayer;
        //private static GLDelegates.void_int_uintN glDrawBuffers;
        //private static GLDelegates.void_uint glDrawBuffer;
        //private static GLDelegates.void_uint glReadBuffer;
        //private static GLDelegates.void_uint_uint_uint_uint glFramebufferRenderbuffer;
        //private static GLDelegates.void_uint_uint_int glFramebufferParameteri;
        //private static GLDelegates.uint_uint glCheckFramebufferStatus;
        //private static GLDelegates.void_int_uintN glDeleteFramebuffers;

        //private GLuint[] frameBufferId = new GLuint[1];

        /// <summary>
        /// Framebuffer Id.
        /// </summary>
        public readonly GLuint id;// { get { return frameBufferId[0]; } }

        /// <summary>
        /// 0 means no renderbuffer attached.
        /// </summary>
        public readonly int width;

        /// <summary>
        /// 0 means no renderbuffer attached.
        /// </summary>
        public readonly int height;

        ///// <summary>
        ///// 
        ///// </summary>
        //public static Framebuffer? CurrentFramebuffer {
        //    get {
        //        if (Framebuffer.bindingStack.Count < 1) {
        //            return null;
        //        }

        //        return Framebuffer.bindingStack.Peek();
        //    }
        //}

        //private static readonly Stack<Framebuffer> bindingStack = new();

        //static Framebuffer()
        //{
        //    glGenFramebuffers = gl.glGetDelegateFor("glGenFramebuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //    glBindFramebuffer = gl.glGetDelegateFor("glBindFramebuffer", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
        //    glFramebufferTexture = gl.glGetDelegateFor("glFramebufferTexture", GLDelegates.typeof_void_uint_uint_uint_int) as GLDelegates.void_uint_uint_uint_int;
        //    //glFramebufferTexture1D = GL.Instance.GetDelegateFor("glFramebufferTexture1D", GLDelegates.typeof_void_uint_uint_uint_uint_int) as GLDelegates.void_uint_uint_uint_uint_int;
        //    glFramebufferTexture2D = gl.glGetDelegateFor("glFramebufferTexture2D", GLDelegates.typeof_void_uint_uint_uint_uint_int) as GLDelegates.void_uint_uint_uint_uint_int;
        //    //glFramebufferTexture3D = GL.Instance.GetDelegateFor("glFramebufferTexture3D", GLDelegates.typeof_void_uint_uint_uint_uint_int_int) as GLDelegates.void_uint_uint_uint_uint_int_int;
        //    glFramebufferTextureLayer = gl.glGetDelegateFor("glFramebufferTextureLayer", GLDelegates.typeof_void_uint_uint_uint_int_int) as GLDelegates.void_uint_uint_uint_int_int;
        //    glDrawBuffers = gl.glGetDelegateFor("glDrawBuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //    glDrawBuffer = gl.glGetDelegateFor("glDrawBuffer", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glReadBuffer = gl.glGetDelegateFor("glReadBuffer", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
        //    glFramebufferRenderbuffer = gl.glGetDelegateFor("glFramebufferRenderbuffer", GLDelegates.typeof_void_uint_uint_uint_uint) as GLDelegates.void_uint_uint_uint_uint;
        //    glFramebufferParameteri = gl.glGetDelegateFor("glFramebufferParameteri", GLDelegates.typeof_void_uint_uint_int) as GLDelegates.void_uint_uint_int;
        //    glCheckFramebufferStatus = gl.glGetDelegateFor("glCheckFramebufferStatus", GLDelegates.typeof_uint_uint) as GLDelegates.uint_uint;
        //    glDeleteFramebuffers = gl.glGetDelegateFor("glDeleteFramebuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;

        //    Framebuffer.maxColorAttachmentCount = Framebuffer.MaxColorAttachments();

        //    Framebuffer.bindingStack.Push(null);// default framebuffer with Id = 0.
        //}

        /// <summary>
        /// Create an empty framebuffer object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Framebuffer(int width, int height) {
            //this.colorBuffers = new Renderbuffer[colorBufferCount];
            this.width = width;
            this.height = height;

            var gl = GL.current; if (gl == null) { return; }
            var framebuffers = stackalloc GLuint[1];
            gl.glGenFramebuffers(1, framebuffers);
            this.id = framebuffers[0];
        }

        /// <summary>
        /// start to use this framebuffer.
        /// </summary>
        /// <param name="target"></param>
        public void Bind(Framebuffer.Target target = Framebuffer.Target.Framebuffer) {
            var gl = GL.current; if (gl == null) { return; }
            //Framebuffer framebuffer = Framebuffer.bindingStack.Peek();
            //if (framebuffer != this) {
            //    Framebuffer.bindingStack.Push(this);

            //    gl.glBindFramebuffer((GLenum)target, this.id);
            //}
            gl.glBindFramebuffer((GLenum)target, this.id);
        }

        /// <summary>
        /// stop to use this framebuffer(and use last framebuffer).
        /// </summary>
        /// <param name="target"></param>
        public void Unbind(Framebuffer.Target target = Framebuffer.Target.Framebuffer) {
            //Framebuffer framebuffer = Framebuffer.bindingStack.Pop();
            //if (framebuffer != this) { throw new Exception("FrameBuffer Bind/Unbind not matching!"); }

            var gl = GL.current; if (gl == null) { return; }
            //Framebuffer top = Framebuffer.bindingStack.Peek();
            //if (top == null) {
            //    gl.glBindFramebuffer((GLenum)target, 0);
            //}
            //else {
            //    gl.glBindFramebuffer((GLenum)target, top.id);
            //}
            gl.glBindFramebuffer((GLenum)target, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Framebuffer Id: {0}", this.id);
        }
    }
}
