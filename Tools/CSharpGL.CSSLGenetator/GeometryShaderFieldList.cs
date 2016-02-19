using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSLGenetator
{
    class GeometryShaderFieldList : ShaderFieldList
    {
        internal static GeometryShaderFieldList Parse(System.Xml.Linq.XElement xElement)
        {
            if (xElement.Name != typeof(GeometryShaderFieldList).Name) { throw new Exception(); }

            return new GeometryShaderFieldList();
        }

        public override object Clone()
        {
            GeometryShaderFieldList list = new GeometryShaderFieldList();

            return list;
        }
    }
}
