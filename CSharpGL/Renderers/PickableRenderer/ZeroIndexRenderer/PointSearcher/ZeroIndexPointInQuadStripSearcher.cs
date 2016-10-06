using System;

namespace CSharpGL
{
    internal class ZeroIndexPointInQuadStripSearcher : ZeroIndexPointSearcher
    {
        internal override uint Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Points, BufferUsage.StaticDraw))
            {
                buffer.Create(4);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    array[0] = lastVertexId - 0;
                    array[1] = lastVertexId - 1;
                    array[2] = lastVertexId - 2;
                    array[3] = lastVertexId - 3;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, arg.CanvasRect.Height - y - 1);

            indexBufferPtr.Dispose();
            if (lastVertexId - 3 <= id && id <= lastVertexId - 0)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}