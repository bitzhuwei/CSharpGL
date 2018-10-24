using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    static class Utilities
    {
        public static T ReadStruct<T>(this System.IO.BinaryReader br) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] bytes = br.ReadBytes(size);
            T result;
            bytes.GetStruct(out result);
            return result;
        }

        public static void GetStruct<T>(this byte[] bytes, out T result) where T : struct
        {
            bytes.GetStruct(0, out result);
        }

        public static void GetStruct<T>(this byte[] bytes, int startIndex, out T result) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            IntPtr addr = Marshal.UnsafeAddrOfPinnedArrayElement(bytes, startIndex);
            result = (T)((object)Marshal.PtrToStructure(addr, typeof(T)));
            pinned.Free();
        }

    }
}
