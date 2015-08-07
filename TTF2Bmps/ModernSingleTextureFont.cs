using CSharpGL;
using CSharpGL.Maths;
using CSharpGL.Objects.Cameras;
using CSharpGL.Objects.Shaders;
using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace TTF2Bmps
{
    /// <summary>
    /// 用一个纹理绘制ASCII表上所有可见字符（具有指定的高度和字体）
    /// </summary>
    public class ModernSingleTextureFont
    {
        private string fontFullname;
        private char firstChar;
        private char lastChar;
        private int maxWidth;
        private int fontHeight;
        private int textureWidth;
        private int textureHeight;
        Dictionary<char, CharacterInfo> charInfoDict = new Dictionary<char, CharacterInfo>();

        /// <summary>
        /// 用一个纹理绘制ASCII表上所有可见字符（具有指定的高度和字体）
        /// </summary>
        /// <param name="fontFullname"></param>
        /// <param name="fontHeight">此值越大，绘制文字的清晰度越高，但占用的纹理资源就越多。</param>
        /// <param name="firstChar"></param>
        /// <param name="lastChar"></param>
        /// <param name="maxWidth">生成的纹理的最大宽度。</param>
        public ModernSingleTextureFont(string fontFullname, int fontHeight, char firstChar, char lastChar, int maxWidth)
        {
            this.fontFullname = fontFullname;
            this.fontHeight = fontHeight;
            this.firstChar = firstChar;
            this.lastChar = lastChar;
            this.maxWidth = maxWidth;
        }

        public System.Drawing.Bitmap GetBitmap()
        {
            // 初始化FreeType库：创建FreeType库指针
            FreeTypeLibrary library = new FreeTypeLibrary();

            // 初始化字体库
            FreeTypeFace face = new FreeTypeFace(library, this.fontFullname);

            GetTextureBlueprint(face, this.fontHeight, this.maxWidth, out this.textureWidth, out this.textureHeight);

            if (this.textureWidth == 0) { this.textureWidth = 1; }
            if (this.textureHeight == 0) { this.textureHeight = 1; }

            System.Drawing.Bitmap bigBitmap = GetBigBitmap(face, this.maxWidth, this.textureWidth, this.textureHeight);

            face.Dispose();
            library.Dispose();

            return bigBitmap;
        }

        private System.Drawing.Bitmap GetBigBitmap(FreeTypeFace face, int maxTextureWidth, int widthOfTexture, int heightOfTexture)
        {
            System.Drawing.Bitmap bigBitmap = new System.Drawing.Bitmap(widthOfTexture, heightOfTexture);
            Graphics graphics = Graphics.FromImage(bigBitmap);

            //for (int i = (int)this.firstChar; i <= (int)this.lastChar; i++)
            for (char c = this.firstChar; c <= this.lastChar; c++)
            {
                //char c = Convert.ToChar(i);
                FreeTypeBitmapGlyph glyph = new FreeTypeBitmapGlyph(face, c, this.fontHeight);
                bool zeroSize = (glyph.obj.bitmap.rows == 0 && glyph.obj.bitmap.width == 0);
                bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                if (zeroSize && (!zeroBuffer)) { throw new Exception(); }
                if ((!zeroSize) && zeroBuffer) { throw new Exception(); }

                if (!zeroSize)
                {
                    int size = glyph.obj.bitmap.width * glyph.obj.bitmap.rows;
                    byte[] byteBitmap = new byte[size];
                    Marshal.Copy(glyph.obj.bitmap.buffer, byteBitmap, 0, byteBitmap.Length);
                    CharacterInfo cInfo;
                    if (this.charInfoDict.TryGetValue(c, out cInfo))
                    {
                        if (cInfo.width > 0)
                        {
                            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(cInfo.width, cInfo.height);
                            for (int tmpRow = 0; tmpRow < cInfo.height; ++tmpRow)
                            {
                                for (int tmpWidth = 0; tmpWidth < cInfo.width; ++tmpWidth)
                                {
                                    byte color = byteBitmap[tmpRow * cInfo.width + tmpWidth];
                                    bitmap.SetPixel(tmpWidth, tmpRow, Color.FromArgb(color, color, color));
                                }
                            }

                            int baseLine = this.fontHeight / 4 * 3;
                            graphics.DrawImage(bitmap, cInfo.xoffset,
                                cInfo.yoffset + baseLine - glyph.obj.top);
                        }
                    }
                    else
                    { throw new Exception(string.Format("Not support for display the char [{0}]", c)); }
                }

            }

            graphics.Dispose();

            return bigBitmap;
        }

        private void GetTextureBlueprint(FreeTypeFace face, int fontHeight, int maxTextureWidth, out int widthOfTexture, out int heightOfTexture)
        {
            widthOfTexture = 0;
            heightOfTexture = this.fontHeight;

            int glyphX = 0;
            int glyphY = 0;

            //for (int i = (int)this.firstChar; i <= (int)this.lastChar; i++)
            for (char c = this.firstChar; c <= this.lastChar; c++)
            {
                //char c = Convert.ToChar(i);
                FreeTypeBitmapGlyph glyph = new FreeTypeBitmapGlyph(face, c, fontHeight);
                bool zeroSize = (glyph.obj.bitmap.rows == 0 && glyph.obj.bitmap.width == 0);
                bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                if (zeroSize && (!zeroBuffer)) { throw new Exception(); }
                if ((!zeroSize) && zeroBuffer) { throw new Exception(); }
                if (zeroSize) { continue; }

                int glyphWidth = glyph.obj.bitmap.width;
                int glyphHeight = glyph.obj.bitmap.rows;

                if (glyphX + glyphWidth + 1 > maxTextureWidth)
                {
                    heightOfTexture += this.fontHeight;

                    glyphX = 0;
                    glyphY = heightOfTexture - this.fontHeight;

                    CharacterInfo cInfo = new CharacterInfo();
                    cInfo.xoffset = glyphX; cInfo.yoffset = glyphY;
                    cInfo.width = glyphWidth; cInfo.height = glyphHeight;
                    this.charInfoDict.Add(c, cInfo);
                }
                else
                {
                    widthOfTexture = Math.Max(widthOfTexture, glyphX + glyphWidth + 1);

                    CharacterInfo cInfo = new CharacterInfo();
                    cInfo.xoffset = glyphX; cInfo.yoffset = glyphY;
                    cInfo.width = glyphWidth; cInfo.height = glyphHeight;
                    this.charInfoDict.Add(c, cInfo);
                }

                glyphX += glyphWidth + 1;
            }

        }

    }

}
