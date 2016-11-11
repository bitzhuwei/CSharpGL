using System;

namespace CSharpGL
{
    internal class OneIndexPointInQuadSearcher : OneIndexPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="primitiveInfo"></param>
        /// <param name="modernRenderer"></param>
        /// <returns></returns>
        internal override uint Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo primitiveInfo,
            OneIndexRenderer modernRenderer)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length != 4) { throw new ArgumentException(); }

            OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.Points, IndexElementType.UInt, 4);
            unsafe
            {
                var array = (uint*)bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = indexList[0];
                array[1] = indexList[1];
                array[2] = indexList[2];
                array[3] = indexList[3];
                bufferPtr.UnmapBuffer();
            }
            modernRenderer.Render4InnerPicking(arg, bufferPtr);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            bufferPtr.Dispose();

            if (id == indexList[0] || id == indexList[1]
                || id == indexList[2] || id == indexList[3])
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}