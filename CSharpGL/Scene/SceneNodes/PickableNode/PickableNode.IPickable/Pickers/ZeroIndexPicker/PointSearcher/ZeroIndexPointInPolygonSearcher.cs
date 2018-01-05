using System;

namespace CSharpGL
{
    internal class ZeroIndexPointInPolygonSearcher : ZeroIndexPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="lastVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg,
            uint lastVertexId, ZeroIndexPicker picker)
        {
            var zeroIndexBuffer = picker.Node.PickingRenderUnit.VertexArrayObject.DrawCommand as ZeroIndexBuffer;
            // when the temp index buffer could be long, it's no longer needed.
            // what a great OpenGL API design!
            ZeroIndexBuffer indexBuffer = ZeroIndexBuffer.Create(DrawMode.Points, zeroIndexBuffer.FirstVertex, zeroIndexBuffer.RenderingVertexCount, zeroIndexBuffer.InstanceCount);
            picker.Node.Render4InnerPicking(arg, indexBuffer);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            indexBuffer.Dispose();

            if (zeroIndexBuffer.FirstVertex <= id
                && id < zeroIndexBuffer.FirstVertex + zeroIndexBuffer.RenderingVertexCount)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}