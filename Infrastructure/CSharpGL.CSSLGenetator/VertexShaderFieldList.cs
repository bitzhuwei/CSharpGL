using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.CSSLGenetator
{
    public class VertexShaderFieldList : ShaderFieldList
    {
        internal static VertexShaderFieldList Parse(System.Xml.Linq.XElement xElement)
        {
            if (xElement.Name != typeof(VertexShaderFieldList).Name) { throw new Exception(); }

            var result = new VertexShaderFieldList();
            foreach (var item in xElement.Elements(typeof(ShaderField).Name))
            {
                result.Add(ShaderField.Parse(item));
            }

            return result;
        }



        public override object Clone()
        {
            VertexShaderFieldList list = new VertexShaderFieldList();
            foreach (var item in this)
            {
                list.Add(item.Clone() as ShaderField);
            }

            return list;
        }
    }
}
