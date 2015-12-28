using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos.VolumeRendering
{
    class VR03IndexBuffer : IndexBuffer<HexahedronIndex>
    {
        //public VR03IndexBuffer(string varNameInVertexShader) : base(varNameInVertexShader, 3, GL.GL_FLOAT, BufferUsage.StaticDraw) { }
        public VR03IndexBuffer() : base(DrawMode.QuadStrip, IndexElementType.UnsignedInt, BufferUsage.StaticDraw) { }

    }
}
