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
        private VertexAttributeBufferPtr positionBufferPtr;

        public const string strColor = "color";
        private VertexAttributeBufferPtr colorBufferPtr;

        private IndexBufferPtr indexBufferPtr = null;

        /// <summary>
        /// 获取指定的顶点属性缓存。
        /// <para>Gets specified vertex buffer object.</para>
        /// </summary>
        /// <param name="bufferName">buffer name(Gets this name from 'strPosition' etc.</param>
        /// <param name="varNameInShader">name in vertex shader like `in vec3 in_Position;`.</param>
        /// <returns>Vertex Buffer Object.</returns>
        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    this.positionBufferPtr = GetPositionBufferPtr(varNameInShader);
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBufferPtr == null)
                {
                    this.colorBufferPtr = GetColorBufferPtr(varNameInShader);
                }
                return this.colorBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private VertexAttributeBufferPtr GetColorBufferPtr(string varNameInShader)
        {
            VertexAttributeBufferPtr colorBufferPtr = null;

            using (var buffer = new VertexAttributeBuffer<vec3>(
                varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
            {
                int uCount = GetUCount(interval);
                int vCount = GetVCount(interval);
                buffer.Create(uCount * vCount);
                unsafe
                {
                    var random = new Random();
                    int index = 0;
                    var array = (vec3*)buffer.Header.ToPointer();
                    for (int uIndex = 0; uIndex < uCount; uIndex++)
                    {
                        for (int vIndex = 0; vIndex < vCount; vIndex++)
                        {
                            double u = Math.PI * uIndex / uCount;
                            double v = Math.PI * 2 * vIndex / vCount;

                            array[index++] = new vec3(
                                (float)random.NextDouble(),
                                (float)random.NextDouble(),
                                (float)random.NextDouble());
                        }
                    }
                }

                colorBufferPtr = buffer.GetBufferPtr();

                return colorBufferPtr;
            }
        }

        private VertexAttributeBufferPtr GetPositionBufferPtr(string varNameInShader)
        {
            VertexAttributeBufferPtr positionBufferPtr = null;

            using (var buffer = new VertexAttributeBuffer<vec3>(
                varNameInShader, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw))
            {
                bool initialized = false;
                vec3 max = new vec3();
                vec3 min = new vec3();
                int uCount = GetUCount(interval);
                int vCount = GetVCount(interval);
                buffer.Create(uCount * vCount);
                unsafe
                {
                    int index = 0;
                    var array = (vec3*)buffer.Header.ToPointer();
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
                }

                positionBufferPtr = buffer.GetBufferPtr();

                return positionBufferPtr;
            }
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

        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int uCount = GetUCount(interval);
                int vCount = GetVCount(interval);
                using (var buffer = new OneIndexBuffer(IndexElementType.UInt, DrawMode.LineLoop, BufferUsage.StaticDraw))
                {
                    int count = (uCount + 1) * vCount + (vCount + 1) * uCount;
                    buffer.Create(count);
                    int index = 0;
                    unsafe
                    {
                        var array = (uint*)buffer.Header.ToPointer();
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
                            array[index++] = uint.MaxValue;// primitive restart index.
                        }
                    }

                    this.indexBufferPtr = buffer.GetBufferPtr();
                }
                //using (var buffer = new ZeroIndexBuffer(
                //    DrawMode.Points, 0, uCount * vCount))
                //{
                //    indexBufferPtr = buffer.GetBufferPtr();
                //}
            }

            return this.indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return false; }
    }
}