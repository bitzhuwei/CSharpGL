using System;
namespace CSharpGL
{
    internal class DrawArraysLineInPolygonSearcher : DrawArraysLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            uint singleNodeVertexId, uint stageVertexId, DrawArraysPicker picker)
        {
            var cmd = picker.DrawCommand as DrawArraysCmd;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            DrawArraysCmd drawCmd = new DrawArraysCmd(DrawMode.LineLoop, cmd.MaxVertexCount, cmd.FirstVertex, cmd.VertexCount);
            picker.Node.Render4InnerPicking(arg, drawCmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            uint baseId = stageVertexId - singleNodeVertexId;
            if (id == baseId + cmd.FirstVertex)
            { return new uint[] { (uint)(baseId + cmd.FirstVertex + cmd.VertexCount - 1), id, }; }
            else if (baseId + cmd.FirstVertex < id && id <= (uint)(baseId + cmd.FirstVertex + cmd.VertexCount - 1))
            { return new uint[] { id - 1, id, }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}