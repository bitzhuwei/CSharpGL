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
            ZeroIndexBufferPtr indexBufferPtr = null;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            using (var buffer = new ZeroIndexBuffer(DrawMode.Points,
                zeroIndexBufferPtr.FirstVertex, zeroIndexBufferPtr.VertexCount))
            {
                indexBufferPtr = buffer.GetBufferPtr() as ZeroIndexBufferPtr;
            }
            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            indexBufferPtr.Dispose();

            if (zeroIndexBufferPtr.FirstVertex <= id
                && id < zeroIndexBufferPtr.FirstVertex + zeroIndexBufferPtr.VertexCount)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}