namespace CSharpGL
{
    internal class DrawArraysLineInTrianglesAdjacencySearcher : DrawArraysLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="flatColorVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            uint flatColorVertexId, uint stageVertexId, DrawArraysPicker picker)
        {
            var array = new uint[] 
            { 
                flatColorVertexId - 2, flatColorVertexId - 0, 
                flatColorVertexId - 4, flatColorVertexId - 2, 
                flatColorVertexId - 0, flatColorVertexId - 4 
            };
            IndexBuffer buffer = array.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id + 4 == stageVertexId)
            { return new uint[] { id + 4, id, }; }
            if (id + 2 == stageVertexId)
            { return new uint[] { id - 2, id, }; }
            if (id + 0 == stageVertexId)
            { return new uint[] { id - 2, id, }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}