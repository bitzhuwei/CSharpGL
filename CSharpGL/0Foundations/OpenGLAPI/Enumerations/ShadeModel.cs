using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// ShadingModel
    /// </summary>
    public enum ShadeModel : uint
    {
        /// <summary>
        /// 
        /// </summary>
        Flat = OpenGL.GL_FLAT,
        /// <summary>
        /// 
        /// </summary>
        Smooth = OpenGL.GL_SMOOTH,
    }
}
