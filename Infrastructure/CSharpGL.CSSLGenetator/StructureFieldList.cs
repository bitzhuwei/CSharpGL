using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    public class StructureFieldList : List<StructureField>, ICloneable
    {
        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name,
                from item in this
                select item.ToXElement()
                    );
        }

        internal static StructureFieldList Parse(XElement xElement)
        {
            if (xElement.Name != typeof(StructureFieldList).Name) { throw new Exception(); }

            StructureFieldList list = new StructureFieldList();
            foreach (var item in xElement.Elements(typeof(StructureField).Name))
            {
                list.Add(StructureField.Parse(item));
            }

            return list;
        }

        public object Clone()
        {
            StructureFieldList list = new StructureFieldList();
            foreach (var item in this)
            {
                list.Add(item.Clone() as StructureField);
            }

            return list;
        }
    }
}