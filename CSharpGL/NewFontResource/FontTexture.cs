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
    public partial class FontTexture : IDisposable
    {
        /// <summary>
        /// Texture's id.
        /// </summary>
        public uint FontTextureId { get; private set; }

        /// <summary>
        /// font of glyphs.
        /// </summary>
        internal Font font;

        /// <summary>
        /// glyph information dictionary.
        /// </summary>
        internal FullDictionary<char, GlyphInfo> glyphInfoDictionary;

        internal FontTexture(Font font, FullDictionary<char, GlyphInfo> dict)
        {
            this.font = font;
            this.glyphInfoDictionary = dict;
        }

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


        internal void Initialize(TextureBuilder textureBuilder, Bitmap bitmap)
        {
            this.FontTextureId = textureBuilder.BuildTexture(bitmap);
        }

    }
}
