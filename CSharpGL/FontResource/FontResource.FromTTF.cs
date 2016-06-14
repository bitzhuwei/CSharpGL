using SharpFont;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Linq;

namespace CSharpGL
{
    /// <summary>
    /// 字形贴图及其UV。
    /// </summary>
    public sealed partial class FontResource
    {

        /// <summary>
        /// Load Font Resource from TTF/OTF file.
        /// </summary>
        /// <param name="ttfFilename">".ttf", or ".otf"</param>
        /// <param name="content">characters that should be included in font resource.</param>
        /// <param name="pixelSize">The desired size of the font, in pixels.</param>
        /// <returns></returns>
        public static FontResource Load(string ttfFilename, char[] content, int pixelSize = 32)
        {
            InitStandardWidths();

            var targets = (from item in content select item).Distinct();

            using (FileStream stream = File.OpenRead(ttfFilename))
            {
                FontResource fontResource = LoadFromSomeChars(stream, targets, pixelSize);

                return fontResource;
            }
        }

        /// <summary>
        /// Load Font Resource from TTF/OTF file.
        /// </summary>
        /// <param name="ttfFilename">".ttf", or ".otf"</param>
        /// <param name="content">characters that should be included in font resource.</param>
        /// <param name="pixelSize">The desired size of the font, in pixels.</param>
        /// <returns></returns>
        public static FontResource Load(string ttfFilename, string content, int pixelSize = 32)
        {
            InitStandardWidths();

            var targets = (from item in content select item).Distinct();

            using (FileStream stream = File.OpenRead(ttfFilename))
            {
                FontResource fontResource = LoadFromSomeChars(stream, targets, pixelSize);

                return fontResource;
            }
        }

        /// <summary>
        /// Load Font Resource from TTF/OTF file.
        /// </summary>
        /// <param name="ttfFilename">".ttf", or ".otf"</param>
        /// <param name="firstChar">first character that should be included in font resource.</param>
        /// <param name="lastChar">last character that should be included in font resource.</param>
        /// <param name="pixelSize">The desired size of the font, in pixels.</param>
        /// <returns></returns>
        public static FontResource Load(string ttfFilename, char firstChar, char lastChar, int pixelSize = 32)
        {
            var targets = new List<char>();
            for (int i = 0; i < lastChar - firstChar; i++)
            {
                targets.Add((char)(i + firstChar));
            }

            using (FileStream stream = File.OpenRead(ttfFilename))
            {
                FontResource fontResource = LoadFromSomeChars(stream, targets, pixelSize);
                return fontResource;
            }
        }

    }
}
