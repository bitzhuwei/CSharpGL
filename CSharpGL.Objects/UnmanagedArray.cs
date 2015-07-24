using CSharpGL.Maths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects
{

    /// <summary>
    /// 元素类型为sbyte, byte, char, short, ushort, int, uint, long, ulong, float, double, decimal, bool或其它struct的非托管数组。
    /// <para>不能使用enum类型作为T。</para>
    /// </summary>
    /// <typeparam name="T">sbyte, byte, char, short, ushort, int, uint, long, ulong, float, double, decimal, bool或其它struct, 不能使用enum类型作为T。</typeparam>
    public class UnmanagedArray<T> : UnmanagedArrayBase where T : struct
    {

        /// <summary>
        ///元素类型为sbyte, byte, char, short, ushort, int, uint, long, ulong, float, double, decimal, bool或其它struct的非托管数组。 
        /// </summary>
        /// <param name="count"></param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public UnmanagedArray(int count)
            : base(count, Marshal.SizeOf(typeof(T)))
        {
        }
     
        /// <summary>
        /// 获取或设置索引为<paramref name="index"/>的元素。
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                    throw new IndexOutOfRangeException("index of UnmanagedArray is out of range");

                var pItem = this.Header + (index * elementSize);
                //var obj = Marshal.PtrToStructure(pItem, typeof(T));
                //T result = (T)obj;
                T result = Marshal.PtrToStructure<T>(pItem);// works in .net 4.5.1
                return result;
            }
            set
            {
                if (index < 0 || index >= this.Count)
                    throw new IndexOutOfRangeException("index of UnmanagedArray is out of range");
                
                var pItem = this.Header + (index * elementSize);
                //Marshal.StructureToPtr(value, pItem, true);
                Marshal.StructureToPtr<T>(value, pItem, true);// works in .net 4.5.1
            }
        }

        /// <summary>
        /// 按索引顺序依次获取各个元素。
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetElements()
        {
            if (!this.disposed)
            {
                for (int i = 0; i < this.Count; i++)
                {
                    yield return this[i];
                }
            }
        }
    }

    /// <summary>
    /// 非托管数组的基类。
    /// </summary>
    public abstract class UnmanagedArrayBase : IDisposable
    {

        /// <summary>
        /// 数组指针。
        /// </summary>
        public IntPtr Header { get; private set; }

        /// <summary>
        /// 元素数目。
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 单个元素的字节数。
        /// </summary>
        protected int elementSize;

        /// <summary>
        /// 申请到的字节数。（元素数目 * 单个元素的字节数）。
        /// </summary>
        public int ByteLength
        {
            get { return this.Count * this.elementSize; }
        }

           
        /// <summary>
        /// 非托管数组。
        /// </summary>
        /// <param name="elementCount">元素数目。</param>
        /// <param name="elementSize">单个元素的字节数。</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        protected UnmanagedArrayBase(int elementCount, int elementSize)
        {
            this.Count = elementCount;
            this.elementSize = elementSize;

            int memSize = elementCount * elementSize;
            this.Header = Marshal.AllocHGlobal(memSize);

            allocatedArrays.Add(this);
        }

        private static readonly List<IDisposable> allocatedArrays = new List<IDisposable>();

        /// <summary>
        /// 立即释放所有<see cref="UnmanagedArray"/>。
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void FreeAll()
        {
            foreach (var item in allocatedArrays)
            {
                item.Dispose();
            }
            allocatedArrays.Clear();
        }

        ~UnmanagedArrayBase()
        {
            Dispose();
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        protected Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //Managed cleanup code here, while managed refs still valid
            }
            //Unmanaged cleanup code here
            IntPtr ptr = this.Header;

            if (ptr != IntPtr.Zero)
            {
                this.Count = 0;
                this.Header = IntPtr.Zero;
                Marshal.FreeHGlobal(ptr);
            }

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate 
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        #endregion
				
    }
}
