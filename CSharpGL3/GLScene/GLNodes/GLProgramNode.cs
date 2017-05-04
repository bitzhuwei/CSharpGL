using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// shader program.
    /// </summary>
    public class GLProgramNode : GLNode
    {
        private static readonly Type type = typeof(GLProgramNode);
        internal override Type SelfTypeCache
        {
            get { return type; }
        }

        private ShaderProgram shaderProgram;
        private ShaderCode[] shaderCodes;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shaderCodes"></param>
        public GLProgramNode(ShaderCode[] shaderCodes)
        {
            this.shaderCodes = shaderCodes;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ShaderProgram GetShaderProgram()
        {
            if (this.shaderProgram == null)
            {
                this.shaderProgram = this.shaderCodes.CreateProgram();
            }

            return this.shaderProgram;
        }
    }
}
