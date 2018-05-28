using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftGL
{
    public abstract class FragmentShader : Shader
    {
        public vec4 gl_FragCoord { get; private set; }
        public bool gl_FrontFacing { get; private set; }
        public float[] gl_ClipDistance { get; private set; }
        public vec2 gl_PointCoord { get; private set; }
        public int gl_PrimitiveID { get; private set; }
        public int gl_SampleID { get; private set; }
        public vec2 gl_SamplePositin { get; private set; }
        public int[] gl_SampleMaskIn { get; private set; }
        public int gl_Layer { get; private set; }
        public int gl_ViewportIndex { get; private set; }

        public float gl_FragDepth { get; set; }
        public int[] gl_SampleMask { get; set; }

        public abstract void main();
    }
}
