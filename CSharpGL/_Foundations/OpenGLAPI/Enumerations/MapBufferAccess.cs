using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum MapBufferAccess : uint
    {
        /// <summary>
        /// 
        /// </summary>
        ReadOnly = OpenGL.GL_READ_ONLY,
        /// <summary>
        /// 
        /// </summary>
        WriteOnly = OpenGL.GL_WRITE_ONLY,
        /// <summary>
        /// 
        /// </summary>
        ReadWrite = OpenGL.GL_READ_WRITE,
    }
}
