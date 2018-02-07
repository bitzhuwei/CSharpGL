using System;

namespace CSharpGL
{
    internal class DrawArraysLineInQuadStripSearcher : DrawArraysLineSearcher
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
                array[0] = flatColorVertexId - 0; array[1] = flatColorVertexId - 2;
                array[2] = flatColorVertexId - 2; array[3] = flatColorVertexId - 3;
                array[4] = flatColorVertexId - 3; array[5] = flatColorVertexId - 1;
                array[6] = flatColorVertexId - 1; array[7] = flatColorVertexId - 0;
                buffer.UnmapBuffer();
            }
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, IndexAccessMode.ByFrame, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();
            if (id + 2 == flatColorVertexId)
            { return new uint[] { flatColorVertexId - 0, flatColorVertexId - 2, }; }
            else if (id + 3 == flatColorVertexId)
            { return new uint[] { flatColorVertexId - 2, flatColorVertexId - 3 }; }
            else if (id + 1 == flatColorVertexId)
            { return new uint[] { flatColorVertexId - 3, flatColorVertexId - 1, }; }
            else if (id + 0 == flatColorVertexId)
            { return new uint[] { flatColorVertexId - 1, flatColorVertexId - 0, }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}