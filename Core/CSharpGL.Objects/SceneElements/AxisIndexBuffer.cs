using CSharpGL.Objects.VertexBuffers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.SceneElements
{
    public class AxisIndexBuffer : IndexBuffer<byte>
    {
        public AxisIndexBuffer()
            : base(DrawMode.QuadStrip, IndexElementType.UnsignedByte, BufferUsage.StaticDraw)
        { }
    }
}
