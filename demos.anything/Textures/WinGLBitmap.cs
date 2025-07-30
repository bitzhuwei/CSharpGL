using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demos.anything {
    public class WinGLBitmap : IGLBitmap {
        private readonly Bitmap bitmap;
        private readonly BitmapData bmpData;
        private readonly PixelFormat pixelFormat;

        public WinGLBitmap(System.Drawing.Bitmap bitmap) {
            this.bitmap = bitmap;
            this.bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, bitmap.PixelFormat);
            this.pixelFormat = bitmap.PixelFormat;
        }
        public WinGLBitmap(System.Drawing.Bitmap bitmap, PixelFormat pixelFormat) {
            this.bitmap = bitmap;
            this.bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, pixelFormat);
            this.pixelFormat = pixelFormat;
        }

        public int PixelBytes {
            get {
                if (!format2Bytes.TryGetValue(this.pixelFormat, out var bytes)) {
                    throw new NotSupportedException($"not support {this.bitmap.PixelFormat} as texture data");
                }
                return bytes;
            }
        }

        public nint Scan0 => this.bmpData.Scan0;

        public int Width => this.bitmap.Width;

        public int Height => this.bitmap.Height;

        public void Dispose() {
            this.bitmap.UnlockBits(this.bmpData);
            this.bitmap.Dispose();
        }

        private static readonly Dictionary<PixelFormat, int> format2Bytes = new() {
            //{ PixelFormat.Indexed, 0 },
            //{ PixelFormat.Gdi, 0 },
            //{ PixelFormat.Alpha, 0 },
            //{ PixelFormat.PAlpha, 0 },
            //{ PixelFormat.Extended, 0 },
            //{ PixelFormat.Canonical, 0 },
            //{ PixelFormat.Undefined, 0 },
            //{ PixelFormat.DontCare, 0 },
            //{ PixelFormat.Format1bppIndexed, 0 },
            //{ PixelFormat.Format4bppIndexed, 0 },
            { PixelFormat.Format8bppIndexed, 1 },
            { PixelFormat.Format16bppGrayScale, 2 },
            { PixelFormat.Format16bppRgb555, 2 },
            { PixelFormat.Format16bppRgb565, 2 },
            { PixelFormat.Format16bppArgb1555, 2 },
            { PixelFormat.Format24bppRgb, 3 },
            { PixelFormat.Format32bppRgb, 4 },
            { PixelFormat.Format32bppArgb, 4 },
            { PixelFormat.Format32bppPArgb, 4 },
            { PixelFormat.Format48bppRgb, 6 },
            { PixelFormat.Format64bppArgb, 8 },
            { PixelFormat.Format64bppPArgb, 8 },
            //{ PixelFormat.Max, 0 },
        };


        public static readonly Dictionary<int, PixelFormat> bytes2Format = new() {
            { 1, PixelFormat.Format8bppIndexed },
            { 2, PixelFormat.Format16bppArgb1555 },
            { 3, PixelFormat.Format24bppRgb },
            { 4, PixelFormat.Format32bppArgb },
            { 6, PixelFormat.Format48bppRgb },
            { 8, PixelFormat.Format64bppArgb },
        };
    }
}
