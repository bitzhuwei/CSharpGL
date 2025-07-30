namespace CSharpGL {
    /// <summary>
    ///
    /// </summary>
    public enum IndependentBufferTarget : GLuint {
        AtomicCounterBuffer = GL.GL_ATOMIC_COUNTER_BUFFER,
        PixelPackBuffer = GL.GL_PIXEL_PACK_BUFFER,
        PixelUnpackBuffer = GL.GL_PIXEL_UNPACK_BUFFER,
        ShaderStorageBuffer = GL.GL_SHADER_STORAGE_BUFFER,
        TextureBuffer = GL.GL_TEXTURE_BUFFER,
        UniformBuffer = GL.GL_UNIFORM_BUFFER,
        TransformFeedbackBuffer = GL.GL_TRANSFORM_FEEDBACK_BUFFER,
    }
}