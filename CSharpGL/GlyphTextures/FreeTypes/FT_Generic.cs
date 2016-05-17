using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.GlyphTextures.FreeTypes
{

    [StructLayout(LayoutKind.Sequential)]
    class FT_Generic
    {
        public System.IntPtr data;
        public System.IntPtr finalizer;
    }
}
