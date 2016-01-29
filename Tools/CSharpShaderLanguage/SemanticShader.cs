using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpShaderLanguage
{
    public abstract class SemanticShader
    {
        protected List<FieldTemplate> fields = new List<FieldTemplate>();
        protected List<string> functions = new List<string>();

        ///// <summary>
        ///// 继承自<see cref="ShaderCode"/>的具体类型。
        ///// </summary>
        //protected Type shaderCodeType;
        protected ShaderCode shaderCode;
        protected string fullname;
        protected string mainFunction;

        public SemanticShader(ShaderCode shaderCode, string fullname)
        {
            this.shaderCode = shaderCode;
            this.fullname = fullname;
        }


        protected abstract string SearchMainFunction(string fullname);

        protected static readonly char[] separator = new char[] { '\r', '\n' };

        private void Parse()
        {
            FieldInfo[] fields = this.shaderCode.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
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

            this.mainFunction = SearchMainFunction(this.fullname);
        }

        public void Dump2File()
        {
            this.Parse();

            string shaderCode = DumpShaderCode();

            File.WriteAllText(this.shaderCode.GetShaderFilename(), shaderCode);
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
