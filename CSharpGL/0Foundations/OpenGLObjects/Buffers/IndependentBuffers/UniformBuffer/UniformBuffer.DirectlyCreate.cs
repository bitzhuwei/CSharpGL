using System;

namespace CSharpGL
{
    public partial class UniformBuffer
    {
        /// <summary>
        /// Creates a <see cref="UniformBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static UniformBuffer Create(Type elementType, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.UniformBuffer, elementType, usage, length) as UniformBuffer);
        }
    }
}