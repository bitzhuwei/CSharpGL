using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class QuadStripRecognizer : PrimitiveRecognizer
    {
        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 3; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 2]);
                        item.IndexIdList.Add(array[i - 3]);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }

        protected override void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 3; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 2]);
                        item.IndexIdList.Add(array[i - 3]);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }

        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveIndex> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 3; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 2]);
                        item.IndexIdList.Add(array[i - 3]);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
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
                for (i = i + 3; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        // try the loop back line.
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && array[i - 3] != primitiveRestartIndex
                        && array[i - 2] != primitiveRestartIndex
                        )
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 2]);
                        item.IndexIdList.Add(array[i - 3]);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
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
                for (i = i + 3; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        // try the loop back line.
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && array[i - 3] != primitiveRestartIndex
                        && array[i - 2] != primitiveRestartIndex
                        )
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 2]);
                        item.IndexIdList.Add(array[i - 3]);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
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
                for (i = i + 3; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        // try the loop back line.
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && array[i - 3] != primitiveRestartIndex
                        && array[i - 2] != primitiveRestartIndex
                        )
                    {
                        var item = new RecognizedPrimitiveIndex(lastVertexId, i);
                        item.IndexIdList.Add(array[i - 2]);
                        item.IndexIdList.Add(array[i - 3]);
                        item.IndexIdList.Add(array[i - 1]);
                        item.IndexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }
    }
}