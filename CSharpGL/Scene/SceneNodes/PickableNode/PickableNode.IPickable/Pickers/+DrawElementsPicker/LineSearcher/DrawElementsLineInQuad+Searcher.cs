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
        /// <param name="singleNodeVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            RecognizedPrimitiveInfo primitiveInfo,
            uint singleNodeVertexId, uint stageVertexId,
            DrawElementsPicker picker)
        {
            uint[] vertexIds = primitiveInfo.VertexIds;
            if (vertexIds.Length != 4) { throw new ArgumentException(); }

            var targetVertexIds = new uint[8] { vertexIds[0], vertexIds[1], vertexIds[1], vertexIds[2], vertexIds[2], vertexIds[3], vertexIds[3], vertexIds[0], };
            IndexBuffer buffer = targetVertexIds.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            uint baseId = stageVertexId - singleNodeVertexId;
            if (id == baseId + vertexIds[1])
            { return new uint[] { baseId + vertexIds[0], id, }; }
            else if (id == baseId + vertexIds[2])
            { return new uint[] { baseId + vertexIds[1], id, }; }
            else if (id == baseId + vertexIds[3])
            { return new uint[] { baseId + vertexIds[2], id, }; }
            else if (id == baseId + vertexIds[0])
            { return new uint[] { baseId + vertexIds[2], id, }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}