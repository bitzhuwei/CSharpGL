namespace CSharpGL
{
    internal class DrawArraysLineInQuadSearcher : DrawArraysLineSearcher
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
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, 8, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = lastVertexId - 1; array[1] = lastVertexId - 0;
                array[2] = lastVertexId - 2; array[3] = lastVertexId - 1;
                array[4] = lastVertexId - 3; array[5] = lastVertexId - 2;
                array[6] = lastVertexId - 0; array[7] = lastVertexId - 3;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, IndexAccessMode.ByFrame, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id + 3 == lastVertexId)
            { return new uint[] { id + 3, id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}