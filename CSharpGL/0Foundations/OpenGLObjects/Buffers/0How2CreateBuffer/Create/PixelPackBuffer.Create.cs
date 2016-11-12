using System;

namespace CSharpGL
{
    public partial class PixelPackBuffer
    {
        /// <summary>
        /// Creates a <see cref="PixelPackBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static PixelPackBuffer Create(Type elementType, BufferUsage usage, int length)
        {
            return (Buffer.Create(IndependentBufferTarget.PixelPackBuffer, elementType, usage, length) as PixelPackBuffer);
        }
    }
}