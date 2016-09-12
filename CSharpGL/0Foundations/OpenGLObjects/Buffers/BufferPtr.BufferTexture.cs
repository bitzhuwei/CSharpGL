namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public static class BufferPtrHelper
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferPtr"></param>
        /// <param name="internalFormat"></param>
        /// <param name="autoDispose">Dispose <paramref name="bufferPtr"/> when disposing returned texture.</param>
        /// <returns></returns>
        public static Texture DumpBufferTexture(this BufferPtr bufferPtr, uint internalFormat, bool autoDispose)
        {
            return Texture.CreateBufferTexture(internalFormat, bufferPtr, autoDispose);
        }
    }
}