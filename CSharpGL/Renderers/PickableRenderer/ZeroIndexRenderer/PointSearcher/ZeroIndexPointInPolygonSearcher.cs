using System;

namespace CSharpGL
{
    internal class ZeroIndexPointInPolygonSearcher : ZeroIndexPointSearcher
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
            ZeroIndexBufferPtr zeroIndexBufferPtr = modernRenderer.IndexBufferPtr;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            ZeroIndexBufferPtr indexBufferPtr = ZeroIndexBufferPtr.Create(DrawMode.Points, zeroIndexBufferPtr.FirstVertex, zeroIndexBufferPtr.RenderingVertexCount, zeroIndexBufferPtr.PrimCount);
            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            indexBufferPtr.Dispose();

            if (zeroIndexBufferPtr.FirstVertex <= id
                && id < zeroIndexBufferPtr.FirstVertex + zeroIndexBufferPtr.RenderingVertexCount)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}