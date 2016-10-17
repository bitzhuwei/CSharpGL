using System;

namespace CSharpGL
{
    /// <summary>
    /// Vertex Buffer Object.
    /// </summary>
    public abstract partial class Buffer : IDisposable
    {
        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glGenBuffers glGenBuffers;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glBindBuffer glBindBuffer;

        /// <summary>
        ///
        /// </summary>
        internal static OpenGL.glBufferData glBufferData;

        /// <summary>
        ///
        /// </summary>
        protected UnmanagedArrayBase array = null;

        /// <summary>
        /// 此VBO中的数据在内存中的起始地址
        /// <para>Start position of this buffer; first element's position of this buffer.</para>
        /// <para>Similar to <code>array</code> in <code>int array[Length];</code></para>
        /// </summary>
        public IntPtr Header
        {
            get
            {
                UnmanagedArrayBase array = this.array;
                return (array == null) ? IntPtr.Zero : array.Header;
            }
        }

        /// <summary>
        /// 此VBO中的数据在内存中占用多少个字节？（元素的总数 * 单个元素的字节数）
        /// <para>How many bytes in this buffer?</para>
        /// <para>Length * elementSize</para>
        /// </summary>
        public int ByteLength
        {
            get
            {
                UnmanagedArrayBase array = this.array;
                return (array == null) ? 0 : array.ByteLength;
            }
        }

        /// <summary>
        /// 此VBO含有多个个元素？
        /// <para>How many elements?</para>
        /// <para>Similar to <code>Length</code> in <code>int array[Length];</code></para>
        /// </summary>
        public int Length
        {
            get
            {
                UnmanagedArrayBase array = this.array;
                return (array == null) ? 0 : array.Length;
            }
        }

        /// <summary>
        /// usage in glBufferData(uint target, int size, IntPtr data, uint usage);
        /// </summary>
        public BufferUsage Usage { get; private set; }

        /// <summary>
        /// Vertex Buffer Object.
        /// </summary>
        /// <param name="usage"></param>
        public Buffer(BufferUsage usage)
        {
            this.Usage = usage;
        }

        /// <summary>
        /// 申请指定元素数目的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        /// <returns></returns>
        protected abstract UnmanagedArrayBase DoAlloc(int elementCount);

        /// <summary>
        /// 申请指定元素数目的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public void Alloc(int elementCount)
        {
            this.array = DoAlloc(elementCount);
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("VBO: {0}, usage: {1}", this.array, Usage);
        }
    }
}