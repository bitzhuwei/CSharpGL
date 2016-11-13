using System;

namespace CSharpGL
{
    internal class OneIndexLineInQuadSearcher : OneIndexLineSearcher
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
            if (indexList.Length != 4) { throw new ArgumentException(); }

            var targetIndexList = new uint[8] { indexList[0], indexList[1], indexList[1], indexList[2], indexList[2], indexList[3], indexList[3], indexList[0], };
            OneIndexBuffer buffer = targetIndexList.GetOneIndexBuffer(DrawMode.Lines, BufferUsage.StaticDraw);
            modernRenderer.Render4InnerPicking(arg, buffer);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            buffer.Dispose();

            if (id == indexList[1])
            { return new uint[] { indexList[0], indexList[1], }; }
            else if (id == indexList[2])
            { return new uint[] { indexList[1], indexList[2], }; }
            else if (id == indexList[3])
            { return new uint[] { indexList[2], indexList[3], }; }
            else if (id == indexList[0])
            { return new uint[] { indexList[2], indexList[0], }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}