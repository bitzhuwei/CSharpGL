using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Texts.FreeTypes
{
    /// <summary>
    /// 字形的包围盒。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class BBox
    {
        public int xMin, yMin;
        public int xMax, yMax;
    }
}
