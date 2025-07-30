using System;
namespace CSharpGL {
    internal class DrawArraysLineInPolygonSearcher : DrawArraysLineSearcher {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            uint singleNodeVertexId, uint stageVertexId, DrawArraysPicker picker) {
            var cmd = picker.DrawCommand as DrawArraysCmd;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            DrawArraysCmd drawCmd = new DrawArraysCmd(DrawMode.LineLoop, cmd.maxVertexCount, cmd.firstVertex, cmd.vertexCount);
            picker.Node.Render4InnerPicking(arg, drawCmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            uint baseId = stageVertexId - singleNodeVertexId;
            if (id == baseId + cmd.firstVertex) { return new uint[] { (uint)(baseId + cmd.firstVertex + cmd.vertexCount - 1), id, }; }
            else if (baseId + cmd.firstVertex < id && id <= (uint)(baseId + cmd.firstVertex + cmd.vertexCount - 1)) { return new uint[] { id - 1, id, }; }
            else { throw new Exception("This should not happen!"); }
        }
    }
}