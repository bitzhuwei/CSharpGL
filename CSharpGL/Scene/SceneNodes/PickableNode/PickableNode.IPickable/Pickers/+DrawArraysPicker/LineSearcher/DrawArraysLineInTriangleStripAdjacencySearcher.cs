namespace CSharpGL
{
    internal class DrawArraysLineInTriangleStripAdjacencySearcher : DrawArraysLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            uint lastVertexId, DrawArraysPicker picker)
        {
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, 6, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = lastVertexId - 2; array[1] = lastVertexId - 0;
                array[2] = lastVertexId - 4; array[3] = lastVertexId - 2;
                array[4] = lastVertexId - 0; array[5] = lastVertexId - 4;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, IndexAccessMode.ByFrame, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id + 4 == lastVertexId)
            { return new uint[] { id + 4, id, }; }
            else
            { return new uint[] { id - 2, id, }; }
        }
    }
}