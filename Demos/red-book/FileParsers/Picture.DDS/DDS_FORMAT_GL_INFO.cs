using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public struct DDS_FORMAT_GL_INFO
    {
        public uint format;
        public uint type;
        public uint internalFormat;
        public uint swizzle_r;
        public uint swizzle_g;
        public uint swizzle_b;
        public uint swizzle_a;
        public int bits_per_texel;

        public DDS_FORMAT_GL_INFO(uint format, uint type, uint internalFormat,
            uint swizzle_r, uint swizzle_g, uint swizzle_b, uint swizzle_a,
            int bits_per_texel)
        {
            this.format = format; this.type = type; this.internalFormat = internalFormat;
            this.swizzle_r = swizzle_r; this.swizzle_g = swizzle_g;
            this.swizzle_b = swizzle_b; this.swizzle_a = swizzle_a;
            this.bits_per_texel = bits_per_texel;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                format, type, internalFormat, swizzle_r, swizzle_g, swizzle_b, swizzle_a, bits_per_texel);
        }
    }
}
