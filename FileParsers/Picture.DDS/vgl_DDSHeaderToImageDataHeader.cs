using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public partial class vgl
    {
        public static bool vgl_DDSHeaderToImageDataHeader(ref DDS_FILE_HEADER header, ref vglImageData image)
        {
            image.swizzle = new uint[4];

            if (header.std_header.ddspf.dwFlags == DDSSignal.DDS_DDPF_FOURCC &&
                header.std_header.ddspf.dwFourCC == DDSSignal.DDS_FOURCC_DX10)
            {
                if (header.dxt10_header.format < vermilion.NUM_DDS_FORMATS)
                {
                    DDS_FORMAT_GL_INFO format = InfoTable.gl_info_table[header.dxt10_header.format];
                    image.format = format.format;
                    image.type = format.type;
                    image.internalFormat = format.internalFormat;
                    image.swizzle[0] = format.swizzle_r;
                    image.swizzle[1] = format.swizzle_g;
                    image.swizzle[2] = format.swizzle_b;
                    image.swizzle[3] = format.swizzle_a;
                    image.mipLevels = (int)header.std_header.mip_levels;
                    return true;
                }
            }
            else if (header.std_header.ddspf.dwFlags == DDSSignal.DDS_DDPF_FOURCC)
            {
                image.swizzle[0] = GL.GL_RED;
                image.swizzle[1] = GL.GL_GREEN;
                image.swizzle[2] = GL.GL_BLUE;
                image.swizzle[3] = GL.GL_ALPHA;
                image.mipLevels = (int)header.std_header.mip_levels;

                switch (header.std_header.ddspf.dwFourCC)
                {
                    case 116:
                        image.format = GL.GL_RGBA;
                        image.type = GL.GL_FLOAT;
                        image.internalFormat = GL.GL_RGBA32F;
                        /*
                        image.swizzle[0] = GL.GL_ALPHA;
                        image.swizzle[1] = GL.GL_BLUE;
                        image.swizzle[2] = GL.GL_GREEN;
                        image.swizzle[3] = GL.GL_RED;
                        */
                        return true;
                    default:
                        break;
                }
            }
            else
            {
                image.swizzle[0] = GL.GL_RED;
                image.swizzle[1] = GL.GL_GREEN;
                image.swizzle[2] = GL.GL_BLUE;
                image.swizzle[3] = GL.GL_ALPHA;
                image.mipLevels = (int)header.std_header.mip_levels;

                switch (header.std_header.ddspf.dwFlags)
                {
                    case DDSSignal.DDS_DDPF_RGB:
                        image.format = GL.GL_BGR;
                        image.type = GL.GL_UNSIGNED_BYTE;
                        image.internalFormat = GL.GL_RGB8;
                        image.swizzle[3] = GL.GL_ONE;
                        return true;
                    case (DDSSignal.DDS_DDPF_RGB | DDSSignal.DDS_DDPF_ALPHA):
                    case (DDSSignal.DDS_DDPF_RGB | DDSSignal.DDS_DDPF_ALPHAPIXELS):
                        image.format = GL.GL_BGRA;
                        image.type = GL.GL_UNSIGNED_BYTE;
                        image.internalFormat = GL.GL_RGBA8;
                        return true;
                    case DDSSignal.DDS_DDPF_ALPHA:
                        image.format = GL.GL_RED;
                        image.type = GL.GL_UNSIGNED_BYTE;
                        image.internalFormat = GL.GL_R8;
                        image.swizzle[0] = image.swizzle[1] = image.swizzle[2] = GL.GL_ZERO;
                        image.swizzle[3] = GL.GL_RED;
                        return true;
                    case DDSSignal.DDS_DDPF_LUMINANCE:
                        image.format = GL.GL_RED;
                        image.type = GL.GL_UNSIGNED_BYTE;
                        image.internalFormat = GL.GL_R8;
                        image.swizzle[0] = image.swizzle[1] = image.swizzle[2] = GL.GL_RED;
                        image.swizzle[3] = GL.GL_ONE;
                        return true;
                    case (DDSSignal.DDS_DDPF_LUMINANCE | DDSSignal.DDS_DDPF_ALPHA):
                        image.format = GL.GL_RG;
                        image.type = GL.GL_UNSIGNED_BYTE;
                        image.internalFormat = GL.GL_RG8;
                        image.swizzle[0] = image.swizzle[1] = image.swizzle[2] = GL.GL_RED;
                        image.swizzle[3] = GL.GL_GREEN;
                        return true;
                    default:
                        break;
                }
            }

            image.format = image.type = image.internalFormat = GL.GL_NONE;
            image.swizzle[0] = image.swizzle[1] = image.swizzle[2] = image.swizzle[3] = GL.GL_ZERO;

            return false;
        }
    }
}
