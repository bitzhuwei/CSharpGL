using System;

namespace CSharpGL
{
    internal class OneIndexLineInPolygonSearcher : OneIndexLineSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="primitiveInfo"></param>
        /// <param name="picker"></param>
        /// <returns></returns>
        internal override uint[] Search(PickingEventArgs arg,
            RecognizedPrimitiveInfo primitiveInfo,
            OneIndexPicker picker)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length < 3) { throw new ArgumentException(); }

            IndexBuffer buffer = indexList.GenIndexBuffer(BufferUsage.StaticDraw);
            var cmd = new DrawElementsCmd(buffer, DrawMode.LineLoop);
            picker.Node.Render4InnerPicking(arg, cmd);
            uint id = ColorCodedPicking.ReadStageVertexId(arg.X, arg.Y);

            buffer.Dispose();

            if (id == indexList[0])
            { return new uint[] { indexList[indexList.Length - 1], id, }; }
            else
            {
                uint[] result = null;
                for (int i = 1; i < indexList.Length; i++)
                {
                    if (id == indexList[i])
                    {
                        result = new uint[] { indexList[i - 1], indexList[i], };
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