using System;
namespace CSharpGL
{
    public partial class PixelPackBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="PixelPackBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PixelPackBufferPtr Create(int byteLength, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.PixelPackBuffer, byteLength, usage, length) as PixelPackBufferPtr);
        }
    }
}
