using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public static class DDSSignal
    {
        public const uint DDS_MAGIC = 0x20534444;

       public const uint   DDSCAPS_COMPLEX = 0x00000008;
       public const uint   DDSCAPS_MIPMAP = 0x00400000;
       public const uint   DDSCAPS_TEXTURE = 0x00001000;

      public const uint   DDSCAPS2_CUBEMAP = 0x00000200;
      public const uint   DDSCAPS2_CUBEMAP_POSITIVEX = 0x00000400;
      public const uint   DDSCAPS2_CUBEMAP_NEGATIVEX = 0x00000800;
      public const uint   DDSCAPS2_CUBEMAP_POSITIVEY = 0x00001000;
      public const uint   DDSCAPS2_CUBEMAP_NEGATIVEY = 0x00002000;
      public const uint   DDSCAPS2_CUBEMAP_POSITIVEZ = 0x00004000;
      public const uint   DDSCAPS2_CUBEMAP_NEGATIVEZ = 0x00008000;
      public const uint   DDSCAPS2_VOLUME = 0x00200000;

        public const uint  DDS_CUBEMAP_ALLFACES = (DDSCAPS2_CUBEMAP_POSITIVEX |
                                                   DDSCAPS2_CUBEMAP_NEGATIVEX |
                                                   DDSCAPS2_CUBEMAP_POSITIVEY |
                                                   DDSCAPS2_CUBEMAP_NEGATIVEY |
                                                   DDSCAPS2_CUBEMAP_POSITIVEZ |
                                                   DDSCAPS2_CUBEMAP_NEGATIVEZ);

       public const uint  DDS_RESOURCE_DIMENSION_UNKNOWN = 0;
       public const uint  DDS_RESOURCE_DIMENSION_BUFFER = 1;
       public const uint  DDS_RESOURCE_DIMENSION_TEXTURE1D = 2;
       public const uint  DDS_RESOURCE_DIMENSION_TEXTURE2D = 3;
       public const uint  DDS_RESOURCE_DIMENSION_TEXTURE3D = 4;

       public const uint   DDS_RESOURCE_MISC_TEXTURECUBE = 0x00000004;

        public const uint  DDS_FOURCC_DX10 = 0x30315844;
        public const uint  DDS_FOURCC_DXT1 = 0x31545844;
        public const uint  DDS_FOURCC_DXT2 = 0x32545844;
        public const uint  DDS_FOURCC_DXT3 = 0x33545844;
        public const uint  DDS_FOURCC_DXT4 = 0x34545844;
        public const uint  DDS_FOURCC_DXT5 = 0x35545844;

       public const uint  DDS_DDPF_ALPHAPIXELS = 0x00000001;
       public const uint  DDS_DDPF_ALPHA = 0x00000002;
       public const uint  DDS_DDPF_FOURCC = 0x00000004;
       public const uint  DDS_DDPF_RGB = 0x00000040;
       public const uint  DDS_DDPF_YUV = 0x00000200;
       public const uint  DDS_DDPF_LUMINANCE = 0x00020000;
    }
}
