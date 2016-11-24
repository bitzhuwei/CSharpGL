using System;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public sealed unsafe partial class UnmanagedArray<T>
    {
        /// <summary>
        /// Creats an unmanaged array instance whose content will be disposed by someone else.
        /// </summary>
        /// <param name="header"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static UnmanagedArray<T> FromHandle(IntPtr header, int count)
        {
            return new UnmanagedArray<T>(header, count);
        }

        private UnmanagedArray(IntPtr header, int count)
            : base(header, count, Marshal.SizeOf(typeof(T)))
        { }
    }
}