using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    // https://www.opengl.org/sdk/docs/man4/html/glBindBufferBase.xhtml
    // https://www.opengl.org/wiki/GLAPI/glBindBufferRange
    /// <summary>
    /// Used for BindBufferBase() or BindBufferRange()
    /// </summary>
    public enum TransformFeedbackBufferTarget : uint
    {
        AtomicCounterBuffer = OpenGL.GL_ATOMIC_COUNTER_BUFFER,
        TransformFeedbackBuffer = OpenGL.GL_TRANSFORM_FEEDBACK_BUFFER,
        UniformBuffer = OpenGL.GL_UNIFORM_BUFFER,
        ShaderStorageBuffer = OpenGL.GL_SHADER_STORAGE_BUFFER,
    }

}
