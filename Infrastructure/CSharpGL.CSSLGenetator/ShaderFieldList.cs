using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    public abstract class ShaderFieldList : List<ShaderField>, ICloneable
    {
        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name,
                from item in this
                select item.ToXElement()
                );
        }

        public abstract object Clone();
    }
}