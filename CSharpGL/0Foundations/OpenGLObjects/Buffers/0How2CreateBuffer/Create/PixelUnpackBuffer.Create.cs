using System;

namespace CSharpGL
{
    public partial class PixelUnpackBuffer
    {
        /// <summary>
        /// Creates a <see cref="PixelUnpackBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PixelUnpackBuffer Create(Type elementType, BufferUsage usage, int length)
        {
            return (Buffer.Create(IndependentBufferTarget.PixelUnpackBuffer, elementType, usage, length) as PixelUnpackBuffer);
        }
    }
}