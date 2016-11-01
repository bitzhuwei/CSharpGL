using System;
namespace CSharpGL
{
    public partial class PixelUnpackBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="PixelUnpackBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PixelUnpackBufferPtr Create(int byteLength, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.PixelUnpackBuffer, byteLength, usage, length) as PixelUnpackBufferPtr);
        }
    }
}
