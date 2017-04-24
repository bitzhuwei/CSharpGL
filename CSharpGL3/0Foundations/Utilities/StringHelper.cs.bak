using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringHelper
    {

        public static IntPtr StringToPtrAnsi(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return IntPtr.Zero;

            byte[] bytes = Encoding.ASCII.GetBytes(str + '\0');
            IntPtr strPtr = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, strPtr, bytes.Length);

            return strPtr;
        }
    }
}
