using System;
using System.Collections.Generic;

namespace CSharpGL {
    internal class LinesAdjacencyRecognizer : PrimitiveRecognizer {
        protected override void RecognizeUInt(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList) {
            IndexBuffer indexBuffer = cmd.indexBuffer;
            int length = indexBuffer.count;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe {
                var array = (uint*)pointer;
                uint i = 0;
                for (i = i + 2; i < length; i += 4) {
                    var value = array[i];
                    if (value == singleNodeVertexId) {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUShort(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList) {
            IndexBuffer indexBuffer = cmd.indexBuffer;
            int length = indexBuffer.count;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe {
                var array = (ushort*)pointer;
                uint i = 0;
                for (i = i + 2; i < length; i += 4) {
                    var value = array[i];
                    if (value == singleNodeVertexId) {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeByte(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList) {
            IndexBuffer indexBuffer = cmd.indexBuffer;
            int length = indexBuffer.count;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe {
                var array = (byte*)pointer;
                uint i = 0;
                for (i = i + 2; i < length; i += 4) {
                    var value = array[i];
                    if (value == singleNodeVertexId) {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUInt(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex) {
            IndexBuffer indexBuffer = cmd.indexBuffer;
            int length = indexBuffer.count;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe {
                var array = (uint*)pointer;
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex) { nearestRestartIndex = i; i++; }
                for (i = i + 2; i < length; i++) {
                    var value = array[i];
                    if (value == primitiveRestartIndex) {
                        nearestRestartIndex = i;
                    }
                    else if (((i - 2 - nearestRestartIndex) % 4 == 0)
                        && (value == singleNodeVertexId)
                        && (array[i + 1] != primitiveRestartIndex)
                        && (array[i - 1] != primitiveRestartIndex)
                        && (array[i - 2] != primitiveRestartIndex)) {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeUShort(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex) {
            IndexBuffer indexBuffer = cmd.indexBuffer;
            int length = indexBuffer.count;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe {
                var array = (ushort*)pointer;
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex) { nearestRestartIndex = i; i++; }
                for (i = i + 2; i < length; i++) {
                    var value = array[i];
                    if (value == primitiveRestartIndex) {
                        nearestRestartIndex = i;
                    }
                    else if (((i - 2 - nearestRestartIndex) % 4 == 0)
                        && (value == singleNodeVertexId)
                        && (array[i + 1] != primitiveRestartIndex)
                        && (array[i - 1] != primitiveRestartIndex)
                        && (array[i - 2] != primitiveRestartIndex)) {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }

        protected override void RecognizeByte(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList, uint primitiveRestartIndex) {
            IndexBuffer indexBuffer = cmd.indexBuffer;
            int length = indexBuffer.count;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe {
                var array = (byte*)pointer;
                long nearestRestartIndex = -1;
                uint i = 0;
                while (i < length && array[i] == primitiveRestartIndex) { nearestRestartIndex = i; i++; }
                for (i = i + 2; i < length; i++) {
                    var value = array[i];
                    if (value == primitiveRestartIndex) {
                        nearestRestartIndex = i;
                    }
                    else if (((i - 2 - nearestRestartIndex) % 4 == 0)
                        && (value == singleNodeVertexId)
                        && (array[i + 1] != primitiveRestartIndex)
                        && (array[i - 1] != primitiveRestartIndex)
                        && (array[i - 2] != primitiveRestartIndex)) {
                        var item = new RecognizedPrimitiveInfo(i, array[i - 1], singleNodeVertexId);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }
    }
}