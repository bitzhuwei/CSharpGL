using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexLineInTriangleStripSearcher : ZeroIndexLineSearcher
    {
        internal override uint[] Search(RenderEventArgs e, int x, int y, int canvasWidth, int canvasHeight, uint lastVertexId, CSharpGL.ZeroIndexModernRenderer zeroIndexModernRenderer)
        {
            throw new NotImplementedException();
        }
    }
}
