using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 在非托管内存之间复制信息的辅助类。
    /// </summary>
    public static class UnmanagedArrayHelper
    {

        /// <summary>
        /// 把此非托管数组复制到目标内存地址上。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination">例如用glMapBuffer()得到的地址。</param>
        public static void CopyTo(this UnmanagedArrayBase source, IntPtr destination)
        {
            CopyMemory(destination, source.Header, (uint)source.ByteLength);
        }

        /// <summary>
        /// Copies a block of memory from one location to another.
        /// </summary>
        /// <param name="Destination">A pointer to the starting address of the copied block's destination.</param>
        /// <param name="Source">A pointer to the starting address of the block of memory to copy.</param>
        /// <param name="Length">The size of the block of memory to copy, in bytes.</param>
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr Destination, IntPtr Source, uint Length);
    }
}
