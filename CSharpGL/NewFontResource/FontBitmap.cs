using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.NewFontResource
{
    /// <summary>
    /// font, bitmap and texture coordiante.
    /// </summary>
    public class FontBitmap
    {
        /// <summary>
        /// font of glyphs in <see cref="glyphBitmap"/>.
        /// </summary>
        internal Font font;
        /// <summary>
        /// bitmap in which glyphs is printed.
        /// </summary>
        internal Bitmap glyphBitmap;
        /// <summary>
        /// glyph information dictionary.
        /// </summary>
        internal FullDictionary<char, GlyphInfo> glyphInfoDictionary = new FullDictionary<char, GlyphInfo>(GlyphInfo.Default);

        internal FontBitmap() { }
    }
}
