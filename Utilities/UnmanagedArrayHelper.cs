using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace System
{
    /// <summary>
    /// 获取<see cref="UnmanagedArray"/>的指针，进行快速读写。
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
            void* header = array.Header.ToPointer();

            return header;
        }

        /// <summary>
        /// 获取非托管数组的最后一个元素的地址。
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static unsafe void* LastElement(this UnmanagedArrayBase array)
        {
            var last = (array.Header + (array.ByteLength - array.ByteLength / array.Length)).ToPointer();

            return last;
        }

        /// <summary>
        /// 获取非托管数组的最后一个元素的地址再向后一个单位的地址。
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static unsafe void* TailAddress(this UnmanagedArrayBase array)
        {
            void* tail = (array.Header + array.ByteLength).ToPointer();

            return tail;
        }

    }
}