namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum DebugSource : uint
    {
        /// <summary>
        ///
        /// </summary>
        DEBUG_SOURCE_API = OpenGL.GL_DEBUG_SOURCE_API,

        /// <summary>
        ///
        /// </summary>
        DEBUG_SOURCE_WINDOW_SYSTEM = OpenGL.GL_DEBUG_SOURCE_WINDOW_SYSTEM,

        /// <summary>
        ///
        /// </summary>
        DEBUG_SOURCE_SHADER_COMPILER = OpenGL.GL_DEBUG_SOURCE_SHADER_COMPILER,

        /// <summary>
        ///
        /// </summary>
        DEBUG_SOURCE_THIRD_PARTY = OpenGL.GL_DEBUG_SOURCE_THIRD_PARTY,

        /// <summary>
        ///
        /// </summary>
        DEBUG_SOURCE_APPLICATION = OpenGL.GL_DEBUG_SOURCE_APPLICATION,

        /// <summary>
        ///
        /// </summary>
        DEBUG_SOURCE_OTHER = OpenGL.GL_DEBUG_SOURCE_OTHER,
    }

    /// <summary>
    ///
    /// </summary>
    public enum DebugType : uint
    {
        /// <summary>
        ///
        /// </summary>
        DEBUG_TYPE_ERROR = OpenGL.GL_DEBUG_TYPE_ERROR,

        /// <summary>
        ///
        /// </summary>
        DEBUG_TYPE_DEPRECATED_BEHAVIOR = OpenGL.GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR,

        /// <summary>
        ///
        /// </summary>
        DEBUG_TYPE_UNDEFINED_BEHAVIOR = OpenGL.GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR,

        /// <summary>
        ///
        /// </summary>
        DEBUG_TYPE_PORTABILITY = OpenGL.GL_DEBUG_TYPE_PORTABILITY,

        /// <summary>
        ///
        /// </summary>
        DEBUG_TYPE_PERFORMANCE = OpenGL.GL_DEBUG_TYPE_PERFORMANCE,

        /// <summary>
        ///
        /// </summary>
        DEBUG_TYPE_OTHER = OpenGL.GL_DEBUG_TYPE_OTHER,
    }

    /// <summary>
    ///
    /// </summary>
    public enum DebugSeverity : uint
    {
        /// <summary>
        ///
        /// </summary>
        DEBUG_SEVERITY_HIGH = OpenGL.GL_DEBUG_SEVERITY_HIGH,

        /// <summary>
        ///
        /// </summary>
        DEBUG_SEVERITY_MEDIUM = OpenGL.GL_DEBUG_SEVERITY_MEDIUM,

        /// <summary>
        ///
        /// </summary>
        DEBUG_SEVERITY_LOW = OpenGL.GL_DEBUG_SEVERITY_LOW,

        //DEBUG_SEVERITY_NOTIFICATION = GL.GL_DEBUG_SEVERITY_NOTIFICATION,
    }
}