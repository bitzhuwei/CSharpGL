using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGL
{
    public class RenderContext
    {
        public ShaderProgram Program { get; set; }

        public VertexBuffer[] VertexBuffers { get; set; }

        public IDrawCommand DrawCommand { get; set; }

        public Framebuffer Target { get; set; }

        public static RenderContext Create()
        {
            throw new NotImplementedException();
        }
    }
}
