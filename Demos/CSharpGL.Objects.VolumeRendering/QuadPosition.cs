using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VolumeRendering
{
    [StructLayout(LayoutKind.Sequential)]
    struct QuadPosition
    {
        public vec3 vertex0;
        public vec3 vertex1;
        public vec3 vertex2;
        public vec3 vertex3;

        public QuadPosition(vec3 v0,vec3 v1, vec3 v2, vec3 v3)
        {
            this.vertex0 = v0;
            this.vertex1 = v1;
            this.vertex2 = v2;
            this.vertex3 = v3;
        }
    }
}
