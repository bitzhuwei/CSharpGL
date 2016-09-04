using CSharpGL;
using Microsoft.CSharp;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace RendererGenerator
{
    internal class RendererBuilder
    {
        public string GetFilename(DataStructure dataStructure)
        {
            return string.Format("{0}.cs", dataStructure.RendererName);
        }

        public void Build(DataStructure dataStructure, string rendererFilename = "")
        {
            if (string.IsNullOrEmpty(rendererFilename)) { rendererFilename = this.GetFilename(dataStructure); }

            var rendererType = new CodeTypeDeclaration(dataStructure.RendererName);
            rendererType.IsClass = true;
            rendererType.IsPartial = true;
            rendererType.BaseTypes.Add(typeof(Renderer));
            rendererType.Comments.Add(new CodeCommentStatement("<summary>", true));
            rendererType.Comments.Add(new CodeCommentStatement(string.Format("Renderer of {0}", dataStructure.TargetName), true));
            rendererType.Comments.Add(new CodeCommentStatement("</summary>", true));
            BuildCreate(rendererType, dataStructure);
            BuildConstructor(rendererType, dataStructure);
            BuildDoInitialize(rendererType, dataStructure);
            BuildDoRender(rendererType, dataStructure);

            var parserNamespace = new CodeNamespace("CSharpGL");
            parserNamespace.Imports.Add(new CodeNamespaceImport(typeof(System.Object).Namespace));
            parserNamespace.Imports.Add(new CodeNamespaceImport(typeof(System.Collections.Generic.List<int>).Namespace));
            parserNamespace.Types.Add(rendererType);

            //生成代码
            using (var stream = new StreamWriter(rendererFilename, false))
            {
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                CodeGeneratorOptions opentions = new CodeGeneratorOptions();//代码生成选项
                opentions.BlankLinesBetweenMembers = true;
                opentions.BracingStyle = "C";
                opentions.ElseOnClosing = false;
                opentions.IndentString = "    ";
                opentions.VerbatimOrder = true;

                codeProvider.GenerateCodeFromNamespace(parserNamespace, stream, opentions);
            }
        }

        private void BuildDoRender(CodeTypeDeclaration rendererType, DataStructure dataStructure)
        {
            //throw new NotImplementedException();
            var method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Family | MemberAttributes.Override;
            method.Name = "DoRender";
            const string arg = "arg";
            method.Parameters.Add(new CodeParameterDeclarationExpression(typeof(RenderEventArgs), arg));
            method.Statements.Add(new CodeCommentStatement("mat4 projection = arg.Camera.GetProjectionMatrix();"));
            method.Statements.Add(new CodeCommentStatement("mat4 view = arg.Camera.GetViewMatrix();"));
            method.Statements.Add(new CodeCommentStatement("mat4 model = this.GetModelMatrix();"));
            method.Statements.Add(new CodeCommentStatement("this.SetUniform(\"projectionMatrix\", projection);"));
            method.Statements.Add(new CodeCommentStatement("this.SetUniform(\"viewMatrix\", view);"));
            method.Statements.Add(new CodeCommentStatement("this.SetUniform(\"modelMatrix\", model);"));

            method.Statements.Add(new CodeSnippetStatement(string.Format("            base.DoRender(arg);")));

            rendererType.Members.Add(method);
        }

        private void BuildDoInitialize(CodeTypeDeclaration rendererType, DataStructure dataStructure)
        {
            //throw new NotImplementedException();
        }

        private void BuildConstructor(CodeTypeDeclaration rendererType, DataStructure dataStructure)
        {
            //throw new NotImplementedException();
            var method = new CodeConstructor();
            method.Attributes = MemberAttributes.Private;
            method.Name = dataStructure.RendererName;
            var bufferable = new CodeParameterDeclarationExpression(typeof(IBufferable), "bufferable");
            method.Parameters.Add(bufferable);
            var shaderCode = new CodeParameterDeclarationExpression(typeof(ShaderCode[]), shaderCodes);
            method.Parameters.Add(shaderCode);
            var map = new CodeParameterDeclarationExpression(typeof(PropertyNameMap), "propertyNameMap");
            method.Parameters.Add(map);
            var last = new CodeParameterDeclarationExpression(new CodeTypeReference(string.Format("params {0}[]", typeof(GLSwitch).Name)), "switches");
            method.Parameters.Add(last);
            method.BaseConstructorArgs.Add(new CodeVariableReferenceExpression("bufferable"));
            method.BaseConstructorArgs.Add(new CodeVariableReferenceExpression(shaderCodes));
            method.BaseConstructorArgs.Add(new CodeVariableReferenceExpression("propertyNameMap"));
            method.BaseConstructorArgs.Add(new CodeVariableReferenceExpression("switches"));

            rendererType.Members.Add(method);
        }

        private void BuildCreate(CodeTypeDeclaration rendererType, DataStructure dataStructure)
        {
            CodeMemberMethod method = CreateDeclaration(dataStructure);
            CreateBody(method, dataStructure);
            rendererType.Members.Add(method);
        }

        private void CreateBody(CodeMemberMethod method, DataStructure dataStructure)
        {
            {
                // var shaderCodes = new ShaderCode[2];
                method.Statements.Add(new CodeSnippetStatement(string.Format("            var {0} = new {1}[2];", shaderCodes, typeof(ShaderCode).Name)));
                method.Statements.Add(new CodeSnippetStatement(string.Format("            {0}[0] = new {1}(File.ReadAllText(@\"shaders\\{2}.vert\"), {3}.{4});", shaderCodes, typeof(ShaderCode).Name, dataStructure.TargetName, ShaderType.VertexShader.GetType().Name, ShaderType.VertexShader)));
                method.Statements.Add(new CodeSnippetStatement(string.Format("            {0}[1] = new {1}(File.ReadAllText(@\"shaders\\{2}.frag\"), {3}.{4});", shaderCodes, typeof(ShaderCode).Name, dataStructure.TargetName, ShaderType.VertexShader.GetType().Name, ShaderType.FragmentShader)));
            }
            {
                // var map = new PropertyNameMap();
                method.Statements.Add(new CodeVariableDeclarationStatement("var", "map",
                    new CodeObjectCreateExpression(typeof(PropertyNameMap))));
                // map.Add("in_Position", GroundModel.strPosition);
                foreach (var item in dataStructure.PropertyList)
                {
                    method.Statements.Add(new CodeMethodInvokeExpression(
                        new CodeVariableReferenceExpression("map"), "Add",
                        new CodePrimitiveExpression(item.NameInShader),
                        new CodeSnippetExpression(string.Format("{0}.{1}",
                            dataStructure.ModelName, item.NameInModel))));
                }
            }
            const string renderer = "renderer";
            {
                // var renderer = new GroundRenderer(model, shaderCodes, map);
                method.Statements.Add(new CodeSnippetStatement(string.Format("            var {0} = new {1}({2}, {3}, map);", renderer, dataStructure.RendererName, model, shaderCodes)));
            }
            {
                // setup renderer's Lengths, WorldPosition etc.
                method.Comments.Add(new CodeCommentStatement(string.Format("renderer.Lengths = ...")));
                method.Comments.Add(new CodeCommentStatement(string.Format("renderer.WorldPosition = ...")));
            }
            {
                // return renderer;
                method.Statements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(renderer)));
            }
        }

        private CodeMemberMethod CreateDeclaration(DataStructure dataStructure)
        {
            var method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Public | MemberAttributes.Static;
            method.ReturnType = new CodeTypeReference(dataStructure.RendererName);
            method.Name = "Create";
            var parameter0 = new CodeParameterDeclarationExpression(dataStructure.ModelName, model);
            method.Parameters.Add(parameter0);
            method.Comments.Add(new CodeCommentStatement(string.Format("you can replace {0} with {1} in the method's parameter.", dataStructure.ModelName, typeof(IBufferable).Name)));

            return method;
        }

        private const string model = "model";
        private const string shaderCodes = "shaderCodes";
    }
}