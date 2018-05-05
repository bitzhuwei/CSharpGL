using System;

namespace CSharpGL
{
    internal class DrawArraysPointInPolygonSearcher : DrawArraysPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="flatColorVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg,
            uint flatColorVertexId, DrawArraysPicker picker)
        {
            var cmd = picker.DrawCommand as DrawArraysCmd;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            var drawCmd = new DrawArraysCmd(DrawMode.Points, cmd.MaxVertexCount, cmd.FirstVertex, cmd.VertexCount);
            picker.Node.Render4InnerPicking(arg, IndexAccessMode.ByFrame, drawCmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            if (cmd.FirstVertex <= id && id < cmd.FirstVertex + cmd.VertexCount)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}