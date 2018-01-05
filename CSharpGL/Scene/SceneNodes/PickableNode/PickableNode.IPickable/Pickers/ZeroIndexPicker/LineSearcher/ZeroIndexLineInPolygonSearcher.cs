namespace CSharpGL
{
    internal class ZeroIndexLineInPolygonSearcher : ZeroIndexLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg, uint lastVertexId, ZeroIndexPicker picker)
        {
            var zeroIndexBuffer = picker.Node.PickingRenderUnit.VertexArrayObject.DrawCommand as DrawArraysCmd;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            DrawArraysCmd drawCmd = new DrawArraysCmd(DrawMode.LineLoop, zeroIndexBuffer.FirstVertex, zeroIndexBuffer.RenderingVertexCount, zeroIndexBuffer.InstanceCount);
            picker.Node.Render4InnerPicking(arg, drawCmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            if (id == zeroIndexBuffer.FirstVertex)
            { return new uint[] { (uint)(zeroIndexBuffer.FirstVertex + zeroIndexBuffer.RenderingVertexCount - 1), id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}