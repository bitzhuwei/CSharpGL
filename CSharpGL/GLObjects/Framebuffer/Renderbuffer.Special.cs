namespace CSharpGL {
    /// <summary>
    /// Create, update, use and delete a framebuffer object.
    /// </summary>
    public unsafe partial class Renderbuffer {
        /// <summary>
        ///
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalFormat"></param>
        /// <returns></returns>
        public static Renderbuffer CreateDepthbuffer(int width, int height, DepthComponentType internalFormat = DepthComponentType.DepthComponent) {
            var renderbuffer = new Renderbuffer(width, height, (GLenum)internalFormat);

            return renderbuffer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalFormat"></param>
        /// <returns></returns>
        public static Renderbuffer CreateColorbuffer(int width, int height, GLenum internalFormat = GL.GL_RGBA) {
            var renderbuffer = new Renderbuffer(width, height, internalFormat);

            return renderbuffer;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public enum DepthComponentType : GLuint {
        /// <summary>
        ///
        /// </summary>
        DepthComponent = GL.GL_DEPTH_COMPONENT,

        /// <summary>
        ///
        /// </summary>
        DepthComponent24 = GL.GL_DEPTH_COMPONENT24,
    }
}