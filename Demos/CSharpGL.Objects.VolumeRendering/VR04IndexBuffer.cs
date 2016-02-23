using CSharpGL.Objects.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VolumeRendering
{
    class VR04IndexBuffer : IndexBuffer<QuadIndex>
    {
        //public VR03IndexBuffer(string varNameInVertexShader) : base(varNameInVertexShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw) { }
        public VR04IndexBuffer() : base(DrawMode.Quads, IndexElementType.UnsignedInt, BufferUsage.StaticDraw) { }

    }
}
