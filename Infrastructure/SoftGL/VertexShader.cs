using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGL
{
    public abstract class VertexShader : Shader
    {
        public int gl_VertexID { get; private set; }
        public int gl_InstanceID { get; private set; }

        public vec4 gl_Position;
        public float gl_PointSize;
        public float[] gl_ClipDistance;

        public abstract void main();
    }
}
