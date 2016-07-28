using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.NewFontResource
{
    /// <summary>
    /// font, texture and texture coordiante.
    /// </summary>
    public class FontTexture
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
        /// <summary>
        /// 
        /// </summary>
        public samplerValue GetSamplerValue()
        {
            return new samplerValue(
                BindTextureTarget.Texture2D,
                this.FontTextureId,
                OpenGL.GL_TEXTURE0);
        }

        /// <summary>
        /// 含有各个字形的贴图的Id。
        /// </summary>
        public uint FontTextureId { get; private set; }

    }
}
