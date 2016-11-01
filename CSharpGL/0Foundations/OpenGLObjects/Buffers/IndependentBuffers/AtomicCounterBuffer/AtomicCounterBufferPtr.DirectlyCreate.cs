using System;

namespace CSharpGL
{
    public partial class AtomicCounterBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="AtomicCounterBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static AtomicCounterBufferPtr Create(Type elementType, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.AtomicCounterBuffer, elementType, usage, length) as AtomicCounterBufferPtr);
        }
    }
}