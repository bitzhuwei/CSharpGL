using System;

namespace CSharpGL
{
    internal class ZeroIndexPointInTriangleStripAdjacencySearcher : ZeroIndexPointSearcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="lastVertexId"></param>
        /// <param name="modernRenderer"></param>
        /// <returns></returns>
        internal override uint Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Points, BufferUsage.StaticDraw))
            {
                buffer.Alloc(3);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    array[0] = lastVertexId - 0;
                    array[1] = lastVertexId - 2;
                    array[2] = lastVertexId - 4;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            indexBufferPtr.Dispose();

            if (id == lastVertexId - 0
                || id == lastVertexId - 2
                || id == lastVertexId - 4)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}