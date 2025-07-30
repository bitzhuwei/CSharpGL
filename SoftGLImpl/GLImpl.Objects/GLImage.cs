using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SoftGLImpl {
    class GLImage : IGLAttachable, IDisposable {
        #region IAttachable

        /// <summary>
        /// 
        /// </summary>
        public uint Format { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// byte*
        /// </summary>
        public IntPtr DataStore { get; private set; }

        /// <summary>
        /// how many bytes in <see cref="DataStore"/>
        /// </summary>
        public int Size { get; private set; }

        #endregion IAttachable

        public GLImage(uint format, int width, int height, int elementByteLength) {
            this.Format = format;
            this.Width = width; this.Height = height;
            var size = elementByteLength * width * height;
            this.DataStore = Marshal.AllocHGlobal(size);
            this.Size = size;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("Image, w:{0}, h:{1}", this.Width, this.Height);
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
        // ~GLImage()
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
