using System;

namespace CSharpGL
{
    /// <summary>
    /// TextureBufferObject matches <code>uniform samplerBuffer xxx;</code> in GLSL shader.
    /// </summary>
    public partial class TextureBuffer : GLBuffer
    {
        /// <summary>
        /// TextureBufferObject matches <code>uniform samplerBuffer xxx;</code> in GLSL shader.
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此buffer含有多个个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此buffer中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        internal TextureBuffer(
            uint bufferId, int length, int byteLength)
            : base(bufferId, length, byteLength)
        {
            this.Target = BufferTarget.TextureBuffer;
        }

        /// <summary>
        /// Creates a <see cref="TextureBuffer"/> object directly in server side(GPU) without initializing its value.
        /// </summary>
        /// <param name="elementType"></param>
        /// <param name="length"></param>
        /// <param name="usage"></param>
        /// <returns></returns>
        public static TextureBuffer Create(Type elementType, int length, BufferUsage usage)
        {
            return (GLBuffer.Create(IndependentBufferTarget.TextureBuffer, elementType, length, usage) as TextureBuffer);
        }
    }
}