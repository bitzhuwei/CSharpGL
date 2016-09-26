namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum BufferTarget : uint
    {
        /// <summary>
        /// vertex attribute buffer object.
        /// </summary>
        ArrayBuffer = OpenGL.GL_ARRAY_BUFFER,

        /// <summary>
        /// glDrawElements().
        /// </summary>
        ElementArrayBuffer = OpenGL.GL_ELEMENT_ARRAY_BUFFER,

        /// <summary>
        /// This means that this buffer doesn't have (or need) a valid binding target.
        /// </summary>
        InvalidTarget = 0,

        /// <summary>
        ///
        /// </summary>
        UniformBuffer = OpenGL.GL_UNIFORM_BUFFER,

        /// <summary>
        ///
        /// </summary>
        TransformFeedbackBuffer = OpenGL.GL_TRANSFORM_FEEDBACK_BUFFER,

        /// <summary>
        ///
        /// </summary>
        PixelUnpackBuffer = OpenGL.GL_PIXEL_UNPACK_BUFFER,

        /// <summary>
        ///
        /// </summary>
        AtomicCounterBuffer = OpenGL.GL_ATOMIC_COUNTER_BUFFER,

        /// <summary>
        ///
        /// </summary>
        TextureBuffer = OpenGL.GL_TEXTURE_BUFFER,

        /// <summary>
        ///
        /// </summary>
        ShaderStorageBuffer = OpenGL.GL_SHADER_STORAGE_BUFFER,
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
        /// <summary>
        ///
        /// </summary>
        StreamDraw = OpenGL.GL_STREAM_DRAW,//= 0x88E0,

        /// <summary>
        ///
        /// </summary>
        StreamRead = OpenGL.GL_STREAM_READ,//= 0x88E1,

        /// <summary>
        ///
        /// </summary>
        StreamCopy = OpenGL.GL_STREAM_COPY,//= 0x88E2,

        /// <summary>
        ///
        /// </summary>
        StaticDraw = OpenGL.GL_STATIC_DRAW,//= 0x88E4,

        /// <summary>
        ///
        /// </summary>
        StaticRead = OpenGL.GL_STATIC_READ,//= 0x88E5,

        /// <summary>
        ///
        /// </summary>
        StaticCopy = OpenGL.GL_STATIC_COPY,//= 0x88E6,

        /// <summary>
        ///
        /// </summary>
        DynamicDraw = OpenGL.GL_DYNAMIC_DRAW,//= 0x88E8,

        /// <summary>
        ///
        /// </summary>
        DynamicRead = OpenGL.GL_DYNAMIC_READ,//= 0x88E9,

        /// <summary>
        ///
        /// </summary>
        DynamicCopy = OpenGL.GL_DYNAMIC_COPY,//= 0x88EA,
    }
}