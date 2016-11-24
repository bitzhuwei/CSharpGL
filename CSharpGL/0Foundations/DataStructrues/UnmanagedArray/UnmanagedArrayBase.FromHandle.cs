using System;

namespace CSharpGL
{
    public abstract partial class UnmanagedArrayBase
    {
        /// <summary>
        /// Creats an unmanaged array instance whose content will be disposed by someone else.
        /// </summary>
        /// <param name="header"></param>
        /// <param name="elementCount"></param>
        /// <param name="elementSize"></param>
        internal UnmanagedArrayBase(IntPtr header, int elementCount, int elementSize)
        {
            this.Header = header;
            this.elementSize = elementSize;
            this.Length = elementCount;
            this.manualDispose = true;
        }
    }
}