using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ByteArrayHelper
    {
        /// <summary>
        /// 从给定的字节数组解析得到指定的struct对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetStruct<T>(this byte[] bytes, out T result) where T : struct
        {
            //GCHandle pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            //IntPtr addr = pinned.AddrOfPinnedObject();
            //result = (T)Marshal.PtrToStructure(addr, typeof(T));
            ////Marshal.PtrToStructure(pinned.AddrOfPinnedObject(), result);
            //pinned.Free();
            //another way to do this
            GetStruct<T>(bytes, 0, out result);
        }

        /// <summary>
        /// 从给定的字节数组解析得到指定的struct对象。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bytes"></param>
        /// <param name="startIndex"></param>
        /// <param name="result"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetStruct<T>(this byte[] bytes, int startIndex, out T result) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            IntPtr addr = Marshal.UnsafeAddrOfPinnedArrayElement(bytes, startIndex);
            result = (T)Marshal.PtrToStructure(addr, typeof(T));
            pinned.Free();
            ////another way to do this
            //var type = typeof(T);
            //int size = Marshal.SizeOf(type);
            //IntPtr buffer = Marshal.AllocHGlobal(size);
            //Marshal.Copy(bytes, startIndex, buffer, size);
            //result = (T)Marshal.PtrToStructure(buffer, type);
            //Marshal.FreeHGlobal(buffer);
        }
    }
}
