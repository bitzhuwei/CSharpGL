using CSharpGL.Texts.FreeTypes;
using CSharpGL.Texts.FreeTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL.Texts
{
    public static class FontTextureHelper
    {
        public const string strTTFTexture = "TTFTexture";
        public const string strFontHeight = "FontHeight";
        public const string strFirstChar = "FirstChar";
        public const string strLastChar = "LastChar";

        public static XElement ToXElement(this FontTexture texture)
        {
            XElement result = new XElement(strTTFTexture,
                new XAttribute(strFontHeight, texture.FontHeight),
                new XAttribute(strFirstChar, (int)texture.FirstChar),
                new XAttribute(strLastChar, (int)texture.LastChar),
                texture.CharInfoDict.ToXElement());

            return result;
        }

        private static FontTexture Parse(XElement xElement)
        {
            FontTexture result = new FontTexture();
            result.FontHeight = int.Parse(xElement.Attribute(strFontHeight).Value);
            result.FirstChar = (char)int.Parse(xElement.Attribute(strFirstChar).Value);
            result.LastChar = (char)int.Parse(xElement.Attribute(strLastChar).Value);
            result.CharInfoDict = CharacterInfoDictHelper.Parse(
                xElement.Element(CharacterInfoDictHelper.strCharacterInfoDict));

            return result;
        }

        /// <summary>
        /// 根据已经生成的贴图和附带的Xml配置文件得到一个<see cref="FontTexture"/>。
        /// <para>此贴图和Xml文件</para>
        /// </summary>
        /// <param name="textureFullname"></param>
        /// <param name="xmlFullname"></param>
        /// <returns></returns>
        public static FontTexture GetTTFTexture(string textureFullname, string xmlFullname)
        {
            XElement ttfTextureElement = XElement.Load(xmlFullname); //new XElement(xmlFullname);
            FontTexture result = Parse(ttfTextureElement);

            System.Drawing.Bitmap bigBitmap = new System.Drawing.Bitmap(textureFullname);
            result.BigBitmap = bigBitmap;

            return result;
        }

        /// <summary>
        /// 用一个纹理绘制指定范围内的所有可见字符
        /// </summary>
        /// <param name="ttfFullname"></param>
        /// <param name="fontHeight">此值越大，绘制文字的清晰度越高，但占用的纹理资源就越多。</param>
        /// <param name="firstChar"></param>
        /// <param name="lastChar"></param>
        /// <param name="maxTextureWidth">生成的纹理的最大宽度。</param>
        /// <returns></returns>
        public static FontTexture GetTTFTexture(string ttfFullname, int fontHeight, int maxTextureWidth, char firstChar, char lastChar)
        {
            FreeTypeLibrary library = new FreeTypeLibrary();

            FreeTypeFace face = new FreeTypeFace(library, ttfFullname);

            Dictionary<char, CharacterInfo> charInfoDict;
            int textureWidth, textureHeight;

            GetTextureBlueprint(face, fontHeight, maxTextureWidth, firstChar, lastChar, out charInfoDict, out textureWidth, out textureHeight);

            if (textureWidth == 0) { textureWidth = 1; }
            if (textureHeight == 0) { textureHeight = 1; }

            System.Drawing.Bitmap bigBitmap = GetBigBitmap(face, fontHeight, maxTextureWidth, firstChar, lastChar, charInfoDict, textureWidth, textureHeight);

            face.Dispose();
            library.Dispose();

            var result = new FontTexture() { TtfFullname = ttfFullname, FontHeight = fontHeight, FirstChar = firstChar, LastChar = lastChar, BigBitmap = bigBitmap, CharInfoDict = charInfoDict, };

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
        private static System.Drawing.Bitmap GetBigBitmap(FreeTypeFace face, int fontHeight, int maxTextureWidth,
            char firstChar, char lastChar,
            Dictionary<char, CharacterInfo> charInfoDict,
            int widthOfTexture, int heightOfTexture)
        {
            System.Drawing.Bitmap bigBitmap = new System.Drawing.Bitmap(widthOfTexture, heightOfTexture);
            Graphics graphics = Graphics.FromImage(bigBitmap);

            for (char c = firstChar; c <= lastChar; c++)
            {
                FreeTypeBitmapGlyph glyph = new FreeTypeBitmapGlyph(face, c, fontHeight);
                int size = glyph.obj.bitmap.width * glyph.obj.bitmap.rows;

                {
                    bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                    if ((size == 0) && (!zeroBuffer)) { throw new Exception(string.Format("glyph size({0}) for non zero buffer({1})", 0, glyph.obj.bitmap.buffer)); }
                    if ((size != 0) && zeroBuffer) { throw new Exception(string.Format("glyph size({0}) for zero buffer({1})", size, glyph.obj.bitmap.buffer)); }
                }

                byte[] byteBitmap = null;

                if ((c == ' ') && (size == 0))
                {
                    size = charInfoDict[' '].width * charInfoDict[' '].height;
                    byteBitmap = new byte[size];
                }
                else if ((c == '\t') && (size == 0))
                {
                    size = charInfoDict['\t'].width * charInfoDict['\t'].height;
                    byteBitmap = new byte[size];
                }
                else if (size != 0)
                {
                    byteBitmap = new byte[size];
                    Marshal.Copy(glyph.obj.bitmap.buffer, byteBitmap, 0, byteBitmap.Length);
                }

                if (size != 0)
                {
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
        private static void GetTextureBlueprint(FreeTypeFace face, int fontHeight, int maxTextureWidth,
            char firstChar, char lastChar,
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

                {
                    bool zeroBuffer = glyph.obj.bitmap.buffer == IntPtr.Zero;
                    if (zeroSize && (!zeroBuffer)) { throw new Exception(); }
                    if ((!zeroSize) && zeroBuffer) { throw new Exception(); }
                }

                int glyphWidth = glyph.obj.bitmap.width;
                int glyphHeight = glyph.obj.bitmap.rows;


                if (c == ' ' && zeroSize)// 空格需要特殊处理
                {
                    zeroSize = false;
                    FreeTypeBitmapGlyph tabGlyph = new FreeTypeBitmapGlyph(face, '\t', fontHeight);
                    glyphWidth = tabGlyph.obj.bitmap.width / 8;
                    if (glyphWidth < 1) { glyphWidth = fontHeight / 2; }
                    glyphHeight = tabGlyph.obj.bitmap.rows;
                    //if (glyphHeight < 1) { glyphHeight = 1; }
                }
                else if (c == '\t' && zeroSize)// tab可能需要特殊处理
                {
                    zeroSize = false;
                    glyphWidth = glyph.obj.bitmap.width;
                    if (glyphWidth < 1) { glyphWidth = fontHeight * 2; }
                    glyphHeight = glyph.obj.bitmap.rows;
                    //if (glyphHeight < 1) { glyphHeight = 1; }
                }

                if (!zeroSize)
                {
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
