using System;

namespace CSharpGL
{
    internal class DrawArraysLineInTriangleStripSearcher : DrawArraysLineSearcher
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
                flatColorVertexId - 0, flatColorVertexId - 2, 
                flatColorVertexId - 2, flatColorVertexId - 1, 
                flatColorVertexId - 1, flatColorVertexId - 0 
            };
            IndexBuffer buffer = array.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg,  cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id + 2 == stageVertexId)
            { return new uint[] { id + 2, id }; }
            else if (id + 1 == stageVertexId)
            { return new uint[] { id - 1, id }; }
            else if (id + 0 == stageVertexId)
            { return new uint[] { id - 1, id }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}