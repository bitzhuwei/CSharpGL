using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    abstract class ShaderFieldList : List<ShaderField>
    {

        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name);
        }

    }
}
