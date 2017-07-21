using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageData : LeveledData
    {
        private Bitmap bitmap;
        private int level;

        private System.Drawing.Imaging.BitmapData bmpData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="level"></param>
        public ImageData(Bitmap bitmap, int level)
        {
            this.bitmap = bitmap;
            this.level = level;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override void LockData(out int level, out IntPtr data)
        {
            level = this.level;
            this.bmpData = this.bitmap.LockBits(new Rectangle(0, 0, this.bitmap.Width, this.bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            data = bmpData.Scan0;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void FreeData()
        {
            this.bitmap.UnlockBits(this.bmpData);
        }
    }
}
