using System;
using System.ComponentModel;

namespace CSharpGL {
    /// <summary>
    /// 
    /// </summary>
    public unsafe class VertexShaderAttribute {
        public readonly VertexBuffer buffer;
        /// <summary>
        /// in vec3 inPosition;
        /// </summary>
        public readonly string inVar;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="inVar"></param>
        public VertexShaderAttribute(VertexBuffer buffer, string inVar) {
            this.buffer = buffer;
            this.inVar = inVar;
        }

    }
}
