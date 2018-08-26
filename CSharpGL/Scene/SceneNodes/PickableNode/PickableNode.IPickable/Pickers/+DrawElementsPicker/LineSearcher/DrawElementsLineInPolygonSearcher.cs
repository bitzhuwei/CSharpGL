using System;

namespace CSharpGL
{
    internal class DrawElementsLineInPolygonSearcher : DrawElementsLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="singleNodeVertexId"></param>
        /// <param name="stageVertexId"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            RecognizedPrimitiveInfo primitiveInfo,
            uint singleNodeVertexId, uint stageVertexId,
            DrawElementsPicker picker)
        {
            uint[] vertexIds = primitiveInfo.VertexIds;
            if (vertexIds.Length < 3) { throw new ArgumentException(); }

            IndexBuffer buffer = vertexIds.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.LineLoop);
            picker.Node.Render4InnerPicking(arg, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            uint baseId = stageVertexId - singleNodeVertexId;
            if (id == baseId + vertexIds[0])
            { return new uint[] { baseId + vertexIds[vertexIds.Length - 1], id, }; }
            else
            {
                uint[] result = null;
                for (int i = 1; i < vertexIds.Length; i++)
                {
                    if (id == baseId + vertexIds[i])
                    {
                        result = new uint[] { baseId + vertexIds[i - 1], id, };
                        break;
                    }
                }

                if (result != null)
                { return result; }
                else
                { throw new Exception("This should not happen!"); }
            }
        }
    }
}