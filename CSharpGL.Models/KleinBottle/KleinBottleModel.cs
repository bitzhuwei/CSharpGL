﻿using System;
using System.Collections.Generic;

namespace CSharpGL {
    /// <summary>
    /// Klein bottle model.
    /// </summary>
    public unsafe class KleinBottleModel : IBufferSource {
        private double interval;

        private int GetUCount(double interval) {
            int uCount = (int)(Math.PI / interval);
            return uCount;
        }

        private int GetVCount(double interval) {
            int vCount = (int)(Math.PI * 2 / interval / 10.0);
            return vCount;
        }

        public KleinBottleModel(double interval = 0.02) {
            this.interval = interval;
            bool initialized = false;
            vec3 max = new vec3();
            vec3 min = new vec3();
            int uCount = GetUCount(interval);
            int vCount = GetVCount(interval);
            for (int uIndex = 0; uIndex < uCount; uIndex++) {
                for (int vIndex = 0; vIndex < vCount; vIndex++) {
                    double u = Math.PI * uIndex / uCount;
                    double v = Math.PI * 2 * vIndex / vCount;
                    var position = GetPosition(u, v);

                    if (!initialized) {
                        max = position;
                        min = position;
                        initialized = true;
                    }
                    else {
                        position.UpdateMax(ref max);
                        position.UpdateMin(ref min);
                    }
                }
            }
            this.Size = max - min;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        public const string strTexCoord = "texCoord";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd;

        private VertexBuffer GetTexCoordBuffer() {
            int uCount = GetUCount(interval);
            int vCount = GetVCount(interval);
            int length = uCount * vCount;
            VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Float, GLBuffer.Usage.StaticDraw);
            unsafe {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (float*)pointer;
                int index = 0;
                for (int uIndex = 0; uIndex < uCount; uIndex++) {
                    for (int vIndex = 0; vIndex < vCount; vIndex++) {
                        array[index++] = (float)uIndex / (float)uCount;
                    }
                }
                buffer.UnmapBuffer();
            }

            return buffer;
        }

        private VertexBuffer GetPositionBuffer() {
            bool initialized = false;
            vec3 max = new vec3();
            vec3 min = new vec3();
            int uCount = GetUCount(interval);
            int vCount = GetVCount(interval);
            int length = uCount * vCount;
            VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, GLBuffer.Usage.StaticDraw);
            unsafe {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (vec3*)pointer;
                int index = 0;
                for (int uIndex = 0; uIndex < uCount; uIndex++) {
                    for (int vIndex = 0; vIndex < vCount; vIndex++) {
                        double u = Math.PI * uIndex / uCount;
                        double v = Math.PI * 2 * vIndex / vCount;
                        var position = GetPosition(u, v);

                        if (!initialized) {
                            max = position;
                            min = position;
                            initialized = true;
                        }
                        else {
                            position.UpdateMax(ref max);
                            position.UpdateMin(ref min);
                        }
                        array[index++] = position;
                    }
                }
                //this.Lengths = max - min;
                vec3 worldSpacePosition = max / 2.0f + min / 2.0f;
                for (int i = 0; i < index; i++) {
                    array[i] = array[i] - worldSpacePosition;
                }
                buffer.UnmapBuffer();
            }

            return buffer;
        }

        public vec3 Size { get; private set; }

        public vec3 GetPosition(double u, double v) {
            double sinU = Math.Sin(u), cosU = Math.Cos(u);
            double sinV = Math.Sin(v), cosV = Math.Cos(v);
            double x = -2.0 * cosU * (3 * cosV - 30 * sinU + 90 * Math.Pow(cosU, 4) * sinU - 60 * Math.Pow(cosU, 6) * sinU + 5 * cosU * cosV * sinU);
            double y = -1.0 * sinU * (3 * cosV - 3 * Math.Pow(cosU, 2) * cosV - 48 * Math.Pow(cosU, 4) * cosV + 48 * Math.Pow(cosU, 6) * cosV - 60 * sinU + 5 * cosU * cosV * sinU - 5 * Math.Pow(cosU, 3) * cosV * sinU - 80 * Math.Pow(cosU, 5) * cosV * sinU + 80 * Math.Pow(cosU, 7) * cosV * sinU);
            double z = 2.0 * (3.0 + 5 * cosU * sinU) * sinV;

            return new vec3((float)x, (float)y, (float)z);
        }


        #region IBufferSource 成员


        /// <summary>
        /// 获取指定的顶点属性缓存。
        /// <para>Gets specified vertex buffer object.</para>
        /// </summary>
        /// <param name="bufferName">buffer name(Gets this name from 'strPosition' etc.</param>
        /// <returns>Vertex Buffer Object.</returns>
        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName) {
            if (bufferName == strPosition) {
                if (this.positionBuffer == null) {
                    this.positionBuffer = GetPositionBuffer();
                }
                yield return this.positionBuffer;
            }
            else if (bufferName == strTexCoord) {
                if (this.colorBuffer == null) {
                    this.colorBuffer = GetTexCoordBuffer();
                }
                yield return this.colorBuffer;
            }
            else {
                throw new ArgumentException();
            }
        }

        public IEnumerable<IDrawCommand> GetDrawCommand() {
            if (this.drawCmd == null) {
                int uCount = GetUCount(interval);
                int vCount = GetVCount(interval);
                int length = (uCount + 1) * vCount + (vCount + 1 + 1) * uCount;
                int index = 0;
                var array = new uint[length];
                // vertical lines.
                for (int i = 0; i < vCount; i++) {
                    for (int j = 0; j < uCount; j++) {
                        array[index++] = (uint)(i + j * vCount);
                    }
                    array[index++] = uint.MaxValue;// primitive restart index.
                }
                // horizontal lines.
                for (int i = 0; i < uCount; i++) {
                    for (int j = 0; j < vCount; j++) {
                        array[index++] = (uint)(j + i * vCount);
                    }
                    array[index++] = (uint)(0 + i * vCount);
                    array[index++] = uint.MaxValue;// primitive restart index.
                }
                IndexBuffer buffer = array.GenIndexBuffer(IndexBuffer.ElementType.UInt, GLBuffer.Usage.StaticDraw);
                this.drawCmd = new DrawElementsCmd(buffer, DrawMode.LineStrip, uint.MaxValue);
            }

            yield return this.drawCmd;
        }

        #endregion
    }
}