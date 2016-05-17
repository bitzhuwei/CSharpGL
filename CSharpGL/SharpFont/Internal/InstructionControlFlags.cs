using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{

    [Flags]
    public enum InstructionControlFlags
    {
        None,
        InhibitGridFitting = 0x1,
        UseDefaultGraphicsState = 0x2
    }
}
