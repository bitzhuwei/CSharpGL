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
        internal override uint Search(PickEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo primitiveInfo,
            OneIndexPicker picker)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length != 4) { throw new ArgumentException(); }

            OneIndexBuffer buffer = indexList.GenIndexBuffer(DrawMode.Points, BufferUsage.StaticDraw);
            picker.Renderer.Render4InnerPicking(arg, buffer);
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            buffer.Dispose();

            if (id == indexList[0] || id == indexList[1]
                || id == indexList[2] || id == indexList[3])
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}