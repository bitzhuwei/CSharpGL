using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSLGenetator
{
    class VertexShaderFieldList : ShaderFieldList
    {
        internal static VertexShaderFieldList Parse(System.Xml.Linq.XElement xElement)
        {
            if (xElement.Name != typeof(VertexShaderFieldList).Name) { throw new Exception(); }

            return new VertexShaderFieldList();
        }

        public override object Clone()
        {
            VertexShaderFieldList list = new VertexShaderFieldList();

            return list;
        }
    }
}
