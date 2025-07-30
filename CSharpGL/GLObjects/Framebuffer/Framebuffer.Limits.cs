namespace CSharpGL {
    public unsafe partial class Framebuffer {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxColorAttachments() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_MAX_COLOR_ATTACHMENTS, result);
            return result[0];
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxFramebufferWidth() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_MAX_FRAMEBUFFER_WIDTH, result);
            return result[0];
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxFramebufferHeight() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_MAX_FRAMEBUFFER_HEIGHT, result);
            return result[0];
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxFramebufferLayers() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_MAX_FRAMEBUFFER_LAYERS, result);
            return result[0];
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public static int MaxFramebufferSamples() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_MAX_FRAMEBUFFER_SAMPLES, result);
            return result[0];
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static int DefaultWidth() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_FRAMEBUFFER_DEFAULT_WIDTH, result);
            return result[0];
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static int DefaultHeight() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_FRAMEBUFFER_DEFAULT_HEIGHT, result);
            return result[0];
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static int DefaultLayers() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_FRAMEBUFFER_DEFAULT_LAYERS, result);
            return result[0];
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static int DefaultSamples() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_FRAMEBUFFER_DEFAULT_SAMPLES, result);
            return result[0];
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public static int DefaultFixedSampleLocations() {
            var gl = GL.current; if (gl == null) { return -1; }
            var result = stackalloc int[1];
            gl.glGetIntegerv(GL.GL_FRAMEBUFFER_DEFAULT_FIXED_SAMPLES_LOCATIONS, result);
            return result[0];
        }
    }
}