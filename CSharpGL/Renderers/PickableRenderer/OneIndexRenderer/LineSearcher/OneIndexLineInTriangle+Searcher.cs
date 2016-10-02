using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class OneIndexLineInTriangleSearcher : OneIndexLineSearcher
    {
        internal override uint[] Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo lastIndexId,
            OneIndexRenderer modernRenderer)
        {
            List<uint> indexList = lastIndexId.VertexIdList;
            if (indexList.Count != 3) { throw new ArgumentException(); }

            //if (indexList[0] == indexList[1]) { return new uint[] { indexList[0], indexList[2], }; }
            //else if (indexList[0] == indexList[2]) { return new uint[] { indexList[0], indexList[1], }; }
            //else if (indexList[1] == indexList[2]) { return new uint[] { indexList[1], indexList[0], }; }

            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Lines, BufferUsage.StaticDraw))
            {
                buffer.Create(6);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    array[0] = indexList[0]; array[1] = indexList[1];
                    array[2] = indexList[1]; array[3] = indexList[2];
                    array[4] = indexList[2]; array[5] = indexList[0];
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();

            if (id == indexList[1])
            { return new uint[] { indexList[0], indexList[1], }; }
            else if (id == indexList[2])
            { return new uint[] { indexList[1], indexList[2], }; }
            else if (id == indexList[0])
            { return new uint[] { indexList[2], indexList[0], }; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}