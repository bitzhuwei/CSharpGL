using System;

namespace CSharpGL
{
    internal class OneIndexPointInPolygonSearcher : OneIndexPointSearcher
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
            OneIndexPicker picker)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length < 3) { throw new ArgumentException(); }

            DrawElementsCmd buffer = indexList.GenIndexBuffer(DrawMode.Points, BufferUsage.StaticDraw);
            picker.Node.Render4InnerPicking(arg, buffer);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id != uint.MaxValue)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}