using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class LineLoopRecognizer : PrimitiveRecognizer
    {
        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList)
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
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[0] == lastVertexId
                    && length > 1)
                {
                    var item = new RecognizedPrimitiveInfo(0, array[length - 1], lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList)
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
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[0] == lastVertexId
                    && length > 1)
                {
                    var item = new RecognizedPrimitiveInfo(0, array[length - 1], lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr,
            List<RecognizedPrimitiveInfo> lastIndexIdList)
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
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[0] == lastVertexId
                    && length > 1)
                {
                    var item = new RecognizedPrimitiveInfo(0, array[length - 1], lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList, uint primitiveRestartIndex)
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
                            var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), value, lastVertexId);
                            lastIndexIdList.Add(item);
                        }
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[nearestRestartIndex + 1] == lastVertexId
                    && array[length - 1] != primitiveRestartIndex
                    && nearestRestartIndex + 1 < length - 1)
                {
                    var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), array[length - 1], lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList, uint primitiveRestartIndex)
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
                            var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), value, lastVertexId);
                            lastIndexIdList.Add(item);
                        }
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[nearestRestartIndex + 1] == lastVertexId
                    && array[length - 1] != primitiveRestartIndex
                    && nearestRestartIndex + 1 < length - 1)
                {
                    var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), array[length - 1], lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }

        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList, uint primitiveRestartIndex)
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
                            var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), value, lastVertexId);
                            lastIndexIdList.Add(item);
                        }
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
                        lastIndexIdList.Add(item);
                    }
                }
                if (array[nearestRestartIndex + 1] == lastVertexId
                    && array[length - 1] != primitiveRestartIndex
                    && nearestRestartIndex + 1 < length - 1)
                {
                    var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), array[length - 1], lastVertexId);
                    lastIndexIdList.Add(item);
                }
            }
        }
    }
}