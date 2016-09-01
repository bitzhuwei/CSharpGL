using System;

namespace CSharpGL.CSSLGenetator
{
    public class FragmentShaderFieldList : ShaderFieldList
    {
        internal static FragmentShaderFieldList Parse(System.Xml.Linq.XElement xElement)
        {
            if (xElement.Name != typeof(FragmentShaderFieldList).Name) { throw new Exception(); }

            var result = new FragmentShaderFieldList();
            foreach (var item in xElement.Elements(typeof(ShaderField).Name))
            {
                result.Add(ShaderField.Parse(item));
            }

            return result;
        }

        public override object Clone()
        {
            FragmentShaderFieldList list = new FragmentShaderFieldList();
            foreach (var item in this)
            {
                list.Add(item.Clone() as ShaderField);
            }

            return list;
        }
    }
}