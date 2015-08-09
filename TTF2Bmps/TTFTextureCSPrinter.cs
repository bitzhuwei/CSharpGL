using CSharpGL.Objects.Texts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TTF2Bmps
{
    class TTFTextureCSPrinter
    {
        private CSharpGL.Objects.Texts.TTFTexture ttfTexture;
        private string strCharacterInfo = "CharacterInfo";

        public TTFTextureCSPrinter(CSharpGL.Objects.Texts.TTFTexture ttfTexture)
        {
            // TODO: Complete member initialization
            this.ttfTexture = ttfTexture;
        }


        public void Print(string fontFullname)
        {
            XElement xElement = CharacterInfoDictHelper.ToXElement(this.ttfTexture.CharInfoDict);
            xElement.Save(fontFullname + ".xml");
        }

    }
}
