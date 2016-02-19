using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    /// <summary>
    /// 在shader间传递的结构体数据的类型
    /// in VS_GS_VERTEX { vec3 normal; } vertex_in[];
    /// </summary>
    class IntermediateStructure : ICloneable
    {

        const string strName = "Name";
        public string Name { get; set; }

        public StructureFieldList FieldList { get; set; }

        public IntermediateStructure()
        {
            this.FieldList = new StructureFieldList();
        }
        public static IntermediateStructure Parse(XElement element)
        {
            if (element.Name != typeof(IntermediateStructure).Name) { throw new NotImplementedException(); }

            IntermediateStructure result = new IntermediateStructure();
            result.Name = element.Attribute(strName).Value;
            result.FieldList = StructureFieldList.Parse(element.Element(typeof(StructureFieldList).Name));

            return result;
        }
        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name,
                new XAttribute(strName, Name),
                this.FieldList.ToXElement()
                );
        }

        public object Clone()
        {
            IntermediateStructure result = new IntermediateStructure();
            result.Name = this.Name;
            result.FieldList = this.FieldList.Clone() as StructureFieldList;

            return result;
        }
    }

}
