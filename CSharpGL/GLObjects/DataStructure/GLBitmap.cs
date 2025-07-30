using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.InteropServices;

namespace CSharpGL {
    /*
    var bitmap = new Bitmap("hello.png");
    var pixels = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
    var bitmap2 = new Bitmap(bitmap.Width, bitmap.Height, pixels.Stride, bitmap.PixelFormat, pixels.Scan0);
    bitmap.UnlockBits(pixels);
    bitmap2.Save("hello2.png");
     */
    public unsafe partial class GLBitmap : IGLBitmap, IDisposable {
        public readonly int pixelBytes;
        public readonly IntPtr scan0;
        public readonly int width;
        public readonly int height;

        public int PixelBytes => pixelBytes;

        public nint Scan0 => scan0;

        public int Width => width;

        public int Height => height;

        public GCHandle? pin = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="pixelBytes">how many bytes per pixel?</param>
        public GLBitmap(int width, int height, int pixelBytes) {
            this.width = width;
            this.height = height;
            this.pixelBytes = pixelBytes;
            var data = new byte[width * height * pixelBytes];
            var pin = GCHandle.Alloc(data, GCHandleType.Pinned);
            this.scan0 = pin.AddrOfPinnedObject();
            this.pin = pin;
        }

        public GLBitmap(int width, int height, int pixelBytes, IntPtr scan0) {
            this.width = width;
            this.height = height;
            this.pixelBytes = pixelBytes;
            this.scan0 = scan0;
        }



        //public IntPtr Lock() {
        //    var pin = GCHandle.Alloc(data, GCHandleType.Pinned);
        //    var address = pin.AddrOfPinnedObject();
        //    this.pin = pin;
        //    return address;
        //}

        //public void Unlock() {
        //    if (this.pin != null) {
        //        this.pin.Value.Free();
        //        this.pin = null;
        //    }
        //}

        private bool disposedValue;


        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                if (this.pin != null) {
                    this.pin.Value.Free();
                    this.pin = null;
                }
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~GLBitmap()
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