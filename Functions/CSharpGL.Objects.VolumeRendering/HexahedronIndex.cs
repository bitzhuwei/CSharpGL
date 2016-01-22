using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.VolumeRendering
{
    [StructLayout(LayoutKind.Sequential)]
    struct HexahedronIndex
    {
        public uint index0;
        public uint index1;
        public uint index2;
        public uint index3;
        public uint index4;
        public uint index5;
        public uint index6;
        public uint index7;
        public uint indexRestart;
        public uint index9;
        public uint index10;
        public uint index11;
        public uint index12;
        public uint index13;
        public uint index14;
        public uint index15;
        public uint index16;
        public uint indexRestart2;

        public HexahedronIndex(uint centerIndex)
        {
            this.index0 = centerIndex + 0;
            this.index1 = centerIndex + 2;
            this.index2 = centerIndex + 1;
            this.index3 = centerIndex + 3;
            this.index4 = centerIndex + 5;
            this.index5 = centerIndex + 7;
            this.index6 = centerIndex + 4;
            this.index7 = centerIndex + 6;
            this.indexRestart = uint.MaxValue;
            this.index9 = centerIndex + 1;
            this.index10 = centerIndex + 5;
            this.index11 = centerIndex + 0;
            this.index12 = centerIndex + 4;
            this.index13 = centerIndex + 2;
            this.index14 = centerIndex + 6;
            this.index15 = centerIndex + 3;
            this.index16 = centerIndex + 7;
            this.indexRestart2 = uint.MaxValue;

        }
    }
}
