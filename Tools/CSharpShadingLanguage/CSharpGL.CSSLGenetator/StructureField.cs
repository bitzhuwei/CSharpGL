using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    public class StructureField : ICloneable
    {
        const string strFieldType = "FieldType";
        public string FieldType { get; set; }

        const string strFieldName = "FieldName";
        public string FieldName { get; set; }

        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name,
                new XAttribute(strFieldType, this.FieldType),
                new XAttribute(strFieldName, this.FieldName)
                );
        }

        internal static StructureField Parse(XElement xElement)
        {
            if (xElement.Name != typeof(StructureField).Name) { throw new Exception(); }

            StructureField result = new StructureField();
            result.FieldType = xElement.Attribute(strFieldType).Value;
            result.FieldName = xElement.Attribute(strFieldName).Value;

            return result;
        }

        public object Clone()
        {
            StructureField list = new StructureField();
            list.FieldType = this.FieldType;
            list.FieldName = this.FieldName;

            return list;
        }

        public override string ToString()
        {
            return string.Format("public {0} {1};", FieldType, FieldName);
        }
    }
}
