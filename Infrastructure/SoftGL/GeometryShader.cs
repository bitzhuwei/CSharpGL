using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGL
{
    public abstract class GeometryShader : Shader
    {
        public class gl_PerVertex
        {
            public vec4 gl_Position;
            public float gl_PointSize;
            public float[] gl_ClipDistance;
        }
        public gl_PerVertex[] gl_in;
        public int gl_PrimitiveIDIn { get; private set; }
        public int gl_InvocationID { get; private set; }
        public vec4 gl_Position;
        public float gl_PointSize;
        public float[] gl_ClipDistance;

        public int gl_PrimitiveID;
        public int gl_Layer;
        public int gl_ViewportIndex;

        public abstract void main();
    }
}
