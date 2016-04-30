using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    abstract class ZeroIndexLineSearcher
    {
        internal abstract uint[] Search(RenderEventArgs e, int x, int y, int canvasWidth, int canvasHeight, uint lastVertexId, CSharpGL.ZeroIndexModernRenderer zeroIndexModernRenderer);
    }
}
