using CSharpGL;
using Microsoft.CSharp;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace RendererGenerator
{
    internal class ModelBuilder
    {
        public string GetFilename(DataStructure dataStructure)
        {
            return string.Format("{0}.cs", dataStructure.ModelName);
        }

        public void Build(DataStructure dataStructure, string modelFilename = "")
        {
            if (string.IsNullOrEmpty(modelFilename)) { modelFilename = this.GetFilename(dataStructure); }

            // public class DemoModel : IBufferable { }
            var modelType = new CodeTypeDeclaration(dataStructure.ModelName);
            modelType.IsClass = true;
            modelType.IsPartial = true;
            modelType.BaseTypes.Add(typeof(IBufferable));
            modelType.Comments.Add(new CodeCommentStatement("<summary>", true));
            modelType.Comments.Add(new CodeCommentStatement(string.Format("Model of {0}", dataStructure.TargetName), true));
            modelType.Comments.Add(new CodeCommentStatement("</summary>", true));
            BuildFields(modelType, dataStructure);
            BuildGetProperty(modelType, dataStructure);
            BuildGetIndex(modelType, dataStructure);

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

        /// <summary>
        /// public IndexBufferPtr GetIndex()
        /// </summary>
        /// <param name="modelType"></param>
        /// <param name="dataStructure"></param>
        private void BuildGetIndex(CodeTypeDeclaration modelType, DataStructure dataStructure)
        {
            CodeMemberMethod method = GetIndexDeclaration(dataStructure);
            GetIndexBody(method, dataStructure);
            modelType.Members.Add(method);
        }

        private void GetIndexBody(CodeMemberMethod method, DataStructure dataStructure)
        {
            // if (indexBufferPtr == null)
            var ifStatement = new CodeConditionStatement(
                new CodeBinaryOperatorExpression(
                    new CodeVariableReferenceExpression(indexBufferPtr),
                    CodeBinaryOperatorType.IdentityEquality,
                    new CodePrimitiveExpression(null)));
            method.Statements.Add(ifStatement);
            if (dataStructure.ZeroIndexBuffer)
            {
                // using (var buffer = new ZeroIndexBuffer(DrawMode.LineStrip, 0, BigDipperModel.positions.Length))
                var usingBegin = new CodeSnippetStatement(string.Format("                using (var buffer = new ZeroIndexBuffer({0}.{1}, 0, ))", dataStructure.DrawMode.GetType().Name, dataStructure.DrawMode));
                ifStatement.TrueStatements.Add(usingBegin);
                ifStatement.TrueStatements.Add(new CodeSnippetStatement("                {// begin of using"));
                ifStatement.TrueStatements.Add(new CodeSnippetStatement(string.Format("                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;")));
                ifStatement.TrueStatements.Add(new CodeSnippetStatement("                }// end of using"));
            }
            else
            {
                // using (var buffer = new OneIndexBuffer<uint>(this.model.mode, BufferUsage.StaticDraw))
                var usingBegin = new CodeSnippetStatement(string.Format("                using (var buffer = new OneIndexBuffer<uint>({0}.{1}, BufferUsage.StaticDraw))", dataStructure.DrawMode.GetType().Name, dataStructure.DrawMode));
                ifStatement.TrueStatements.Add(usingBegin);
                ifStatement.TrueStatements.Add(new CodeSnippetStatement("                {// begin of using"));
                ifStatement.TrueStatements.Add(new CodeSnippetStatement("                    buffer.Create();"));
                // unsafe {
                ifStatement.TrueStatements.Add(new CodeSnippetStatement("                    unsafe"));
                ifStatement.TrueStatements.Add(new CodeSnippetStatement("                    {// begin of unsafe"));
                // var array = (uint*)buffer.Header.ToPointer();
                ifStatement.TrueStatements.Add(new CodeSnippetStatement(string.Format("                        var array = (uint*)buffer.Header.ToPointer();")));
                // array[0] =  ...;;
                ifStatement.TrueStatements.Add(new CodeSnippetStatement(string.Format("                        // TODO: set array's values: array[0] = ...;")));
                // }
                ifStatement.TrueStatements.Add(new CodeSnippetStatement("                    }// end of unsafe"));
                ifStatement.TrueStatements.Add(new CodeSnippetStatement(string.Format("                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;")));
                ifStatement.TrueStatements.Add(new CodeSnippetStatement("                }// end of using"));
            }
            method.Statements.Add(new CodeMethodReturnStatement(
                new CodeVariableReferenceExpression(indexBufferPtr)));
        }

        private CodeMemberMethod GetIndexDeclaration(DataStructure dataStructure)
        {
            var method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            method.ReturnType = new CodeTypeReference(typeof(IndexBufferPtr));
            method.Name = "GetIndex";
            return method;
        }

        /// <summary>
        /// public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        /// </summary>
        /// <param name="modelType"></param>
        /// <param name="dataStructure"></param>
        private void BuildGetProperty(CodeTypeDeclaration modelType, DataStructure dataStructure)
        {
            //public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
            var method = GetPropertyDeclaration();
            GetPropertyBody(method, dataStructure);

            modelType.Members.Add(method);
        }

        /// <summary>
        /// body of public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        /// </summary>
        /// <param name="method"></param>
        private void GetPropertyBody(CodeMemberMethod method, DataStructure dataStructure)
        {
            foreach (var item in dataStructure.PropertyList)
            {
                // if (bufferName == position)
                var ifStatement = new CodeConditionStatement(
                    new CodeBinaryOperatorExpression(
                        new CodeVariableReferenceExpression(bufferName),
                        CodeBinaryOperatorType.IdentityEquality,
                        new CodeVariableReferenceExpression(item.NameInModel)));
                method.Statements.Add(ifStatement);
                // if (positionBufferPtr != null)
                var ifStatement2 = new CodeConditionStatement(
                    new CodeBinaryOperatorExpression(
                        new CodeVariableReferenceExpression(item.BufferPtrName),
                        CodeBinaryOperatorType.IdentityEquality,
                        new CodePrimitiveExpression(null)));
                ifStatement.TrueStatements.Add(ifStatement2);
                // using (var buffer = new PropertyBuffer<vec3>(varNameInShader))
                var usingBegin = new CodeSnippetStatement(string.Format("                    using(var buffer = new PropertyBuffer<{0}>({1}))", item.PropertyType, varNameInShader));
                ifStatement2.TrueStatements.Add(usingBegin);
                ifStatement2.TrueStatements.Add(new CodeSnippetStatement("                    {// begin of using"));
                var create = new CodeSnippetStatement("                        buffer.Create();");
                ifStatement2.TrueStatements.Add(create);
                // unsafe {
                ifStatement2.TrueStatements.Add(new CodeSnippetStatement("                        unsafe"));
                ifStatement2.TrueStatements.Add(new CodeSnippetStatement("                        {// begin of unsafe"));
                // var array = (vec3*)buffer.Header.ToPointer();
                ifStatement2.TrueStatements.Add(new CodeSnippetStatement(string.Format("                            var array = ({0}*)buffer.Header.ToPointer();", item.PropertyType)));
                // array[0] =  ...;;
                ifStatement2.TrueStatements.Add(new CodeSnippetStatement(string.Format("                            // TODO: set array's values: array[0] = ...;")));
                // }
                ifStatement2.TrueStatements.Add(new CodeSnippetStatement("                        }// end of unsafe"));
                ifStatement2.TrueStatements.Add(new CodeSnippetStatement(string.Format("                        {0} = buffer.GetBufferPtr() as PropertyBufferPtr;", item.BufferPtrName)));
                ifStatement2.TrueStatements.Add(new CodeSnippetStatement("                    }// end of using"));
                ifStatement.TrueStatements.Add(new CodeMethodReturnStatement(
                    new CodeVariableReferenceExpression(item.BufferPtrName)));
            }

            // throw new NotImplementedException();
            {
                // This CodeThrowExceptionStatement throws a new System.Exception.
                var throwException = new CodeThrowExceptionStatement(
                    // codeExpression parameter indicates the exception to throw.
                    // You must use an object create expression to new an exception here.
                    new CodeObjectCreateExpression(
                    // createType parameter inidicates the type of object to create.
                    new CodeTypeReference(typeof(System.ArgumentException)),
                    // parameters parameter indicates the constructor parameters.
                    new CodeExpression[] { new CodePrimitiveExpression(bufferName) }));
                method.Statements.Add(throwException);
            }
        }

        /// <summary>
        /// public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        /// </summary>
        /// <returns></returns>
        private CodeMemberMethod GetPropertyDeclaration()
        {
            var method = new CodeMemberMethod();
            method.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            method.ReturnType = new CodeTypeReference(typeof(VertexAttributeBufferPtr));
            method.Name = "GetProperty";
            var parameter0 = new CodeParameterDeclarationExpression(typeof(string), bufferName);
            method.Parameters.Add(parameter0);
            var parameter1 = new CodeParameterDeclarationExpression(typeof(string), varNameInShader);
            method.Parameters.Add(parameter1);
            return method;
        }

        /// <summary>
        /// fields.
        /// </summary>
        /// <param name="modelType"></param>
        /// <param name="dataStructure"></param>
        private void BuildFields(CodeTypeDeclaration modelType, DataStructure dataStructure)
        {
            foreach (var item in dataStructure.PropertyList)
            {
                {
                    // public const string position = "position";
                    var constField = new CodeMemberField(typeof(string), string.Format("{0}", item.NameInModel));
                    constField.Attributes = MemberAttributes.Public | MemberAttributes.Const;
                    constField.InitExpression = new CodePrimitiveExpression(item.NameInModel);
                    modelType.Members.Add(constField);
                }
                {
                    // private PropertyBufferPtr positionBufferPtr;
                    var bufferPtrField = new CodeMemberField(typeof(VertexAttributeBufferPtr), item.BufferPtrName);
                    modelType.Members.Add(bufferPtrField);
                }
            }
            {
                // private IndexBufferPtr indexBufferPtr;
                var bufferPtrField = new CodeMemberField(typeof(IndexBufferPtr), indexBufferPtr);
                modelType.Members.Add(bufferPtrField);
            }
        }

        private const string indexBufferPtr = "indexBufferPtr";
        private const string bufferName = "bufferName";
        private const string varNameInShader = "varNameInShader";
    }
}