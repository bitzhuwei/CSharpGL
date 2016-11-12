using System;

namespace CSharpGL.Demos
{
    /// <summary>
    /// Klein bottle model.
    /// </summary>
    internal class KleinBottleModel : IBufferable
    {
        private double interval;

        private int GetUCount(double interval)
        {
            int uCount = (int)(Math.PI / interval);
            return uCount;
        }

        private int GetVCount(double interval)
        {
            int vCount = (int)(Math.PI * 2 / interval / 10.0);
            return vCount;
        }

        public KleinBottleModel(double interval = 0.02)
        {
            this.interval = interval;
            bool initialized = false;
            vec3 max = new vec3();
            vec3 min = new vec3();
            int uCount = GetUCount(interval);
            int vCount = GetVCount(interval);
            for (int uIndex = 0; uIndex < uCount; uIndex++)
            {
                for (int vIndex = 0; vIndex < vCount; vIndex++)
                {
                    double u = Math.PI * uIndex / uCount;
                    double v = Math.PI * 2 * vIndex / vCount;
                    var position = GetPosition(u, v);

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
            }
            this.Lengths = max - min;
        }

        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        public const string strTexCoord = "texCoord";
        private VertexBuffer colorBuffer;

        private IndexBuffer indexBuffer = null;

        /// <summary>
        /// 获取指定的顶点属性缓存。
        /// <para>Gets specified vertex buffer object.</para>
        /// </summary>
        /// <param name="bufferName">buffer name(Gets this name from 'strPosition' etc.</param>
        /// <param name="varNameInShader">name in vertex shader like `in vec3 in_Position;`.</param>
        /// <returns>Vertex Buffer Object.</returns>
        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    this.positionBuffer = GetPositionBuffer(varNameInShader);
                }
                return this.positionBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.colorBuffer == null)
                {
                    this.colorBuffer = GetTexCoordBuffer(varNameInShader);
                }
                return this.colorBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private VertexBuffer GetTexCoordBuffer(string varNameInShader)
        {
            int uCount = GetUCount(interval);
            int vCount = GetVCount(interval);
            int length = uCount * vCount;
            VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Float, BufferUsage.StaticDraw, varNameInShader);
            unsafe
            {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (float*)pointer;
                int index = 0;
                for (int uIndex = 0; uIndex < uCount; uIndex++)
                {
                    for (int vIndex = 0; vIndex < vCount; vIndex++)
                    {
                        array[index++] = (float)uIndex / (float)uCount;
                    }
                }
                buffer.UnmapBuffer();
            }

            return buffer;
        }

        private VertexBuffer GetPositionBuffer(string varNameInShader)
        {
            bool initialized = false;
            vec3 max = new vec3();
            vec3 min = new vec3();
            int uCount = GetUCount(interval);
            int vCount = GetVCount(interval);
            int length = uCount * vCount;
            VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
            unsafe
            {
                IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                var array = (vec3*)pointer;
                int index = 0;
                for (int uIndex = 0; uIndex < uCount; uIndex++)
                {
                    for (int vIndex = 0; vIndex < vCount; vIndex++)
                    {
                        double u = Math.PI * uIndex / uCount;
                        double v = Math.PI * 2 * vIndex / vCount;
                        var position = GetPosition(u, v);

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

        public vec3 GetPosition(double u, double v)
        {
            double sinU = Math.Sin(u), cosU = Math.Cos(u);
            double sinV = Math.Sin(v), cosV = Math.Cos(v);
            double x = -2.0 * cosU * (3 * cosV - 30 * sinU + 90 * Math.Pow(cosU, 4) * sinU - 60 * Math.Pow(cosU, 6) * sinU + 5 * cosU * cosV * sinU);
            double y = -1.0 * sinU * (3 * cosV - 3 * Math.Pow(cosU, 2) * cosV - 48 * Math.Pow(cosU, 4) * cosV + 48 * Math.Pow(cosU, 6) * cosV - 60 * sinU + 5 * cosU * cosV * sinU - 5 * Math.Pow(cosU, 3) * cosV * sinU - 80 * Math.Pow(cosU, 5) * cosV * sinU + 80 * Math.Pow(cosU, 7) * cosV * sinU);
            double z = 2.0 * (3.0 + 5 * cosU * sinU) * sinV;

            return new vec3((float)x, (float)y, (float)z);
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int uCount = GetUCount(interval);
                int vCount = GetVCount(interval);
                int length = (uCount + 1) * vCount + (vCount + 1 + 1) * uCount;
                OneIndexBuffer buffer = CSharpGL.Buffer.Create(IndexElementType.UInt, length, DrawMode.LineStrip, BufferUsage.StaticDraw);
                unsafe
                {
                    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    var array = (uint*)pointer;
                    int index = 0;
                    // vertical lines.
                    for (int i = 0; i < vCount; i++)
                    {
                        for (int j = 0; j < uCount; j++)
                        {
                            array[index++] = (uint)(i + j * vCount);
                        }
                        array[index++] = uint.MaxValue;// primitive restart index.
                    }
                    // horizontal lines.
                    for (int i = 0; i < uCount; i++)
                    {
                        for (int j = 0; j < vCount; j++)
                        {
                            array[index++] = (uint)(j + i * vCount);
                        }
                        array[index++] = (uint)(0 + i * vCount);
                        array[index++] = uint.MaxValue;// primitive restart index.
                    }
                    buffer.UnmapBuffer();
                }
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }
    }
}