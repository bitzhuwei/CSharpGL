using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexPointInQuadSearcher : ZeroIndexPointSearcher
    {
        internal override uint Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.Points, BufferUsage.StaticDraw))
            {
                buffer.Alloc(4);
                unsafe
                {
                    var array = (uint*)buffer.FirstElement();
                    buffer[0] = lastVertexId - 0;
                    buffer[1] = lastVertexId - 1;
                    buffer[2] = lastVertexId - 2;
                    buffer[3] = lastVertexId - 3;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();

            if (lastVertexId - 3 <= id && id <= lastVertexId - 0)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}
