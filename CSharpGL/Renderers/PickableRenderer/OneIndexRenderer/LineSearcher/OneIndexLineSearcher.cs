using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    abstract class OneIndexLineSearcher
    {
        internal abstract uint[] Search(RenderEventArg arg,
            int x, int y,
            RecognizedPrimitiveIndex lastIndexId,
            OneIndexRenderer modernRenderer);

    }
}
