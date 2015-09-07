using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public struct DDS_HEADER
    {
      public  uint size;
      public  uint flags;
      public  uint height;
      public  uint width;
      public  uint pitch_or_linear_size;
      public  uint depth;
      public  uint mip_levels;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
      public  uint[] reserved;// = new uint[11];
      public  DDS_PIXELFORMAT ddspf;
      public  uint caps1;
      public  uint caps2;
      public  uint caps3;
      public  uint caps4;
      public  uint reserved2;
    }
}
