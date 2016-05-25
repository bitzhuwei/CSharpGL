using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum ShaderType : uint
    {
        VertexShader = OpenGL.GL_VERTEX_SHADER,
        GeometryShader = OpenGL.GL_GEOMETRY_SHADER,
        FragmentShader = OpenGL.GL_FRAGMENT_SHADER,
        ComputeShader = OpenGL.GL_COMPUTE_SHADER,
    }
}
