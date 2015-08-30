using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public struct DDS_HEADER_DXT10
    {
        public uint format;
        public uint dimension;
        public uint misc_flag;
        public uint array_size;
        public uint reserved;
    }
}
