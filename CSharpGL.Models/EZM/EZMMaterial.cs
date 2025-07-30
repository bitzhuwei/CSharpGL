using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CSharpGL {
    public unsafe class EZMMaterial {
        private static readonly string[] materialSeparator = new string[] { "diffuse=", "%20" };
        // <Material name="character_anim:eyeBallM" meta_data="diffuse=%20upBodyC.jpg%20"/>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xElement"></param>
        /// <returns></returns>
        public static EZMMaterial Parse(XElement xElement) {
            EZMMaterial result = null;
            if (xElement.Name == "Material") {
                result = new EZMMaterial();
                {
                    var name = xElement.Attribute("name");
                    if (name != null) { result.Name = name.Value; }
                }
                {
                    var meta_data = xElement.Attribute("meta_data");
                    if (meta_data != null) {
                        string value = meta_data.Value;
                        string[] parts = value.Split(materialSeparator, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length > 0) { result.MetaData = parts[0]; }
                    }
                }
            }

            return result;
        }

        public string Name { get; private set; }

        public string MetaData { get; private set; }

        public object Tag { get; set; }

        public override string ToString() {
            return string.Format("{0} {1}", this.MetaData, this.Tag);
        }
    }
}
