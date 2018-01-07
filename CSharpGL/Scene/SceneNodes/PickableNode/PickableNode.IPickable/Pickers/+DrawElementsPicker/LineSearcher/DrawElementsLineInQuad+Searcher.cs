using System;

namespace CSharpGL
{
    internal class DrawElementsLineInQuadSearcher : DrawElementsLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            RecognizedPrimitiveInfo primitiveInfo,
            DrawElementsPicker picker)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length != 4) { throw new ArgumentException(); }

            var targetIndexList = new uint[8] { indexList[0], indexList[1], indexList[1], indexList[2], indexList[2], indexList[3], indexList[3], indexList[0], };
            IndexBuffer buffer = targetIndexList.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, ControlMode.ByFrame, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

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