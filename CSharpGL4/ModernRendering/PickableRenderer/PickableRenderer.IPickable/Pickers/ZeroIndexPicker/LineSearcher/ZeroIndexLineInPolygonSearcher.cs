namespace CSharpGL
{
    internal class ZeroIndexLineInPolygonSearcher : ZeroIndexLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="lastVertexId"></param>
        /// <param name="modernRenderer"></param>
        /// <returns></returns>
        internal override uint[] Search(PickEventArgs arg,
            uint lastVertexId, ZeroIndexPicker picker)
        {
            var zeroIndexBuffer = picker.Renderer.IndexBuffer as ZeroIndexBuffer;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            ZeroIndexBuffer indexBuffer = ZeroIndexBuffer.Create(DrawMode.LineLoop, zeroIndexBuffer.FirstVertex, zeroIndexBuffer.RenderingVertexCount, zeroIndexBuffer.PrimCount);
            picker.Renderer.Render4InnerPicking(arg, indexBuffer);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.Position.X, arg.Position.Y);

            indexBuffer.Dispose();

            if (id == zeroIndexBuffer.FirstVertex)
            { return new uint[] { (uint)(zeroIndexBuffer.FirstVertex + zeroIndexBuffer.RenderingVertexCount - 1), id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}