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

        ///// <summary>
        ///// font of glyphs.
        ///// </summary>
        //Font GlyphFont { get; }

        /// <summary>
        /// glyph's height.
        /// </summary>
        float GlyphHeight { get; }

        /// <summary>
        /// texture's size.
        /// </summary>
        Size TextureSize { get; }

        /// <summary>
        /// glyph information dictionary.
        /// </summary>
        FullDictionary<char, GlyphInfo> GlyphInfoDictionary { get; }

        /// <summary>
        /// 
        /// </summary>
        samplerValue GetSamplerValue();

    }
}
