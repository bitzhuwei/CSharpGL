using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace CSharpGL.NewFontResource
{
    /// <summary>
    /// font, bitmap and texture coordiante.
    /// </summary>
    public class FontBitmap
    {
        private Font font;
        private GLFontBuilderConfiguration config;

        public FontBitmap(Font font, GLFontBuilderConfiguration config)
        {
            // TODO: Complete member initialization
            this.font = font;
            this.config = config;
        }
    }
}
