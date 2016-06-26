using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexPointInTriangleFanSearcher : ZeroIndexPointSearcher
    {
        internal override uint Search(RenderEventArg arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer<uint>(DrawMode.Points, BufferUsage.StaticDraw))
            {
                buffer.Alloc(3);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    array[0] = 0;
                    array[1] = lastVertexId - 1;
                    array[2] = lastVertexId - 0;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();

            if (0 == id || lastVertexId - 1 == id || lastVertexId - 0 == id)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}
