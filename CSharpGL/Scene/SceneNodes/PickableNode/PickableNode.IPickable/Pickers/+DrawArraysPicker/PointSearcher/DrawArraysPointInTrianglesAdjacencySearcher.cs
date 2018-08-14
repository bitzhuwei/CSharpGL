using System;

namespace CSharpGL
{
    internal class DrawArraysPointInTrianglesAdjacencySearcher : DrawArraysPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg,
            uint singleNodeVertexId, uint stageVertexId, DrawArraysPicker picker)
        {
            var array = new uint[] 
            { 
                singleNodeVertexId - 0, 
                singleNodeVertexId - 2, 
                singleNodeVertexId - 4 
            };
            IndexBuffer buffer = array.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Points);
            picker.Node.Render4InnerPicking(arg,  cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (stageVertexId - 0 == id || stageVertexId - 2 == id || stageVertexId - 4 == id)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}