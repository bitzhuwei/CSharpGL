using CSharpGL;
using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RendererGenerator
{
    class RendererBuilder
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
    }
}
