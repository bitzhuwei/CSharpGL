
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    // check http://www.cnblogs.com/bitzhuwei/p/CSharpGL-18-Picking-of-OneIndexBuffer.html
    partial class OneIndexRenderer
    {

        /// <summary>
        /// 在所有可能的图元（<see cref="lastVertexId"/>匹配）中，
        /// 逐个测试，找到最接近摄像机的那个图元，
        /// 返回此图元的最后一个索引在<see cref="indexBufferPtr"/>中的索引（位置）。
        /// </summary>
        /// <param name="lastIndexIdList"></param>
        /// <returns></returns>
        private RecognizedPrimitiveIndex GetLastIndexId(
            RenderEventArgs arg,
            List<RecognizedPrimitiveIndex> lastIndexIdList,
            int x, int y)
        {
            if (lastIndexIdList == null || lastIndexIdList.Count == 0) { return null; }

            int current = 0;
#if DEBUG
            NoPrimitiveRestartIndex(lastIndexIdList);
#endif
            for (int i = 1; i < lastIndexIdList.Count; i++)
            {
                OneIndexBufferPtr twoPrimitivesIndexBufferPtr;
                uint lastIndex0, lastIndex1;
                AssembleIndexBuffer(
                    lastIndexIdList[current], lastIndexIdList[i], this.indexBufferPtr.Mode,
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

            return lastIndexIdList[current];
        }

        private void NoPrimitiveRestartIndex(List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            PrimitiveRestartSwitch glSwitch = GetPrimitiveRestartSwitch();
            if (glSwitch != null)
            {
                foreach (var lastIndexId in lastIndexIdList)
                {
                    foreach (var indexId in lastIndexId.IndexIdList)
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
            RecognizedPrimitiveIndex recognizedPrimitiveIndex0,
            RecognizedPrimitiveIndex recognizedPrimitiveIndex1,
            DrawMode drawMode,
            out OneIndexBufferPtr oneIndexBufferPtr,
            out uint lastIndex0, out uint lastIndex1)
        {
            List<uint> indexArray = ArrangeIndexes(
                recognizedPrimitiveIndex0, recognizedPrimitiveIndex1, drawMode,
                out lastIndex0, out lastIndex1);
            if (indexArray.Count !=
                recognizedPrimitiveIndex0.IndexIdList.Count
                + 1
                + recognizedPrimitiveIndex1.IndexIdList.Count)
            { throw new Exception(); }

            using (var indexBuffer = new OneIndexBuffer<uint>(drawMode, BufferUsage.StaticDraw))
            {
                indexBuffer.Alloc(
                    recognizedPrimitiveIndex0.IndexIdList.Count
                    + 1
                    + recognizedPrimitiveIndex1.IndexIdList.Count);
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
        /// <returns></returns>
        private List<uint> ArrangeIndexes(
            RecognizedPrimitiveIndex recognizedPrimitiveIndex0,
            RecognizedPrimitiveIndex recognizedPrimitiveIndex1,
            DrawMode drawMode,
            out uint lastIndex0, out uint lastIndex1)
        {
            List<uint> sameIndexList = new List<uint>();
            List<uint> array0 = new List<uint>(recognizedPrimitiveIndex0.IndexIdList);
            List<uint> array1 = new List<uint>(recognizedPrimitiveIndex1.IndexIdList);
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
