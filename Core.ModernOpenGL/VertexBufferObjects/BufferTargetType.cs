using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VertexBufferObjects
{
    public enum BufferTargetType : uint
    {
        /// <summary>
        /// GL.GL_ARRAY_BUFFER
        /// </summary>
        ArrayBuffer = GL.GL_ARRAY_BUFFER,

        /// <summary>
        /// GL.GL_ELEMENT_ARRAY_BUFFER
        /// </summary>
        ElementArrayBuffer = GL.GL_ELEMENT_ARRAY_BUFFER,
    }
}
