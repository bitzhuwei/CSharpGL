using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ByteArrayHelper
    {
        public static void GetStruct<T>(this byte[] bytes, out T result) where T : struct
        {
            GCHandle pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            result = (T)Marshal.PtrToStructure(pinned.AddrOfPinnedObject(), typeof(T));
            //Marshal.PtrToStructure(pinned.AddrOfPinnedObject(), result);
            pinned.Free();
        }
    }
}
