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
    public sealed partial class FontResource
    {
        private static readonly object synObj = new object();
        private static readonly Dictionary<IntPtr, FontResource> dict = new Dictionary<IntPtr, FontResource>();

        private FontResource() { }

        /// <summary>
        /// Default FontResource instance for this render context.
        /// </summary>
        public static FontResource Default
        {
            get
            {
                IntPtr renderContext = Win32.wglGetCurrentContext();
                FontResource resource;
                if (!dict.TryGetValue(renderContext, out resource))
                {
                    lock (synObj)
                    {
                        if (!dict.TryGetValue(renderContext, out resource))
                        {
                            resource = InitializeDefaultFontResource();
                            dict.Add(renderContext, resource);
                        }
                    }
                }

                return resource;
            }
        }

        private static FontResource InitializeDefaultFontResource()
        {
            Bitmap glyphBitmap;
            FullDictionary<char, GlyphInfo> glyphDict;
            const int pixelSize = 64;
            if (FontResource.defaultGlyphBitmap == null)
            {
                var builder = new StringBuilder();
                for (int i = 32; i < 127; i++)
                {
                    builder.Append((char)i);
                }
                string targets = builder.ToString();
                GetGlyphInfo(out glyphBitmap, out glyphDict, pixelSize, targets);
                FontResource.defaultGlyphBitmap = glyphBitmap;
                FontResource.defaultGlyphDict = glyphDict;
            }
            else
            {
                glyphBitmap = FontResource.defaultGlyphBitmap;
                glyphDict = FontResource.defaultGlyphDict;
            }

            var fontResource = new FontResource();
            fontResource.FontHeight = pixelSize + yInterval;
            fontResource.CharInfoDict = defaultGlyphDict;
            fontResource.InitTexture(glyphBitmap);

            return fontResource;
        }


        //public FontResource Load(string filename, string config)
        //{
        //    var result = new FontResource();

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
