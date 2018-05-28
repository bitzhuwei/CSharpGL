using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGL
{
    public abstract class Shader
    {
        public struct gl_DepthRangeParameters { public float near; public float far; public float diff;}
        // uniform
        public gl_DepthRangeParameters gl_DepthRange;
        // uniform
        public int gl_NumSamples;
    }
}
