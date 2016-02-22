using CSharpShadingLanguage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpGL.CSSL2GLSL
{
    public sealed class SemanticGeometryShader : SemanticShader
    {

        public SemanticGeometryShader(CSShaderCode shaderCode, string fullname)
            : base(shaderCode, fullname)
        {
        }

        protected override string DumpShaderCode()
        {
            StringBuilder builder = new StringBuilder();

            GeometryCSShaderCode shaderCode = this.shaderCode as GeometryCSShaderCode;
            Type shaderCodeType = shaderCode.GetType();

            // #version 150 core
            GLSLVersionAttribute versionAttribute = shaderCodeType.GetCustomAttribute<GLSLVersionAttribute>();
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

            // layout (triangles) in;
            // layout (triangle_strip, max_vertices = 11) out;
            builder.AppendLine(string.Format("layout ({0}) in;", shaderCode.LayoutIn));
            builder.AppendLine(string.Format("layout ({0}, max_vertices = {1}) out;",
                shaderCode.LayoutOut, shaderCode.max_vertices));
            builder.AppendLine();

            foreach (var field in shaderCodeType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                foreach (var attr in field.GetCustomAttributes<QualifierAttribute>())
                {
                    var semanticField = new SemanticField(attr, field.FieldType, field.Name, this.shaderCode);
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
            //bool isFragmentShader = this.ShaderCode.GetType().IsSubclassOf(typeof(FragmentCSShaderCode));
            foreach (var item in parts)
            {
                string line = Regex.Replace(item, "\t", "    ");

                if (Regex.Match(line, @"[\t ]*").Length >= preEmptyCount)
                {
                    line = line.Substring(preEmptyCount);
                }
                //if (isFragmentShader)
                //{
                //    line = Regex.Replace(line, @"discard\s*\(\s*\)\s*;", "discard;");
                //}
                line = Regex.Replace(line, @"Float\s*\(", @"float(");
                line = Regex.Replace(line, @"Uint\s*\(", @"uint(");
                line = Regex.Replace(line, @"int\s*\(", @"int(");
                //line = Regex.Replace(line, @"^[a-zA-Z0-9_]+Float\s*\(", @"float(");
                mainBuilder.AppendLine(line);
            }
            return mainBuilder.ToString();
        }

    }
}
