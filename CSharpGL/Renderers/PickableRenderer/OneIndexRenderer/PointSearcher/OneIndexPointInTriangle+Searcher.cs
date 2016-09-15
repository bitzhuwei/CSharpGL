using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class OneIndexPointInTriangleSearcher : OneIndexPointSearcher
    {
        internal override uint Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveIndex lastIndexId,
            OneIndexRenderer modernRenderer)
        {
            List<uint> indexList = lastIndexId.IndexIdList;
            if (indexList.Count != 3) { throw new ArgumentException(); }

            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UnsignedInt, DrawMode.Points, BufferUsage.StaticDraw))
            {
                buffer.Create(3);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    array[0] = indexList[0];
                    array[1] = indexList[1];
                    array[2] = indexList[2];
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();

            if (id == indexList[0] || id == indexList[1] || id == indexList[2])
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}