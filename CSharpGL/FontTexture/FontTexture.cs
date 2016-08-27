using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// font, texture and texture coordiante.
    /// </summary>
    public partial class FontTexture : IFontTexture, IDisposable
    {
        /// <summary>
        /// Texture that contains all glyphs.
        /// </summary>
        public Texture TextureObj { get; internal set; }

        /// <summary>
        /// font of glyphs.
        /// </summary>
        public Font GlyphFont { get; internal set; }

        /// <summary>
        /// glyph's height.
        /// </summary>
        public float GlyphHeight { get; internal set; }

        /// <summary>
        /// texture's size.
        /// </summary>
        public Size TextureSize { get; internal set; }

        /// <summary>
        /// glyph information dictionary.
        /// </summary>
        public FullDictionary<char, GlyphInfo> GlyphInfoDictionary { get; internal set; }

        internal FontTexture() { }

    }
}
