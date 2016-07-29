using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 字形贴图及其UV。
    /// </summary>
    public sealed partial class FontTexture
    {
        private static readonly object synObj = new object();
        private static readonly Dictionary<IntPtr, FontTexture> dict = new Dictionary<IntPtr, FontTexture>();

        /// <summary>
        /// Default FontTexture instance for this render context.
        /// </summary>
        public static FontTexture Default
        {
            get
            {
                IntPtr renderContext = Win32.wglGetCurrentContext();
                FontTexture resource;
                if (!dict.TryGetValue(renderContext, out resource))
                {
                    lock (synObj)
                    {
                        if (!dict.TryGetValue(renderContext, out resource))
                        {
                            resource = InitializeDefaultFontTexture();
                            dict.Add(renderContext, resource);
                        }
                    }
                }

                return resource;
            }
        }

        private const string defaultCharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890.:,;'\"(!?)+-*/=_{}[]@~#\\<>|^%$£&";

        private static FontTexture InitializeDefaultFontTexture()
        {
            Font font = SystemFonts.DefaultFont;
            FontBitmap fontBitmap = font.GetFontBitmap(defaultCharSet);
            FontTexture fontTexture = fontBitmap.GetFontTexture();
            return fontTexture;
        }


        //public FontTexture Load(string filename, string config)
        //{
        //    var result = new FontTexture();

        //    var bitmap = new Bitmap(filename);
        //    result.InitTexture(bitmap);
        //    bitmap.Dispose();

        //    XElement xElement = XElement.Load(config, LoadOptions.None);
        //    result.InitConfig(xElement);

        //    return result;
        //}

        //private void InitConfig(XElement config)
        //{
        //    this.FontHeight = int.Parse(config.Attribute(strFontHeight).Value);
        //    //this.FirstChar = (char)int.Parse(config.Attribute(strFirstChar).Value);
        //    //this.LastChar = (char)int.Parse(config.Attribute(strLastChar).Value);
        //    this.CharInfoDict = CharacterInfoDictHelper.Parse(
        //        config.Element(CharacterInfoDictHelper.strCharacterInfoDict));
        //}

    }
}
