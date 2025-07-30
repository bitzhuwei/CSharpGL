using System.Runtime.InteropServices;

namespace CSharpGL {
    class Managed2Buffer<T> : IDisposable where T : struct {
        public readonly T[] data;
        private readonly GCHandle pin;
        private readonly nint addr;
        private readonly int byteLength;
        private readonly ShaderStorageBuffer buffer;

        public Managed2Buffer(T[] data) {
            this.data = data;
            this.pin = GCHandle.Alloc(data, GCHandleType.Pinned);
            this.addr = this.pin.AddrOfPinnedObject();
            this.byteLength = data.Length * Marshal.SizeOf(typeof(T));
            this.buffer = data.GenShaderStorageBuffer(GLBuffer.Usage.DynamicRead);
        }

        /// <summary>
        /// modify data in <see cref="data"/> and call <see cref="Upload"/> to upload data to GPU memory.
        /// </summary>
        public bool Upload() {
            return this.buffer.UpdateData(this.addr, this.byteLength);
        }

        private bool disposedValue;
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                this.pin.Free();
                this.buffer.Dispose();
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        ~Managed2Buffer() {
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