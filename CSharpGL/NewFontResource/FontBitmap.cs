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
        private Font font;
        /// <summary>
        /// bitmap in which glyphs is printed.
        /// </summary>
        private Bitmap glyphBitmap;
        /// <summary>
        /// glyph information dictionary.
        /// </summary>
        private Dictionary<char, GlyphInfo> glyphInfoDictionary = new Dictionary<char, GlyphInfo>();

    }
}
