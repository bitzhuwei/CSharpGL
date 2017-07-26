using System;
using System.ComponentModel;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public class VertexShaderAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public VertexBuffer Buffer { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string VarNameInVertexShader { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="varNameInVertexShader"></param>
        public VertexShaderAttribute(VertexBuffer buffer, string varNameInVertexShader)
        {
            this.Buffer = buffer;
            this.VarNameInVertexShader = varNameInVertexShader;
        }

    }
}
