using System;

namespace CSharpGL
{
    public partial class PixelPackBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="PixelPackBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PixelPackBufferPtr Create(Type elementType, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.PixelPackBuffer, elementType, usage, length) as PixelPackBufferPtr);
        }
    }
}