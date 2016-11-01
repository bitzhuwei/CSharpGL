using System.Runtime.InteropServices;
namespace CSharpGL
{
    public partial class Texture
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="internalFormat"></param>
        /// <param name="bufferPtr"></param>
        /// <param name="autoDispose">Dispose <paramref name="bufferPtr"/> when disposing returned texture.</param>
        /// <returns></returns>
        public static Texture CreateBufferTexture(uint internalFormat, BufferPtr bufferPtr, bool autoDispose)
        {
            return bufferPtr.DumpBufferTexture(internalFormat, autoDispose);
        }

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="internalFormat"></param>
        /// <param name="elementCount"></param>
        /// <param name="usage"></param>
        /// <param name="dataCopying"></param>
        /// <returns></returns>
        public static Texture CreateBufferTexture<T>(uint internalFormat, int elementCount, BufferUsage usage) where T : struct
        {
            int elementLength = Marshal.SizeOf(typeof(T));
            int byteLength = elementLength * elementCount;
            TextureBufferPtr bufferPtr = TextureBufferPtr.Create(byteLength, usage, elementCount);
            return bufferPtr.DumpBufferTexture(internalFormat, autoDispose: true);
        }
    }
}