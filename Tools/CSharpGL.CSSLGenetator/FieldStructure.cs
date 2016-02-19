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
    class FieldStructure : ICloneable
    {

        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name);
        }

        public object Clone()
        {
            FieldStructure result = new FieldStructure();

            return result;
        }
    }
}
