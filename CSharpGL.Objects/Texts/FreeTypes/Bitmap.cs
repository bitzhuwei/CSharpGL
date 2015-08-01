using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts.FreeTypes
{

    [StructLayout(LayoutKind.Sequential)]
    public class Bitmap
    {
        public int rows;
        public int width;
        public int pitch;
        public IntPtr buffer;
        public short num_grays;
        public sbyte pixel_mode;
        public sbyte palette_mode;
        public IntPtr palette;
    }
}
