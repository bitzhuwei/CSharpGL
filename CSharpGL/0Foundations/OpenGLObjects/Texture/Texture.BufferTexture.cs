using System.Runtime.InteropServices;
namespace CSharpGL
{
    public partial class Texture
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="buffer"></param>
        /// <param name="autoDispose">Dispose <paramref name="buffer"/> when disposing returned texture.</param>
        /// <returns></returns>
        public static Texture CreateBufferTexture(uint internalFormat, Buffer buffer, bool autoDispose)
        {
            return buffer.DumpBufferTexture(internalFormat, autoDispose);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="internalFormat"></param>
        /// <param name="elementCount"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static Texture CreateBufferTexture<T>(uint internalFormat, int elementCount, BufferUsage usage) where T : struct
        {
            TextureBuffer buffer = TextureBuffer.Create(typeof(T), elementCount, usage);
            return buffer.DumpBufferTexture(internalFormat, autoDispose: true);
        }
    }
}