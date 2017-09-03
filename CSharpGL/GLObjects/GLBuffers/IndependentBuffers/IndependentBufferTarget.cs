namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public enum IndependentBufferTarget : uint
    {
        /// <summary>
        ///
        /// </summary>
        AtomicCounterBuffer = GL.GL_ATOMIC_COUNTER_BUFFER,

        /// <summary>
        ///
        /// </summary>
        PixelPackBuffer = GL.GL_PIXEL_PACK_BUFFER,

        /// <summary>
        ///
        /// </summary>
        PixelUnpackBuffer = GL.GL_PIXEL_UNPACK_BUFFER,

        /// <summary>
        ///
        /// </summary>
        ShaderStorageBuffer = GL.GL_SHADER_STORAGE_BUFFER,

        /// <summary>
        ///
        /// </summary>
        TextureBuffer = GL.GL_TEXTURE_BUFFER,

        /// <summary>
        ///
        /// </summary>
        UniformBuffer = GL.GL_UNIFORM_BUFFER,

        /// <summary>
        /// 
        /// </summary>
        TransformFeedbackBuffer = GL.GL_TRANSFORM_FEEDBACK_BUFFER,
    }
}