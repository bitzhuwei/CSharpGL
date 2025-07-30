using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SoftGLImpl {
    partial class GLRenderbuffer : IGLAttachable, IDisposable {
        internal readonly GLuint Id;
        internal readonly GLuint Target;

        /// <summary>
        /// glDeleteBuffer
        /// </summary>
        internal bool deleteFlag = false;

        public GLRenderbuffer(GLenum/*BindBufferTarget*/ target, uint id) {
            this.Target = target;
            this.Id = id;
        }

        /// <summary>
        /// RenderbufferStorage(..).
        /// </summary>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="dataStore">unmanaged byte*</param>
        public void Storage(uint internalformat, int width, int height, IntPtr dataStore, int size) {
            var data = this.DataStore;
            if (data != IntPtr.Zero && data != dataStore) {
                this.DataStore = IntPtr.Zero;
                Marshal.FreeHGlobal(data);
            }
            this.Format = internalformat;
            this.Width = width;
            this.Height = height;
            this.DataStore = dataStore;
            this.Size = size;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Renderbuffer:internalFormat:{0}, w:{1}, h:{2}", (RenderbufferStorageInternalformat)this.Format, this.Width, this.Height);
        }

        private bool disposedValue;
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                var data = this.DataStore;
                if (data != IntPtr.Zero) {
                    Marshal.FreeHGlobal(data);
                    this.DataStore = IntPtr.Zero;
                }
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~GLRenderbuffer()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose() {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
