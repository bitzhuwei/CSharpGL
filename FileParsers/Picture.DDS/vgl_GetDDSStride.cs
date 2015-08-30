using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public partial class vgl
    {
        int vgl_GetDDSStride(ref DDS_FILE_HEADER header, int width)
        {
            if (header.std_header.ddspf.dwFlags == DDSSignal.DDS_DDPF_FOURCC &&
                    header.std_header.ddspf.dwFourCC == DDSSignal.DDS_FOURCC_DX10)
            {
                if (header.dxt10_header.format < vermilion.NUM_DDS_FORMATS)
                {
                    DDS_FORMAT_GL_INFO format = InfoTable.gl_info_table[header.dxt10_header.format];
                    return (format.bits_per_texel * width + 7) / 8;
                }
            }
            else
            {
                switch (header.std_header.ddspf.dwFlags)
                {
                    case DDSSignal.DDS_DDPF_RGB:
                        return width * 3;
                    case (DDSSignal.DDS_DDPF_RGB | DDSSignal.DDS_DDPF_ALPHA):
                    case (DDSSignal.DDS_DDPF_RGB | DDSSignal.DDS_DDPF_ALPHAPIXELS):
                        return width * 4;
                    case DDSSignal.DDS_DDPF_ALPHA:
                        return width;
                    default:
                        break;
                }
            }

            return 0;
        }
    }
}
