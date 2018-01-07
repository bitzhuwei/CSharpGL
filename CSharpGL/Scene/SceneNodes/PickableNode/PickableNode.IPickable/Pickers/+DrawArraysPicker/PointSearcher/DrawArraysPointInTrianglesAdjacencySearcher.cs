using System;

namespace CSharpGL
{
    internal class DrawArraysPointInTrianglesAdjacencySearcher : DrawArraysPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg,
            uint lastVertexId, DrawArraysPicker picker)
        {
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, 3, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = lastVertexId - 0;
                array[1] = lastVertexId - 2;
                array[2] = lastVertexId - 4;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Points);
            picker.Node.Render4InnerPicking(arg, ControlMode.ByFrame, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (lastVertexId - 0 == id || lastVertexId - 2 == id || lastVertexId - 4 == id)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}