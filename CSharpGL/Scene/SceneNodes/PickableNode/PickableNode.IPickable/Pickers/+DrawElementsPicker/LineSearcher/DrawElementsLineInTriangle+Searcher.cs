using System;

namespace CSharpGL
{
    internal class DrawElementsLineInTriangleSearcher : DrawElementsLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            RecognizedPrimitiveInfo primitiveInfo,
            uint singleNodeVertexId, uint stageVertexId,
            DrawElementsPicker picker)
        {
            uint[] verttexIds = primitiveInfo.VertexIds;
            if (verttexIds.Length != 3) { throw new ArgumentException(); }

            //if (indexList[0] == indexList[1]) { return new uint[] { indexList[0], indexList[2], }; }
            //else if (indexList[0] == indexList[2]) { return new uint[] { indexList[0], indexList[1], }; }
            //else if (indexList[1] == indexList[2]) { return new uint[] { indexList[1], indexList[0], }; }

            var targetVertexIds = new uint[6] { verttexIds[0], verttexIds[1], verttexIds[1], verttexIds[2], verttexIds[2], verttexIds[0], };
            IndexBuffer buffer = targetVertexIds.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            uint baseId = stageVertexId - singleNodeVertexId;
            if (id == baseId + verttexIds[1])
            { return new uint[] { baseId + verttexIds[0], id, }; }
            else if (id == baseId + verttexIds[2])
            { return new uint[] { baseId + verttexIds[1], id, }; }
            else if (id == baseId + verttexIds[0])
            { return new uint[] { baseId + verttexIds[2], id, }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}