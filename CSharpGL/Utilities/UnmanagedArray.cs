using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{

    /// <summary>
    /// 元素类型为sbyte, byte, char, short, ushort, int, uint, long, ulong, float, double, decimal, bool或其它struct的非托管数组。
    /// <para>不能使用enum类型作为T。</para>
    /// <para>Check http://www.cnblogs.com/bitzhuwei/p/huge-unmanged-array-in-csharp.html </para>
    /// </summary>
    /// <typeparam name="T">sbyte, byte, char, short, ushort, int, uint, long, ulong, float, double, decimal, bool或其它struct, 不能使用enum类型作为T。</typeparam>
    public sealed unsafe class UnmanagedArray<T> : UnmanagedArrayBase where T : struct
    {
        /// <summary>
        /// 此类型（即参数为T）一共申请了多少个对象？
        /// <para>仅为调试之用，无应用意义。</para>
        /// </summary>
        private static int thisTypeAllocatedCount = 0;
        /// <summary>
        /// 此类型（即参数为T）一共释放了多少个对象？
        /// <para>仅为调试之用，无应用意义。</para>
        /// </summary>
        private static int thisTypeDisposedCount = 0;

        /// <summary>
        ///元素类型为sbyte, byte, char, short, ushort, int, uint, long, ulong, float, double, decimal, bool或其它struct的非托管数组。
        /// </summary>
        /// <param name="count"></param>
        public UnmanagedArray(int count)
            : base(count, Marshal.SizeOf(typeof(T)))
        {
            UnmanagedArray<T>.thisTypeAllocatedCount++;
        }

        /// <summary>
        /// 获取或设置索引为<paramref name="index"/>的元素。
        /// <para>如果要处理的元素数目较大，请使用unsafe方式(<see cref="UnmanagedArrayFastAccessHelper"/>)。</para>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public unsafe T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Length)
                    throw new IndexOutOfRangeException("index of UnmanagedArray is out of range");

                var pItem = this.Header + (index * elementSize);
                var obj = Marshal.PtrToStructure(pItem, typeof(T));
                T result = (T)obj;
                //T result = Marshal.PtrToStructure<T>(pItem);// works in .net 4.5.1
                return result;
            }
            set
            {
                if (index < 0 || index >= this.Length)
                    throw new IndexOutOfRangeException("index of UnmanagedArray is out of range");

                var pItem = this.Header + (index * elementSize);
                Marshal.StructureToPtr(value, pItem, true);
                //Marshal.StructureToPtr<T>(value, pItem, true);// works in .net 4.5.1
            }
        }

        protected override void CleanUnmanagedRes()
        {
            UnmanagedArray<T>.thisTypeDisposedCount++;

            base.CleanUnmanagedRes();
        }
        ///// <summary>
        ///// 按索引顺序依次获取各个元素。
        ///// </summary>
        ///// <returns></returns>
        //public IEnumerable<T> Elements()
        //{
        //    for (int i = 0; i < this.Length; i++)
        //    {
        //        yield return this[i];
        //    }
        //}
    }

    /// <summary>
    /// 非托管数组的基类。
    /// </summary>
    public abstract class UnmanagedArrayBase : IDisposable
    {
        /// <summary>
        /// 一共申请了多少个<see cref="UnmanagedArrayBase"/>对象？
        /// <para>仅为调试之用，无应用意义。</para>
        /// </summary>
        public static int allocatedCount = 0;

        /// <summary>
        /// 一共释放了多少个<see cref="UnmanagedArrayBase"/>对象？
        /// <para>仅为调试之用，无应用意义。</para>
        /// </summary>
        public static int disposedCount = 0;

        /// <summary>
        /// 此数组的起始位置。
        /// </summary>
        public IntPtr Header { get; private set; }

        /// <summary>
        /// 元素的总数。
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// 单个元素的字节数。
        /// </summary>
        protected int elementSize;

        /// <summary>
        /// 申请到的字节数。（元素的总数 * 单个元素的字节数）。
        /// </summary>
        public int ByteLength
        {
            get { return (this.Length * this.elementSize); }
        }

        /// <summary>
        /// 非托管数组。
        /// </summary>
        /// <param name="elementCount">元素的总数。</param>
        /// <param name="elementSize">单个元素的字节数。</param>
        //[MethodImpl(MethodImplOptions.Synchronized)]//这造成死锁，不知道是为什么
        protected UnmanagedArrayBase(int elementCount, int elementSize)
        {
            this.Length = elementCount;
            this.elementSize = elementSize;

            int memSize = elementCount * elementSize;
            this.Header = Marshal.AllocHGlobal(memSize);

            UnmanagedArrayBase.allocatedCount++;
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
                    CleanManagedRes();
                } // end if

                // Dispose unmanaged resources.
                CleanUnmanagedRes();

                UnmanagedArrayBase.disposedCount++;
            } // end if

            this.disposedValue = true;
        } // end sub

        #endregion

        protected virtual void CleanUnmanagedRes()
        {
        }

        protected virtual void CleanManagedRes()
        {
        }

        public override string ToString()
        {
            return string.Format("head: {0}, element count: {1}, byte length: {2}",
                this.Header, this.Length, this.ByteLength);
        }
    }
}
