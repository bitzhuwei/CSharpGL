using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public struct DDS_PIXELFORMAT
    {
        public uint dwSize;
        public uint dwFlags;
        public uint dwFourCC;
        public uint dwRGBBitCount;
        public uint dwRBitMask;
        public uint dwGBitMask;
        public uint dwBBitMask;
        public uint dwABitMask;
    }
}
