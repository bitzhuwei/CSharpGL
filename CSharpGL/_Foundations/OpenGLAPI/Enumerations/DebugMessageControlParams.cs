using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum DebugMessageControlSource : uint
    {
        /// <summary>
        /// 
        /// </summary>
        DONT_CARE = OpenGL.GL_DONT_CARE,
        /// <summary>
        /// 
        /// </summary>
        API_ARB = OpenGL.GL_DEBUG_SOURCE_API_ARB,
        /// <summary>
        /// 
        /// </summary>
        WINDOW_SYSTEM_ARB = OpenGL.GL_DEBUG_SOURCE_WINDOW_SYSTEM_ARB,
        /// <summary>
        /// 
        /// </summary>
        SHADER_COMPILER_ARB = OpenGL.GL_DEBUG_SOURCE_SHADER_COMPILER_ARB,
        /// <summary>
        /// 
        /// </summary>
        THIRD_PARTY_ARB = OpenGL.GL_DEBUG_SOURCE_THIRD_PARTY_ARB,
        /// <summary>
        /// 
        /// </summary>
        APPLICATION_ARB = OpenGL.GL_DEBUG_SOURCE_APPLICATION_ARB,
        /// <summary>
        /// 
        /// </summary>
        OTHER_ARB = OpenGL.GL_DEBUG_SOURCE_OTHER_ARB,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum DebugMessageControlType : uint
    {
        /// <summary>
        /// 
        /// </summary>
        DONT_CARE = OpenGL.GL_DONT_CARE,
        /// <summary>
        /// 
        /// </summary>
        DEBUG_TYPE_ERROR_ARB = OpenGL.GL_DEBUG_TYPE_ERROR_ARB,
        /// <summary>
        /// 
        /// </summary>
        DEBUG_TYPE_DEPRECATED_BEHAVIOR_ARB = OpenGL.GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR_ARB,
        /// <summary>
        /// 
        /// </summary>
        DEBUG_TYPE_UNDEFINED_BEHAVIOR_ARB = OpenGL.GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR_ARB,
        /// <summary>
        /// 
        /// </summary>
        DEBUG_TYPE_PORTABILITY_ARB = OpenGL.GL_DEBUG_TYPE_PORTABILITY_ARB,
        /// <summary>
        /// 
        /// </summary>
        DEBUG_TYPE_PERFORMANCE_ARB = OpenGL.GL_DEBUG_TYPE_PERFORMANCE_ARB,
        /// <summary>
        /// 
        /// </summary>
        DEBUG_TYPE_OTHER_ARB = OpenGL.GL_DEBUG_TYPE_OTHER_ARB,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum DebugMessageControlSeverity : uint
    {
        /// <summary>
        /// 
        /// </summary>
        DONT_CARE = OpenGL.GL_DONT_CARE,
        /// <summary>
        /// 
        /// </summary>
        DEBUG_SEVERITY_HIGH_ARB = OpenGL.GL_DEBUG_SEVERITY_HIGH_ARB,
        /// <summary>
        /// 
        /// </summary>
        DEBUG_SEVERITY_MEDIUM_ARB = OpenGL.GL_DEBUG_SEVERITY_MEDIUM_ARB,
        /// <summary>
        /// 
        /// </summary>
        DEBUG_SEVERITY_LOW_ARB = OpenGL.GL_DEBUG_SEVERITY_LOW_ARB,
        //DEBUG_SEVERITY_NOTIFICATION_ARB = GL.GL_DEBUG_SEVERITY_NOTIFICATION_ARB,
    }
}
