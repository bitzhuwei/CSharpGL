using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.ModernRendering
{
    public class CodeShader
    {
        public CodeShader(string sourceCode, GLSLShaderType shaderType)
        {
            this.SourceCode = sourceCode;
            this.ShaderType = shaderType;   
        }

        public string SourceCode { get; set; }

        public CodeShader.GLSLShaderType ShaderType { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", this.ShaderType);
        }


        /// <summary>
        /// 等以后涉及其他类型shader时再加入。
        /// </summary>
        public enum GLSLShaderType
        {
            VertexShader,
            GeometryShader,
            FragmentShader,
        }
    }

}
