using System;
namespace CSharpGL
{
    public partial class ShaderStorageBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="ShaderStorageBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ShaderStorageBufferPtr Create(int byteLength, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.ShaderStorageBuffer, byteLength, usage, length) as ShaderStorageBufferPtr);
        }
    }
}
