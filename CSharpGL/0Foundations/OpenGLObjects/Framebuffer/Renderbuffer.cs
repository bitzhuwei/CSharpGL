namespace CSharpGL
{
    /// <summary>
    /// Create, update, use and delete a renderbuffer object.
    /// </summary>
    public partial class Renderbuffer
    {
        private static GLDelegates.void_int_uintN glGenRenderbuffers;
        private static GLDelegates.void_uint_uint glBindRenderbuffer;
        private static GLDelegates.void_uint_uint_int_int glRenderbufferStorage;
        private static GLDelegates.void_int_uintN glDeleteRenderbuffers;

        static Renderbuffer()
        {
            glGenRenderbuffers = OpenGL.GetDelegateFor("glGenRenderbuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
            glBindRenderbuffer = OpenGL.GetDelegateFor("glBindRenderbuffer", GLDelegates.typeof_void_uint_uint) as GLDelegates.void_uint_uint;
            glRenderbufferStorage = OpenGL.GetDelegateFor("glRenderbufferStorage", GLDelegates.typeof_void_uint_uint_int_int) as GLDelegates.void_uint_uint_int_int;
            glDeleteRenderbuffers = OpenGL.GetDelegateFor("glDeleteRenderbuffers", GLDelegates.typeof_void_int_uintN) as GLDelegates.void_int_uintN;
        }

        private uint[] renderbuffer = new uint[1];

        /// <summary>
        /// Create, update, use and delete a renderbuffer object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalformat"></param>
        /// <param name="bufferType"></param>
        public Renderbuffer(int width, int height, uint internalformat, RenderbufferType bufferType)
        {
            this.Width = width;
            this.Height = height;
            this.BufferType = bufferType;

            glGenRenderbuffers(1, renderbuffer);
            glBindRenderbuffer(OpenGL.GL_RENDERBUFFER, renderbuffer[0]);
            glRenderbufferStorage(OpenGL.GL_RENDERBUFFER,
                internalformat,// TODO: add comment about GL.GL_DEPTH24_STENCIL8, GL.GL_RGBA,
                width, height);
        }

        /// <summary>
        ///
        /// </summary>
        public RenderbufferType BufferType { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Framebuffer Id.
        /// </summary>
        public uint Id { get { return renderbuffer[0]; } }

        /// <summary>
        ///
        /// </summary>
        public int Width { get; set; }

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
        public override string ToString()
        {
            return string.Format("{0}: [w:{1}, h:{2}] {3}", this.GetType().Name, this.Width, this.Height, this.BufferType);
        }
    }
}