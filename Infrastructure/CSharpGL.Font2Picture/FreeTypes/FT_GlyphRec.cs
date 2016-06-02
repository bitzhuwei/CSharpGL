using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{

    [StructLayout(LayoutKind.Sequential)]
    public class FT_GlyphRec
    {
        public System.IntPtr library;
        public System.IntPtr clazz;
        public int format;
        public FT_Vector advance;
    }
}
