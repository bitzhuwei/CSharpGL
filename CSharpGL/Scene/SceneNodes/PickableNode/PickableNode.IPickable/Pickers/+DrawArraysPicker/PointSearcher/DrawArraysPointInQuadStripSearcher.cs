using System;

namespace CSharpGL
{
    internal class DrawArraysPointInQuadStripSearcher : DrawArraysPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg, uint lastVertexId, DrawArraysPicker picker)
        {
            IndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, 4, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = lastVertexId - 0;
                array[1] = lastVertexId - 1;
                array[2] = lastVertexId - 2;
                array[3] = lastVertexId - 3;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Points);
            picker.Node.Render4InnerPicking(arg, IndexAccessMode.ByFrame, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();
            if (lastVertexId - 3 <= id && id <= lastVertexId - 0)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}