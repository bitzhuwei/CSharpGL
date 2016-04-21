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
        protected CSSLFileGroup fileGroup;
        protected string mainFunction;

        public GLSLVersion Version { get; set; }

        public SemanticShader(CSShaderCode shaderCode, CSSLFileGroup fileGroup)
        {
            this.shaderCode = shaderCode;
            this.fileGroup = fileGroup;
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
                    (new FileInfo(fileGroup.CsslFile)).DirectoryName, this.shaderCode.GetShaderFilename());
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

        protected sealed class TokenComparer : IComparer<Token<EnumTokenTypeCSSLCompiler>>
        {
            private TokenComparer() { }

            private static readonly TokenComparer instance = new TokenComparer();

            public static TokenComparer Instance
            {
                get { return TokenComparer.instance; }
            }


            int IComparer<Token<EnumTokenTypeCSSLCompiler>>.Compare(Token<EnumTokenTypeCSSLCompiler> x, Token<EnumTokenTypeCSSLCompiler> y)
            {
                if (x == null && y == null) { return 0; }
                if (x == null || y == null) { return 1; }

                if (x.Detail == y.Detail
                    && x.TokenType == y.TokenType) { return 0; }

                return 1;
            }
        }

    }

}
