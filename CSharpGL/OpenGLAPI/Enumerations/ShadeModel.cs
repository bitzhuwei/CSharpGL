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
        Flat = OpenGL.GL_FLAT,
        Smooth = OpenGL.GL_SMOOTH
    }
}
