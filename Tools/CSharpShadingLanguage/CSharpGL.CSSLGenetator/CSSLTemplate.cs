using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.CodeDom;
using Microsoft.CSharp;
using CSharpShadingLanguage;
using System.CodeDom.Compiler;

namespace CSharpGL.CSSLGenetator
{
    /// <summary>
    /// 生成一套CSSL+Renderer所需的所有信息都在这里。
    /// </summary>
    public class CSSLTemplate : ICloneable
    {
        const GLSLVersion defaultVersion = GLSLVersion.v150;
        const CSharpShadingLanguage.GeometryCSShaderCode.InType defaultLayoutIn = GeometryCSShaderCode.InType.triangles;
        const CSharpShadingLanguage.GeometryCSShaderCode.OutType defaultLayoutOut = GeometryCSShaderCode.OutType.triangle_strip;

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

        //TODO:生成Renderer的过程也用CodeDom重写一下吧。
        //可参考 http://www.cnblogs.com/nokiaguy/archive/2008/05/12/1193471.html
        /// <summary>
        /// 
        /// </summary>
        public string GenerateRenderer()
        {
            string directory = (new FileInfo(this.Fullname)).DirectoryName;
            var rendererFullname = Path.Combine(directory, this.ShaderName + "Renderer.cs");

            var fileStream = new FileStream(rendererFullname, FileMode.Create);
            var listener = new TextWriterTraceListener(fileStream);
            Debug.Listeners.Add(listener);
            //
            #region generate renderer
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
            Debug.WriteLine("IndexBufferRendererBase indexBufferRenderer;");
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
            Debug.WriteLine("this.indexBufferRenderer = model.GetIndexes() as IndexBufferRendererBase;");
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
            foreach (var item in this.VertexShaderFieldList)
            {
                if (item.Qualider == FieldQualifier.In)
                {
                    Debug.WriteLine(string.Format("this.{0}BufferRenderer,", item.FieldName));
                }
            }
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
            #endregion  generate renderer
            //
            Debug.Close();
            Debug.Listeners.Remove(listener);

            return rendererFullname;
        }

        public string GenerateCSSLMain()
        {
            string directory = (new FileInfo(this.Fullname)).DirectoryName;
            var csslMainFullname = Path.Combine(directory, this.ShaderName + ".main.cs");

            Debug.WriteLine("#if DEBUG");// todo: 没有对应#if 的对象？
            CodeNamespace csslNamespace = new CodeNamespace(string.Format("CSharpShadingLanguage.{0}", this.ShaderName));
            csslNamespace.Imports.Add(new CodeNamespaceImport(typeof(CSharpShadingLanguage.CSShaderCode).Namespace));
            csslNamespace.Comments.Add(new CodeCommentStatement("此文件由CSharpGL.CSSLGenerator.exe生成。"));
            csslNamespace.Comments.Add(new CodeCommentStatement("用法：使用CSSL2GLSL.exe编译此文件，即可获得对应的vertex shader, geometry shader, fragment shader。"));
            csslNamespace.Comments.Add(new CodeCommentStatement("此文件中的类型不应被直接调用，发布release时可以去掉。"));
            csslNamespace.Comments.Add(new CodeCommentStatement("不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）"));
            csslNamespace.Types.Add(GenerateVertexShaderMain());
            if (this.ProgramType == ShaderProgramType.VertexGeometryFragment)
            {
                Debug.WriteLine("");
                csslNamespace.Types.Add(GenerateGeometryShaderMain());
            }
            csslNamespace.Types.Add(GenerateFragmentShaderMain());
            Debug.WriteLine("#endif");// todo: 没有对应#if 的对象？

            using (var sw = new StreamWriter(csslMainFullname, false))
            {
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                CodeGeneratorOptions geneOptions = new CodeGeneratorOptions();//代码生成选项
                geneOptions.BlankLinesBetweenMembers = true;
                geneOptions.BracingStyle = "C";
                geneOptions.ElseOnClosing = false;
                geneOptions.IndentString = "    ";
                geneOptions.VerbatimOrder = true;

                codeProvider.GenerateCodeFromNamespace(csslNamespace, sw, geneOptions);
            }

            return csslMainFullname;
        }

