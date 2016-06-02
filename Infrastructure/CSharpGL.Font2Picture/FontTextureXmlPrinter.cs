using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL.Font2Picture
{
    class FontTextureXmlPrinter
    {
        private FontTexture ttfTexture;

        public FontTextureXmlPrinter(FontTexture ttfTexture)
        {
            // TODO: Complete member initialization
            this.ttfTexture = ttfTexture;
        }


        public void Print(string fontFullname)
        {
            XElement xElement = FontTextureHelper.ToXElement(this.ttfTexture);
            xElement.Save(fontFullname + ".xml");
        }

    }
}
