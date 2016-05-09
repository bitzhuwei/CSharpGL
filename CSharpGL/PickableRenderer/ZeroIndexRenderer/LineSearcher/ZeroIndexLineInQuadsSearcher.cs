using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexLineInQuadSearcher : ZeroIndexLineSearcher
    {
        internal override uint[] Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.Lines, BufferUsage.StaticDraw))
            {
                buffer.Alloc(8);
                unsafe
                {
                    var array = (uint*)buffer.FirstElement();
                    buffer[0] = lastVertexId - 1; buffer[1] = lastVertexId - 0;
                    buffer[2] = lastVertexId - 2; buffer[3] = lastVertexId - 1;
                    buffer[4] = lastVertexId - 3; buffer[5] = lastVertexId - 2;
                    buffer[6] = lastVertexId - 0; buffer[7] = lastVertexId - 3;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();

            if (id + 3 == lastVertexId)
            { return new uint[] { id + 3, id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}
