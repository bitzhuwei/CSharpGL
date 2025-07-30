namespace CSharpGL {
    /// <summary>
    /// Create, update, use and delete a renderbuffer object.
    /// </summary>
    public unsafe partial class Renderbuffer {
        //private static GLDelegates.void_int_uintN glGenRenderbuffers;
        //private static GLDelegates.void_uint_uint glBindRenderbuffer;
        //private static GLDelegates.void_uint_uint_int_int glRenderbufferStorage;
        //private static GLDelegates.void_int_uintN glDeleteRenderbuffers;

        //static Renderbuffer() {
        //    glGenRenderbuffers = gl.glGetDelegateFor("glGenRenderbuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //    glBindRenderbuffer = gl.glGetDelegateFor("glBindRenderbuffer", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
        //    glRenderbufferStorage = gl.glGetDelegateFor("glRenderbufferStorage", GLDelegates.typeof_void_uint_uint_int_int) as GLDelegates.void_uint_uint_int_int;
        //    glDeleteRenderbuffers = gl.glGetDelegateFor("glDeleteRenderbuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        //}

        /// <summary>
        /// Framebuffer Id.
        /// </summary>
        public readonly uint id;

        public readonly int width;
        public readonly int height;


        /// <summary>
        /// Create, update, use and delete a renderbuffer object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalformat"></param>
        public Renderbuffer(int width, int height, GLenum internalformat) {
            this.width = width;
            this.height = height;

            var gl = GL.current; if (gl == null) { return; }
            var renderbufferIds = stackalloc GLuint[1];
            gl.glGenRenderbuffers(1, renderbufferIds);
            gl.glBindRenderbuffer(GL.GL_RENDERBUFFER, renderbufferIds[0]);
            gl.glRenderbufferStorage(GL.GL_RENDERBUFFER,
                internalformat, // TODO: add comment about GL.GL_DEPTH24_STENCIL8, GL.GL_RGBA,
                width, height);
            gl.glBindRenderbuffer(GL.GL_RENDERBUFFER, 0);
            this.id = renderbufferIds[0];
        }
        ///// <summary>
        ///// Bind a named renderbuffer object.
        ///// </summary>
        //public void Bind()
        //{
        //    glBindRenderbuffer(GL.GL_RENDERBUFFER, this.Id);
        //}

        //  TODO: We should be able to just use the code below - however we
        //  get invalid dimension issues at the moment, so recreate for now.
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="format"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public void Resize(uint format, int width, int height, bool autoBind = true)
        //{
        //    if (autoBind)
        //    {
        //        glBindRenderbuffer(GL.GL_RENDERBUFFER, this.Id);
        //    }
        //    glRenderbufferStorage(GL.GL_RENDERBUFFER, format, width, height);
        //    if (autoBind)
        //    {
        //        glBindRenderbuffer(GL.GL_RENDERBUFFER, 0);
        //    }
        //}

        ///// <summary>
        ///// Unbind this renderbuffer object.
        ///// </summary>
        //public void Unbind()
        //{
        //    glBindRenderbuffer(GL.GL_RENDERBUFFER, 0);
        //}

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("{0}: [w:{1}, h:{2}]", this.GetType().Name, this.width, this.height);
        }
    }
}