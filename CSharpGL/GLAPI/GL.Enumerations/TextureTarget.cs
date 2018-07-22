namespace CSharpGL
{
    /// <summary>
    /// Specifies the target to which the texture is bound.
    /// </summary>
    public enum TextureTarget : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Texture1D = GL.GL_TEXTURE_1D,

        /// <summary>
        ///
        /// </summary>
        Texture2D = GL.GL_TEXTURE_2D,

        /// <summary>
        /// 
        /// </summary>
        Texture2DMultisample = GL.GL_TEXTURE_2D_MULTISAMPLE,

        /// <summary>
        /// 
        /// </summary>
        Texture2DArray = GL.GL_TEXTURE_2D_ARRAY,

        /// <summary>
        ///
        /// </summary>
        Texture3D = GL.GL_TEXTURE_3D,

        /// <summary>
        /// 
        /// </summary>
        Texture2DMultisampleArray = GL.GL_TEXTURE_2D_MULTISAMPLE_ARRAY,

        /// <summary>
        ///
        /// </summary>
        TextureCubeMap = GL.GL_TEXTURE_CUBE_MAP,

        /// <summary>
        ///
        /// </summary>
        TextureBuffer = GL.GL_TEXTURE_BUFFER,

        /// <summary>
        /// 
        /// </summary>
        TextureRectangle = GL.GL_TEXTURE_RECTANGLE,
    }
}