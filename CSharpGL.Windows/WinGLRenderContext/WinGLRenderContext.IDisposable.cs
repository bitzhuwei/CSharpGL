using CSharpGL.Windows;
using System;
using System.Diagnostics;
using System.Drawing;

namespace CSharpGL.Windows {
    /// <summary>
    /// openGL implementation on Windows Operation System.
    /// </summary>
    public unsafe partial class WinGLRenderContext {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                //  Destroy the internal dc.
                this.dibSection.Dispose();
                //	Release the device context.
                Win32.ReleaseDC(this.handle, this.hDC);
                ////	Destroy the window.
                //Win32.DestroyWindow(windowHandle);
                Win32.wglMakeCurrent(IntPtr.Zero, IntPtr.Zero);
                // If we have a render context, destroy it.
                if (this.hRC != IntPtr.Zero) {
                    Win32.wglDeleteContext(this.hRC);
                    //this.renderContextHandle = IntPtr.Zero;
                }
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        ~WinGLRenderContext() {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: false);
        }

        public void Dispose() {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
