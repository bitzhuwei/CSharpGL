using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpGL.CSSLGenetator
{
    /// <summary>
    /// 生成一套CSSL+Renderer所需的所有信息都在这里。
    /// </summary>
    class CSSLTemplate : ICloneable
    {
        const string strExtentsion = "xml";
        public string Fullname { get; set; }

        const string strShaderName = "ShaderName";
        public string ShaderName { get; set; }

        const string strProgramType = "ProgramType";
        public ShaderProgramType ProgramType { get; set; }

        public VertexShaderFieldList VertexShaderFieldList { get; set; }
        public GeometryShaderFieldList GeometryShaderFieldList { get; set; }
        public FragmentShaderFieldList FragmentShaderFieldList { get; set; }
        public FieldStructureList StrutureList { get; set; }

        public CSSLTemplate()
        {
            this.ShaderName = "SomeShader";
            this.ProgramType = ShaderProgramType.VertexFragment;
            this.VertexShaderFieldList = new VertexShaderFieldList();
            this.GeometryShaderFieldList = new GeometryShaderFieldList();
            this.FragmentShaderFieldList = new FragmentShaderFieldList();
            this.StrutureList = new FieldStructureList();
        }

        public XElement ToXElement()
        {
            return new XElement(this.GetType().Name,
                new XAttribute(strShaderName, ShaderName),
                new XAttribute(strProgramType, ProgramType),
                this.VertexShaderFieldList.ToXElement(),
                this.GeometryShaderFieldList.ToXElement(),
                this.FragmentShaderFieldList.ToXElement(),
                this.StrutureList.ToXElement());
        }

        public void Save()
        {
            if (string.IsNullOrEmpty(this.Fullname)) { throw new Exception("file name not specified"); }

            if (!this.Fullname.ToLower().EndsWith("." + strExtentsion))
            {
                this.Fullname += "." + strExtentsion;
            }

            this.ToXElement().Save(this.Fullname);
        }

        internal static CSSLTemplate Load(string fullname)
        {
            XElement element = XElement.Load(fullname);
            if (element.Name != typeof(CSSLTemplate).Name) { throw new Exception(); }

            CSSLTemplate result = new CSSLTemplate();
            result.ShaderName = element.Attribute(strShaderName).Value;
            result.ProgramType = (ShaderProgramType)Enum.Parse(
                typeof(ShaderProgramType), element.Attribute(strProgramType).Value);
            result.VertexShaderFieldList = VertexShaderFieldList.Parse(element.Element(typeof(VertexShaderFieldList).Name));
            result.GeometryShaderFieldList = GeometryShaderFieldList.Parse(element.Element(typeof(GeometryShaderFieldList).Name));
            result.FragmentShaderFieldList = FragmentShaderFieldList.Parse(element.Element(typeof(FragmentShaderFieldList).Name));
            result.StrutureList = FieldStructureList.Parse(element.Element(typeof(FieldStructureList).Name));

            result.Fullname = fullname;

            return result;
        }

        public object Clone()
        {
            CSSLTemplate result = new CSSLTemplate();
            result.ShaderName = this.ShaderName;
            result.ProgramType = this.ProgramType;
            result.VertexShaderFieldList = this.VertexShaderFieldList.Clone() as VertexShaderFieldList;
            result.GeometryShaderFieldList = this.GeometryShaderFieldList.Clone() as GeometryShaderFieldList;
            result.FragmentShaderFieldList = this.FragmentShaderFieldList.Clone() as FragmentShaderFieldList;
            result.StrutureList = this.StrutureList.Clone() as FieldStructureList;

            return result;
        }


        public void Generate()
        {
            string directory = (new FileInfo(this.Fullname)).DirectoryName;
            {
                var listener = new TextWriterTraceListener(Path.Combine(directory, this.ShaderName + ".cssl.cs"));
                Debug.Listeners.Add(listener);

                Debug.Close();
                Debug.Listeners.Remove(listener);
            }
            {
                var listener = new TextWriterTraceListener(Path.Combine(directory, this.ShaderName + "Renderer.cs"));
                Debug.Listeners.Add(listener);

                Debug.Close();
                Debug.Listeners.Remove(listener);
            }
        }
    }

    enum ShaderProgramType
    {
        VertexFragment,
        VertexGeometryFragment,
    }
}
