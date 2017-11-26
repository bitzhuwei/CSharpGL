﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpGL
{
    // check http://www.cnblogs.com/bitzhuwei/p/CSharpGL-18-Picking-of-OneIndexBuffer.html
    partial class OneIndexPicker
    {
        /// <summary>
        /// 在所有可能的图元（lastVertexId匹配）中，
        /// 逐个测试，找到最接近摄像机的那个图元，
        /// 返回此图元的最后一个索引在<see cref="IndexBuffer"/>中的索引（位置）。
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="primitiveInfoList"></param>
        /// <returns></returns>
        private RecognizedPrimitiveInfo GetLastIndexId(
            PickingEventArgs arg,
            List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            if (primitiveInfoList == null || primitiveInfoList.Count == 0) { return null; }
#if DEBUG
            SameLengths(primitiveInfoList);
#endif
            if (primitiveInfoList[0].VertexIds.Length == 1)// picking a point.
            {
                return primitiveInfoList[0];
            }

            int target = 0;
#if DEBUG
            NoPrimitiveRestartIndex(primitiveInfoList);
#endif
            for (int left = 0; left < primitiveInfoList.Count - 1; left++)
            {
                for (int right = left + 1; right < primitiveInfoList.Count; right++)
                {
                    OneIndexBuffer twoPrimitivesIndexBuffer;
                    uint leftLastIndex, rightLastIndex;
                    AssembleIndexBuffer(
                        primitiveInfoList[left], primitiveInfoList[right], this.Node.PickingRenderUnit.VertexArrayObject.IndexBuffer.Mode,
                        out twoPrimitivesIndexBuffer, out leftLastIndex, out rightLastIndex);
                    uint pickedIndex = Pick(arg, twoPrimitivesIndexBuffer);
                    if (pickedIndex == rightLastIndex)
                    {
                        target = right;
                        break;
                    }
                    else if (pickedIndex == leftLastIndex)
                    {
                        target = left;
                        break;
                    }
                    else if (pickedIndex == uint.MaxValue)// 两个候选图元都没有被拾取到
                    { /* nothing to do */}
                    else
                    { throw new Exception("This should not happen!"); }
                }
            }

            return primitiveInfoList[target];
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
            PrimitiveRestartState glState = GetPrimitiveRestartState();
            if (glState != null)
            {
                foreach (RecognizedPrimitiveInfo info in primitiveInfoList)
                {
                    foreach (uint vertexId in info.VertexIds)
                    {
                        if (vertexId == glState.RestartIndex) { throw new Exception(); }
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
        /// <param name="oneIndexBuffer"></param>
        /// <param name="lastIndex0"></param>
        /// <param name="lastIndex1"></param>
        private void AssembleIndexBuffer(
            RecognizedPrimitiveInfo recognizedPrimitiveIndex0,
            RecognizedPrimitiveInfo recognizedPrimitiveIndex1,
            DrawMode drawMode,
            out OneIndexBuffer oneIndexBuffer,
            out uint lastIndex0, out uint lastIndex1)
        {
            List<uint> indexArray = ArrangeIndexes(
                recognizedPrimitiveIndex0, recognizedPrimitiveIndex1, drawMode,
                out lastIndex0, out lastIndex1);
            if (indexArray.Count !=
                recognizedPrimitiveIndex0.VertexIds.Length
                + 1
                + recognizedPrimitiveIndex1.VertexIds.Length)
            { throw new Exception(string.Format("index array[{0}] not same length with [recognized primitive1 index length{1}] + [1] + recognized primitive2 index length[{2}]", indexArray.Count, recognizedPrimitiveIndex0.VertexIds.Length, recognizedPrimitiveIndex1.VertexIds.Length)); }

            oneIndexBuffer = indexArray.ToArray().GenIndexBuffer(drawMode, BufferUsage.StaticDraw);
            //oneIndexBuffer = Buffer.Create(IndexElementType.UInt,
            //    recognizedPrimitiveIndex0.VertexIds.Length
            //    + 1
            //    + recognizedPrimitiveIndex1.VertexIds.Length,
            //    drawMode, BufferUsage.StaticDraw);
            //unsafe
            //{
            //    var array = (uint*)oneIndexBuffer.MapBuffer(MapBufferAccess.WriteOnly);
            //    for (int i = 0; i < indexArray.Count; i++)
            //    {
            //        array[i] = indexArray[i];
            //    }
            //    oneIndexBuffer.UnmapBuffer();
            //}
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
            var sameIndexList = new List<uint>();
            var array0 = new List<uint>(recognizedPrimitiveIndex0.VertexIds);
            var array1 = new List<uint>(recognizedPrimitiveIndex1.VertexIds);
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

            var result = new List<uint>();
            result.AddRange(sameIndexList);
            result.AddRange(array0);
            result.Add(uint.MaxValue);// primitive restart index
            result.AddRange(sameIndexList);
            result.AddRange(array1);

            return result;
        }
    }
}
