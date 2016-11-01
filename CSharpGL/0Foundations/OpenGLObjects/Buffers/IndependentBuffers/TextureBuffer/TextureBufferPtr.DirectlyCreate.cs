using System;
namespace CSharpGL
{
    public partial class TextureBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="OneIndexBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <param name="mode"></param>
        /// <param name="type"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static TextureBufferPtr Create(int byteLength, BufferUsage usage, DrawMode mode, IndexElementType type, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.TextureBuffer, byteLength, usage, mode, type, length) as TextureBufferPtr);
        }
    }
}
