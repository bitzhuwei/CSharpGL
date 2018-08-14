using System;

namespace CSharpGL
{
    internal class DrawArraysPointInTriangleStripAdjacencySearcher : DrawArraysPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="flatColorVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg, uint flatColorVertexId, uint stageVertexId, DrawArraysPicker picker)
        {
            var array = new uint[] 
            { 
                flatColorVertexId - 0, 
                flatColorVertexId - 2, 
                flatColorVertexId - 4 
            };
            IndexBuffer buffer = array.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Points);
            picker.Node.Render4InnerPicking(arg,  cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id == stageVertexId - 0
                || id == stageVertexId - 2
                || id == stageVertexId - 4)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}