namespace CSharpGL
{
    internal class DrawArraysLineInQuadSearcher : DrawArraysLineSearcher
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
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, 8, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = flatColorVertexId - 1; array[1] = flatColorVertexId - 0;
                array[2] = flatColorVertexId - 2; array[3] = flatColorVertexId - 1;
                array[4] = flatColorVertexId - 3; array[5] = flatColorVertexId - 2;
                array[6] = flatColorVertexId - 0; array[7] = flatColorVertexId - 3;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, IndexAccessMode.ByFrame, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id + 3 == flatColorVertexId)
            { return new uint[] { id + 3, id, }; }
            else
            { return new uint[] { id - 1, id, }; }
        }
    }
}