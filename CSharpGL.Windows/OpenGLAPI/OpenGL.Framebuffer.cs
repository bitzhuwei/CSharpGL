namespace CSharpGL
{
    public static partial class OpenGL
    {
        #region GL_framebuffer_no_attachments

        //////  Delegates
        ///// <summary>
        ///// Set a named parameter of a framebuffer.
        ///// </summary>
        ///// <param name="target">The target of the operation, which must be GL_READ_FRAMEBUFFER​, GL_DRAW_FRAMEBUFFER​ or GL_FRAMEBUFFER​.</param>
        ///// <param name="pname">A token indicating the parameter to be modified.</param>
        ///// <param name="param">The new value for the parameter named pname​.</param>
        //internal delegate void glFramebufferParameteri(uint target, uint pname, int param);

        ///// <summary>
        ///// Retrieve a named parameter from a framebuffer
        ///// </summary>
        ///// <param name="target">The target of the operation, which must be GL_READ_FRAMEBUFFER​, GL_DRAW_FRAMEBUFFER​ or GL_FRAMEBUFFER​.</param>
        ///// <param name="pname">A token indicating the parameter to be retrieved.</param>
        ///// <param name="parameters">The address of a variable to receive the value of the parameter named pname​.</param>
        //public delegate void glGetFramebufferParameteriv(uint target, uint pname, int[] parameters);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="framebuffer"></param>
        ///// <param name="pname"></param>
        ///// <param name="param"></param>
        //public delegate void glNamedFramebufferParameteri(uint framebuffer, uint pname, int param);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="framebuffer"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetNamedFramebufferParameteriv(uint framebuffer, uint pname, int[] parameters);

        #endregion GL_framebuffer_no_attachments

        #region GL_EXT_framebuffer_object

        ////  Delegates
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="renderbuffer"></param>
        ///// <returns></returns>
        //public delegate bool glIsRenderbuffer(uint renderbuffer);

        ///// <summary>
        ///// bind a named renderbuffer object.
        ///// </summary>
        ///// <param name="target">Specifies the target to which the renderbuffer object is bound. The symbolic constant must be GL_RENDERBUFFER.</param>
        ///// <param name="renderbuffer">Specifies the name of a renderbuffer object.</param>
        //internal delegate void glBindRenderbuffer(uint target, uint renderbuffer);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="renderbuffers"></param>
        //private delegate void glDeleteRenderbuffers(uint n, uint[] renderbuffers);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="renderbuffers"></param>
        //internal delegate void glGenRenderbuffers(uint n, uint[] renderbuffers);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //internal delegate void glRenderbufferStorage(uint target, uint internalformat, int width, int height);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetRenderbufferParameteriv(uint target, uint pname, int[] parameters);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="framebuffer"></param>
        ///// <returns></returns>
        //public delegate bool glIsFramebuffer(uint framebuffer);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="framebuffer"></param>
        //internal delegate void glBindFramebuffer(uint target, uint framebuffer);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="framebuffers"></param>
        //private delegate void glDeleteFramebuffers(uint n, uint[] framebuffers);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="framebuffers"></param>
        //internal delegate void glGenFramebuffers(uint n, uint[] framebuffers);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <returns></returns>
        //internal delegate uint glCheckFramebufferStatus(uint target);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="attachment"></param>
        ///// <param name="textarget"></param>
        ///// <param name="texture"></param>
        ///// <param name="level"></param>
        //public delegate void glFramebufferTexture1D(uint target, uint attachment, uint textarget, uint texture, int level);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="attachment"></param>
        ///// <param name="textarget"></param>
        ///// <param name="texture"></param>
        ///// <param name="level"></param>
        //internal delegate void glFramebufferTexture2D(uint target, uint attachment, uint textarget, uint texture, int level);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="attachment"></param>
        ///// <param name="textarget"></param>
        ///// <param name="texture"></param>
        ///// <param name="level"></param>
        ///// <param name="zoffset"></param>
        //public delegate void glFramebufferTexture3D(uint target, uint attachment, uint textarget, uint texture, int level, int zoffset);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="attachment"></param>
        ///// <param name="renderbuffertarget"></param>
        ///// <param name="renderbuffer"></param>
        //internal delegate void glFramebufferRenderbuffer(uint target, uint attachment, uint renderbuffertarget, uint renderbuffer);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="attachment"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetFramebufferAttachmentParameteriv(uint target, uint attachment, uint pname, int[] parameters);

        /// <summary>
        ///private delegate void glGenerateMipmap(uint target);
        /// </summary>
        private static GLDelegates.void_uint _glGenerateMipmap;

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        public static void GenerateMipmap(MipmapTarget target)
        {
            if (_glGenerateMipmap == null)
            {
                _glGenerateMipmap = WinGL.Instance.GetDelegateFor("glGenerateMipmap", GLDelegates.typeof_void_uint) as GLDelegates.void_uint;
            }
            _glGenerateMipmap((uint)target);
        }

        #endregion GL_EXT_framebuffer_object

        //#region GL_EXT_framebuffer_multisample

        ////  Delegates
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="samples"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public delegate void glRenderbufferStorageMultisample(uint target, int samples, uint internalformat, int width, int height);

        //#endregion
    }
}