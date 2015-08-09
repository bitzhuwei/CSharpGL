using CSharpGL.Objects.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts
{
    /// <summary>
    /// 用一个纹理绘制指定范围内的所有可见字符
    /// </summary>
    public class TTFTexture : IDisposable
    {

        /// <summary>
        /// TTF文件名
        /// </summary>
        public string TtfFullname { get; set; }

        /// <summary>
        /// 字形高度
        /// </summary>
        public int FontHeight { get; set; }

        /// <summary>
        /// 第一个字符
        /// </summary>
        public char FirstChar { get; set; }

        /// <summary>
        /// 最后一个字符
        /// </summary>
        public char LastChar { get; set; }

        /// <summary>
        /// 存储了从<see cref="FirstChar"/>到<see cref="LastChar"/>的所有可见字符的位图。
        /// </summary>
        public System.Drawing.Bitmap BigBitmap { get; set; }

        /// <summary>
        /// 记录每个字符在<see cref="BigBitmap"/>里的偏移量及其字形的宽高。
        /// </summary>
        public Dictionary<char, CharacterInfo> CharInfoDict { get; set; }

        internal TTFTexture() { }

        /// <summary>
        /// 获取一个<see cref="TTFTexture"/>实例。
        /// </summary>
        /// <param name="ttfFullname"></param>
        /// <param name="fontHeight"></param>
        /// <param name="firstChar"></param>
        /// <param name="lastChar"></param>
        /// <param name="maxTextureWidth"></param>
        /// <returns></returns>
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

        public void GetTextureWidthHeight(int maxTextureWidth, out int width, out int height)
        {
            int textureWidth = maxTextureWidth;
            int textureHeight = maxTextureWidth;
            System.Drawing.Bitmap bitmap = this.BigBitmap;

            for (int size = 1; size <= maxTextureWidth; size *= 2)
            {
                if (bitmap.Width < size)
                {
                    textureWidth = size / 2;
                    break;
                }
                if (bitmap.Width == size)
                    textureWidth = size;

            }

            for (int size = 1; size <= maxTextureWidth; size *= 2)
            {
                if (bitmap.Height < size)
                {
                    textureHeight = size / 2;
                    break;
                }
                if (bitmap.Height == size)
                    textureHeight = size;
            }

            width = textureWidth;
            height = textureHeight;
        }
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

            Dictionary<char, CharacterInfo> charInfoDict;
            int textureWidth, textureHeight;

            GetTextureBlueprint(face, fontHeight, firstChar, lastChar, maxTextureWidth, out charInfoDict, out textureWidth, out textureHeight);

            if (textureWidth == 0) { textureWidth = 1; }
            if (textureHeight == 0) { textureHeight = 1; }

            System.Drawing.Bitmap bigBitmap = GetBigBitmap(face, fontHeight, firstChar, lastChar, maxTextureWidth, charInfoDict, textureWidth, textureHeight);

            face.Dispose();
            library.Dispose();

            var result = new TTFTexture() { TtfFullname = ttfFullname, FontHeight = fontHeight, FirstChar = firstChar, LastChar = lastChar, BigBitmap = bigBitmap, CharInfoDict = charInfoDict, };

            return result;
        }

        /// <summary>
        /// 根据<paramref name="charInfoDict"/>等信息把各个字形写入一个大的位图并返回之。
        /// </summary>
        /// <param name="face"></param>
        /// <param name="fontHeight"></param>
        /// <param name="firstChar"></param>
        /// <param name="lastChar"></param>
        /// <param name="maxTextureWidth"></param>
        /// <param name="charInfoDict"></param>
        /// <param name="widthOfTexture"></param>
        /// <param name="heightOfTexture"></param>
        /// <returns></returns>
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
                int size = glyph.obj.bitmap.width * glyph.obj.bitmap.rows;
                bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                if ((size == 0) && (!zeroBuffer)) { throw new Exception(string.Format("glyph size({0}) for non zero buffer({1})", 0, glyph.obj.bitmap.buffer)); }
                if ((!(size == 0)) && zeroBuffer) { throw new Exception(string.Format("glyph size({0}) for zero buffer({1})", size, glyph.obj.bitmap.buffer)); }

                if (!(size == 0))
                {
                    byte[] byteBitmap = new byte[size];
                    Marshal.Copy(glyph.obj.bitmap.buffer, byteBitmap, 0, byteBitmap.Length);
                    CharacterInfo cInfo;
                    if (charInfoDict.TryGetValue(c, out cInfo))
                    {
                        if (cInfo.width > 0 && cInfo.height > 0)
                        {
                            System.Drawing.Imaging.PixelFormat format = System.Drawing.Imaging.PixelFormat.Format32bppRgb;
                            System.Drawing.Imaging.ImageLockMode lockMode = System.Drawing.Imaging.ImageLockMode.WriteOnly;
                            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(cInfo.width, cInfo.height, format);
                            Rectangle bitmapRect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                            System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(bitmapRect, lockMode, format);

                            int length = Math.Abs(bmpData.Stride) * bitmap.Height;
                            byte[] bitmapBytes = new byte[length];
                            for (int row = 0; row < cInfo.height; row++)
                            {
                                for (int col = 0; col < cInfo.width; col++)
                                {
                                    byte color = byteBitmap[row * cInfo.width + col];
                                    bitmapBytes[row * bmpData.Stride + col * 4 + 0] = color;
                                    bitmapBytes[row * bmpData.Stride + col * 4 + 1] = color;
                                    bitmapBytes[row * bmpData.Stride + col * 4 + 2] = color;
                                    //bitmapBytes[row * bmpData.Stride + col * 4 + 3] = color;
                                }
                            }

                            System.Runtime.InteropServices.Marshal.Copy(bitmapBytes, 0, bmpData.Scan0, length);

                            bitmap.UnlockBits(bmpData);

                            //int baseLine = fontHeight * 3 / 4 + 4;
                            //graphics.DrawImage(bitmap, cInfo.xoffset, cInfo.yoffset + baseLine - glyph.obj.top);
                            int skyHeight = fontHeight * 3 / 4 - glyph.obj.top;
                            if (skyHeight < 0) { skyHeight = 0; }
                            graphics.DrawImage(bitmap, cInfo.xoffset, cInfo.yoffset + skyHeight);
                        }
                    }
                    else
                    { throw new Exception(string.Format("Not support for display the char [{0}]", c)); }
                }

                if (c == char.MaxValue) { break; }
            }

            graphics.Dispose();

            return bigBitmap;
        }

        private static void TmpTest(byte[] byteBitmap, CharacterInfo cInfo)
        {
            {
                var tempBmp = new System.Drawing.Bitmap("modernSingleTextureFont.png");
                Console.WriteLine(tempBmp.PixelFormat);
                var color = Color.FromArgb(0, 0, 0);
            }
            {

                System.Drawing.Imaging.PixelFormat format = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(cInfo.width, cInfo.height,
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                     System.Drawing.Imaging.ImageLockMode.WriteOnly, format);
                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;

                // Declare an array to hold the bytes of the bitmap.
                int bytes = Math.Abs(bmpData.Stride) * bitmap.Height;
                byte[] rgbValues = new byte[bytes];
                for (int row = 0; row < cInfo.height; row++)
                {
                    for (int col = 0; col < cInfo.width; col++)
                    {
                        byte color = byteBitmap[row * cInfo.width + col];
                        //if (color == 0) { color = byte.MaxValue; }
                        rgbValues[row * bmpData.Stride + col * 4 + 0] = color;
                        rgbValues[row * bmpData.Stride + col * 4 + 1] = color;
                        rgbValues[row * bmpData.Stride + col * 4 + 2] = color;
                        rgbValues[row * bmpData.Stride + col * 4 + 3] = color;
                    }
                }

                // Copy the RGB values back to the bitmap
                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                // Unlock the bits.
                bitmap.UnlockBits(bmpData);
                bitmap.Save("tmp" + ".png");
            }
        }


        /// <summary>
        /// 根据<paramref name="firstChar"/>等信息获取要制作的贴图的宽高和各个字形的位置信息。
        /// </summary>
        /// <param name="face"></param>
        /// <param name="fontHeight"></param>
        /// <param name="firstChar"></param>
        /// <param name="lastChar"></param>
        /// <param name="maxTextureWidth"></param>
        /// <param name="charInfoDict"></param>
        /// <param name="textureWidth"></param>
        /// <param name="textureHeight"></param>
        private static void GetTextureBlueprint(FreeTypeFace face, int fontHeight,
            char firstChar, char lastChar, int maxTextureWidth,
            out Dictionary<char, CharacterInfo> charInfoDict, out int textureWidth, out int textureHeight)
        {
            charInfoDict = new Dictionary<char, CharacterInfo>();
            textureWidth = 0;
            textureHeight = fontHeight;

            int glyphXOffset = 0;
            int glyphYOffset = 0;

            for (char c = firstChar; c <= lastChar; c++)
            {
                FreeTypeBitmapGlyph glyph = new FreeTypeBitmapGlyph(face, c, fontHeight);

                bool zeroSize = (glyph.obj.bitmap.rows == 0 && glyph.obj.bitmap.width == 0);

                bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                if (zeroSize && (!zeroBuffer)) { throw new Exception(); }
                if ((!zeroSize) && zeroBuffer) { throw new Exception(); }

                if(!zeroSize)
                {
                    int glyphWidth = glyph.obj.bitmap.width;
                    int glyphHeight = glyph.obj.bitmap.rows;

                    if (glyphXOffset + glyphWidth + 1 <= maxTextureWidth)
                    {
                        textureWidth = Math.Max(textureWidth, glyphXOffset + glyphWidth + 1);
                    }
                    else// 此字形将超出最大宽度，所以要换行。
                    {
                        textureHeight += fontHeight;

                        glyphXOffset = 0;
                        glyphYOffset = textureHeight - fontHeight;
                    }

                    CharacterInfo cInfo = new CharacterInfo();
                    cInfo.xoffset = glyphXOffset; cInfo.yoffset = glyphYOffset;
                    cInfo.width = glyphWidth; cInfo.height = glyphHeight;
                    charInfoDict.Add(c, cInfo);

                    glyphXOffset += glyphWidth + 1;
                }

                if (c == char.MaxValue) { break; }
            }

        }
    }
}

