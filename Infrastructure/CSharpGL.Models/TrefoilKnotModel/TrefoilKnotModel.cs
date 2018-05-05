using System;
using System.Collections.Generic;

namespace CSharpGL
{
    /// <summary>
    /// Trefoil knot model.
    /// </summary>
    internal class TrefoilKnotModel : IBufferSource
    {
        private double interval;

        private int GetUCount(double interval)
        {
            int uCount = (int)(Math.PI * 2 / interval);
            return uCount;
        }

        public TrefoilKnotModel(double interval = 0.02)
        {
            this.interval = interval;
            bool initialized = false;
            vec3 max = new vec3();
            vec3 min = new vec3();
            int uCount = GetUCount(interval);
            for (int uIndex = 0; uIndex < uCount; uIndex++)
            {
                double t = Math.PI * 2 * uIndex / uCount;
                var position = GetPosition(t);

                if (!initialized)
                {
                    max = position;
                    min = position;
                    initialized = true;
                }
                else
                {
                    position.UpdateMax(ref max);
                    position.UpdateMin(ref min);
                }
            }
            this.Lengths = max - min;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        public const string strTexCoord = "texCoord";
        private VertexBuffer colorBuffer;

        private IDrawCommand drawCmd = null;

        /// <summary>
        /// 获取指定的顶点属性缓存。
        /// <para>Gets specified vertex buffer object.</para>
        /// </summary>
        /// <param name="bufferName">buffer name(Gets this name from 'strPosition' etc.</param>
        /// <returns>Vertex Buffer Object.</returns>
        public IEnumerable<VertexBuffer> GetVertexAttribute(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = GetPositionBuffer();
                }
                yield return this.positionBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = GetTexCoordBuffer();
                }
                yield return this.colorBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private VertexBuffer GetTexCoordBuffer()
        {
            int uCount = GetUCount(interval);
            int length = uCount;
            VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Float, BufferUsage.StaticDraw);
            unsafe
            {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                int index = 0;
                var array = (float*)pointer;
                for (int uIndex = 0; uIndex < uCount; uIndex++)
                {
                    array[index++] = (float)uIndex / (float)uCount;
                }
                buffer.UnmapBuffer();
            }

            return buffer;
        }

        private VertexBuffer GetPositionBuffer()
        {
            int uCount = GetUCount(interval);
            int length = uCount;
            VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw);
            bool initialized = false;
            vec3 max = new vec3();
            vec3 min = new vec3();
            unsafe
            {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                int index = 0;
                var array = (vec3*)pointer;
                for (int uIndex = 0; uIndex < uCount; uIndex++)
                {
                    double t = Math.PI * 2 * uIndex / uCount;
                    var position = GetPosition(t);

                    if (!initialized)
                    {
                        max = position;
                        min = position;
                        initialized = true;
                    }
                    else
                    {
                        position.UpdateMax(ref max);
                        position.UpdateMin(ref min);
                    }
                    array[index++] = position;
                }
                //this.Lengths = max - min;
                vec3 worldPosition = max / 2.0f + min / 2.0f;
                for (int i = 0; i < index; i++)
                {
                    array[i] = array[i] - worldPosition;
                }
                buffer.UnmapBuffer();
            }

            return buffer;
        }

        public vec3 Lengths { get; private set; }

        public vec3 GetPosition(double t)
        {
            double sinT = Math.Sin(t), cosT = Math.Cos(t);
            double sin2T = Math.Sin(2 * t), cos2T = Math.Cos(2 * t);
            double sin3T = Math.Sin(3 * t);//, cos3T = Math.Cos(3 * t);
            double x = sinT + 2 * sin2T;
            double y = cosT - 2 * cos2T;
            double z = -sin3T;

            return new vec3((float)x, (float)y, (float)z);
        }

        public IEnumerable<IDrawCommand> GetDrawCommand()
        {
            if (this.drawCmd == null)
            {
                int uCount = GetUCount(interval);
                DrawArraysCmd buffer = new DrawArraysCmd(DrawMode.Points, uCount);
                this.drawCmd = buffer;
            }

            yield return this.drawCmd;
        }
    }
}