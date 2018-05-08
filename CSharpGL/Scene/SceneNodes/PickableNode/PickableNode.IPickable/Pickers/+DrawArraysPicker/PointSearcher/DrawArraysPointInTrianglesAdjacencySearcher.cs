using System;

namespace CSharpGL
{
    internal class DrawArraysPointInTrianglesAdjacencySearcher : DrawArraysPointSearcher
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
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, 3, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = flatColorVertexId - 0;
                array[1] = flatColorVertexId - 2;
                array[2] = flatColorVertexId - 4;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Points);
            picker.Node.Render4InnerPicking(arg,  cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (flatColorVertexId - 0 == id || flatColorVertexId - 2 == id || flatColorVertexId - 4 == id)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}