using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts.FreeTypes
{
    [StructLayout(LayoutKind.Sequential)]
    public class FT_ListRec
    {
        public System.IntPtr head;
        public System.IntPtr tail;
    }
}
