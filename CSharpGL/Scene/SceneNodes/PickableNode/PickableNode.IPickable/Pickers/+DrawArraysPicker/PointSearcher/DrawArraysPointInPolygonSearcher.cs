using System;

namespace CSharpGL
{
    internal class DrawArraysPointInPolygonSearcher : DrawArraysPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg,
            uint singleNodeVertexId, uint stageVertexId, DrawArraysPicker picker)
        {
            var cmd = picker.DrawCommand as DrawArraysCmd;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            var drawCmd = new DrawArraysCmd(DrawMode.Points, cmd.MaxVertexCount, cmd.FirstVertex, cmd.VertexCount);
            picker.Node.Render4InnerPicking(arg, drawCmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            uint baseId = stageVertexId - singleNodeVertexId;
            if (baseId + cmd.FirstVertex <= id && id < baseId + cmd.FirstVertex + cmd.VertexCount)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}