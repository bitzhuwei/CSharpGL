using System;
using System.ComponentModel;

namespace CSharpGL
{
    public class VertexShaderAttribute
    {

        public VertexBuffer Buffer { get; private set; }

        public string VarNameInVertexShader { get; private set; }

        public VertexShaderAttribute(VertexBuffer buffer, string varNameInVertexShader)
        {
            this.Buffer = buffer;
            this.VarNameInVertexShader = varNameInVertexShader;
        }

    }
}
