using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class LinesAdjacencyRecognizer : PrimitiveRecognizer
    {
        protected override void RecognizeUInt(uint lastVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 2; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId
                        && (i - 2) % 4 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
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
                for (i = i + 2; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId
                        && (i - 2) % 4 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeByte(uint lastVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                uint i = 0;
                for (i = i + 2; i < length; i++)
                {
                    var value = array[i];
                    if (value == lastVertexId
                        && (i - 2) % 4 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
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
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && (i - nearestRestartIndex) % 2 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
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
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && (i - nearestRestartIndex) % 2 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
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
                for (i = i + 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == primitiveRestartIndex)
                    {
                        nearestRestartIndex = i;
                    }
                    else if (value == lastVertexId
                        && array[i - 1] != primitiveRestartIndex
                        && (i - nearestRestartIndex) % 2 == 0)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], lastVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }
    }
}