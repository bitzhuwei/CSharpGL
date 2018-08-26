using System;
using System.Collections.Generic;

namespace CSharpGL
{
    internal class LineLoopRecognizer : PrimitiveRecognizer
    {
        protected override void RecognizeByte(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (byte*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == singleNodeVertexId)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
                if (array[0] == singleNodeVertexId
                    && length > 1)
                {
                    var item = new RecognizedPrimitiveInfo(0, array[length - 1], singleNodeVertexId);
                    primitiveInfoList.Add(item);
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUShort(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (ushort*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == singleNodeVertexId)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
                if (array[0] == singleNodeVertexId
                    && length > 1)
                {
                    var item = new RecognizedPrimitiveInfo(0, array[length - 1], singleNodeVertexId);
                    primitiveInfoList.Add(item);
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUInt(uint singleNodeVertexId, DrawElementsCmd cmd,
            List<RecognizedPrimitiveInfo> primitiveInfoList)
        {
            IndexBuffer indexBuffer = cmd.IndexBufferObject;
            int length = indexBuffer.Length;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe
            {
                var array = (uint*)pointer.ToPointer();
                for (uint i = 1; i < length; i++)
                {
                    var value = array[i];
                    if (value == singleNodeVertexId)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
                if (array[0] == singleNodeVertexId
                    && length > 1)
                {
                    var item = new RecognizedPrimitiveInfo(0, array[length - 1], singleNodeVertexId);
                    primitiveInfoList.Add(item);
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeByte(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex)
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
                        // try the loop back line.
                        if (array[nearestRestartIndex + 1] == singleNodeVertexId
                            && array[i - 1] != primitiveRestartIndex
                            && nearestRestartIndex + 1 < i - 1)
                        {
                            var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), value, singleNodeVertexId);
                            primitiveInfoList.Add(item);
                        }
                        nearestRestartIndex = i;
                    }
                    else if (value == singleNodeVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
                if (array[nearestRestartIndex + 1] == singleNodeVertexId
                    && array[length - 1] != primitiveRestartIndex
                    && nearestRestartIndex + 1 < length - 1)
                {
                    var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), array[length - 1], singleNodeVertexId);
                    primitiveInfoList.Add(item);
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUShort(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex)
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
                        // try the loop back line.
                        if (array[nearestRestartIndex + 1] == singleNodeVertexId
                            && array[i - 1] != primitiveRestartIndex
                            && nearestRestartIndex + 1 < i - 1)
                        {
                            var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), value, singleNodeVertexId);
                            primitiveInfoList.Add(item);
                        }
                        nearestRestartIndex = i;
                    }
                    else if (value == singleNodeVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
                if (array[nearestRestartIndex + 1] == singleNodeVertexId
                    && array[length - 1] != primitiveRestartIndex
                    && nearestRestartIndex + 1 < length - 1)
                {
                    var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), array[length - 1], singleNodeVertexId);
                    primitiveInfoList.Add(item);
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUInt(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex)
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
                        // try the loop back line.
                        if (array[nearestRestartIndex + 1] == singleNodeVertexId
                            && array[i - 1] != primitiveRestartIndex
                            && nearestRestartIndex + 1 < i - 1)
                        {
                            var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), value, singleNodeVertexId);
                            primitiveInfoList.Add(item);
                        }
                        nearestRestartIndex = i;
                    }
                    else if (value == singleNodeVertexId
                        && array[i - 1] != primitiveRestartIndex)
                    {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
                if (array[nearestRestartIndex + 1] == singleNodeVertexId
                    && array[length - 1] != primitiveRestartIndex
                    && nearestRestartIndex + 1 < length - 1)
                {
                    var item = new RecognizedPrimitiveInfo((uint)(nearestRestartIndex + 1), array[length - 1], singleNodeVertexId);
                    primitiveInfoList.Add(item);
                }
            }
            indexBuffer.UnmapBuffer();
        }
    }
}