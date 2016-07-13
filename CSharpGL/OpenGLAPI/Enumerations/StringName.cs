using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// </summary>
    public enum StringName : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Vendor = OpenGL.GL_VENDOR,// 0x1F00,
        /// <summary>
        /// 
        /// </summary>
        Renderer = OpenGL.GL_RENDERER,// 0x1F01,
        /// <summary>
        /// 
        /// </summary>
        Version = OpenGL.GL_VERSION,// 0x1F02,
        /// <summary>
        /// 
        /// </summary>
        Extensions = OpenGL.GL_EXTENSIONS,// 0x1F03,
    }
}
