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
        PatchVertices = GL.GL_PATCH_VERTICES,
        PatchDefaultOuterLevel = GL.GL_PATCH_DEFAULT_OUTER_LEVEL,
        PatchDefaultInnerLevel = GL.GL_PATCH_DEFAULT_INNER_LEVEL,
    }
}
