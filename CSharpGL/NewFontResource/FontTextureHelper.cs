using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.NewFontResource
{
    /// <summary>
    /// helper class.
    /// </summary>
    public static class FontTextureHelper
    {
        /// <summary>
        /// Gets an instance of <see cref="FontTexture"/>.
        /// </summary>
        /// <param name="fontBitmap"></param>
        /// <returns></returns>
        public static FontTexture GetFontTexture(this FontBitmap fontBitmap)
        {
            var result = new FontTexture(fontBitmap.font, fontBitmap.glyphInfoDictionary);
            result.Initialize(fontBitmap.glyphBitmap);
            return result;
        }
    }
}
