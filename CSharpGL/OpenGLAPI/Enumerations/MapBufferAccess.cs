using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public enum MapBufferAccess : uint
    {
        ReadOnly = OpenGL.GL_READ_ONLY,
        WriteOnly = OpenGL.GL_WRITE_ONLY,
        ReadWrite = OpenGL.GL_READ_WRITE,
    }
}
