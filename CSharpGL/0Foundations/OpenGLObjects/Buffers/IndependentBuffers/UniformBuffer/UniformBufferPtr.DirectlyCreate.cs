using System;
namespace CSharpGL
{
    public partial class UniformBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="UniformBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static UniformBufferPtr Create(int byteLength, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.UniformBuffer, byteLength, usage, length) as UniformBufferPtr);
        }
    }
}
