using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    /// <summary>
    /// unmanaged huge array.
    /// <para>Check http://www.cnblogs.com/bitzhuwei/p/huge-unmanged-array-in-csharp.html </para>
    /// </summary>
    /// <typeparam name="T">sbyte, byte, char, short, ushort, int, uint, long, ulong, float, double, decimal, bool or other struct types. enum not supported.</typeparam>
    public sealed unsafe class UnmanagedArray<T> : UnmanagedArrayBase where T : struct
    {
        /// <summary>
        /// How many <see cref="UnmanagedArray&lt;T&gt;"/> objects allocated?
        /// <para>Only used for debugging.</para>
        /// </summary>
        private static int thisTypeAllocatedCount = 0;

        /// <summary>
        /// How many <see cref="UnmanagedArray&lt;T&gt;"/> objects released?
        /// <para>Only used for debugging.</para>
        /// </summary>
        private static int thisTypeDisposedCount = 0;

        /// <summary>
        /// unmanaged array.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="autoAlloc"></param>
        public UnmanagedArray(int count, bool autoAlloc = true)
            : base(count, Marshal.SizeOf(typeof(T)), autoAlloc)
        {
            UnmanagedArray<T>.thisTypeAllocatedCount++;
        }

        /// <summary>
        /// Dispose unmanaged resources
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            base.DisposeUnmanagedResources();

            UnmanagedArray<T>.thisTypeDisposedCount++;
        }
    }

    /// <summary>
    /// Base type of unmanaged array.
    /// <para>Similar to array in <code>int array[Length];</code></para>
    /// </summary>
    public abstract class UnmanagedArrayBase : IDisposable
    {
        /// <summary>
        /// How many <see cref="UnmanagedArrayBase"/> allocated?
        /// <para>Only used for debugging.</para>
        /// </summary>
        public static int allocatedCount = 0;

        /// <summary>
        /// How many <see cref="UnmanagedArrayBase"/> released?
        /// <para>Only used for debugging.</para>
        /// </summary>
        public static int disposedCount = 0;

        /// <summary>
        /// 此非托管数组中的数据在内存中的起始地址
        /// Start position of array; Head of array; first element's position of array.
        /// <para>Similar to <code>array</code> in <code>int array[Length];</code></para>
        /// </summary>
        public IntPtr Header { get; private set; }

        /// <summary>
        /// How many elements?
        /// <para>Similar to <code>Length</code> in <code>int array[Length];</code></para>
        /// </summary>
        public int Length { get; private set; }

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
        /// <param name="autoAlloc"></param>
        //[MethodImpl(MethodImplOptions.Synchronized)]//这造成死锁，不知道是为什么 Dead lock, Why?
        protected UnmanagedArrayBase(int elementCount, int elementSize, bool autoAlloc)
        {
            this.Length = elementCount;
            this.elementSize = elementSize;
            if (autoAlloc)
            {
                this.Alloc();
            }

            UnmanagedArrayBase.allocatedCount++;
        }

        private bool initialized = false;

        /// <summary>
        /// Alloate memory for this array.
        /// </summary>
        public void Alloc()
        {
            if (!this.initialized)
            {
                int memSize = this.Length * this.elementSize;
                this.Header = Marshal.AllocHGlobal(memSize);

                this.initialized = true;
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        } // end sub

        /// <summary>
        /// Destruct instance of the class.
        /// </summary>
        ~UnmanagedArrayBase()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Backing field to track whether Dispose has been called.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// Dispose managed and unmanaged resources of this instance.
        /// </summary>
        /// <param name="disposing">If disposing equals true, managed and unmanaged resources can be disposed. If disposing equals false, only unmanaged resources can be disposed. </param>
        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    //DisposeManagedResources();
                } // end if

                // Dispose unmanaged resources.
                DisposeUnmanagedResources();

                UnmanagedArrayBase.disposedCount++;
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion IDisposable Members

        /// <summary>
        /// Dispose unmanaged resources
        /// </summary>
        protected virtual void DisposeUnmanagedResources()
        {
            IntPtr header = this.Header;
            if (header != IntPtr.Zero)
            {
                this.Header = IntPtr.Zero;
                Marshal.FreeHGlobal(header);
            }
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