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
    public partial class FontTexture
    {

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
                FullDictionary<char, GlyphInfo> dict = this.GlyphInfoDictionary;
                this.GlyphInfoDictionary = null;
                if (dict != null)
                {
                    dict.Clear();
                }
                Font font = this.GlyphFont;
                this.GlyphFont = null;
                if (font != null)
                {
                    font.Dispose();
                }
                var ids = new uint[] { this.FontTextureId, };
                OpenGL.DeleteTextures(ids.Length, ids);
            }

            this.disposedValue = true;
        }

    }
}
