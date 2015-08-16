using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    // https://www.opengl.org/sdk/docs/man4/html/glBindBufferBase.xhtml
    // https://www.opengl.org/wiki/GLAPI/glBindBufferRange
    public enum BindBufferTarget : uint
    {
        TransformFeedbackBuffer = GL.GL_TRANSFORM_FEEDBACK_BUFFER,
        AtomicCounterBuffer = GL.GL_ATOMIC_COUNTER_BUFFER,
        UniformBuffer = GL.GL_UNIFORM_BUFFER,
        ShaderStorageBuffer = GL.GL_SHADER_STORAGE_BUFFER,
    }

}
