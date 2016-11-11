using System;

namespace CSharpGL
{
    public partial class TextureBuffer
    {
        /// <summary>
        /// Creates a <see cref="TextureBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static TextureBuffer Create(Type elementType, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.TextureBuffer, elementType, usage, length) as TextureBuffer);
        }
    }
}