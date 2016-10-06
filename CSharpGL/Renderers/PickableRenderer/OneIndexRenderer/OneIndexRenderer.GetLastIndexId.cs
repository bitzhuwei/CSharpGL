using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpGL
{
    // check http://www.cnblogs.com/bitzhuwei/p/CSharpGL-18-Picking-of-OneIndexBuffer.html
    partial class OneIndexRenderer
    {
        /// <summary>
        /// 在所有可能的图元（lastVertexId匹配）中，
        /// 逐个测试，找到最接近摄像机的那个图元，
        /// 返回此图元的最后一个索引在<see cref="IndexBufferPtr"/>中的索引（位置）。
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="primitiveInfoList"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private RecognizedPrimitiveInfo GetLastIndexId(
            RenderEventArgs arg,
            List<RecognizedPrimitiveInfo> primitiveInfoList,
            int x, int y)
        {
            if (primitiveInfoList == null || primitiveInfoList.Count == 0) { return null; }
#if DEBUG
            SameLengths(primitiveInfoList);
#endif
            if (primitiveInfoList[0].VertexIds.Length == 1)// picking a point.
            {
                return primitiveInfoList[0];
            }

            int current = 0;
#if DEBUG
            NoPrimitiveRestartIndex(primitiveInfoList);
#endif
            for (int i = 1; i < primitiveInfoList.Count; i++)
            {
                OneIndexBufferPtr twoPrimitivesIndexBufferPtr;
                uint lastIndex0, lastIndex1;
                AssembleIndexBuffer(
                    primitiveInfoList[current], primitiveInfoList[i], this.indexBufferPtr.Mode,
                    out twoPrimitivesIndexBufferPtr, out lastIndex0, out lastIndex1);
                uint pickedIndex = Pick(arg, twoPrimitivesIndexBufferPtr,
                    x, y);
                if (pickedIndex == lastIndex1)
                { current = i; }
                else if (pickedIndex == lastIndex0)
                { /* nothing to do */}
                else if (pickedIndex == uint.MaxValue)// 两个候选图元都没有被拾取到
                { /* nothing to do */}
                else
                { throw new Exception("This should not happen!"); }
            }

            return primitiveInfoList[current];
        }

        private void SameLengths(List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            int length = primitiveInfoList[0].VertexIds.Length;
            for (int i = 0; i < primitiveInfoList.Count; i++)
            {
                if (primitiveInfoList[i].VertexIds.Length != length)
                {
                    throw new Exception("This should not happen!");
                }
            }
        }

        private void NoPrimitiveRestartIndex(List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            PrimitiveRestartSwitch glSwitch = GetPrimitiveRestartSwitch();
            if (glSwitch != null)
            {
                foreach (var lastIndexId in primitiveInfoList)
                {
                    foreach (var indexId in lastIndexId.VertexIds)
                    {
                        if (indexId == glSwitch.RestartIndex) { throw new Exception(); }
                    }
                }
            }
        }

        /// <summary>
        /// 将共享点前移，然后重新渲染、拾取
        /// </summary>
        /// <param name="recognizedPrimitiveIndex0"></param>
        /// <param name="recognizedPrimitiveIndex1"></param>
        /// <param name="drawMode"></param>
        /// <param name="oneIndexBufferPtr"></param>
        /// <param name="lastIndex0"></param>
        /// <param name="lastIndex1"></param>
        private void AssembleIndexBuffer(
            RecognizedPrimitiveInfo recognizedPrimitiveIndex0,
            RecognizedPrimitiveInfo recognizedPrimitiveIndex1,
            DrawMode drawMode,
            out OneIndexBufferPtr oneIndexBufferPtr,
            out uint lastIndex0, out uint lastIndex1)
        {
            List<uint> indexArray = ArrangeIndexes(
                recognizedPrimitiveIndex0, recognizedPrimitiveIndex1, drawMode,
                out lastIndex0, out lastIndex1);
            if (indexArray.Count !=
                recognizedPrimitiveIndex0.VertexIds.Length
                + 1
                + recognizedPrimitiveIndex1.VertexIds.Length)
            { throw new Exception(); }

            using (var indexBuffer = new OneIndexBuffer(IndexElementType.UInt, drawMode, BufferUsage.StaticDraw))
            {
                indexBuffer.Create(
                    recognizedPrimitiveIndex0.VertexIds.Length
                    + 1
                    + recognizedPrimitiveIndex1.VertexIds.Length);
                unsafe
                {
                    var array = (uint*)indexBuffer.Header.ToPointer();
                    for (int i = 0; i < indexArray.Count; i++)
                    {
                        array[i] = indexArray[i];
                    }
                }

                oneIndexBufferPtr = indexBuffer.GetBufferPtr() as OneIndexBufferPtr;
            }
        }

        /// <summary>
        /// 将共享点前移，构成2个图元组成的新的小小的索引。
        /// </summary>
        /// <param name="recognizedPrimitiveIndex0"></param>
        /// <param name="recognizedPrimitiveIndex1"></param>
        /// <param name="drawMode"></param>
        /// <param name="lastIndex0"></param>
        /// <param name="lastIndex1"></param>
        /// <returns></returns>
        private List<uint> ArrangeIndexes(
            RecognizedPrimitiveInfo recognizedPrimitiveIndex0,
            RecognizedPrimitiveInfo recognizedPrimitiveIndex1,
            DrawMode drawMode,
            out uint lastIndex0, out uint lastIndex1)
        {
            List<uint> sameIndexList = new List<uint>();
            List<uint> array0 = new List<uint>(recognizedPrimitiveIndex0.VertexIds);
            List<uint> array1 = new List<uint>(recognizedPrimitiveIndex1.VertexIds);
            array0.Sort(); array1.Sort();
            int p0 = 0, p1 = 0;
            while (p0 < array0.Count && p1 < array1.Count)
            {
                if (array0[p0] < array1[p1])
                { p0++; }
                else if (array0[p0] > array1[p1])
                { p1++; }
                else
                {
                    sameIndexList.Add(array0[p0]);
                    array0.RemoveAt(p0);
                    array1.RemoveAt(p1);
                }
            }

            if (array0.Count == 0 && array1.Count == 0)
            { throw new Exception("Two primitives are totally the same!"); }

            if (array0.Count > 0)
            { lastIndex0 = array0.Last(); }
            else
            {
                if (sameIndexList.Count == 0)
                { throw new Exception("array0 is totally empty!"); }

                lastIndex0 = sameIndexList.Last();
            }

            if (array1.Count > 0)
            { lastIndex1 = array1.Last(); }
            else
            {
                if (sameIndexList.Count == 0)
                { throw new Exception("array1 is totally empty!"); }

                lastIndex1 = sameIndexList.Last();
            }

            if (lastIndex0 == lastIndex1) { throw new Exception(); }

            List<uint> result = new List<uint>();
            result.AddRange(sameIndexList);
            result.AddRange(array0);
            result.Add(uint.MaxValue);// primitive restart index
            result.AddRange(sameIndexList);
            result.AddRange(array1);

            return result;
        }
    }
}