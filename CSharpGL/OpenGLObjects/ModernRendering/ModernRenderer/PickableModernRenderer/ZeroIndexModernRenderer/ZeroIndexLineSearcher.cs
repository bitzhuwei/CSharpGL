using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    abstract class ZeroIndexLineSearcher
    {
        internal abstract PickedGeometry Search(int x, int y, int canvasWidth, int canvasHeight, uint lastVertexId, CSharpGL.ZeroIndexModernRenderer zeroIndexModernRenderer);
    }
}
