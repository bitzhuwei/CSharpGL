using CSharpShadingLanguage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharpGL.CSSL2GLSL
{
    public abstract class SemanticShader
    {
        protected List<SemanticField> fields = new List<SemanticField>();
        protected List<string> functions = new List<string>();

        ///// <summary>
        ///// 继承自<see cref="ShaderCode"/>的具体类型。
        ///// </summary>
        //protected Type shaderCodeType;
        private CSShaderCode shaderCode;

        public CSShaderCode ShaderCode
        {
            get { return shaderCode; }
            protected set { shaderCode = value; }
        }
        protected string fullname;
        protected string mainFunction;

        public SemanticShader(CSShaderCode shaderCode, string fullname)
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
                    this.fields.Add(new SemanticField(FieldQualifier.In, field.FieldType, field.Name));
                }
                else if (field.GetCustomAttribute<OutAttribute>() != null)
                {
                    this.fields.Add(new SemanticField(FieldQualifier.Out, field.FieldType, field.Name));
                }
                else if (field.GetCustomAttribute<UniformAttribute>() != null)
                {
                    this.fields.Add(new SemanticField(FieldQualifier.Uniform, field.FieldType, field.Name));
                }
            }

            this.mainFunction = SearchMainFunction(this.fullname);
        }

        public bool Dump2File()
        {
            this.Parse();

            string shaderCode = DumpShaderCode();

            string targetFullname = Path.Combine(
                (new FileInfo(fullname)).DirectoryName, this.shaderCode.GetShaderFilename());
            if (File.Exists(targetFullname))
            {
                if (File.ReadAllText(targetFullname) != shaderCode)
                {
                    File.WriteAllText(targetFullname, shaderCode);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                File.WriteAllText(targetFullname, shaderCode);
                return true;
            }
        }

        private string DumpShaderCode()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("#version 150 core");
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
