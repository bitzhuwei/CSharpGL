using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TTF2Bmps
{
    /// <summary>
    /// 用一个纹理绘制指定范围内的所有可见字符
    /// </summary>
    public class TTFTexture : IDisposable
    {
        private string ttfFullname;

        public string TtfFullname
        {
            get { return ttfFullname; }
            set { ttfFullname = value; }
        }
        private int fontHeight;

        public int FontHeight
        {
            get { return fontHeight; }
            set { fontHeight = value; }
        }
        private char firstChar;

        public char FirstChar
        {
            get { return firstChar; }
            set { firstChar = value; }
        }
        private char lastChar;

        public char LastChar
        {
            get { return lastChar; }
            set { lastChar = value; }
        }
        private System.Drawing.Bitmap bigBitmap;

        public System.Drawing.Bitmap BigBitmap
        {
            get { return bigBitmap; }
            set { bigBitmap = value; }
        }
        private Dictionary<char, CharacterInfo> charInfoDict;

        public Dictionary<char, CharacterInfo> CharInfoDict
        {
            get { return charInfoDict; }
            set { charInfoDict = value; }
        }

        internal TTFTexture(string ttfFullname, int fontHeight, char firstChar, char lastChar,
            System.Drawing.Bitmap bigBitmap, Dictionary<char, CharacterInfo> charInfoDict)
        {
            this.ttfFullname = ttfFullname;
            this.fontHeight = fontHeight;
            this.firstChar = firstChar;
            this.lastChar = lastChar;
            this.bigBitmap = bigBitmap;
            this.charInfoDict = charInfoDict;
        }

        public static TTFTexture GetTTFTexture(string ttfFullname, int fontHeight, char firstChar, char lastChar, int maxTextureWidth)
        {
            var result = TTFTextureHelper.GetTTFTexture(ttfFullname, fontHeight, firstChar, lastChar, maxTextureWidth);

            return result;
        }
        ~TTFTexture()
        {
            this.Dispose();
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        protected Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //Managed cleanup code here, while managed refs still valid
            }
            //Unmanaged cleanup code here
            System.Drawing.Bitmap bmp = this.BigBitmap;
            if (bmp != null)
            {
                this.BigBitmap = null;
                this.CharInfoDict.Clear();
                bmp.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        #endregion

    }

    static class TTFTextureHelper
    {
        /// <summary>
        /// 用一个纹理绘制指定范围内的所有可见字符
        /// </summary>
        /// <param name="ttfFullname"></param>
        /// <param name="fontHeight">此值越大，绘制文字的清晰度越高，但占用的纹理资源就越多。</param>
        /// <param name="firstChar"></param>
        /// <param name="lastChar"></param>
        /// <param name="maxTextureWidth">生成的纹理的最大宽度。</param>
        /// <returns></returns>
        public static TTFTexture GetTTFTexture(string ttfFullname, int fontHeight, char firstChar, char lastChar, int maxTextureWidth)
        {
            FreeTypeLibrary library = new FreeTypeLibrary();

            FreeTypeFace face = new FreeTypeFace(library, ttfFullname);

            Dictionary<char, CharacterInfo> charInfoDict = new Dictionary<char, CharacterInfo>();
            int textureWidth, textureHeight;

            GetTextureBlueprint(face, fontHeight, firstChar, lastChar, maxTextureWidth, charInfoDict, out textureWidth, out textureHeight);

            if (textureWidth == 0) { textureWidth = 1; }
            if (textureHeight == 0) { textureHeight = 1; }

            System.Drawing.Bitmap bigBitmap = GetBigBitmap(face, fontHeight, firstChar, lastChar, maxTextureWidth, charInfoDict, textureWidth, textureHeight);

            face.Dispose();
            library.Dispose();

            var result = new TTFTexture(ttfFullname, fontHeight, firstChar, lastChar, bigBitmap, charInfoDict);

            return result;
        }

        private static System.Drawing.Bitmap GetBigBitmap(FreeTypeFace face, int fontHeight,
            char firstChar, char lastChar, int maxTextureWidth,
            Dictionary<char, CharacterInfo> charInfoDict,
            int widthOfTexture, int heightOfTexture)
        {
            System.Drawing.Bitmap bigBitmap = new System.Drawing.Bitmap(widthOfTexture, heightOfTexture);
            Graphics graphics = Graphics.FromImage(bigBitmap);

            for (char c = firstChar; c <= lastChar; c++)
            {
                FreeTypeBitmapGlyph glyph = new FreeTypeBitmapGlyph(face, c, fontHeight);
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
                    if (charInfoDict.TryGetValue(c, out cInfo))
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

                            int baseLine = fontHeight / 4 * 3;
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

        private static void GetTextureBlueprint(FreeTypeFace face, int fontHeight,
            char firstChar, char lastChar, int maxTextureWidth,
            Dictionary<char, CharacterInfo> charInfoDict,
            out int widthOfTexture, out int heightOfTexture)
        {
            widthOfTexture = 0;
            heightOfTexture = fontHeight;

            int glyphX = 0;
            int glyphY = 0;

            for (char c = firstChar; c <= lastChar; c++)
            {
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
                    heightOfTexture += fontHeight;

                    glyphX = 0;
                    glyphY = heightOfTexture - fontHeight;

                    CharacterInfo cInfo = new CharacterInfo();
                    cInfo.xoffset = glyphX; cInfo.yoffset = glyphY;
                    cInfo.width = glyphWidth; cInfo.height = glyphHeight;
                    charInfoDict.Add(c, cInfo);
                }
                else
                {
                    widthOfTexture = Math.Max(widthOfTexture, glyphX + glyphWidth + 1);

                    CharacterInfo cInfo = new CharacterInfo();
                    cInfo.xoffset = glyphX; cInfo.yoffset = glyphY;
                    cInfo.width = glyphWidth; cInfo.height = glyphHeight;
                    charInfoDict.Add(c, cInfo);
                }

                glyphX += glyphWidth + 1;
            }

        }
    }
}
