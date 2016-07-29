using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// font, bitmap and texture coordiante.
    /// </summary>
    public partial class FontBitmap : IDisposable
    {
        /// <summary>
        /// font of glyphs in <see cref="GlyphBitmap"/>.
        /// </summary>
        public Font GlyphFont { get; internal set; }
        /// <summary>
        /// bitmap in which glyphs is printed.
        /// </summary>
        public Bitmap GlyphBitmap { get; internal set; }
        /// <summary>
        /// glyph's height.
        /// </summary>
        public float GlyphHeight { get; internal set; }
        /// <summary>
        /// glyph information dictionary.
        /// </summary>
        public FullDictionary<char, GlyphInfo> GlyphInfoDictionary { get; internal set; }

        internal FontBitmap() { this.GlyphInfoDictionary = new FullDictionary<char, GlyphInfo>(GlyphInfo.Default); }

    }
}
