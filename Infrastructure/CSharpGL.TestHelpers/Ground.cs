using System;

namespace CSharpGL
{
    /// <summary>
    /// 正方形
    /// </summary>
    public class Ground : IBufferable
    {
        internal vec3[] positions;
        internal vec3[] colors;

        /// <summary>
        ///
        /// </summary>
        /// <param name="squreCountPerUnit">每个world space里的1个距离单位有几个方块？</param>
        /// <param name="xUnit">在x轴正方向画多少个距离单位？</param>
        /// <param name="zUnit">在z轴正方向画多少个距离单位？</param>
        public Ground(int squreCountPerUnit = 10, int xUnit = 10, int zUnit = 10)
        {
            this.positions = GeneratePositions(squreCountPerUnit, xUnit, zUnit);
            this.colors = GenerateColors(squreCountPerUnit, xUnit, zUnit);
        }

        private vec3[] GenerateColors(int squreCountPerUnit, int xUnit, int zUnit)
        {
            var colors = new vec3[
                (xUnit * 2 * squreCountPerUnit + 1) * 2
                + (zUnit * 2 * squreCountPerUnit + 1) * 2
                ];
            int index = 0;
            for (int i = 0; i < xUnit * 2 * squreCountPerUnit + 1; i++)
            {
                if (i % squreCountPerUnit == 0)
                {
                    colors[index++] = new vec3(1,
                        Math.Abs((float)(i) / (float)(xUnit * 2 * squreCountPerUnit) * 2 - 1.0f),
                        0);
                    colors[index++] = new vec3(1,
                        Math.Abs((float)(i) / (float)(xUnit * 2 * squreCountPerUnit) * 2 - 1.0f),
                        0);
                }
                else
                {
                    colors[index++] = new vec3(1, 1, 1);
                    colors[index++] = new vec3(1, 1, 1);
                }
            }
            for (int i = 0; i < zUnit * 2 * squreCountPerUnit + 1; i++)
            {
                if (i % squreCountPerUnit == 0)
                {
                    colors[index++] = new vec3(0,
                        Math.Abs((float)(i) / (float)(xUnit * 2 * squreCountPerUnit) * 2 - 1.0f),
                        1);
                    colors[index++] = new vec3(0,
                        Math.Abs((float)(i) / (float)(xUnit * 2 * squreCountPerUnit) * 2 - 1.0f),
                        1);
                }
                else
                {
                    colors[index++] = new vec3(1, 1, 1);
                    colors[index++] = new vec3(1, 1, 1);
                }
            }

            return colors;
        }

        private vec3[] GeneratePositions(int squreCountPerUnit, int xUnit, int zUnit)
        {
            var positions = new vec3[
                (xUnit * 2 * squreCountPerUnit + 1) * 2
                + (zUnit * 2 * squreCountPerUnit + 1) * 2
                ];
            int index = 0;
            for (int i = 0; i < xUnit * 2 * squreCountPerUnit + 1; i++)
            {
                positions[index++] = new vec3(
                    zUnit, 0, xUnit * 2 * ((float)i / (float)(xUnit * 2 * squreCountPerUnit) - 0.5f));
                positions[index++] = new vec3(
                    -zUnit, 0, xUnit * 2 * ((float)i / (float)(xUnit * 2 * squreCountPerUnit) - 0.5f));
            }
            for (int i = 0; i < zUnit * 2 * squreCountPerUnit + 1; i++)
            {
                positions[index++] = new vec3(
                    zUnit * 2 * ((float)i / (float)(zUnit * 2 * squreCountPerUnit) - 0.5f), 0, xUnit);
                positions[index++] = new vec3(
                    zUnit * 2 * ((float)i / (float)(zUnit * 2 * squreCountPerUnit) - 0.5f), 0, -xUnit);
            }

            return positions;
        }

        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strColor = "color";

        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr colorBufferPtr;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    int length = positions.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < positions.Length; i++)
                        {
                            array[i] = positions[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBufferPtr == null)
                {
                    int length = colors.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < colors.Length; i++)
                        {
                            array[i] = colors[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.colorBufferPtr = bufferPtr;
                }
                return this.colorBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int vertexCount = positions.Length;
                ZeroIndexBufferPtr bufferPtr = ZeroIndexBufferPtr.Create(DrawMode.Lines, 0, vertexCount);
                this.indexBufferPtr = bufferPtr;
            }

            return this.indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}