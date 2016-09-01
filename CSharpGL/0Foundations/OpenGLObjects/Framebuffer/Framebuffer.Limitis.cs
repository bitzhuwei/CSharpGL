namespace CSharpGL
{
    public partial class Framebuffer
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxColorAttachments()
        {
            var result = new int[1];
            OpenGL.GetInteger(OpenGL.GL_MAX_COLOR_ATTACHMENTS, result);
            return result[0];
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxFramebufferWidth()
        {
            var result = new int[1];
            OpenGL.GetInteger(OpenGL.GL_MAX_FRAMEBUFFER_WIDTH, result);
            return result[0];
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxFramebufferHeight()
        {
            var result = new int[1];
            OpenGL.GetInteger(OpenGL.GL_MAX_FRAMEBUFFER_HEIGHT, result);
            return result[0];
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxFramebufferLayers()
        {
            var result = new int[1];
            OpenGL.GetInteger(OpenGL.GL_MAX_FRAMEBUFFER_LAYERS, result);
            return result[0];
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxFramebufferSamples()
        {
            var result = new int[1];
            OpenGL.GetInteger(OpenGL.GL_MAX_FRAMEBUFFER_SAMPLES, result);
            return result[0];
        }

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public static int DefaultWidth()
        //{
        //    var result = new int[1];
        //    OpenGL.GetInteger(OpenGL.GL_FRAMEBUFFER_DEFAULT_WIDTH, result);
        //    return result[0];
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public static int DefaultHeight()
        //{
        //    var result = new int[1];
        //    OpenGL.GetInteger(OpenGL.GL_FRAMEBUFFER_DEFAULT_HEIGHT, result);
        //    return result[0];
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public static int DefaultLayers()
        //{
        //    var result = new int[1];
        //    OpenGL.GetInteger(OpenGL.GL_FRAMEBUFFER_DEFAULT_LAYERS, result);
        //    return result[0];
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public static int DefaultSamples()
        //{
        //    var result = new int[1];
        //    OpenGL.GetInteger(OpenGL.GL_FRAMEBUFFER_DEFAULT_SAMPLES, result);
        //    return result[0];
        //}

        ///// <summary>
        /////
        ///// </summary>
        ///// <returns></returns>
        //public static int DefaultFixedSampleLocations()
        //{
        //    var result = new int[1];
        //    OpenGL.GetInteger(OpenGL.GL_FRAMEBUFFER_DEFAULT_FIXED_SAMPLES_LOCATIONS, result);
        //    return result[0];
        //}
    }
}