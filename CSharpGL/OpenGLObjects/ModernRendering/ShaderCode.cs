using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 各种类型的shader代码
    /// </summary>
    public class ShaderCode
    {

        /// <summary>
        /// 各种类型的shader代码
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <param name="shaderType"></param>
        public ShaderCode(string sourceCode, ShaderType shaderType)
        {
            this.SourceCode = sourceCode;
            this.ShaderType = shaderType;
        }

        public string SourceCode { get; set; }

        public ShaderType ShaderType { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", this.ShaderType);
        }

        public Shader CreateShader()
        {
            var shader = new Shader();
            shader.Create((uint)this.ShaderType, this.SourceCode);

            return shader;
        }
    }
}
