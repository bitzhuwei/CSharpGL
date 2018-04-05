using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace c06d00_TextureArray
{
    class ImageGenerator
    {
        /// <summary>
        /// Generate 1D Texture Images.
        /// </summary>
        /// <param name="originalImage"></param>
        /// <param name="originalImageFilename"></param>
        /// <param name="unitHeight"></param>
        /// <param name="id"></param>
        public static void Run(string originalImageFilename, int unitHeight, string id)
        {
            var originalImage = new Bitmap(originalImageFilename);
            int width = originalImage.Width;
            var random = new Random();
            var level0 = new Bitmap(width, 1);
            for (int i = 0; i < width; i++)
            {
                var index = random.Next(width);
                Color color = originalImage.GetPixel(index, 0);
                level0.SetPixel(i, 0, color);
            }

            var list = new List<Bitmap>(); list.Add(level0);
            int targetWidth = width / 2;
            Bitmap currentBitmap = level0;
            while (targetWidth > 0)
            {
                var levelX = new Bitmap(currentBitmap, targetWidth, 1);
                list.Add(levelX);

                targetWidth = targetWidth / 2;
            }

            var final = new Bitmap(width, list.Count * 3);
            using (var g = Graphics.FromImage(final))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var image = list[i];
                    g.DrawImage(image, 0, i * 3);
                }
            }
            final.Save(string.Format("1DARray{0}.png", id));
        }
    }
}
