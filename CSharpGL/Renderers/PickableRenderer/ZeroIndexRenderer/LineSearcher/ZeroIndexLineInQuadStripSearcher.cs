using System;

namespace CSharpGL
{
    internal class ZeroIndexLineInQuadStripSearcher : ZeroIndexLineSearcher
    {
        internal override uint[] Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UnsignedInt, DrawMode.Lines, BufferUsage.StaticDraw))
            {
                buffer.Create(8);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    array[0] = lastVertexId - 0; array[1] = lastVertexId - 2;
                    array[2] = lastVertexId - 2; array[3] = lastVertexId - 3;
                    array[4] = lastVertexId - 3; array[5] = lastVertexId - 1;
                    array[6] = lastVertexId - 1; array[7] = lastVertexId - 0;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();
            if (id + 2 == lastVertexId)
            { return new uint[] { lastVertexId - 0, lastVertexId - 2, }; }
            else if (id + 3 == lastVertexId)
            { return new uint[] { lastVertexId - 2, lastVertexId - 3 }; }
            else if (id + 1 == lastVertexId)
            { return new uint[] { lastVertexId - 3, lastVertexId - 1, }; }
            else if (id + 0 == lastVertexId)
            { return new uint[] { lastVertexId - 1, lastVertexId - 0, }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}