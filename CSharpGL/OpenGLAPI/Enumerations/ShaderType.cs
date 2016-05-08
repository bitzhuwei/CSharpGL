using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum ShaderType : uint
    {
        VertexShader = GL.GL_VERTEX_SHADER,
        GeometryShader = GL.GL_GEOMETRY_SHADER,
        FragmentShader = GL.GL_FRAGMENT_SHADER,
        ComputeShader = GL.GL_COMPUTE_SHADER,
    }
}
