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
    public class CSSLTemplate : ICloneable
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
        public IntermediateStructureList StrutureList { get; set; }

        public CSSLTemplate()
        {
            this.ShaderName = "SomeShader";
            this.ProgramType = ShaderProgramType.VertexFragment;
            this.VertexShaderFieldList = new VertexShaderFieldList();
            this.GeometryShaderFieldList = new GeometryShaderFieldList();
            this.FragmentShaderFieldList = new FragmentShaderFieldList();
            this.StrutureList = new IntermediateStructureList();
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
            result.StrutureList = IntermediateStructureList.Parse(element.Element(typeof(IntermediateStructureList).Name));

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
            result.StrutureList = this.StrutureList.Clone() as IntermediateStructureList;

            return result;
        }


        public void Generate()
        {
            string directory = (new FileInfo(this.Fullname)).DirectoryName;
            var csslFullname = Path.Combine(directory, this.ShaderName + ".cssl.cs");
            var rendererFullname = Path.Combine(directory, this.ShaderName + "Renderer.cs");

            {
                var fileStream = new FileStream(csslFullname, FileMode.Create);
                var listener = new TextWriterTraceListener(fileStream);
                Debug.Listeners.Add(listener);
                Debug.WriteLine("// hello cssl template.");
                Debug.Close();
                Debug.Listeners.Remove(listener);
            }
            {
                var fileStream = new FileStream(rendererFullname, FileMode.Create);
                var listener = new TextWriterTraceListener(fileStream);
                Debug.Listeners.Add(listener);
                Debug.WriteLine("// hello cssl template renderer.");
                Debug.Close();
                Debug.Listeners.Remove(listener);
            }

            //Process.Start("explorer", "/select," + csslFullname + "," + rendererFullname);
            OpenFolderHelper.OpenFolderAndSelectFiles(directory, csslFullname, rendererFullname);
        }

        internal IEnumerable<IntermediateStructure> GetAllIntermediateStructures()
        {
            foreach (var item in BuildInFieldTypeHelper.GetBuildInTypeList())
            {
                yield return item;
            }

            foreach (var item in this.StrutureList)
            {
                yield return item;
            }
        }
    }

    public enum ShaderProgramType
    {
        VertexFragment,
        VertexGeometryFragment,
    }
}
