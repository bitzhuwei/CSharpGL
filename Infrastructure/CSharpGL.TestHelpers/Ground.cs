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

        private VertexAttributeBuffer positionBuffer;
        private VertexAttributeBuffer colorBuffer;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    int length = positions.Length;
                    VertexAttributeBuffer buffer = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < positions.Length; i++)
                        {
                            array[i] = positions[i];
                        }
                        buffer.UnmapBuffer();
                    }
                    this.positionBuffer = buffer;
                }
                return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    int length = colors.Length;
                    VertexAttributeBuffer buffer = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < colors.Length; i++)
                        {
                            array[i] = colors[i];
                        }
                        buffer.UnmapBuffer();
                    }
                    this.colorBuffer = buffer;
                }
                return this.colorBuffer;
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
        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int vertexCount = positions.Length;
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.Lines, 0, vertexCount);
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
        }

        private IndexBuffer indexBuffer = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}