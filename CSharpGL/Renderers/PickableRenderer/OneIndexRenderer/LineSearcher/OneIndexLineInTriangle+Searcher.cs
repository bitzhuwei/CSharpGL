using System;

namespace CSharpGL
{
    internal class OneIndexLineInTriangleSearcher : OneIndexLineSearcher
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
        internal override uint[] Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo primitiveInfo,
            OneIndexRenderer modernRenderer)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length != 3) { throw new ArgumentException(); }

            //if (indexList[0] == indexList[1]) { return new uint[] { indexList[0], indexList[2], }; }
            //else if (indexList[0] == indexList[2]) { return new uint[] { indexList[0], indexList[1], }; }
            //else if (indexList[1] == indexList[2]) { return new uint[] { indexList[1], indexList[0], }; }

            OneIndexBufferPtr bufferPtr = OneIndexBufferPtr.Create(BufferUsage.StaticDraw, DrawMode.Lines, IndexElementType.UInt, 6);
            unsafe
            {
                var array = (uint*)bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = indexList[0]; array[1] = indexList[1];
                array[2] = indexList[1]; array[3] = indexList[2];
                array[4] = indexList[2]; array[5] = indexList[0];
                bufferPtr.UnmapBuffer();
            }
            modernRenderer.Render4InnerPicking(arg, bufferPtr);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            bufferPtr.Dispose();

            if (id == indexList[1])
            { return new uint[] { indexList[0], indexList[1], }; }
            else if (id == indexList[2])
            { return new uint[] { indexList[1], indexList[2], }; }
            else if (id == indexList[0])
            { return new uint[] { indexList[2], indexList[0], }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}