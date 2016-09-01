using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class LineLoopRecognizer : PrimitiveRecognizer
    {
        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[0] == lastVertexId
                    && length > 1)
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, 0);
                    item.IndexIdList.Add(array[length - 1]);
                    item.IndexIdList.Add(lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[0] == lastVertexId
                    && length > 1)
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, 0);
                    item.IndexIdList.Add(array[length - 1]);
                    item.IndexIdList.Add(lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr,
            List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[0] == lastVertexId
                    && length > 1)
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, 0);
                    item.IndexIdList.Add(array[length - 1]);
                    item.IndexIdList.Add(lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex)
                { nearestRestartIndex = i; i++; }
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        // try the loop back line.
                        if (array[nearestRestartIndex + 1] == lastVertexId
                            && array[i - 1] != primitiveRestartIndex
                            && nearestRestartIndex + 1 < i - 1)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(nearestRestartIndex + 1));
                            item.IndexIdList.Add(value);
                            item.IndexIdList.Add(lastVertexId);
                            lastIndexIdList.Add(item);
                        }
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[nearestRestartIndex + 1] == lastVertexId
                    && array[length - 1] != primitiveRestartIndex
                    && nearestRestartIndex + 1 < length - 1)
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(nearestRestartIndex + 1));
                    item.IndexIdList.Add(array[length - 1]);
                    item.IndexIdList.Add(lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex)
                { nearestRestartIndex = i; i++; }
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        // try the loop back line.
                        if (array[nearestRestartIndex + 1] == lastVertexId
                            && array[i - 1] != primitiveRestartIndex
                            && nearestRestartIndex + 1 < i - 1)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(nearestRestartIndex + 1));
                            item.IndexIdList.Add(value);
                            item.IndexIdList.Add(lastVertexId);
                            lastIndexIdList.Add(item);
                        }
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[nearestRestartIndex + 1] == lastVertexId
                    && array[length - 1] != primitiveRestartIndex
                    && nearestRestartIndex + 1 < length - 1)
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(nearestRestartIndex + 1));
                    item.IndexIdList.Add(array[length - 1]);
                    item.IndexIdList.Add(lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList, uint primitiveRestartIndex)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex)
                { nearestRestartIndex = i; i++; }
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        // try the loop back line.
                        if (array[nearestRestartIndex + 1] == lastVertexId
                            && array[i - 1] != primitiveRestartIndex
                            && nearestRestartIndex + 1 < i - 1)
                        {
                            var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(nearestRestartIndex + 1));
                            item.IndexIdList.Add(value);
                            item.IndexIdList.Add(lastVertexId);
                            lastIndexIdList.Add(item);
                        }
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[nearestRestartIndex + 1] == lastVertexId
                    && array[length - 1] != primitiveRestartIndex
                    && nearestRestartIndex + 1 < length - 1)
                {
                    var item = new RecognizedPrimitiveIndex(lastVertexId, (uint)(nearestRestartIndex + 1));
                    item.IndexIdList.Add(array[length - 1]);
                    item.IndexIdList.Add(lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }
    }
}