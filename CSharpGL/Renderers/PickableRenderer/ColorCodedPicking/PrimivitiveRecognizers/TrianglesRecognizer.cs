using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class TrianglesRecognizer : PrimitiveRecognizer
    {
        protected override void RecognizeByte(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                for (i = i + 2; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId
                        && (i - nearestRestartIndex) % 3 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i);
                        item.VertexIdList.Add(array[i - 2]);
                        item.VertexIdList.Add(array[i - 1]);
                        item.VertexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }

        protected override void RecognizeUShort(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                for (i = i + 2; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId
                        && (i - nearestRestartIndex) % 3 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i);
                        item.VertexIdList.Add(array[i - 2]);
                        item.VertexIdList.Add(array[i - 1]);
                        item.VertexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }

        protected override void RecognizeUInt(uint lastVertexId, IntPtr pointer, OneIndexBufferPtr oneIndexBufferPtr, List<RecognizedPrimitiveInfo> lastIndexIdList)
        {
            int length = oneIndexBufferPtr.Length;
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                for (i = i + 2; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId
                        && (i - nearestRestartIndex) % 3 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i);
                        item.VertexIdList.Add(array[i - 2]);
                        item.VertexIdList.Add(array[i - 1]);
                        item.VertexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
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
                for (i = i + 2; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && array[i - 2] != primitiveRestartIndex
                        && (i - nearestRestartIndex) % 3 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i);
                        item.VertexIdList.Add(array[i - 2]);
                        item.VertexIdList.Add(array[i - 1]);
                        item.VertexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
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
                for (i = i + 2; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && array[i - 2] != primitiveRestartIndex
                        && (i - nearestRestartIndex) % 3 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i);
                        item.VertexIdList.Add(array[i - 2]);
                        item.VertexIdList.Add(array[i - 1]);
                        item.VertexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
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
                for (i = i + 2; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && array[i - 2] != primitiveRestartIndex
                        && (i - nearestRestartIndex) % 3 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i);
                        item.VertexIdList.Add(array[i - 2]);
                        item.VertexIdList.Add(array[i - 1]);
                        item.VertexIdList.Add(value);
                        lastIndexIdList.Add(item);
                    }
                }
            }
        }
    }
}