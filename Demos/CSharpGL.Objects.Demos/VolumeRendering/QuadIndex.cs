using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Demos.VolumeRendering
{
    [StructLayout(LayoutKind.Sequential)]
    struct QuadIndex
    {
        public uint index0;
        public uint index1;
        public uint index2;
        public uint index3;

        public QuadIndex(uint i0, uint i1, uint i2, uint i3)
        {
            this.index0 = i0;
            this.index1 = i1;
            this.index2 = i2;
            this.index3 = i3;
        }
    }
}
