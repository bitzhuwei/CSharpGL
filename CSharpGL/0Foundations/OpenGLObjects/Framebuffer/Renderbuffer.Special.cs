namespace CSharpGL
{
    /// <summary>
    /// Create, update, use and delete a framebuffer object.
    /// </summary>
    public partial class Renderbuffer
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalFormat"></param>
        /// <returns></returns>
        public static Renderbuffer CreateDepthbuffer(int width, int height, DepthComponentType internalFormat = DepthComponentType.DepthComponent)
        {
            return CreateDepthbuffer(width, height, (uint)internalFormat);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalFormat"></param>
        /// <returns></returns>
        public static Renderbuffer CreateDepthbuffer(int width, int height, uint internalFormat = OpenGL.GL_DEPTH_COMPONENT)
        {
            var renderbuffer = new Renderbuffer(width, height, internalFormat, RenderbufferType.DepthBuffer);

            return renderbuffer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="internalFormat"></param>
        /// <returns></returns>
        public static Renderbuffer CreateColorbuffer(int width, int height, uint internalFormat = OpenGL.GL_RGBA)
        {
            var renderbuffer = new Renderbuffer(width, height, internalFormat, RenderbufferType.ColorBuffer);

            return renderbuffer;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public enum DepthComponentType : uint
    {
        /// <summary>
        ///
        /// </summary>
        DepthComponent = OpenGL.GL_DEPTH_COMPONENT,

        /// <summary>
        ///
        /// </summary>
        DepthComponent24 = OpenGL.GL_DEPTH_COMPONENT24,
    }
}