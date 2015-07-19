using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    [Flags]
    public enum ClassStyles : uint
    {
        ByteAlignClient = 0x1000,
        ByteAlignWindow = 0x2000,
        ClassDC = 0x40,
        DoubleClicks = 0x8,
        DropShadow = 0x20000,
        GlobalClass = 0x4000,
        HorizontalRedraw = 0x2,
        NoClose = 0x200,
        OwnDC = 0x20,
        ParentDC = 0x80,
        SaveBits = 0x800,
        VerticalRedraw = 0x1
    }
}
