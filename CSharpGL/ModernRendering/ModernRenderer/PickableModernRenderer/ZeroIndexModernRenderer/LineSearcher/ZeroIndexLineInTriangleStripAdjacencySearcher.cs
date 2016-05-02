using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexLineInTriangleStripAdjacencySearcher : ZeroIndexLineSearcher
    {
        internal override uint[] Search(RenderEventArgs arg,
            int x, int y, 
            uint lastVertexId, ZeroIndexModernRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.Lines, BufferUsage.StaticDraw))
            {
                buffer.Alloc(6);
                unsafe
                {
                    var array = (uint*)buffer.FirstElement();
                    array[0] = lastVertexId - 2; array[1] = lastVertexId - 0;
                    array[2] = lastVertexId - 4; array[3] = lastVertexId - 2;
                    array[4] = lastVertexId - 0; array[5] = lastVertexId - 4;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();

            if (id + 4 == lastVertexId)
            { return new uint[] { id + 4, id, }; }
            else
            { return new uint[] { id - 2, id, }; }
        }
    }
}
