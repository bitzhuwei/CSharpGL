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
        private ShaderProgram shaderProgram;
        private ShaderCode[] shaderCodes;

        public GLProgramNode(ShaderCode[] shaderCodes)
        {
            this.shaderCodes = shaderCodes;
        }
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
