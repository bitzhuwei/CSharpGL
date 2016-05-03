using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    abstract class OneIndexLineSearcher
    {
        internal abstract uint[] Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId,RecognizedPrimitiveIndex lastIndexId,
            OneIndexRenderer modernRenderer);
        
    }
}
