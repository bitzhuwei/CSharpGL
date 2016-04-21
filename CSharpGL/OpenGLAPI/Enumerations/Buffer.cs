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

    ///// <summary>
    ///// STREAM: You should use STREAM_DRAW when the data store contents will be modified once and used at most a few times.
    ///// <para>STATIC: Use STATIC_DRAW when the data store contents will be modified once and used many times.</para>
    ///// <para>DYNAMIC: Use DYNAMIC_DRAW when the data store contents will be modified repeatedly and used many times.</para>
    ///// </summary>
    /// <summary>
    /// <para>Static-只需要一次指定缓冲区对象中的数据,但使用次数很多.</para>
    /// <para>Dynamic-数据不仅需要时常更新,使用次数也很多.</para>
    /// <para>Stream-缓冲区的对象需要时常更新,但使用次数很少.</para>
    /// <para>Draw-数据作为顶点数据,用于渲染.</para>
    /// <para>Read-数据从一个OpenGL缓冲区(桢缓冲区之类的)读取,并在程序中与渲染并不直接相关的各种计算过程中使用.</para>
    /// <para>Copy-数据从一个OpenGL缓冲区读取,然后作为顶点数据,用于渲染.</para>
    /// </summary>
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
