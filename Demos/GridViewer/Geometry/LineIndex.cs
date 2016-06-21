using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimLab.SimGrid.Geometry
{

    [StructLayout(LayoutKind.Sequential)]
    public struct LineIndex
    {
       public uint p0;
       public uint p1;
    }
}
