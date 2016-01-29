using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpShaderLanguage.Convertor
{
    class ShaderTemplate
    {
        public List<FieldTemplate> fields = new List<FieldTemplate>();
        public List<string> functions = new List<string>();
        /// <summary>
        /// 继承自<see cref="ShaderCode"/>的具体类型。
        /// </summary>
        private Type targetType;
        private string fullname;
        private string mainFunction;

        public ShaderTemplate(Type type, string fullname)
        {
            // TODO: Complete member initialization
            this.targetType = type;
            this.fullname = fullname;
        }

        private void SearchMainFunction(string fullname)
        {
            string content = File.ReadAllText(fullname);
            // class XxxVertexShader : VertexShaderCode
            Match match = Regex.Match(content, @"class\s+" + this.targetType.Name + @"\s+"
                + @":\s+" + GetShaderCode());
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
            int preEmptyCount = parts[parts.Length - 1].Length - 1;
            foreach (var item in parts)
            {
                mainBuilder.AppendLine(item.Substring(preEmptyCount));
            }
            this.mainFunction = mainBuilder.ToString();
        }

        static readonly char[] separator = new char[] { '\r', '\n' };

        private void Parse()
        {
            FieldInfo[] fields = targetType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                if (field.GetCustomAttribute<InAttribute>() != null)
                {
                    this.fields.Add(new FieldTemplate(FieldQualifier.In, field.FieldType, field.Name));
                }
                else if (field.GetCustomAttribute<OutAttribute>() != null)
                {
                    this.fields.Add(new FieldTemplate(FieldQualifier.Out, field.FieldType, field.Name));
                }
                else if (field.GetCustomAttribute<UniformAttribute>() != null)
                {
                    this.fields.Add(new FieldTemplate(FieldQualifier.Uniform, field.FieldType, field.Name));
                }
            }

            SearchMainFunction(fullname);
        }

        public void Dump2File()
        {
            this.Parse();

            FileInfo fileInfo = new FileInfo(fullname);

            string shaderCode = DumpShaderCode();
            string shaderName = string.Empty;
            if (this.targetType.Name.ToLower().EndsWith(GetShaderExtensionName()))
            {
                shaderName = this.targetType.Name.Substring(0, this.targetType.Name.Length - GetShaderExtensionName().Length);
            }
            else
            {
                shaderName = this.targetType.Name;
            }
            string outputFullname = Path.Combine(fileInfo.DirectoryName,
                string.Format("{0}-{1}.{2}", fileInfo.Name, shaderName, GetShaderExtensionName()));
            File.WriteAllText(outputFullname, shaderCode);
        }

        protected string GetShaderCode()
        {
            if (this.targetType.IsSubclassOf(typeof(VertexShaderCode)))
            {
                return typeof(VertexShaderCode).Name;
            }
            else if (this.targetType.IsSubclassOf(typeof(FragmentShaderCode)))
            {
                return typeof(FragmentShaderCode).Name;
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        protected string GetShaderExtensionName()
        {
            if (this.targetType.IsSubclassOf(typeof(VertexShaderCode)))
            {
                return "vert";
            }
            else if (this.targetType.IsSubclassOf(typeof(FragmentShaderCode)))
            {
                return "frag";
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        private string DumpShaderCode()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("#version core 150");
            builder.AppendLine();

            foreach (var item in this.fields)
            {
                string field = item.Dump();
                builder.AppendLine(field);
            }
            builder.AppendLine();

            builder.Append(this.mainFunction);
            builder.AppendLine();

            return builder.ToString();
        }
    }
}
