using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexPointInTrianglesAdjacencySearcher : ZeroIndexPointSearcher
    {
        internal override uint Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.Points, BufferUsage.StaticDraw))
            {
                buffer.Alloc(3);
                unsafe
                {
                    var array = (uint*)buffer.FirstElement();
                    array[0] = lastVertexId - 0;
                    array[1] = lastVertexId - 2;
                    array[2] = lastVertexId - 4;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();

            if (lastVertexId - 0 == id || lastVertexId - 2 == id || lastVertexId - 4 == id)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}
