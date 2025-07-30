using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SoftGLImpl {
    internal unsafe class GLBuffer : IDisposable {
        internal readonly GLuint id;
        internal readonly GLuint target;

        /// <summary>
        /// Data.Length in bytes
        /// </summary>
        internal int Size;

        /// <summary>
        /// byte*
        /// </summary>
        internal IntPtr Data = IntPtr.Zero;

        internal GLenum Usage;

        /// <summary>
        /// glDeleteBuffer
        /// </summary>
        internal bool deleteFlag = false;

        public GLBuffer(GLenum/*BindBufferTarget*/ target, uint id) {
            this.target = target;
            this.id = id;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("GLBuffer: Id:{0}, T:{1}", this.id, this.target);
        }

        public unsafe void SetData(int size, IntPtr data, GLenum usage) {
            Debug.Assert(size >= 0);
            if (size != this.Size) {
                var old = this.Data;
                if (old != IntPtr.Zero) {
                    this.Data = IntPtr.Zero;
                    Marshal.FreeHGlobal(old);
                }
                this.Data = Marshal.AllocHGlobal(size);
            }

            if (data != IntPtr.Zero) {
                var dest = (byte*)this.Data; var source = (byte*)data;
                for (int i = 0; i < size; i++) {
                    dest[i] = source[i];
                }
            }

            this.Size = size;
            this.Usage = usage;
        }

        private bool disposedValue;
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                var data = this.Data;
                if (data != IntPtr.Zero) {
                    this.Data = IntPtr.Zero;
                    Marshal.FreeHGlobal(data);
                }
                // TODO: 将大型字段设置为 null

                disposedValue = true;
            }
        }

        // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        ~GLBuffer() {
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