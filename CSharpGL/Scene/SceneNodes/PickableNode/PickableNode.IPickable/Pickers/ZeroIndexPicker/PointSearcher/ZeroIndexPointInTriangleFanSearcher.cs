using System;

namespace CSharpGL
{
    internal class ZeroIndexPointInTriangleFanSearcher : ZeroIndexPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg, uint lastVertexId, ZeroIndexPicker picker)
        {
            OneIndexBuffer buffer = GLBuffer.Create(IndexBufferElementType.UInt, 3, DrawMode.Points, BufferUsage.StaticDraw);
            unsafe
            {
                var array = (uint*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
                array[0] = 0;
                array[1] = lastVertexId - 1;
                array[2] = lastVertexId - 0;
                buffer.UnmapBuffer();
            }
            picker.Node.Render4InnerPicking(arg, buffer);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (0 == id || lastVertexId - 1 == id || lastVertexId - 0 == id)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}