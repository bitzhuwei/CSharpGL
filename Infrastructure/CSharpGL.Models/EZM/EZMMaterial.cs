using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL.EZM
{
    class EZMMaterial
    {
        // <Material name="character_anim:eyeBallM" meta_data="diffuse=%20upBodyC.jpg%20"/>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static EZMMaterial Parse(XElement xElement)
        {
            EZMMaterial result = null;
            if (xElement.Name == "Material")
            {
                result = new EZMMaterial();
                result.Name = xElement.Attribute("name").Value;
                result.MataData = xElement.Attribute("meta_data").Value;
            }

            return result;
        }

        public string Name { get; private set; }

        public string MataData { get; private set; }

    }
}
