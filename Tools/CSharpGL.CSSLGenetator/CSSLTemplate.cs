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
                GenerateCSSL();
                Debug.Close();
                Debug.Listeners.Remove(listener);
            }
            {
                var fileStream = new FileStream(rendererFullname, FileMode.Create);
                var listener = new TextWriterTraceListener(fileStream);
                Debug.Listeners.Add(listener);
                GenerateRenderer();
                Debug.Close();
                Debug.Listeners.Remove(listener);
            }

            //Process.Start("explorer", "/select," + csslFullname + "," + rendererFullname);
            OpenFolderHelper.OpenFolderAndSelectFiles(directory, csslFullname, rendererFullname);
        }

        private void GenerateRenderer()
        {
            Debug.WriteLine(string.Format("namespace Renderers.{0}", this.ShaderName));
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("using CSharpGL;");
            Debug.WriteLine("using CSharpGL.Objects;");
            Debug.WriteLine("using CSharpGL.Objects.Models;");
            Debug.WriteLine("using CSharpGL.Objects.Shaders;");
            Debug.WriteLine("using CSharpGL.Objects.Textures;");
            Debug.WriteLine("using CSharpGL.Objects.VertexBuffers;");
            Debug.WriteLine("using GLM;");
            Debug.WriteLine("using System;");
            Debug.WriteLine("using System.Collections.Generic;");
            Debug.WriteLine("using System.Linq;");
            Debug.WriteLine("using System.Threading.Tasks;");
            Debug.WriteLine("");
            Debug.WriteLine("/// <summary>");
            Debug.WriteLine(string.Format("/// 一个<see cref=\"\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。", this.ShaderName + "Renderer"));
            Debug.WriteLine("/// </summary>");
            Debug.WriteLine(string.Format("public class {0} : RendererBase", this.ShaderName + "Renderer"));
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("ShaderProgram shaderProgram;");
            Debug.WriteLine("");
            Debug.WriteLine("#region VAO/VBO renderers");
            Debug.WriteLine("");
            Debug.WriteLine("VertexArrayObject vertexArrayObject;");
            Debug.WriteLine("");
            foreach (var item in this.VertexShaderFieldList)
            {
                if (item.Qualider == FieldQualifier.In)
                {
                    Debug.WriteLine(string.Format("const string str{0} = \"{0}\";", item.FieldName, item.FieldName));
                    Debug.WriteLine(string.Format("BufferRenderer {0}BufferRenderer;", item.FieldName));
                }
            }
            Debug.WriteLine("");
            Debug.WriteLine("BufferRenderer indexBufferRenderer;");
            Debug.WriteLine("");
            Debug.WriteLine("#endregion");
            Debug.WriteLine("");

            GenerateDeclaringUniforms();

            Debug.WriteLine("");
            Debug.WriteLine("public PolygonModes polygonMode = PolygonModes.Filled;");
            Debug.WriteLine("");
            Debug.WriteLine("private int elementCount;");
            Debug.WriteLine("");
            Debug.WriteLine("private IModel model;");
            Debug.WriteLine("");
            Debug.WriteLine(string.Format("public {0}(IModel model)", this.ShaderName + "Renderer"));
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("this.model = model;");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("");
            Debug.WriteLine("protected void InitializeShader(out ShaderProgram shaderProgram)");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine(string.Format("var vertexShaderSource = ManifestResourceLoader.LoadTextFile(\"{0}.vert\");", this.ShaderName));
            Debug.WriteLine(string.Format("var fragmentShaderSource = ManifestResourceLoader.LoadTextFile(\"{0}.frag\");", this.ShaderName));
            if (this.ProgramType == ShaderProgramType.VertexGeometryFragment)
            {
                Debug.WriteLine(string.Format("var geometryShaderSource = ManifestResourceLoader.LoadTextFile(\"{0}.geom\");", this.ShaderName));
            }
            Debug.WriteLine("");
            Debug.WriteLine("shaderProgram = new ShaderProgram();");
            if (this.ProgramType == ShaderProgramType.VertexGeometryFragment)
            {
                Debug.WriteLine("shaderProgram.Create(vertexShaderSource, fragmentShaderSource, geometryShaderSource);");
            }
            else
            {
                Debug.WriteLine("shaderProgram.Create(vertexShaderSource, fragmentShaderSource, null);");
            }
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("");
            Debug.WriteLine("protected void InitializeVAO()");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("IModel model = this.model;");
            GenerateSetRenderer();
            Debug.WriteLine("this.indexBufferRenderer = model.GetIndexes();");
            Debug.WriteLine("");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;");
            Debug.WriteLine("if (renderer != null)");
            Debug.WriteLine("{ this.elementCount = renderer.ElementCount; }");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;");
            Debug.WriteLine("if (renderer != null)");
            Debug.WriteLine("{ this.elementCount = renderer.VertexCount; } ");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("");
            Debug.WriteLine("protected override void DoInitialize()");
            Debug.WriteLine("{");
            Debug.WriteLine("    InitializeShader(out shaderProgram);");
            Debug.WriteLine("");
            Debug.WriteLine("    InitializeVAO();");
            Debug.WriteLine("}");
            Debug.WriteLine("");
            Debug.WriteLine("protected override void DoRender(RenderEventArgs e)");
            Debug.WriteLine("{");
            Debug.Indent();
            GenerateSetUniforms();
            Debug.WriteLine("");
            Debug.WriteLine("int[] originalPolygonMode = new int[1];");
            Debug.WriteLine("GL.GetInteger(GetTarget.PolygonMode, originalPolygonMode);");
            Debug.WriteLine("GL.PolygonMode(PolygonModeFaces.FrontAndBack, this.polygonMode);");
            Debug.WriteLine("");
            Debug.WriteLine("GL.Enable(GL.GL_PRIMITIVE_RESTART);");
            Debug.WriteLine("GL.PrimitiveRestartIndex(uint.MaxValue);");
            Debug.WriteLine("");
            Debug.WriteLine("if (this.vertexArrayObject == null)");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("var vertexArrayObject = new VertexArrayObject(");
            Debug.WriteLine("this.positionBufferRenderer,");
            Debug.WriteLine("this.indexBufferRenderer);");
            Debug.WriteLine("vertexArrayObject.Create(e, this.shaderProgram);");
            Debug.WriteLine("");
            Debug.WriteLine("this.vertexArrayObject = vertexArrayObject;");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("else");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("this.vertexArrayObject.Render(e, this.shaderProgram);");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("");
            Debug.WriteLine("GL.Disable(GL.GL_PRIMITIVE_RESTART);");
            Debug.WriteLine("");
            Debug.WriteLine("GL.PolygonMode(PolygonModeFaces.FrontAndBack, (PolygonModes)(originalPolygonMode[0]));");
            Debug.WriteLine("");
            Debug.WriteLine("// 解绑shader");
            Debug.WriteLine("program.Unbind();");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("");
            Debug.WriteLine("protected override void DisposeUnmanagedResources()");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("if (this.vertexArrayObject != null)");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("this.vertexArrayObject.Dispose();");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("");
            Debug.WriteLine("public void DecreaseVertexCount()");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;");
            Debug.WriteLine("if (renderer != null)");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("if (renderer.ElementCount > 0) { renderer.ElementCount--; }");
            Debug.WriteLine("return;");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;");
            Debug.WriteLine("if (renderer != null)");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("if (renderer.VertexCount > 0) { renderer.VertexCount--; }");
            Debug.WriteLine("return;");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("");
            Debug.WriteLine("public void IncreaseVertexCount()");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("IndexBufferRenderer renderer = this.indexBufferRenderer as IndexBufferRenderer;");
            Debug.WriteLine("if (renderer != null)");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("if (renderer.ElementCount < this.elementCount) { renderer.ElementCount++; }");
            Debug.WriteLine("return;");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("ZeroIndexBufferRenderer renderer = this.indexBufferRenderer as ZeroIndexBufferRenderer;");
            Debug.WriteLine("if (renderer != null)");
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("if (renderer.VertexCount < this.elementCount) { renderer.VertexCount++; }");
            Debug.WriteLine("return;");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
        }

        private void GenerateSetRenderer()
        {
            foreach (var item in this.VertexShaderFieldList)
            {
                if (item.Qualider == FieldQualifier.In)
                {
                    switch (item.PropertyType)
                    {
                        case PropertyType.Position:
                            Debug.WriteLine(string.Format(
                                "this.{0}BufferRenderer = model.GetPositionBufferRenderer(str{0});", item.FieldName));
                            break;
                        case PropertyType.Color:
                            Debug.WriteLine(string.Format(
                                "this.{0}BufferRenderer = model.GetColorBufferRenderer(str{0});", item.FieldName));
                            break;
                        case PropertyType.Normal:
                            Debug.WriteLine(string.Format(
                                "this.{0}BufferRenderer = model.GetNormalBufferRenderer(str{0});", item.FieldName));
                            break;
                        case PropertyType.Other:
                            Debug.WriteLine(string.Format(
                                "//this.{0}BufferRenderer = ???(str{0});", item.FieldName));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void GenerateSetUniforms()
        {
            Debug.WriteLine("ShaderProgram program = this.shaderProgram;");
            Debug.WriteLine("// 绑定shader");
            Debug.WriteLine("program.Bind();");
            var list = (from item in this.VertexShaderFieldList where item.Qualider == FieldQualifier.Uniform select item)
                                 .Union(
                                 from item in this.GeometryShaderFieldList where item.Qualider == FieldQualifier.Uniform select item)
                                 .Union(from item in this.FragmentShaderFieldList where item.Qualider == FieldQualifier.Uniform select item).Distinct();
            foreach (var item in list)
            {
                if (item.FieldType == "float")
                {
                    Debug.WriteLine(string.Format(
                        "program.SetUniform(str{0}, {0});", item.FieldName));
                }
                else if (item.FieldType == "vec2")
                {
                    Debug.WriteLine(string.Format(
                        "program.SetUniform(str{0}, {0}.x, {0}.y);", item.FieldName));
                }
                else if (item.FieldType == "vec3")
                {
                    Debug.WriteLine(string.Format(
                        "program.SetUniform(str{0}, {0}.x, {0}.y, {0}.z);", item.FieldName));
                }
                else if (item.FieldType == "vec4")
                {
                    Debug.WriteLine(string.Format(
                        "program.SetUniform(str{0}, {0}.x, {0}.y, {0}.z, {0}.w);", item.FieldName));
                }
                else if (item.FieldType == "mat2")
                {
                    Debug.WriteLine(string.Format(
                        "program.SetUniformMatrix2(str{0}, {0}.to_array());", item.FieldName));
                }
                else if (item.FieldType == "mat3")
                {
                    Debug.WriteLine(string.Format(
                        "program.SetUniformMatrix3(str{0}, {0}.to_array());", item.FieldName));
                }
                else if (item.FieldType == "mat4")
                {
                    Debug.WriteLine(string.Format(
                        "program.SetUniformMatrix4(str{0}, {0}.to_array());", item.FieldName));
                }
                
            }
        }

        private IEnumerable<ShaderField> GenerateDeclaringUniforms()
        {
            Debug.WriteLine("#region uniforms");
            Debug.WriteLine("");
            var list = (from item in this.VertexShaderFieldList where item.Qualider == FieldQualifier.Uniform select item)
                       .Union(
                       from item in this.GeometryShaderFieldList where item.Qualider == FieldQualifier.Uniform select item)
                       .Union(from item in this.FragmentShaderFieldList where item.Qualider == FieldQualifier.Uniform select item).Distinct();
            foreach (var item in list)
            {
                Debug.WriteLine(string.Format("const string str{0} = \"{0}\";", item.FieldName, item.FieldName));
                Debug.WriteLine(string.Format("public {0} {1};", item.FieldType, item.FieldName));
                Debug.WriteLine("");
            }
            Debug.WriteLine("#endregion");
            return list;
        }

        private void GenerateCSSL()
        {
            Debug.WriteLine(string.Format("namespace CSharpShadingLanguage.{0}", this.ShaderName));
            Debug.WriteLine("{");
            Debug.Indent();
            Debug.WriteLine("// 不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）");
            Debug.WriteLine("using CSharpShadingLanguage;");
            Debug.WriteLine("");
            Debug.Unindent();
            Debug.WriteLine("#if DEBUG");
            Debug.WriteLine("");
            Debug.Indent();
            GenerateStructures();
            Debug.WriteLine("");
            GenerateVertexShader();
            if (this.ProgramType == ShaderProgramType.VertexGeometryFragment)
            {
                Debug.WriteLine("");
                GenerateGeometryShader();
            }
            Debug.WriteLine("");
            GenerateFragmentShader();
            Debug.WriteLine("");
            Debug.Unindent();
            Debug.WriteLine("#endif");
            Debug.WriteLine("}");
            Debug.WriteLine("");
        }

        private void GenerateFragmentShader()
        {
            Debug.WriteLine("/// <summary>");
            Debug.WriteLine(string.Format(
                "/// 一个<see cref=\"{0}\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。",
                this.ShaderName + "Frag"));
            Debug.WriteLine("/// </summary>");
            Debug.WriteLine("[Dump2File(true)]");
            Debug.WriteLine("[GLSLVersion(GLSLVersion.v150)]");
            Debug.WriteLine(string.Format("sealed class {0} : FragmentCSShaderCode", this.ShaderName + "Frag"));
            Debug.WriteLine("{");
            Debug.Indent();
            foreach (var item in this.FragmentShaderFieldList)
            {
                Debug.WriteLine(string.Format("[{0}]", item.Qualider));
                Debug.WriteLine(string.Format("{0} {1};", item.FieldType, item.FieldName));
                Debug.WriteLine("");
            }
            Debug.WriteLine("public override void main()");
            Debug.WriteLine("{");
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
        }

        private void GenerateGeometryShader()
        {
            Debug.WriteLine("/// <summary>");
            Debug.WriteLine(string.Format(
                "/// 一个<see cref=\"{0}\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。",
                this.ShaderName + "Geom"));
            Debug.WriteLine("/// </summary>");
            Debug.WriteLine("[Dump2File(true)]");
            Debug.WriteLine("[GLSLVersion(GLSLVersion.v150)]");
            Debug.WriteLine(string.Format("sealed class {0} : GeometryCSShaderCode", this.ShaderName + "Geom"));
            Debug.WriteLine("{");
            Debug.Indent();
            foreach (var item in this.GeometryShaderFieldList)
            {
                Debug.WriteLine(string.Format("[{0}]", item.Qualider));
                Debug.WriteLine(string.Format("{0} {1};", item.FieldType, item.FieldName));
                Debug.WriteLine("");
            }
            Debug.WriteLine("public override void main()");
            Debug.WriteLine("{");
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
        }

        private void GenerateVertexShader()
        {
            Debug.WriteLine("/// <summary>");
            Debug.WriteLine(string.Format(
                "/// 一个<see cref=\"{0}\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。",
                this.ShaderName + "Vert"));
            Debug.WriteLine("/// </summary>");
            Debug.WriteLine("[Dump2File(true)]");
            Debug.WriteLine("[GLSLVersion(GLSLVersion.v150)]");
            Debug.WriteLine(string.Format("sealed class {0} : VertexCSShaderCode", this.ShaderName + "Vert"));
            Debug.WriteLine("{");
            Debug.Indent();
            foreach (var item in this.VertexShaderFieldList)
            {
                Debug.WriteLine(string.Format("[{0}]", item.Qualider));
                Debug.WriteLine(string.Format("{0} {1};", item.FieldType, item.FieldName));
                Debug.WriteLine("");
            }
            Debug.WriteLine("public override void main()");
            Debug.WriteLine("{");
            Debug.WriteLine("}");
            Debug.Unindent();
            Debug.WriteLine("}");
        }

        private void GenerateStructures()
        {
            foreach (var item in this.StrutureList)
            {
                Debug.WriteLine(string.Format("class {0}", item.Name));
                Debug.WriteLine("{");
                Debug.Indent();
                foreach (var field in item.FieldList)
                {
                    Debug.WriteLine(string.Format("public {0} {1};", field.FieldType, field.FieldName));
                }
                Debug.Unindent();
                Debug.WriteLine("}");
                Debug.WriteLine("");
            }
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
