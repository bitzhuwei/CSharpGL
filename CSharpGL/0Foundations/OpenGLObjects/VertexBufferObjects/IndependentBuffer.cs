using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// Buffer object that not work as input variable in shader.
    /// </summary>
    /// <typeparam name="T">此buffer存储的是哪种struct的数据？<para>type of index value.</para></typeparam>
    public class IndependentBuffer<T> : Buffer where T : struct
    {
        private int length;

        /// <summary>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="usage"></param>
        /// <param name="noDataCopyed"></param>
        public IndependentBuffer(BufferTarget target, BufferUsage usage, bool noDataCopyed)
            : base(usage)
        {
            this.Target = target;
            this.NoDataCopyed = noDataCopyed;
        }

        /// <summary>
        ///
        /// </summary>
        public override int ByteLength
        {
            get
            {
                if (this.NoDataCopyed)
                {
                    return this.length * Marshal.SizeOf(typeof(T));
                }
                else
                {
                    return base.ByteLength;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override IntPtr Header
        {
            get
            {
                if (this.NoDataCopyed)
                {
                    return IntPtr.Zero;
                }
                else
                {
                    return base.Header;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public override int Length
        {
            get
            {
                if (this.NoDataCopyed)
                {
                    return this.length;
                }
                else
                {
                    return base.Length;
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public bool NoDataCopyed { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public BufferTarget Target { get; private set; }

        /// <summary>
        /// 申请指定长度的非托管数组。
        /// <para>create an unmanaged array to store data for this buffer.</para>
        /// </summary>
        /// <param name="elementCount">数组元素的数目。<para>How many elements?</para></param>
        public override void Create(int elementCount)
        {
            if (this.NoDataCopyed)
            {
                this.length = elementCount;
            }
            else
            {
                this.array = new UnmanagedArray<T>(elementCount);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, ByteLength: {1}, Header: {2}", this.Target, this.ByteLength, this.Header);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        protected override BufferPtr Upload2GPU()
        {
            uint[] buffers = new uint[1];
            glGenBuffers(1, buffers);
            var target = (uint)this.Target;
            glBindBuffer(target, buffers[0]);
            glBufferData(target, this.ByteLength, this.Header, (uint)this.Usage);
            glBindBuffer(target, 0);

            var bufferPtr = new IndependentBufferPtr(this.Target,
                buffers[0], this.Length, this.ByteLength);

            return bufferPtr;
        }
    }
}