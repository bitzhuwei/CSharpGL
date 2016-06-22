using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public enum UniformType : uint
    {
        MATERIAL = 0,
        TRANSFORM0 = 1,
        TRANSFORM1 = 2,
        INDIRECTION = 3,
        CONSTANT = 0,
        PER_FRAME = 1,
        PER_PASS = 2
    }
}
