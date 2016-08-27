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
    public partial class FontBitmap
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
        ~FontBitmap()
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
                Bitmap bmp = this.GlyphBitmap;
                this.GlyphBitmap = null;
                if (bmp != null)
                {
                    bmp.Dispose();
                }
                //FullDictionary<char, GlyphInfo> dict = this.GlyphInfoDictionary;
                //this.GlyphInfoDictionary = null;
                //if (dict != null)
                //{
                //    dict.Clear();
                //}
                //Font font = this.GlyphFont;
                //this.GlyphFont = null;
                //if (font != null)
                //{
                //    font.Dispose();
                //}
            }

            this.disposedValue = true;
        }
    }
}
