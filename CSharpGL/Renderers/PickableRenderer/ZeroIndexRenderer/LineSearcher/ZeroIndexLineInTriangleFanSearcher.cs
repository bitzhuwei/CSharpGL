using System;

namespace CSharpGL
{
    internal class ZeroIndexLineInTriangleFanSearcher : ZeroIndexLineSearcher
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
        internal override uint[] Search(RenderEventArgs arg,
            int x, int y,
            uint lastVertexId, ZeroIndexRenderer modernRenderer)
        {
            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Lines, BufferUsage.StaticDraw))
            {
                buffer.Alloc(6);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    array[0] = 0; array[1] = lastVertexId - 1;
                    array[2] = lastVertexId - 1; array[3] = lastVertexId - 0;
                    array[4] = lastVertexId - 0; array[5] = 0;
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y);

            indexBufferPtr.Dispose();

            if (id + 1 == lastVertexId)
            { return new uint[] { 0, lastVertexId - 1, }; }
            else if (id == lastVertexId)
            { return new uint[] { lastVertexId - 1, lastVertexId - 0, }; }
            else if (id == 0)
            { return new uint[] { lastVertexId - 0, 0, }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}