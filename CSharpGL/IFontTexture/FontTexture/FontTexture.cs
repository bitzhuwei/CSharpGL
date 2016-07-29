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
    public partial class FontTexture : IDisposable
    {
        /// <summary>
        /// Texture's id.
        /// </summary>
        public uint FontTextureId { get; private set; }

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
        public FullDictionary<char, GlyphInfo> glyphInfoDictionary { get; internal set; }

        internal FontTexture() { }

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
            TextureInfo textureInfo = textureBuilder.BuildTexture(bitmap);
            this.FontTextureId = textureInfo.Id;
        }

    }
}
