using System;
namespace CSharpGL
{
    public partial class TextureBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="TextureBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static TextureBufferPtr Create(int byteLength, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.TextureBuffer, byteLength, usage, length) as TextureBufferPtr);
        }
    }
}
