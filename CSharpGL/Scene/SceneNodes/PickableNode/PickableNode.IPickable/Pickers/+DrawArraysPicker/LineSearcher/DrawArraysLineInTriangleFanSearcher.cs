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
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            uint flatColorVertexId, uint stageVertexId, DrawArraysPicker picker)
        {
            var array = new uint[] 
            { 
                0, flatColorVertexId - 1, 
                flatColorVertexId - 1, flatColorVertexId - 0, 
                flatColorVertexId - 0, 0 
            };
            IndexBuffer buffer = array.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Lines);
            picker.Node.Render4InnerPicking(arg, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id + 1 == stageVertexId)
            { return new uint[] { 0, id, }; }
            else if (id == stageVertexId)
            { return new uint[] { id - 1, id, }; }
            else if (id == 0)
            { return new uint[] { stageVertexId, 0, }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}