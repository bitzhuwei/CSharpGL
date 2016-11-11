namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public static class BufferPtrHelper
    {
        /// <summary>
        /// Dump a <see cref="Texture"/> filled with this <see cref="Buffer"/>.
        /// </summary>
        /// <param name="bufferPtr"></param>
        /// <param name="internalFormat"></param>
        /// <param name="autoDispose">Dispose <paramref name="bufferPtr"/> when disposing returned texture.</param>
        /// <returns></returns>
        public static Texture DumpBufferTexture(this Buffer bufferPtr, uint internalFormat, bool autoDispose)
        {
            var texture = new Texture(TextureTarget.TextureBuffer,
                new TexBufferImageFiller(internalFormat, bufferPtr, autoDispose),
                new NullSampler());
            texture.Initialize();
            return texture;
        }
    }
}