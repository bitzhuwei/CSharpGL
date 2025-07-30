using System;
using System.Runtime.InteropServices;

namespace CSharpGL {
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    public unsafe partial class PixelPackBuffer : GLBuffer {
        /// <summary>
        /// pixel unpack buffer's pointer.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此buffer含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此buffer中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal PixelPackBuffer(
            GLuint bufferId, int length, int byteLength, Usage usage)
            : base(Target.PixelPackBuffer, bufferId, length, byteLength, usage) {
        }

        /// <summary>
        /// Creates a <see cref="PixelPackBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="count">how many elements?</param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static PixelPackBuffer Create(Type elementType, int count, GLBuffer.Usage usage) {
            if (!elementType.IsValueType) { throw new ArgumentException(string.Format("{0} must be a value type!", elementType)); }

            var byteLength = Marshal.SizeOf(elementType) * count;
            var bufferId = CallGL((GLenum)IndependentBufferTarget.PixelPackBuffer, byteLength, IntPtr.Zero, usage);

            var buffer = new PixelPackBuffer(bufferId, count, byteLength, usage);
            return buffer;
        }
    }
}