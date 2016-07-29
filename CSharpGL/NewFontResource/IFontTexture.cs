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
    public interface IFontTexture
    {
        /// <summary>
        /// Texture's id.
        /// </summary>
        uint FontTextureId { get; }

        /// <summary>
        /// font of glyphs.
        /// </summary>
        Font GlyphFont { get; }

        /// <summary>
        /// glyph's height.
        /// </summary>
        int GlyphHeight { get; }

        /// <summary>
        /// glyph information dictionary.
        /// </summary>
        FullDictionary<char, GlyphInfo> glyphInfoDictionary { get; }

        /// <summary>
        /// 
        /// </summary>
        samplerValue GetSamplerValue();

    }
}
