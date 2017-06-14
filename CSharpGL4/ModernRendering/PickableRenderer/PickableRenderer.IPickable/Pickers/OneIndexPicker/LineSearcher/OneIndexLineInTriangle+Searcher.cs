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
        internal override uint[] Search(PickEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo primitiveInfo,
            OneIndexPicker modernRenderer)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length != 3) { throw new ArgumentException(); }

            //if (indexList[0] == indexList[1]) { return new uint[] { indexList[0], indexList[2], }; }
            //else if (indexList[0] == indexList[2]) { return new uint[] { indexList[0], indexList[1], }; }
            //else if (indexList[1] == indexList[2]) { return new uint[] { indexList[1], indexList[0], }; }

            var targetIndexList = new uint[6] { indexList[0], indexList[1], indexList[1], indexList[2], indexList[2], indexList[0], };
            OneIndexBuffer buffer = targetIndexList.GenIndexBuffer(DrawMode.Lines, BufferUsage.StaticDraw);
            modernRenderer.Renderer.Render4InnerPicking(arg, buffer);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            buffer.Dispose();

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