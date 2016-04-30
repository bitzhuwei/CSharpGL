using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexLineInTriangleSearcher : ZeroIndexLineSearcher
    {
        internal override uint[] Search(RenderEventArgs e,
            int x, int y, int canvasWidth, int canvasHeight,
            uint lastVertexId, CSharpGL.ZeroIndexModernRenderer zeroIndexModernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.Lines, BufferUsage.StaticDraw))
            {
                buffer.Alloc(6);
                buffer[0] = lastVertexId - 1; buffer[1] = lastVertexId - 0;
                buffer[2] = lastVertexId - 2; buffer[3] = lastVertexId - 1;
                buffer[4] = lastVertexId - 0; buffer[5] = lastVertexId - 2;
                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            zeroIndexModernRenderer.Render4Picking(e, indexBufferPtr);
            uint id = zeroIndexModernRenderer.ReadPixel(x, y, canvasHeight);

            indexBufferPtr.Dispose();

            if (id <= 2)
            {
                return new uint[] { lastVertexId - (id + 1) % 3, lastVertexId - id, };
            }
            else { throw new Exception(string.Format("this should not happen!")); }
        }
    }
}
