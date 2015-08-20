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
    /// 
    /// </summary>
    public static class UnmanagedArrayHelper
    {
        ///// <summary>
        ///// 错误	1	无法获取托管类型(“T”)的地址和大小，或无法声明指向它的指针	C:\Users\威\Documents\GitHub\CSharpGL\Utilities\UnmanagedArrayHelper.cs	16	33	Utilities
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="array"></param>
        ///// <returns></returns>
        //public static unsafe T* FirstElement<T>(this UnmanagedArray<T> array) where T : struct
        //{
        //    var header = (void*)array.Header;
        //    return (T*)header;
        //}

        /// <summary>
        /// 获取非托管数组的第一个元素的地址。
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static unsafe void* FirstElement(this UnmanagedArrayBase array)
        {
            var header = (void*)array.Header;

            return header;
        }

        /// <summary>
        /// 获取非托管数组的最后一个元素的地址。
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static unsafe void* LastElement(this UnmanagedArrayBase array)
        {
            var last = (void*)(array.Header + (array.ByteLength - array.ByteLength / array.Length));

            return last;
        }

        /// <summary>
        /// 获取非托管数组的最后一个元素的地址再向后一个单位的地址。
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static unsafe void* TailAddress(this UnmanagedArrayBase array)
        {
            var tail = (void*)(array.Header + array.ByteLength);

            return tail;
        }

        public static void TypicalScene()
        {
            int length = 1000000;
            UnmanagedArray<int> array = new UnmanagedArray<int>(length);
            UnmanagedArray<int> array2 = new UnmanagedArray<int>(length);

            long tick = DateTime.Now.Ticks;
            for (int i = 0; i < length; i++)
            {
                array[i] = i;
            }
            long totalTicks = DateTime.Now.Ticks - tick;

            tick = DateTime.Now.Ticks;
            unsafe
            {
                int* header = (int*)array2.FirstElement();
                int* last = (int*)array2.LastElement();
                int* tailAddress = (int*)array2.TailAddress();
                int value = 0;
                for (int* ptr = header; ptr <= last/*or: ptr < tailAddress*/; ptr++)
                {
                    *ptr = value++;
                }
            }
            long totalTicks2 = DateTime.Now.Ticks - tick;
            Console.WriteLine("ticks: {0}, {1}", totalTicks, totalTicks2);// unsafe method works faster.

            for (int i = 0; i < length; i++)
            {
                if (array[i] != i)
                {
                    Console.WriteLine("something wrong here");
                }
                if (array2[i] != i)
                {
                    Console.WriteLine("something wrong here");
                }
            }

            array.Dispose();
            array2.Dispose();
        }
    }
}