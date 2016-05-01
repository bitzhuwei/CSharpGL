using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexLineInPolygonSearcher : ZeroIndexLineSearcher
    {
        internal override uint[] Search(RenderEventArgs e,
            int x, int y, int canvasWidth, int canvasHeight,
            uint lastVertexId, CSharpGL.ZeroIndexModernRenderer zeroIndexModernRenderer)
        {
            if (0 < lastVertexId)
            { return new uint[] { lastVertexId - 1, lastVertexId, }; }
            else
            { return new uint[] { (uint)(zeroIndexModernRenderer.Length - 1), lastVertexId, }; }
        }
    }
}
