using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    // https://www.opengl.org/sdk/docs/man4/html/glBindBufferBase.xhtml
    // https://www.opengl.org/wiki/GLAPI/glBindBufferRange
    /// <summary>
    /// Used for BindBufferBase() or BindBufferRange()
    /// </summary>
    public enum BindBufferBaseTarget : uint
    {
        /// <summary>
        /// 
        /// </summary>
        AtomicCounterBuffer = OpenGL.GL_ATOMIC_COUNTER_BUFFER,
        /// <summary>
        /// 
        /// </summary>
        TransformFeedbackBuffer = OpenGL.GL_TRANSFORM_FEEDBACK_BUFFER,
        /// <summary>
        /// 
        /// </summary>
        UniformBuffer = OpenGL.GL_UNIFORM_BUFFER,
        /// <summary>
        /// 
        /// </summary>
        ShaderStorageBuffer = OpenGL.GL_SHADER_STORAGE_BUFFER,
    }

}
