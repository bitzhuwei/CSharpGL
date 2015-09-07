using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Texts
{
    public static class FontResourceHelper
    {
        // TODO: 这里生成的中间贴图太大，有优化的空间
        /// <summary>
        /// 为指定的字符串生成贴图。
        /// </summary>
        /// <param name="fontResource"></param>
        /// <param name="content"></param>
        /// <param name="fontSize"></param>
        /// <param name="maxRowWidth"></param>
        /// <returns></returns>
        public static System.Drawing.Bitmap GenerateBitmapForString(this FontResource fontResource,
            string content, int fontSize, int maxRowWidth)
        {
            //fontResource.FontBitmap.Save("FontBitmap.png");
            // step 1: get totalLength
            int totalLength = 0;
            {
                int glyphsLength = 0;
                for (int i = 0; i < content.Length; i++)
                {
                    char c = content[i];
                    CharacterInfo cInfo;
                    if (fontResource.CharInfoDict.TryGetValue(c, out cInfo))
                    {
                        int glyphWidth = cInfo.width;
                        glyphsLength += glyphWidth;
                    }
                    //else
                    //{ throw new Exception(string.Format("Not support for display the char [{0}]", c)); }
                }

                //glyphsLength = (glyphsLength * this.fontSize / FontResource.Instance.FontHeight);
                int interval = fontResource.FontHeight / 10; if (interval < 1) { interval = 1; }
                totalLength = glyphsLength + interval * (content.Length - 1);
            }

            // step 2: setup contentBitmap
            System.Drawing.Bitmap contentBitmap = null;
            {
                int interval = fontResource.FontHeight / 10; if (interval < 1) { interval = 1; }
                //int totalLength = glyphsLength + interval * (content.Length - 1);
                int currentTextureWidth = 0;
                int currentWidthPos = 0;
                int currentHeightPos = 0;
                if (totalLength * fontSize > maxRowWidth * fontResource.FontHeight)// 超过1行能显示的内容
                {
                    currentTextureWidth = maxRowWidth * fontResource.FontHeight / fontSize;

                    int lineCount = (totalLength - 1) / currentTextureWidth + 1;
                    // 确保整篇文字的高度在贴图中间。
                    currentHeightPos = (currentTextureWidth - fontResource.FontHeight * lineCount) / 2;
                    //- FontResource.Instance.FontHeight / 2;
                }
                else//只在一行内即可显示所有字符
                {
                    if (totalLength >= fontResource.FontHeight)
                    {
                        currentTextureWidth = totalLength;

                        // 确保整篇文字的高度在贴图中间。
                        currentHeightPos = (currentTextureWidth - fontResource.FontHeight) / 2;
                        //- FontResource.Instance.FontHeight / 2;
                    }
                    else
                    {
                        currentTextureWidth = fontResource.FontHeight;

                        currentWidthPos = (currentTextureWidth - totalLength) / 2;
                        //glyphsLength = fontResource.FontHeight;
                    }
                }

                //this.textureWidth = textureWidth * this.fontSize / FontResource.Instance.FontHeight;
                //currentWidthPosition = currentWidthPosition * this.fontSize / FontResource.Instance.FontHeight;
                //currentHeightPosition = currentHeightPosition * this.fontSize / FontResource.Instance.FontHeight;

                contentBitmap = new Bitmap(currentTextureWidth, currentTextureWidth);
                Graphics gContentBitmap = Graphics.FromImage(contentBitmap);
                Bitmap bigBitmap = fontResource.FontBitmap;
                for (int i = 0; i < content.Length; i++)
                {
                    char c = content[i];
                    CharacterInfo cInfo;
                    if (fontResource.CharInfoDict.TryGetValue(c, out cInfo))
                    {
                        if (currentWidthPos + cInfo.width > contentBitmap.Width)
                        {
                            currentWidthPos = 0;
                            currentHeightPos += fontResource.FontHeight;
                        }

                        gContentBitmap.DrawImage(bigBitmap,
                            new Rectangle(currentWidthPos, currentHeightPos, cInfo.width, fontResource.FontHeight),
                            new Rectangle(cInfo.xoffset, cInfo.yoffset, cInfo.width, fontResource.FontHeight),
                            GraphicsUnit.Pixel);

                        currentWidthPos += cInfo.width + interval;
                    }
                }
                gContentBitmap.Dispose();
                //contentBitmap.Save("PointSpriteStringElement-contentBitmap.png");
                System.Drawing.Bitmap bmp = null;
                if (totalLength * fontSize > maxRowWidth * fontResource.FontHeight)// 超过1行能显示的内容
                {
                    bmp = (System.Drawing.Bitmap)contentBitmap.GetThumbnailImage(
                        maxRowWidth, maxRowWidth, null, IntPtr.Zero);
                }
                else//只在一行内即可显示所有字符
                {
                    if (totalLength >= fontResource.FontHeight)
                    {
                        bmp = (System.Drawing.Bitmap)contentBitmap.GetThumbnailImage(
                            totalLength * fontSize / fontResource.FontHeight,
                            totalLength * fontSize / fontResource.FontHeight,
                            null, IntPtr.Zero);

                    }
                    else
                    {
                        bmp = (System.Drawing.Bitmap)contentBitmap.GetThumbnailImage(
                            fontSize, fontSize, null, IntPtr.Zero);
                    }
                }
                contentBitmap.Dispose();
                contentBitmap = bmp;
                //contentBitmap.Save("PointSpriteStringElement-contentBitmap-scaled.png");
            }

            return contentBitmap;

        }
    }
}
