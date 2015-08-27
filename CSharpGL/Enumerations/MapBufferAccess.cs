using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum MapBufferAccess : uint
    {
        ReadOnly = GL.GL_READ_ONLY,
        WriteOnly = GL.GL_WRITE_ONLY,
        ReadWrite = GL.GL_READ_WRITE,
    }
}
