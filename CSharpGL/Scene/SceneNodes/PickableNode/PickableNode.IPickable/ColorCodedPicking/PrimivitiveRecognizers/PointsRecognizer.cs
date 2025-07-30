﻿using System;
using System.Collections.Generic;

namespace CSharpGL {
    internal class PointsRecognizer : PrimitiveRecognizer {
        protected override void RecognizeUInt(uint singleNodeVertexId, DrawElementsCmd cmd, List<RecognizedPrimitiveInfo> primitiveInfoList) {
            IndexBuffer indexBuffer = cmd.indexBuffer;
            int length = indexBuffer.count;
            IntPtr pointer = indexBuffer.MapBuffer(MapBufferAccess.ReadOnly);
            unsafe {
                var array = (uint*)pointer;
                for (uint i = 0; i < length; i++) {
                    var value = array[i];
                    if (value == singleNodeVertexId) {
                        var item = new RecognizedPrimitiveInfo(i, value);
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
                for (uint i = 0; i < length; i++) {
                    var value = array[i];
                    if (value == singleNodeVertexId) {
                        var item = new RecognizedPrimitiveInfo(i, value);
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
                for (uint i = 0; i < length; i++) {
                    var value = array[i];
                    if (value == singleNodeVertexId) {
                        var item = new RecognizedPrimitiveInfo(i, value);
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
                for (uint i = 0; i < length; i++) {
                    var value = array[i];
                    if (value == singleNodeVertexId) {
                        var item = new RecognizedPrimitiveInfo(i, value);
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
                for (uint i = 0; i < length; i++) {
                    var value = array[i];
                    if (value == singleNodeVertexId) {
                        var item = new RecognizedPrimitiveInfo(i, value);
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
                for (uint i = 0; i < length; i++) {
                    var value = array[i];
                    if (value == singleNodeVertexId) {
                        var item = new RecognizedPrimitiveInfo(i, value);
                        primitiveInfoList.Add(item);
                    }
                }
            }
            indexBuffer.UnmapBuffer();
        }
    }
}