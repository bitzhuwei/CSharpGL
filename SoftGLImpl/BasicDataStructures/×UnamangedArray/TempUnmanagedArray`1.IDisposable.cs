using System;
namespace SoftGLImpl {
    sealed unsafe partial class TempUnmanagedArray<T> {
        /// <summary>
        /// Dispose unmanaged resources
        /// </summary>
        protected override void DisposeUnmanagedResources() {
            this.Header = IntPtr.Zero;
            this.Length = 0;
        }
    }
}