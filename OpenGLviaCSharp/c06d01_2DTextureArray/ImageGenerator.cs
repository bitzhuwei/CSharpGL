using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace c06d01_2DTextureArray
{
    class ImageGenerator
    {
        /// <summary>
        /// Generate 2D Texture Images.
        /// </summary>
        /// <param name="originalImage"></param>
        /// <param name="originalImageFilename"></param>
        /// <param name="id"></param>
        public static void Run(string originalImageFilename, string id)
        {
            var originalImage = new Bitmap(originalImageFilename);
            int width = originalImage.Width;
            int height = originalImage.Height;
            var level0 = originalImage;

            var list = new List<Bitmap>(); list.Add(level0);
            int targetWidth = width / 2;
            int targetHeight = height / 2;
            Bitmap currentBitmap = level0;
            while (targetWidth > 0 && targetHeight > 0)
            {
                var levelX = new Bitmap(currentBitmap, targetWidth, targetHeight);
                list.Add(levelX);

                targetWidth = targetWidth / 2;
                targetHeight = targetHeight / 2;
            }

            var final = new Bitmap(width * 2 + list.Count, height);
            using (var g = Graphics.FromImage(final))
            {
                int currentX = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    var image = list[i];
                    g.DrawImage(image, currentX, 0);
                    currentX += image.Width + 1;
                }
            }
            final.Save(string.Format("index{0}.png", id));
        }
    }
}
