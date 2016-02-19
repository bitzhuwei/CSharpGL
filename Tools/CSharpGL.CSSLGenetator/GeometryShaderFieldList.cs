using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSLGenetator
{
    public class GeometryShaderFieldList : ShaderFieldList
    {
        internal static GeometryShaderFieldList Parse(System.Xml.Linq.XElement xElement)
        {
            if (xElement.Name != typeof(GeometryShaderFieldList).Name) { throw new Exception(); }

            var result = new GeometryShaderFieldList();
            foreach (var item in xElement.Elements(typeof(ShaderField).Name))
            {
                result.Add(ShaderField.Parse(item));
            }

            return result;
        }
    }
}
