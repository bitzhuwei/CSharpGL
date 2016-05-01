using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexLineInQuadSearcher : ZeroIndexLineSearcher
    {
        internal override uint[] Search(RenderEventArgs e,
            int x, int y, int canvasWidth, int canvasHeight,
            uint lastVertexId, CSharpGL.ZeroIndexModernRenderer zeroIndexModernRenderer)
        {
            if (lastVertexId % 4 == 0)
            { return new uint[] { lastVertexId + 4 - 1, lastVertexId, }; }
            else
            { return new uint[] { lastVertexId - 1, lastVertexId, }; }
        }
    }
}
