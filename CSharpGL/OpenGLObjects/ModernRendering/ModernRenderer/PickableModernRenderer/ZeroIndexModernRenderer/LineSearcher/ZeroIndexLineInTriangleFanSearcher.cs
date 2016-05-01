using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    class ZeroIndexLineInTriangleFanSearcher : ZeroIndexLineSearcher
    {
        internal override uint[] Search(RenderEventArgs e,
            int x, int y, int canvasWidth, int canvasHeight,
            uint lastVertexId, ZeroIndexModernRenderer modernRenderer)
        {
            {
                uint first = 0;// this is the read triangle in ZeroIndexLineInTriangleFanSearcher.jpg
                OneIndexBufferPtr indexBufferPtr = null;
                using (var buffer = new OneIndexBuffer<uint>(DrawMode.Lines, BufferUsage.StaticDraw))
                {
                    buffer.Alloc((int)(lastVertexId * 2));
                    unsafe
                    {
                        var array = (uint*)buffer.FirstElement();
                        for (uint i = 0; i < lastVertexId; i++)
                        {
                            array[i * 2 + 0] = first;
                            array[i * 2 + 1] = first + (i + 1);
                        }
                    }
                    indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
                }

                modernRenderer.Render4Picking(e, indexBufferPtr);
                uint id = modernRenderer.ReadPixel(x, y, canvasHeight);

                indexBufferPtr.Dispose();

                if (first + 1 <= id && id <= lastVertexId)
                { return new uint[] { first, id, }; }
            }

            {
                uint first = 0;// this is the read triangle in ZeroIndexLineInTriangleFanSearcher.jpg
                OneIndexBufferPtr indexBufferPtr = null;
                using (var buffer = new OneIndexBuffer<uint>(DrawMode.Lines, BufferUsage.StaticDraw))
                {
                    buffer.Alloc((int)((lastVertexId - 1) * 2));
                    unsafe
                    {
                        var array = (uint*)buffer.FirstElement();
                        for (uint i = 0; i < lastVertexId; i++)
                        {
                            array[i * 2 + 0] = first + ((i + 1) - 1);
                            array[i * 2 + 1] = first + (i + 1);
                        }
                    }
                    indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
                }

                modernRenderer.Render4Picking(e, indexBufferPtr);
                uint id = modernRenderer.ReadPixel(x, y, canvasHeight);

                indexBufferPtr.Dispose();

                if (first + 2 <= id && id <= lastVertexId)
                { return new uint[] { id - 1, id, }; }
            }

            throw new Exception("this should not happen!");
        }
    }
}