        private CodeTypeDeclaration GenerateFragmentShaderMain()
        {
            CodeTypeDeclaration fragmentShaderType = new CodeTypeDeclaration(this.ShaderName + "Frag");
            fragmentShaderType.IsPartial = true;
            fragmentShaderType.BaseTypes.Add(typeof(FragmentCSShaderCode));
            fragmentShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("<summary>", true)));
            fragmentShaderType.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
              "一个<see cref=\"{0}\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。",
              this.ShaderName + "Frag"), true)));
            fragmentShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("</summary>", true)));

            CodeMemberMethod method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            method.ReturnType = new CodeTypeReference(typeof(void));
            method.Name = "main";
            fragmentShaderType.Members.Add(method);

            return fragmentShaderType;
        }

        private CodeTypeDeclaration GenerateGeometryShaderMain()
        {
            CodeTypeDeclaration geometryShaderType = new CodeTypeDeclaration(this.ShaderName + "Geom");
            geometryShaderType.IsPartial = true;
            geometryShaderType.BaseTypes.Add(typeof(GeometryCSShaderCode));
            geometryShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("<summary>", true)));
            geometryShaderType.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
              "一个<see cref=\"{0}\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。",
              this.ShaderName + "Geom"), true)));
            geometryShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("</summary>", true)));

            CodeMemberMethod method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            method.ReturnType = new CodeTypeReference(typeof(void));
            method.Name = "main";
            geometryShaderType.Members.Add(method);

            return geometryShaderType;
        }

        private CodeTypeDeclaration GenerateVertexShaderMain()
        {
            CodeTypeDeclaration vertexShaderType = new CodeTypeDeclaration(this.ShaderName + "Vert");
            vertexShaderType.IsPartial = true;
            vertexShaderType.BaseTypes.Add(typeof(VertexCSShaderCode));
            vertexShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("<summary>", true)));
            vertexShaderType.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
                "一个<see cref=\"{0}\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。",
                this.ShaderName + "Vert"), true)));
            vertexShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("</summary>", true)));

            CodeMemberMethod method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Public | MemberAttributes.Override;
            method.ReturnType = new CodeTypeReference(typeof(void));
            method.Name = "main";
            vertexShaderType.Members.Add(method);

            return vertexShaderType;
        }

        public string GenerateCSSL()
        {
            string directory = (new FileInfo(this.Fullname)).DirectoryName;
            var csslFullname = Path.Combine(directory, this.ShaderName + ".cssl.cs");

            Debug.WriteLine("#if DEBUG");// todo: 没有对应#if 的对象？
            CodeNamespace csslNamespace = new CodeNamespace(string.Format("CSharpShadingLanguage.{0}", this.ShaderName));
            csslNamespace.Imports.Add(new CodeNamespaceImport(typeof(CSharpShadingLanguage.CSShaderCode).Namespace));
            csslNamespace.Comments.Add(new CodeCommentStatement("此文件由CSharpGL.CSSLGenerator.exe生成。"));
            csslNamespace.Comments.Add(new CodeCommentStatement("用法：使用CSSL2GLSL.exe编译此文件，即可获得对应的vertex shader, geometry shader, fragment shader。"));
            csslNamespace.Comments.Add(new CodeCommentStatement("此文件中的类型不应被直接调用，发布release时可以去掉。"));
            csslNamespace.Comments.Add(new CodeCommentStatement("不可将此文件中的代码复制到其他文件内（如果包含了其他的using ...;，那么CSSL2GLSL.exe就无法正常编译这些代码了。）"));
            csslNamespace.Types.AddRange(GenerateStructures());
            csslNamespace.Types.Add(GenerateVertexShader());
            if (this.ProgramType == ShaderProgramType.VertexGeometryFragment)
            {
                Debug.WriteLine("");
                csslNamespace.Types.Add(GenerateGeometryShader());
            }
            csslNamespace.Types.Add(GenerateFragmentShader());
            Debug.WriteLine("#endif");// todo: 没有对应#if 的对象？

            using (var sw = new StreamWriter(csslFullname, false))
            {
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                CodeGeneratorOptions geneOptions = new CodeGeneratorOptions();//代码生成选项
                geneOptions.BlankLinesBetweenMembers = true;
                geneOptions.BracingStyle = "C";
                geneOptions.ElseOnClosing = false;
                geneOptions.IndentString = "    ";
                geneOptions.VerbatimOrder = true;

                codeProvider.GenerateCodeFromNamespace(csslNamespace, sw, geneOptions);
            }

            return csslFullname;
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

        private CodeTypeDeclaration GenerateFragmentShader()
        {
            CodeTypeDeclaration fragmentShaderType = new CodeTypeDeclaration(this.ShaderName + "Frag");
            fragmentShaderType.IsPartial = true;
            fragmentShaderType.BaseTypes.Add(typeof(FragmentCSShaderCode));
            fragmentShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("<summary>", true)));
            fragmentShaderType.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
              "一个<see cref=\"{0}\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。",
              this.ShaderName + "Frag"), true)));
            fragmentShaderType.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
                "(GLSLVersion){0} is GLSLVersion.{1}", (uint)defaultVersion, defaultVersion), true)));
            fragmentShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("</summary>", true)));
            fragmentShaderType.CustomAttributes.Add(new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(Dump2FileAttribute)), new CodeAttributeArgument(
                    new CodePrimitiveExpression(true))));
            var codeVersionAttribute = new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(GLSLVersionAttribute)),
                    new CodeAttributeArgument(
                        new CodeCastExpression(typeof(GLSLVersion), new CodePrimitiveExpression((uint)defaultVersion))));
            fragmentShaderType.CustomAttributes.Add(codeVersionAttribute);

            foreach (var item in this.FragmentShaderFieldList)
            {
                CodeMemberField fieldCode = GetCodeMemberField(item);
                fieldCode.CustomAttributes.Add(new CodeAttributeDeclaration(
                    new CodeTypeReference(item.Qualider.GetAttributeType())));
                fragmentShaderType.Members.Add(fieldCode);
            }

            return fragmentShaderType;
        }

        private CodeTypeDeclaration GenerateGeometryShader()
        {
            CodeTypeDeclaration geometryShaderType = new CodeTypeDeclaration(this.ShaderName + "Geom");
            geometryShaderType.IsPartial = true;
            geometryShaderType.BaseTypes.Add(typeof(GeometryCSShaderCode));
            geometryShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("<summary>", true)));
            geometryShaderType.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
              "一个<see cref=\"{0}\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。",
              this.ShaderName + "Geom"), true)));
            geometryShaderType.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
                "(GLSLVersion){0} is GLSLVersion.{1}", (uint)defaultVersion, defaultVersion), true)));
            geometryShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("</summary>", true)));
            geometryShaderType.CustomAttributes.Add(new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(Dump2FileAttribute)), new CodeAttributeArgument(
                    new CodePrimitiveExpression(true))));
            var codeVersionAttribute = new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(GLSLVersionAttribute)),
                    new CodeAttributeArgument(
                        new CodeCastExpression(typeof(GLSLVersion), new CodePrimitiveExpression((uint)defaultVersion))));
            geometryShaderType.CustomAttributes.Add(codeVersionAttribute);

            {
                var layoutInProperty = new CodeMemberProperty();
                layoutInProperty.Attributes = MemberAttributes.Public | MemberAttributes.Override;
                layoutInProperty.Type = new CodeTypeReference(typeof(GeometryCSShaderCode.InType));
                layoutInProperty.Name = "LayoutIn";
                layoutInProperty.HasGet = true;
                layoutInProperty.HasSet = false;
                layoutInProperty.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeCastExpression(typeof(GeometryCSShaderCode.InType), new CodePrimitiveExpression((uint)defaultLayoutIn))));
                layoutInProperty.Comments.Add(new CodeCommentStatement(new CodeComment("<summary>", true)));
                layoutInProperty.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
                    "(InType){0} is InType.{1}", (uint)defaultLayoutIn, defaultLayoutIn), true)));
                layoutInProperty.Comments.Add(new CodeCommentStatement(new CodeComment("</summary>", true)));
                geometryShaderType.Members.Add(layoutInProperty);
            }

            {
                var layoutOutProperty = new CodeMemberProperty();
                layoutOutProperty.Attributes = MemberAttributes.Public | MemberAttributes.Override;
                layoutOutProperty.Type = new CodeTypeReference(typeof(GeometryCSShaderCode.OutType));
                layoutOutProperty.Name = "LayoutOut";
                layoutOutProperty.HasGet = true;
                layoutOutProperty.HasSet = false;
                layoutOutProperty.GetStatements.Add(new CodeMethodReturnStatement(
                    new CodeCastExpression(typeof(GeometryCSShaderCode.OutType), new CodePrimitiveExpression((uint)defaultLayoutOut))));
                layoutOutProperty.Comments.Add(new CodeCommentStatement(new CodeComment("<summary>", true)));
                layoutOutProperty.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
                    "(OutType){0} is OutType.{1}", (uint)defaultLayoutOut, defaultLayoutOut), true)));
                layoutOutProperty.Comments.Add(new CodeCommentStatement(new CodeComment("</summary>", true)));
                geometryShaderType.Members.Add(layoutOutProperty);
            }

            {
                var max_verticesProperty = new CodeMemberProperty();
                max_verticesProperty.Attributes = MemberAttributes.Public | MemberAttributes.Override;
                max_verticesProperty.Type = new CodeTypeReference(typeof(int));
                max_verticesProperty.Name = "max_vertices";
                max_verticesProperty.HasGet = true;
                max_verticesProperty.HasSet = false;
                max_verticesProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodePrimitiveExpression(100)));
                geometryShaderType.Members.Add(max_verticesProperty);
            }

            foreach (var item in this.GeometryShaderFieldList)
            {
                CodeMemberField fieldCode = GetCodeMemberField(item);
                fieldCode.CustomAttributes.Add(new CodeAttributeDeclaration(
                    new CodeTypeReference(item.Qualider.GetAttributeType())));
                geometryShaderType.Members.Add(fieldCode);
            }

            return geometryShaderType;
        }

        private CodeTypeDeclaration GenerateVertexShader()
        {
            CodeTypeDeclaration vertexShaderType = new CodeTypeDeclaration(this.ShaderName + "Vert");
            vertexShaderType.IsPartial = true;
            vertexShaderType.BaseTypes.Add(typeof(VertexCSShaderCode));
            vertexShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("<summary>", true)));
            vertexShaderType.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
                "一个<see cref=\"{0}\"/>对应一个(vertex shader+fragment shader+..shader)组成的shader program。",
                this.ShaderName + "Vert"), true)));
            vertexShaderType.Comments.Add(new CodeCommentStatement(new CodeComment(string.Format(
                "(GLSLVersion){0} is GLSLVersion.{1}", (uint)defaultVersion, defaultVersion), true)));
            vertexShaderType.Comments.Add(new CodeCommentStatement(new CodeComment("</summary>", true)));
            var dump2FileAttrArg = new CodeAttributeArgument();
            vertexShaderType.CustomAttributes.Add(new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(Dump2FileAttribute)), new CodeAttributeArgument(
                    new CodePrimitiveExpression(true))));
            var codeVersionAttribute = new CodeAttributeDeclaration(
                new CodeTypeReference(typeof(GLSLVersionAttribute)),
                    new CodeAttributeArgument(
                        new CodeCastExpression(typeof(GLSLVersion), new CodePrimitiveExpression((uint)defaultVersion))));
            vertexShaderType.CustomAttributes.Add(codeVersionAttribute);

            foreach (var item in this.VertexShaderFieldList)
            {
                CodeMemberField fieldCode = GetCodeMemberField(item);
                fieldCode.CustomAttributes.Add(new CodeAttributeDeclaration(
                    new CodeTypeReference(item.Qualider.GetAttributeType())));
                vertexShaderType.Members.Add(fieldCode);
            }

            return vertexShaderType;
        }

        static readonly Dictionary<string, Type> primitiveDict = new Dictionary<string, Type>();

        static CSSLTemplate()
        {
            primitiveDict.Add("float", typeof(float));
            primitiveDict.Add("int", typeof(int));
            primitiveDict.Add("bool", typeof(bool));
        }
        private CodeMemberField GetCodeMemberField(ShaderField shaderField)
        {
            CodeMemberField result = null;
            Type type = null;
            if (primitiveDict.TryGetValue(shaderField.FieldType, out type))
            {
                result = new CodeMemberField(type, shaderField.FieldName);
            }
            else
            {
                result = new CodeMemberField(shaderField.FieldType, shaderField.FieldName);
            }

            return result;
        }

        private CodeTypeDeclarationCollection GenerateStructures()
        {
            CodeTypeDeclarationCollection collection = new CodeTypeDeclarationCollection();
            //todo:
            foreach (var item in this.StrutureList)
            {
                CodeTypeDeclaration codeType = new CodeTypeDeclaration(item.Name);
                codeType.IsClass = true;
                foreach (var field in item.FieldList)
                {
                    CodeMemberField member = GetCodeMemberField(field);
                    codeType.Members.Add(member);
                }
                collection.Add(codeType);
            }

            return collection;
        }

        private CodeMemberField GetCodeMemberField(StructureField structureField)
        {
            CodeMemberField result = null;
            Type type = null;
            if (primitiveDict.TryGetValue(structureField.FieldType, out type))
            {
                result = new CodeMemberField(type, structureField.FieldName);
            }
            else
            {
                result = new CodeMemberField(structureField.FieldType, structureField.FieldName);
            }

            return result;
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
