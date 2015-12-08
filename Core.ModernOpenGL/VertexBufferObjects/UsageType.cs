using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexBufferObjects
{

    public enum UsageType : uint
    {
        StreamDraw = GL.GL_STREAM_DRAW,
        StreamRead = GL.GL_STREAM_READ,
        StreamCopy = GL.GL_STREAM_COPY,
        StaticDraw = GL.GL_STATIC_DRAW,
        StaticRead = GL.GL_STATIC_READ,
        StaticCopy = GL.GL_STATIC_COPY,
        DynamicDraw = GL.GL_DYNAMIC_DRAW,
        DynamicRead = GL.GL_DYNAMIC_READ,
        DynamicCopy = GL.GL_DYNAMIC_COPY,
    }
}
