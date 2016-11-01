using System;

namespace CSharpGL
{
    public partial class TextureBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="TextureBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static TextureBufferPtr Create(Type elementType, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.TextureBuffer, elementType, usage, length) as TextureBufferPtr);
        }
    }
}