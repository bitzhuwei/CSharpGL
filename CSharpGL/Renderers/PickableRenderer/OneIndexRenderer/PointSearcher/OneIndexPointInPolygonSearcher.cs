using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class OneIndexPointInPolygonSearcher : OneIndexPointSearcher
    {
        internal override uint Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo lastIndexId,
            OneIndexRenderer modernRenderer)
        {
            uint[] indexList = lastIndexId.VertexIdList;
            if (indexList.Length < 3) { throw new ArgumentException(); }

            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Points, BufferUsage.StaticDraw))
            {
                buffer.Create(indexList.Length);
                unsafe
                {
                    var array = (uint*)buffer.Header.ToPointer();
                    for (int i = 0; i < indexList.Length; i++)
                    {
                        array[i] = indexList[i];
                    }
                }

                indexBufferPtr = buffer.GetBufferPtr() as OneIndexBufferPtr;
            }

            modernRenderer.Render4InnerPicking(arg, indexBufferPtr);
            uint id = ColorCodedPicking.ReadPixel(x, y, arg.CanvasRect.Height);

            indexBufferPtr.Dispose();

            if (id != uint.MaxValue)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}