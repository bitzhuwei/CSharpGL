using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSLGenetator
{
    class FragmentShaderFieldList : ShaderFieldList
    {
        internal static FragmentShaderFieldList Parse(System.Xml.Linq.XElement xElement)
        {
            if (xElement.Name != typeof(FragmentShaderFieldList).Name) { throw new Exception(); }

            return new FragmentShaderFieldList();
        }
    }
}
