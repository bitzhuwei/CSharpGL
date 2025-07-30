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
    public unsafe interface IGLBitmap : IDisposable {
        public int PixelBytes { get; }
        public IntPtr Scan0 { get; }
        public int Width { get; }
        public int Height { get; }

        /*
          var bitmap = new Bitmap("hello.png");
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
            var glBitmap = new GLBitmap(bitmap.Width, bitmap.Height, 4, data.Scan0);
            var bmp2 = glBitmap.ZoomOut(0.5f, 0.5f);
            var bmp3 = new Bitmap(bmp2.width, bmp2.height, bmp2.width * 4, bitmap.PixelFormat, bmp2.scan0);
            bmp3.Save("hello3.png");
         */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="scaleWidth">0.5 means scale to half with and half height</param>
        /// <param name="scaleHeight">0.5 means scale to half with and half height</param>
        /// <returns></returns>
        public IGLBitmap ZoomOut(float scaleWidth, float scaleHeight) {
            if (scaleWidth >= 1 || scaleHeight >= 1) { throw new ArgumentException("params should be less than 1."); }

            var width = this.Width; var height = this.Height;
            var newWidth = (int)(width * scaleWidth);
            if (newWidth < 1) { newWidth = 1; }
            var newHeight = (int)(height * scaleHeight);
            if (newHeight < 1) { newHeight = 1; }
            var pixelBytes = this.PixelBytes;
            var result = new GLBitmap(newWidth, newHeight, pixelBytes);
            var newData = (byte*)result.scan0;

            var original = (byte*)this.Scan0;
            for (int y = 0; y < newHeight; y++) {
                for (int x = 0; x < newWidth; x++) {
                    // 计算原始图像中的对应位置（浮点坐标）
                    float srcX = x / scaleWidth;
                    float srcY = y / scaleHeight;

                    // 获取四个最近的像素坐标
                    int x1 = (int)Math.Floor(srcX);
                    int y1 = (int)Math.Floor(srcY);
                    int x2 = Math.Min(x1 + 1, width - 1);
                    int y2 = Math.Min(y1 + 1, height - 1);

                    // 计算插值权重
                    float dx = srcX - x1;
                    float dy = srcY - y1;

                    // 双线性插值公式
                    if (pixelBytes == 4) {
                        // 获取四个相邻像素的颜色
                        var original2 = (int*)original;
                        var c11 = original2[y1 * width + x1];
                        var c21 = original2[y1 * width + x2];
                        var c12 = original2[y2 * width + x1];
                        var c22 = original2[y2 * width + x2];

                        // 水平方向插值
                        var c1 = InterpolateColor(c11, c21, dx);
                        var c2 = InterpolateColor(c12, c22, dx);

                        // 垂直方向插值
                        var newC = InterpolateColor(c1, c2, dy);
                        var newData2 = (int*)newData;
                        newData2[y * newWidth + x] = newC;
                    }
                    else {
                        for (int i = 0; i < pixelBytes; i++) {
                            // 获取四个相邻像素的颜色
                            var c11 = original[(y1 * width + x1) * pixelBytes + i];
                            var c21 = original[(y1 * width + x2) * pixelBytes + i];
                            var c12 = original[(y2 * width + x1) * pixelBytes + i];
                            var c22 = original[(y2 * width + x2) * pixelBytes + i];

                            // 水平方向插值
                            var c1 = InterpolateColor(c11, c21, dx);
                            var c2 = InterpolateColor(c12, c22, dx);

                            // 垂直方向插值
                            var newC = InterpolateColor(c1, c2, dy);
                            newData[(y * newWidth + x) * pixelBytes + i] = newC;
                        }
                    }
                }
            }

            return result;
        }

        private static int InterpolateColor(int c1, int c2, float t) {
            var r = c1 + (c2 - c1) * t;
            return (int)r;
        }
        private static byte InterpolateColor(byte c1, byte c2, float t) {
            var r = c1 + (c2 - c1) * t;
            return (byte)r;
        }
    }
}