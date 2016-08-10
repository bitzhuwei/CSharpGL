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
    class ModelBuilder
    {

        public string GetFilename(DataStructure dataStructure)
        {
            return string.Format("{0}.cs", dataStructure.ModelName);
        }

        public void Build(DataStructure dataStructure, string modelFilename = "")
        {
            if (string.IsNullOrEmpty(modelFilename)) { modelFilename = this.GetFilename(dataStructure); }

            var modelType = new CodeTypeDeclaration(dataStructure.ModelName);
            modelType.IsClass = true;
            modelType.IsPartial = true;
            modelType.BaseTypes.Add(typeof(IBufferable));
            modelType.Comments.Add(new CodeCommentStatement("<summary>", true));
            modelType.Comments.Add(new CodeCommentStatement(string.Format("Model of {0}", dataStructure.TargetName), true));
            modelType.Comments.Add(new CodeCommentStatement("</summary>", true));

            var parserNamespace = new CodeNamespace("CSharpGL");
            parserNamespace.Imports.Add(new CodeNamespaceImport(typeof(System.Object).Namespace));
            parserNamespace.Imports.Add(new CodeNamespaceImport(typeof(System.Collections.Generic.List<int>).Namespace));
            parserNamespace.Types.Add(modelType);

            //生成代码  
            using (var stream = new StreamWriter(modelFilename, false))
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
