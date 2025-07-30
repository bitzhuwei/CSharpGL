﻿namespace SoftGLImpl {
    /// <summary>
    ///
    /// </summary>
    public enum BufferTarget : uint {
        /// <summary>
        /// vertex attribute buffer object.
        /// </summary>
        ArrayBuffer = GL.GL_ARRAY_BUFFER,

        /// <summary>
        /// glDrawElements().
        /// </summary>
        ElementArrayBuffer = GL.GL_ELEMENT_ARRAY_BUFFER,

        /// <summary>
        ///
        /// </summary>
        UniformBuffer = GL.GL_UNIFORM_BUFFER,

        /// <summary>
        ///
        /// </summary>
        TransformFeedbackBuffer = GL.GL_TRANSFORM_FEEDBACK_BUFFER,

        /// <summary>
        ///
        /// </summary>
        PixelUnpackBuffer = GL.GL_PIXEL_UNPACK_BUFFER,

        /// <summary>
        /// 
        /// </summary>
        PixelPackBuffer = GL.GL_PIXEL_PACK_BUFFER,

        /// <summary>
        ///
        /// </summary>
        AtomicCounterBuffer = GL.GL_ATOMIC_COUNTER_BUFFER,

        /// <summary>
        ///
        /// </summary>
        TextureBuffer = GL.GL_TEXTURE_BUFFER,

        /// <summary>
        ///
        /// </summary>
        ShaderStorageBuffer = GL.GL_SHADER_STORAGE_BUFFER,
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
    public enum BufferUsage : uint {
        /// <summary>
        ///
        /// </summary>
        StreamDraw = GL.GL_STREAM_DRAW,//= 0x88E0,

        /// <summary>
        ///
        /// </summary>
        StreamRead = GL.GL_STREAM_READ,//= 0x88E1,

        /// <summary>
        ///
        /// </summary>
        StreamCopy = GL.GL_STREAM_COPY,//= 0x88E2,

        /// <summary>
        ///
        /// </summary>
        StaticDraw = GL.GL_STATIC_DRAW,//= 0x88E4,

        /// <summary>
        ///
        /// </summary>
        StaticRead = GL.GL_STATIC_READ,//= 0x88E5,

        /// <summary>
        ///
        /// </summary>
        StaticCopy = GL.GL_STATIC_COPY,//= 0x88E6,

        /// <summary>
        ///
        /// </summary>
        DynamicDraw = GL.GL_DYNAMIC_DRAW,//= 0x88E8,

        /// <summary>
        ///
        /// </summary>
        DynamicRead = GL.GL_DYNAMIC_READ,//= 0x88E9,

        /// <summary>
        ///
        /// </summary>
        DynamicCopy = GL.GL_DYNAMIC_COPY,//= 0x88EA,
    }
}