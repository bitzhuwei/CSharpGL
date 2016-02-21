using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.GlyphTextures.FromTTF.FreeTypes
{
    [StructLayout(LayoutKind.Sequential)]
    public class FT_Vector
    {
        public int x;
        public int y;
    }
}
