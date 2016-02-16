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
        protected CSShaderCode shaderCode;

        public CSShaderCode ShaderCode
        {
            get { return shaderCode; }
            protected set { shaderCode = value; }
        }
        protected string fullname;
        protected string mainFunction;

        public GLSLVersion Version { get; set; }

        public SemanticShader(CSShaderCode shaderCode, string fullname)
        {
            this.shaderCode = shaderCode;
            this.fullname = fullname;
        }

        protected static readonly char[] separator = new char[] { '\r', '\n' };

        public bool Dump2File()
        {
            Dump2FileAttribute attribute = this.shaderCode.GetType().GetCustomAttribute<Dump2FileAttribute>();
            if (attribute == null || attribute.Dump2File)
            {
                //this.Parse();

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
            else
            {
                return false;
            }
        }

        protected abstract string DumpShaderCode();
    }

}
