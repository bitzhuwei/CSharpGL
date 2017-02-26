using System;
using System.Runtime.InteropServices;
namespace CSharpGL
{
    public sealed unsafe partial class UnmanagedArray<T>
    {
        /// <summary>
        /// How many <see cref="UnmanagedArray&lt;T&gt;"/> objects allocated?
        /// <para>Only used for debugging.</para>
        /// </summary>
        private static int thisTypeAllocatedCount = 0;

        /// <summary>
        /// How many <see cref="UnmanagedArray&lt;T&gt;"/> objects released?
        /// <para>Only used for debugging.</para>
        /// </summary>
        private static int thisTypeDisposedCount = 0;

        /// <summary>
        /// Dispose unmanaged resources
        /// </summary>
        protected override void DisposeUnmanagedResources()
        {
            IntPtr header = this.Header;
            if (header != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(header);
                this.Header = IntPtr.Zero;
            }

            this.Length = 0;

            UnmanagedArray<T>.thisTypeDisposedCount++;
        }
    }
}