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
        AtomicCounterBuffer = OpenGL.GL_ATOMIC_COUNTER_BUFFER,

        /// <summary>
        ///
        /// </summary>
        PixelPackBuffer = OpenGL.GL_PIXEL_PACK_BUFFER,

        /// <summary>
        ///
        /// </summary>
        PixelUnpackBuffer = OpenGL.GL_PIXEL_UNPACK_BUFFER,

        /// <summary>
        ///
        /// </summary>
        ShaderStorageBuffer = OpenGL.GL_SHADER_STORAGE_BUFFER,

        /// <summary>
        ///
        /// </summary>
        TextureBuffer = OpenGL.GL_TEXTURE_BUFFER,

        /// <summary>
        ///
        /// </summary>
        UniformBuffer = OpenGL.GL_UNIFORM_BUFFER,
    }
}