using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum BufferTarget : uint
    {
        ArrayBuffer = GL.GL_ARRAY_BUFFER,
        ElementArrayBuffer = GL.GL_ELEMENT_ARRAY_BUFFER,
        UniformBuffer = GL.GL_UNIFORM_BUFFER,
        TransformFeedbackBuffer = GL.GL_TRANSFORM_FEEDBACK_BUFFER,
    }

    public enum BufferUsage : uint
    {
        StreamDraw = GL.GL_STREAM_DRAW,//= 0x88E0,
        StreamRead = GL.GL_STREAM_READ,//= 0x88E1,
        StreamCopy = GL.GL_STREAM_COPY,//= 0x88E2,
        StaticDraw = GL.GL_STATIC_DRAW,//= 0x88E4,
        StaticRead = GL.GL_STATIC_READ,//= 0x88E5,
        StaticCopy = GL.GL_STATIC_COPY,//= 0x88E6,
        DynamicDraw = GL.GL_DYNAMIC_DRAW,//= 0x88E8,
        DynamicRead = GL.GL_DYNAMIC_READ,//= 0x88E9,
        DynamicCopy = GL.GL_DYNAMIC_COPY,//= 0x88EA,
    }
}
