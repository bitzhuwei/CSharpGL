using System;

namespace CSharpGL
{
    public partial class AtomicCounterBuffer
    {
        /// <summary>
        /// Creates a <see cref="AtomicCounterBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static AtomicCounterBuffer Create(Type elementType, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.AtomicCounterBuffer, elementType, usage, length) as AtomicCounterBuffer);
        }
    }
}