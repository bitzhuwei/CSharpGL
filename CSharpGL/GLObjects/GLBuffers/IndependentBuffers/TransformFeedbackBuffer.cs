using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace CSharpGL {
    /// <summary>
    /// 位于服务器端（GPU内存）的定长数组。
    /// <para>An array at server side (GPU memory) with fixed length.</para>
    /// </summary>

    public unsafe partial class TransformFeedbackBuffer : GLBuffer, IDisposable {
        /// <summary>
        /// 位于服务器端（GPU内存）的定长数组。
        /// <para>An array at server side (GPU memory) with fixed length.</para>
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此buffer含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此buffer中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal TransformFeedbackBuffer(uint bufferId, int length, int byteLength, Usage usage)
            : base(Target.TransformFeedbackBuffer, bufferId, length, byteLength, usage) {
        }

        /// <summary>
        /// Creates a <see cref="AtomicCounterBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="count">how many elements?</param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TransformFeedbackBuffer Create(Type elementType, int count, GLBuffer.Usage usage) {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            var byteLength = Marshal.SizeOf(elementType) * count;
            var bufferId = CallGL((GLenum)IndependentBufferTarget.TransformFeedbackBuffer, byteLength, IntPtr.Zero, usage);

            var buffer = new TransformFeedbackBuffer(bufferId, count, byteLength, usage);
            return buffer;
        }
    }
}
