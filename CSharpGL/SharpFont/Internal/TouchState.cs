using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{
    [Flags]
    enum TouchState
    {
        None = 0,
        X = 0x1,
        Y = 0x2,
        Both = X | Y
    }
}
