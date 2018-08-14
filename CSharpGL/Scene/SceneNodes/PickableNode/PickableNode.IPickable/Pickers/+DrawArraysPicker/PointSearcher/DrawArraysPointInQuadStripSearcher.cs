using System;

namespace CSharpGL
{
    internal class DrawArraysPointInQuadStripSearcher : DrawArraysPointSearcher
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
                flatColorVertexId - 1, 
                flatColorVertexId - 2, 
                flatColorVertexId - 3 
            };
            IndexBuffer buffer = array.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Points);
            picker.Node.Render4InnerPicking(arg,  cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();
            if (flatColorVertexId - 3 <= id && id <= flatColorVertexId - 0)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}