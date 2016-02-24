using bitzhuwei.CompilerBase;
using CSharpShadingLanguage;
using CSharpShadingLanguage.Compiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpGL.CSSL2GLSL
{
    public sealed class SemanticFragmentShader : SemanticShader
    {

        public SemanticFragmentShader(CSShaderCode shaderCode, string fullname)
            : base(shaderCode, fullname)
        {
        }

        protected override string DumpShaderCode()
        {
            StringBuilder builder = new StringBuilder();

            GLSLVersionAttribute versionAttribute = this.shaderCode.GetType().GetCustomAttribute<GLSLVersionAttribute>();
            if (versionAttribute != null)
            {
                this.Version = versionAttribute.Version;
            }
            switch (this.Version)
            {
                case GLSLVersion.v150:
                    builder.AppendLine("#version 150 core");
                    break;
                default:
                    builder.AppendLine("#version this is not implemented in CSSL2GLSL!");
                    break;
            }
            builder.AppendLine();

            foreach (var field in this.shaderCode.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                foreach (var attr in field.GetCustomAttributes<QualifierAttribute>())
                {
                    var semanticField = new SemanticField(attr, field.FieldType, field.Name, shaderCode);
                    string fieldCode = semanticField.Dump();
                    builder.AppendLine(fieldCode);
                }
            }
            builder.AppendLine();

            builder.Append(this.SearchMainFunction(fullname));
            builder.AppendLine();

            return builder.ToString();
        }

        string SearchMainFunction(string fullname)
        {
            string content = File.ReadAllText(fullname);
            var lexi = new CSharpShadingLanguage.Compiler.LexicalAnalyzerCSSLCompiler(content);
            var tokenList = lexi.Analyze();
            int classIndex, mainIndex;
            {
                // class XxxFragmentShader : FragmentCSShaderCode
                List<Token<EnumTokenTypeCSSLCompiler>> target = new List<Token<EnumTokenTypeCSSLCompiler>>();
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "class", });
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = this.shaderCode.GetType().Name, });
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.token_Colon_, Detail = ":", });
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = typeof(FragmentCSShaderCode).Name, });
                classIndex = tokenList.KMP(target, 0, TokenComparer.Instance);
                if (classIndex < 0)
                {
                    target.Clear();//CSharpShadingLanguage
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "class", });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = this.shaderCode.GetType().Name, });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.token_Colon_, Detail = ":", });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = typeof(FragmentCSShaderCode).Namespace, });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.token_Dot_, Detail = ".", });
                    target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = typeof(FragmentCSShaderCode).Name, });
                    classIndex = tokenList.KMP(target, 0, TokenComparer.Instance);
                    if (classIndex < 0) { throw new Exception(string.Format("class for {0} not found!", this.shaderCode.GetType().Name)); }
                }
            }
            {
                // public override void main() { }
                List<Token<EnumTokenTypeCSSLCompiler>> target = new List<Token<EnumTokenTypeCSSLCompiler>>();
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "public", });
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "override", });
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "void", });
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.identifier, Detail = "main", });
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.token_LeftParentheses_, Detail = "(", });
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.token_RightParentheses_, Detail = ")", });
                target.Add(new Token<EnumTokenTypeCSSLCompiler>() { TokenType = EnumTokenTypeCSSLCompiler.token_LeftBrace_, Detail = "{", });
                mainIndex = tokenList.KMP(target, classIndex + 3, TokenComparer.Instance);
                if (mainIndex < 0) { throw new Exception(string.Format("main() for {0} not found!", this.shaderCode.GetType().Name)); }
            }
            int lastRightBraceIndex = -1;
            {
                int leftBraceCount = 1;
                for (int rightBraceIndex = mainIndex + 7; rightBraceIndex < tokenList.Count; rightBraceIndex++)
                {
                    if (tokenList[rightBraceIndex].TokenType == EnumTokenTypeCSSLCompiler.token_LeftBrace_)
                    {
                        leftBraceCount++;
                    }
                    else if (tokenList[rightBraceIndex].TokenType == EnumTokenTypeCSSLCompiler.token_RightBrace_)
                    {
                        leftBraceCount--;
                        if (leftBraceCount == 0)
                        {
                            lastRightBraceIndex = tokenList[rightBraceIndex].IndexOfSourceCode;
                            break;
                        }
                    }
                }
            }

            int firstLeftBraceIndex = tokenList[mainIndex + 6].IndexOfSourceCode;
            StringBuilder mainBuilder = new StringBuilder();
            mainBuilder.AppendLine("void main(void)");
            mainBuilder.AppendLine("{");
            string[] parts = content.Substring(firstLeftBraceIndex + 1, lastRightBraceIndex - (firstLeftBraceIndex - 1))
                .Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int preEmptyCount = 0;
            {
                string line = Regex.Replace(parts[parts.Length - 1], "\t", "    ");
                preEmptyCount = Regex.Match(line, @" *").Length;
            }
            //bool isFragmentShader = this.ShaderCode.GetType().IsSubclassOf(typeof(FragmentCSShaderCode));
            foreach (var item in parts)
            {
                string line = Regex.Replace(item, "\t", "    ");

                if (Regex.Match(line, @"[\t ]*").Length >= preEmptyCount)
                {
                    line = line.Substring(preEmptyCount);
                }
                //if (isFragmentShader)
                {
                    line = Regex.Replace(line, @"discard\s*\(\s*\)\s*;", "discard;");
                }
                mainBuilder.AppendLine(line);
            }
            return mainBuilder.ToString();
        }

        //string SearchMainFunction(string fullname)
        //{
        //    string content = File.ReadAllText(fullname);
        //    // class XxxVertexShader : VertexShaderCode
        //    Match match = Regex.Match(content, @"class\s+" + this.ShaderCode.GetType().Name + @"\s*:");
        //    int classStart = match.Index + match.Length;
        //    // public override void main() { ... }
        //    match = Regex.Match(content.Substring(classStart),
        //        @"public\s+override\s+void\s+main\s*\(\s*\)\s*\{");
        //    // 自行找到main(){}函数的‘}’
        //    int firstLeftBrace = classStart + match.Index + match.Length - 1;
        //    int left = 1;
        //    int lastRightBrace = -1;
        //    for (int i = firstLeftBrace + 1; i < content.Length; i++)
        //    {
        //        char c = content[i];
        //        if (c == '\"')
        //        {
        //            for (int j = i + 1; j < content.Length; j++)
        //            {
        //                char tmp = content[j];
        //                if (tmp == '\"')
        //                {
        //                    i = j;
        //                    break;
        //                }
        //            }
        //        }
        //        else if (c == '\'')
        //        {
        //            i = i + 2;
        //        }
        //        else if (c == '{')
        //        {
        //            left++;
        //        }
        //        else if (c == '}')
        //        {
        //            left--;
        //            if (left == 0)
        //            {
        //                lastRightBrace = i;
        //                break;
        //            }
        //        }
        //    }

        //    StringBuilder mainBuilder = new StringBuilder();
        //    mainBuilder.AppendLine("void main(void)");
        //    mainBuilder.AppendLine("{");
        //    string[] parts = content.Substring(firstLeftBrace + 1, lastRightBrace - (firstLeftBrace - 1))
        //        .Split(separator, StringSplitOptions.RemoveEmptyEntries);
        //    int preEmptyCount = 0;
        //    {
        //        string line = Regex.Replace(parts[parts.Length - 1], "\t", "    ");
        //        preEmptyCount = Regex.Match(line, @" *").Length;
        //    }
        //    //bool isFragmentShader = this.ShaderCode.GetType().IsSubclassOf(typeof(FragmentCSShaderCode));
        //    foreach (var item in parts)
        //    {
        //        string line = Regex.Replace(item, "\t", "    ");

        //        if (Regex.Match(line, @"[\t ]*").Length >= preEmptyCount)
        //        {
        //            line = line.Substring(preEmptyCount);
        //        }
        //        //if (isFragmentShader)
        //        {
        //            line = Regex.Replace(line, @"discard\s*\(\s*\)\s*;", "discard;");
        //        }
        //        mainBuilder.AppendLine(line);
        //    }
        //    return mainBuilder.ToString();
        //}
    }
}
