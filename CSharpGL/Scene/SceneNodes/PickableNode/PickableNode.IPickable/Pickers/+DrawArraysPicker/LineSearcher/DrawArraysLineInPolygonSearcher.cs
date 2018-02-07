namespace CSharpGL
{
    internal class DrawArraysLineInPolygonSearcher : DrawArraysLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="flatColorVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg, uint flatColorVertexId, DrawArraysPicker picker)
        {
            var cmd = picker.DrawCommand as DrawArraysCmd;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            DrawArraysCmd drawCmd = new DrawArraysCmd(DrawMode.LineLoop, cmd.FirstVertex, cmd.RenderingVertexCount, cmd.InstanceCount, cmd.FrameCount);
            picker.Node.Render4InnerPicking(arg, IndexAccessMode.ByFrame, drawCmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            if (id == cmd.FirstVertex)
            { return new uint[] { (uint)(cmd.FirstVertex + cmd.RenderingVertexCount - 1), id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}