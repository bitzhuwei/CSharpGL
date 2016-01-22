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
    struct HexahedronPosition
    {
        public vec3 v0;
        public vec3 v1;
        public vec3 v2;
        public vec3 v3;
        public vec3 v4;
        public vec3 v5;
        public vec3 v6;
        public vec3 v7;
    }
}
