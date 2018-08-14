using System;

namespace CSharpGL
{
    internal class DrawElementsPointInPolygonSearcher : DrawElementsPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint Search(PickingEventArgs arg,
            RecognizedPrimitiveInfo primitiveInfo,
            DrawElementsPicker picker)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length < 3) { throw new ArgumentException(); }

            IndexBuffer buffer = indexList.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.Points);
            picker.Node.Render4InnerPicking(arg, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

#if DEBUG
            foreach (var item in indexList)
            {
                if (item == id) { return id; }
            }

            if (id == uint.MaxValue) // Scene's changed before second rendering for picking>
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
#else
            return id; // TODO: this is not safe.
#endif
        }
    }
}