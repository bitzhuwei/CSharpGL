namespace CSharpGL
{
    internal class DrawArraysLineInTriangleStripAdjacencySearcher : DrawArraysLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="flatColorVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            uint flatColorVertexId, DrawArraysPicker picker)
        {
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, 6, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = flatColorVertexId - 2; array[1] = flatColorVertexId - 0;
                array[2] = flatColorVertexId - 4; array[3] = flatColorVertexId - 2;
                array[4] = flatColorVertexId - 0; array[5] = flatColorVertexId - 4;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, IndexAccessMode.ByFrame, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id + 4 == flatColorVertexId)
            { return new uint[] { id + 4, id, }; }
            else
            { return new uint[] { id - 2, id, }; }
        }
    }
}