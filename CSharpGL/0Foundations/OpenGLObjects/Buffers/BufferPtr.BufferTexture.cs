namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class BufferPtrHelper
    {
        /// <summary>
        /// Dump a <see cref="Texture"/> filled with this <see cref="BufferPtr"/>.
        /// </summary>
        /// <param name="bufferPtr"></param>
        /// <param name="internalFormat"></param>
        /// <param name="autoDispose">Dispose <paramref name="bufferPtr"/> when disposing returned texture.</param>
        /// <returns></returns>
        public static Texture DumpBufferTexture(this BufferPtr bufferPtr, uint internalFormat, bool autoDispose)
        {
            var texture = new Texture(BindTextureTarget.TextureBuffer,
                new TexBufferImageFiller(internalFormat, bufferPtr, autoDispose),
                new NullSampler());
            texture.Initialize();
            return texture;
        }
    }
}