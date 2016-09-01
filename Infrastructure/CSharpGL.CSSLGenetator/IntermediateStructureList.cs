using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    public class IntermediateStructureList : List<IntermediateStructure>, ICloneable
    {
        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name,
                from item in this
                select item.ToXElement()
                    );
        }

        internal static IntermediateStructureList Parse(XElement xElement)
        {
            if (xElement.Name != typeof(IntermediateStructureList).Name) { throw new Exception(); }

            IntermediateStructureList list = new IntermediateStructureList();
            foreach (var item in xElement.Elements(typeof(IntermediateStructure).Name))
            {
                list.Add(IntermediateStructure.Parse(item));
            }

            return list;
        }

        public object Clone()
        {
            IntermediateStructureList list = new IntermediateStructureList();
            foreach (var item in this)
            {
                list.Add(item.Clone() as IntermediateStructure);
            }

            return list;
        }
    }
}