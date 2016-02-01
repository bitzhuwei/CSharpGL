using CSharpShadingLanguage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        protected override string SearchMainFunction(string fullname)
        {
            string content = File.ReadAllText(fullname);
            // class XxxVertexShader : VertexShaderCode
            Match match = Regex.Match(content, @"class\s+" + this.ShaderCode.GetType().Name + @"\s*:");
            int classStart = match.Index + match.Length;
            // public override void main() { ... }
            match = Regex.Match(content.Substring(classStart),
                @"public\s+override\s+void\s+main\s*\(\s*\)\s*\{");
            // 自行找到main(){}函数的‘}’
            int firstLeftBrace = classStart + match.Index + match.Length - 1;
            int left = 1;
            int lastRightBrace = -1;
            for (int i = firstLeftBrace + 1; i < content.Length; i++)
            {
                char c = content[i];
                if (c == '\"')
                {
                    for (int j = i + 1; j < content.Length; j++)
                    {
                        char tmp = content[j];
                        if (tmp == '\"')
                        {
                            i = j;
                            break;
                        }
                    }
                }
                else if (c == '\'')
                {
                    i = i + 2;
                }
                else if (c == '{')
                {
                    left++;
                }
                else if (c == '}')
                {
                    left--;
                    if (left == 0)
                    {
                        lastRightBrace = i;
                        break;
                    }
                }
            }

            StringBuilder mainBuilder = new StringBuilder();
            mainBuilder.AppendLine("void main(void)");
            mainBuilder.AppendLine("{");
            string[] parts = content.Substring(firstLeftBrace + 1, lastRightBrace - (firstLeftBrace - 1))
                .Split(separator, StringSplitOptions.RemoveEmptyEntries);
            int preEmptyCount = 0;
            {
                string line = Regex.Replace(parts[parts.Length - 1], "\t", "    ");
                preEmptyCount = Regex.Match(line, @" *").Length;
            }
            bool isFragmentShader = this.ShaderCode.GetType().IsSubclassOf(typeof(FragmentCSShaderCode));
            foreach (var item in parts)
            {
                string line = Regex.Replace(item, "\t", "    ");

                if (Regex.Match(line, @"[\t ]*").Length >= preEmptyCount)
                {
                    line = line.Substring(preEmptyCount);
                }
                if (isFragmentShader)
                {
                    line = Regex.Replace(line, @"discard\s*\(\s*\)\s*;", "discard;");
                }
                mainBuilder.AppendLine(line);
            }
            return mainBuilder.ToString();
        }
    }
}
