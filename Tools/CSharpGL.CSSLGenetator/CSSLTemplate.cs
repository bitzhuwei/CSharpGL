using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    class CSSLTemplate
    {
        const string strShaderName = "ShaderName";
        public string ShaderName { get; set; }

        const string strProgramType = "ProgramType";
        public ShaderProgramType ProgramType { get; set; }

        public XElement ToXElement()
        {
            return new XElement(typeof(CSSLTemplate).Name,
                new XAttribute(strShaderName, ShaderName),
                new XAttribute(strProgramType, ProgramType));
        }
    }

    enum ShaderProgramType
    {
        VertexFragment,
        VertexGeometryFragment,
    }
}
