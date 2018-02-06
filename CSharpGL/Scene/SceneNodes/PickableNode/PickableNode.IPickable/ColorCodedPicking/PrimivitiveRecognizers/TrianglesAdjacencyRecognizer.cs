using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class TrianglesAdjacencyRecognizer : PrimitiveRecognizer
    {
        protected override void RecognizeByte(uint lastVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 4; i < length; i += 6)
                {
                    var value = array[i];
                    if (value == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 4], array[i - 2], lastVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUShort(uint lastVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 4; i < length; i += 6)
                {
                    var value = array[i];
                    if (value == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 4], array[i - 2], lastVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUInt(uint lastVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 4; i < length; i += 6)
                {
                    var value = array[i];
                    if (value == lastVertexId)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 4], array[i - 2], lastVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeByte(uint lastVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex)
                { nearestRestartIndex = i; i++; }
                for (i = i + 4; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        nearestRestartIndex = i;
                    }
                    else if (
                        array[i + 1] != primitiveRestartIndex
                        && value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && array[i - 2] != primitiveRestartIndex
                        && array[i - 3] != primitiveRestartIndex
                        && array[i - 4] != primitiveRestartIndex
                        && (i - 4 - nearestRestartIndex) % 6 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 4], array[i - 2], lastVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUShort(uint lastVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex)
                { nearestRestartIndex = i; i++; }
                for (i = i + 4; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        nearestRestartIndex = i;
                    }
                    else if (array[i + 1] != primitiveRestartIndex
                        && value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && array[i - 2] != primitiveRestartIndex
                        && array[i - 3] != primitiveRestartIndex
                        && array[i - 4] != primitiveRestartIndex
                        && (i - 4 - nearestRestartIndex) % 6 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 4], array[i - 2], lastVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUInt(uint lastVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex)
                { nearestRestartIndex = i; i++; }
                for (i = i + 4; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        nearestRestartIndex = i;
                    }
                    else if (array[i + 1] != primitiveRestartIndex
                        && value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && array[i - 2] != primitiveRestartIndex
                        && array[i - 3] != primitiveRestartIndex
                        && array[i - 4] != primitiveRestartIndex
                        && (i - 4 - nearestRestartIndex) % 6 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 4], array[i - 2], lastVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }
    }
}
