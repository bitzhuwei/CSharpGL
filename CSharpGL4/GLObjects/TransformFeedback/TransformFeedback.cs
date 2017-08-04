using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace CSharpGL
{
    /// <summary>
    /// 位于服务器端（GPU内存）的定长数组。
    /// <para>An array at server side (GPU memory) with fixed length.</para>
    /// </summary>
    [Editor(typeof(PropertyGridEditor), typeof(UITypeEditor))]
    public abstract partial class TransformFeedback : IDisposable
    {
        /// <summary>
        /// 用glGenBuffers()得到的VBO的Id。
        /// <para>Id got from glGenBuffers();</para>
        /// </summary>
        public uint Id { get; private set; }

        /// <summary>
        /// 此VBO含有多少个元素？
        /// <para>How many elements in thie buffer?</para>
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// 此VBO中的数据在内存中占用多少个字节？
        /// <para>How many bytes in this buffer?</para>
        /// </summary>
        public int ByteLength { get; private set; }

        /// <summary>
        /// Target that this buffer should bind to.
        /// </summary>
        public BufferTarget Target { get; protected set; }

        /// <summary>
        /// 位于服务器端（GPU内存）的定长数组。
        /// <para>An array at server side (GPU memory) with fixed length.</para>
        /// </summary>
        /// <param name="bufferId">用glGenBuffers()得到的VBO的Id。<para>Id got from glGenBuffers();</para></param>
        /// <param name="length">此VBO含有多少个元素？<para>How many elements?</para></param>
        /// <param name="byteLength">此VBO中的数据在内存中占用多少个字节？<para>How many bytes in this buffer?</para></param>
        protected TransformFeedback(uint bufferId, int length, int byteLength)
        {
            Debug.Assert(bufferId >= 0);
            Debug.Assert(length >= 0);
            Debug.Assert(byteLength >= 0);

            this.Id = bufferId;
            this.Length = length;
            this.ByteLength = byteLength;
        }


        /// <summary>
        ///Bind this buffer.
        /// </summary>
        public virtual void Bind()
        {
            glBindBuffer((uint)this.Target, this.Id);
        }

        /// <summary>
        /// Unind this buffer.
        /// </summary>
        public virtual void Unbind()
        {
            glBindBuffer((uint)this.Target, 0);
        }

    }
}