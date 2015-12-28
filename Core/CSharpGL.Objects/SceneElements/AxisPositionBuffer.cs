using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    class AxisPositionBuffer : PropertyBuffer<vec3>
    {
        public AxisPositionBuffer(string varNameInVertexShader, BufferUsage usage)
            : base(varNameInVertexShader, 3, GL.GL_FLOAT, usage)
        { }

    }
}
