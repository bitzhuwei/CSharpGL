using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    /// Helper class for screen shot of OpenGL canvas.
    /// </summary>
    public static class Save2PictureHelper
    {
        /// <summary>
        /// Screen shot of OpenGL canvas.
        /// </summary>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public static Bitmap ScreenShot(int x, int y, int width, int height)
        {
            var format = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
            var bitmap = new Bitmap(width, height, format);
            var bitmapRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var lockMode = System.Drawing.Imaging.ImageLockMode.WriteOnly;
            System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(bitmapRect, lockMode, format);
            OpenGL.ReadPixels(x, y, width, height, OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, bmpData.Scan0);
            bitmap.UnlockBits(bmpData);
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            return bitmap;
        }
    }
}