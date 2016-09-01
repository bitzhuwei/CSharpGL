using System.Runtime.InteropServices;

namespace SimLab.SimGrid.Geometry
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LineIndex
    {
        public uint p0;
        public uint p1;
    }
}