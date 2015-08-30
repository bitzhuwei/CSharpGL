using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public struct DDS_FILE_HEADER
    {
        public uint magic;
        public DDS_HEADER std_header;
        public DDS_HEADER_DXT10 dxt10_header;
    }
}
