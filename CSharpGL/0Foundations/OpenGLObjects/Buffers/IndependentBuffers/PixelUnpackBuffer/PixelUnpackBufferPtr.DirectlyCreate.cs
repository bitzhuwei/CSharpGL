using System;

namespace CSharpGL
{
    public partial class PixelUnpackBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="PixelUnpackBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PixelUnpackBufferPtr Create(Type elementType, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.PixelUnpackBuffer, elementType, usage, length) as PixelUnpackBufferPtr);
        }
    }
}