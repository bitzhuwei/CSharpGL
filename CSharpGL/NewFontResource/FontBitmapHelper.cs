using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.NewFontResource
{
    /// <summary>
    /// helper class.
    /// </summary>
    public static class FontBitmapHelper
    {
        /// <summary>
        /// Gets a <see cref="FontBitmap"/>'s intance.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static FontBitmap GetFontBitmap(this Font font)
        {
            var result = new FontBitmap();
            result.font = font;
            throw new NotImplementedException();
        }
    }
}
