using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    class CSSLTemplate : ICloneable
    {
        const string strExtentsion = "xml";
        public string Fullname { get; set; }

        const string strShaderName = "ShaderName";
        public string ShaderName { get; set; }

        const string strProgramType = "ProgramType";
        public ShaderProgramType ProgramType { get; set; }

        public ShaderFieldList VertexShaderFieldList { get; set; }
        public ShaderFieldList GeometryShaderFieldList { get; set; }
        public ShaderFieldList FragmentShaderFieldList { get; set; }

        public XElement ToXElement()
        {
            return new XElement(typeof(CSSLTemplate).Name,
                new XAttribute(strShaderName, ShaderName),
                new XAttribute(strProgramType, ProgramType));
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(this.Fullname)) { throw new Exception("file name not specified"); }

            if (this.Fullname.ToLower().EndsWith("." + strExtentsion))
            {
                this.Fullname += "." + strExtentsion;
            }

            this.ToXElement().Save(this.Fullname);
        }

        internal static CSSLTemplate Load(string p)
        {
            throw new NotImplementedException();
        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }
    }

    enum ShaderProgramType
    {
        VertexFragment,
        VertexGeometryFragment,
    }
}
