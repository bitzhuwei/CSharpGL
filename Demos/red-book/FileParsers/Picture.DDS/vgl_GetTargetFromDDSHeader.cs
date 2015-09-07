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
        public static uint vgl_GetTargetFromDDSHeader(ref DDS_FILE_HEADER header)
        {
            // If the DX10 header is present it's format should be non-zero (unless it's unknown)
            if (header.dxt10_header.format != 0)
            {
                // Check the dimension...
                switch (header.dxt10_header.dimension)
                {
                    // Could be a 1D or 1D array texture
                    case DDSSignal.DDS_RESOURCE_DIMENSION_TEXTURE1D:
                        if (header.dxt10_header.array_size > 1)
                        {
                            return GL.GL_TEXTURE_1D_ARRAY;
                        }
                        return GL.GL_TEXTURE_1D;
                    // 2D means 2D, 2D array, cubemap or cubemap array
                    case DDSSignal.DDS_RESOURCE_DIMENSION_TEXTURE2D:
                        if ((header.dxt10_header.misc_flag & DDSSignal.DDS_RESOURCE_MISC_TEXTURECUBE) != 0)
                        {
                            if (header.dxt10_header.array_size > 1)
                                return GL.GL_TEXTURE_CUBE_MAP_ARRAY;
                            return GL.GL_TEXTURE_CUBE_MAP;
                        }
                        if (header.dxt10_header.array_size > 1)
                            return GL.GL_TEXTURE_2D_ARRAY;
                        return GL.GL_TEXTURE_2D;
                    // 3D should always be a volume texture
                    case DDSSignal.DDS_RESOURCE_DIMENSION_TEXTURE3D:
                        return GL.GL_TEXTURE_3D;
                }
                return GL.GL_NONE;
            }

            // No DX10 header. Check volume texture flag
            if ((header.std_header.caps2 & DDSSignal.DDSCAPS2_VOLUME) != 0)
                return GL.GL_TEXTURE_3D;

            // Could be a cubemap
            if ((header.std_header.caps2 & DDSSignal.DDSCAPS2_CUBEMAP) != 0)
            {
                // This shouldn't happen if the DX10 header is present, but what the hey
                if (header.dxt10_header.array_size > 1)
                    return GL.GL_TEXTURE_CUBE_MAP_ARRAY;
                else
                    return GL.GL_TEXTURE_CUBE_MAP;
            }

            // Alright, if there's no height, guess 1D
            if (header.std_header.height <= 1)
                return GL.GL_TEXTURE_1D;

            // Last ditch, probably 2D
            return GL.GL_TEXTURE_2D;
        }
    }
}
