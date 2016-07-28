using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.NewFontResource
{
    class GLFontBuilder
    {
        private System.Drawing.Font font;
        private GLFontBuilderConfiguration config;

        public GLFontBuilder(System.Drawing.Font font, GLFontBuilderConfiguration config)
        {
            // TODO: Complete member initialization
            this.font = font;
            this.config = config;
        }

        internal GLFontData BuildFontData()
        {
            throw new NotImplementedException();
        }
    }
}
