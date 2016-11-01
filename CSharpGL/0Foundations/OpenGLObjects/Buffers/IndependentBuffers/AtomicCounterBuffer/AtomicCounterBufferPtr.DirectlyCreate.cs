using System;
namespace CSharpGL
{
    public partial class AtomicCounterBufferPtr
    {
        /// <summary>
        /// Creates a <see cref="AtomicCounterBufferPtr"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="byteLength"></param>
        /// <param name="usage"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static AtomicCounterBufferPtr Create(int byteLength, BufferUsage usage, int length)
        {
            return (IndependentBufferPtr.Create(IndependentBufferTarget.AtomicCounterBuffer, byteLength, usage, length) as AtomicCounterBufferPtr);
        }
    }
}
