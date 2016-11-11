using System;

namespace CSharpGL
{
    public partial class ShaderStorageBuffer
    {
        /// <summary>
        /// Creates a <see cref="ShaderStorageBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static ShaderStorageBuffer Create(Type elementType, BufferUsage usage, int length)
        {
            return (IndependentBuffer.Create(IndependentBufferTarget.ShaderStorageBuffer, elementType, usage, length) as ShaderStorageBuffer);
        }
    }
}