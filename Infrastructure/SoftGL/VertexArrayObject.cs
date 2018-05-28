using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGL
{
    public class VertexArrayObject
    {
        public VertexBuffer[] VertexzBuffers { get; set; }

        public IDrawCommand DrawCommand { get; set; }

    }
}
