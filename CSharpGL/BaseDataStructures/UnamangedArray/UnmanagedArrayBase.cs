using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Base type of unmanaged array.
    /// <para>Similar to array in <code>int array[Length];</code></para>
    /// </summary>
    public abstract partial class UnmanagedArrayBase : IDisposable
    {
        /// <summary>
        /// 此非托管数组中的数据在内存中的起始地址
        /// Start position of array; Head of array; first element's position of array.
        /// <para>Similar to <code>array</code> in <code>int array[Length];</code></para>
        /// </summary>
        public IntPtr Header { get; protected set; }

        /// <summary>
        /// How many elements?
        /// <para>Similar to <code>Length</code> in <code>int array[Length];</code></para>
        /// </summary>
        public int Length { get; protected set; }

        /// <summary>
        /// 单个元素的字节数。
        /// <para>How manay bytes for one element of array?</para>
        /// </summary>
        protected int elementSize;

        /// <summary>
        /// 申请到的字节数。（元素的总数 * 单个元素的字节数）。
        /// <para>How many bytes for total array?</para>
        /// <para>Length * elementSize</para>
        /// </summary>
        public int ByteLength
        {
            get { return (this.Length * this.elementSize); }
        }

        /// <summary>
        /// Base type of unmanaged array.
        /// <para>Similar to array in <code>int array[Length];</code></para>
        /// </summary>
        /// <param name="elementCount">How many elements?</param>
        /// <param name="elementSize">How manay bytes for one element of array?</param>
        //[MethodImpl(MethodImplOptions.Synchronized)]//这造成死锁，不知道是为什么 Dead lock, Why?
        protected UnmanagedArrayBase(int elementCount, int elementSize)
        {
            Debug.Assert(elementCount >= 0);
            Debug.Assert(elementSize >= 0);

            this.Length = elementCount;
            this.elementSize = elementSize;

            UnmanagedArrayBase.allocatedCount++;
        }

        /// <summary>
        /// return string.Format("head: {0}, element count: {1}, byte length: {2}",
        ///     this.Header, this.Length, this.ByteLength);
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("head: {0}, element count: {1}, byte length: {2}",
                this.Header, this.Length, this.ByteLength);
        }
    }
}