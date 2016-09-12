using System;

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
        /// <param name="noDataCopyed"></param>
        /// <returns></returns>
        public static Texture CreateBufferTexture<T>(uint internalFormat, int elementCount, BufferUsage usage, bool noDataCopyed = false) where T : struct
        {
            var buffer = new TextureBuffer<T>(usage, noDataCopyed);
            buffer.Create(elementCount);
            BufferPtr bufferPtr = buffer.GetBufferPtr();

            const bool autoDispose = true;
            return bufferPtr.DumpBufferTexture(internalFormat, autoDispose);
        }
    }
}