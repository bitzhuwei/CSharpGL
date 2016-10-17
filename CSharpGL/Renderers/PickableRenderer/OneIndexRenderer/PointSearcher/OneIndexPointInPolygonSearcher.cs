using System;

namespace CSharpGL
{
    internal class OneIndexPointInPolygonSearcher : OneIndexPointSearcher
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="x">mouse position(Left Down is (0, 0)).</param>
        /// <param name="y">mouse position(Left Down is (0, 0)).</param>
        /// <param name="primitiveInfo"></param>
        /// <param name="modernRenderer"></param>
        /// <returns></returns>
        internal override uint Search(RenderEventArgs arg,
            int x, int y,
            RecognizedPrimitiveInfo primitiveInfo,
            OneIndexRenderer modernRenderer)
        {
            uint[] indexList = primitiveInfo.VertexIds;
            if (indexList.Length < 3) { throw new ArgumentException(); }

            OneIndexBufferPtr indexBufferPtr = null;
            using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.Points, BufferUsage.StaticDraw))
            {
                buffer.Alloc(indexList.Length);
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
            uint id = ColorCodedPicking.ReadStageVertexId(x, y);

            indexBufferPtr.Dispose();

            if (id != uint.MaxValue)
            { return id; }
            else
            { throw new Exception("This should not happen!"); }
        }
    }
}