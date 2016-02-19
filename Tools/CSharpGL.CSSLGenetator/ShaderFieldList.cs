using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    abstract class ShaderFieldList : List<ShaderField>, ICloneable
    {

        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name);
        }


        public abstract object Clone();
    }
}
