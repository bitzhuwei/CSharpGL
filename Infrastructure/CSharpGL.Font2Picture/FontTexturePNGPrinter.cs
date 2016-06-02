using CSharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Font2Picture
{
    class FontTexturePNGPrinter
    {
        private FontTexture ttfTexture;

        public FontTexturePNGPrinter(FontTexture ttfTexture)
        {
            this.ttfTexture = ttfTexture;
            this.font = new Font("微软雅黑", ttfTexture.FontHeight / 2);
            this.outputWidth = ttfTexture.FontHeight * 40;
        }


        public IEnumerable<SingleFileProgress> Print(string fontFullname, int maxTextureWidth)
        {
            int count = this.ttfTexture.CharInfoDict.Count;
            FileInfo fileInfo = new FileInfo(fontFullname);

            int width;
            int height;
            {
                System.Drawing.Bitmap bigBitmap = this.ttfTexture.BigBitmap;
                width = bigBitmap.Width;
                height = bigBitmap.Height;
            }

            const int magicNumber = 100;
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(this.outputWidth,
                (this.ttfTexture.FontHeight + 1) * magicNumber); //this.ttfTexture.CharInfoDict.Count);
            Graphics g = Graphics.FromImage(bitmap);

            int index = 0;
            foreach (var item in this.ttfTexture.CharInfoDict)
            {
                char c = item.Key;
                CharacterInfo info = item.Value;
                System.Drawing.Bitmap singleGlyph = new Bitmap(info.width, info.height);
                Graphics singleGlyphGraphics = Graphics.FromImage(singleGlyph);
                g.DrawImage(this.ttfTexture.BigBitmap,
                    new Rectangle(1, (index % magicNumber) * (this.ttfTexture.FontHeight + 1),
                        info.width, this.ttfTexture.FontHeight),
                    new Rectangle(info.xoffset, info.yoffset - info.yoffset % this.ttfTexture.FontHeight,
                        info.width, this.ttfTexture.FontHeight), GraphicsUnit.Pixel);
                g.DrawString(string.Format("{0}/{1}: offset: [{2}, {3}] size:　[{4}, {5}], texCoord: [{6}, {7}, {8}， {9}]",
                    index, c, info.xoffset, info.yoffset, info.width, info.height,
                    (float)info.xoffset / (float)width,
                    (float)info.yoffset / (float)height,
                    (float)(info.xoffset + info.width) / (float)width,
                    (float)(info.yoffset + ttfTexture.FontHeight) / (float)height), font, brush,
                    info.width + 1, (index % magicNumber) * (this.ttfTexture.FontHeight + 1)
                    );
                index++;

                if (index % magicNumber == 0)
                {
                    g.Dispose();
                    bitmap.Save(fontFullname + "list" + index / magicNumber + ".png");
                    bitmap.Dispose();

                    bitmap = new System.Drawing.Bitmap(this.outputWidth,
                        (this.ttfTexture.FontHeight + 1) * magicNumber); //this.ttfTexture.CharInfoDict.Count);
                    g = Graphics.FromImage(bitmap);
                }


                yield return new SingleFileProgress()
                {
                    progress = (index * magicNumber / count),
                    message = string.Format("print PNG list for {0}", fileInfo.Name),
                };
            }

            g.Dispose();
            bitmap.Save(fontFullname + "list" + index / magicNumber + ".png");
            bitmap.Dispose();

            yield return new SingleFileProgress()
            {
                progress = magicNumber,
                message = string.Format("print PNG list for {0} done!", fileInfo.Name),
            };
        }

        public Font font = new Font("微软雅黑", 12);
        public Brush brush = new SolidBrush(Color.Red);
        private int outputWidth;
    }

}
