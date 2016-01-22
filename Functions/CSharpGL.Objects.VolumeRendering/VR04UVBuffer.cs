using CSharpGL.Objects.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VolumeRendering
{
    class VR04UVBuffer : PropertyBuffer<QuadUV>
    {
        public VR04UVBuffer(string varNameInVertexShader) : base(varNameInVertexShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw) { }

    }
}
