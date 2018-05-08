using System;

namespace CSharpGL
{
    internal class DrawArraysLineInTriangleFanSearcher : DrawArraysLineSearcher
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
                array[0] = 0; array[1] = flatColorVertexId - 1;
                array[2] = flatColorVertexId - 1; array[3] = flatColorVertexId - 0;
                array[4] = flatColorVertexId - 0; array[5] = 0;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg,  cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id + 1 == flatColorVertexId)
            { return new uint[] { 0, flatColorVertexId - 1, }; }
            else if (id == flatColorVertexId)
            { return new uint[] { flatColorVertexId - 1, flatColorVertexId - 0, }; }
            else if (id == 0)
            { return new uint[] { flatColorVertexId - 0, 0, }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}