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
    public class FontTexture : IDisposable
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


        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        ~FontTexture()
        {
            this.Dispose(false);
        }

        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (this.disposedValue == false)
            {
                if (disposing)
                {
                    // Dispose managed resources.

                }

                // Dispose unmanaged resources.
                var ids = new uint[] { FontTextureId, };
                OpenGL.DeleteTextures(ids.Length, ids);
            }

            this.disposedValue = true;
        }
    }
}
