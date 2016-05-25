using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 
    /// </summary>
    public enum PatchParameterName : uint
    {
        PatchVertices = OpenGL.GL_PATCH_VERTICES,
        PatchDefaultOuterLevel = OpenGL.GL_PATCH_DEFAULT_OUTER_LEVEL,
        PatchDefaultInnerLevel = OpenGL.GL_PATCH_DEFAULT_INNER_LEVEL,
    }
}
