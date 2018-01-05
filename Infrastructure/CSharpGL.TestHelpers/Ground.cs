﻿using System;

namespace CSharpGL
{
    /// <summary>
    /// 正方形
    /// </summary>
    public class Ground : IBufferSource
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

        private VertexBuffer positionBuffer;
        private VertexBuffer colorBuffer;

        private IndexBuffer indexBuffer;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public IEnumerable<VertexBuffer> GetVertexAttributeBuffer(string bufferName)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    //int length = positions.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (vec3*)pointer;
                    //    for (int i = 0; i < positions.Length; i++)
                    //    {
                    //        array[i] = positions[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.positionBuffer = buffer;
                    this.positionBuffer = positions.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
                }
                return this.positionBuffer;
            }
            else if (bufferName == strColor)
            {
                if (this.colorBuffer == null)
                {
                    //int length = colors.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (vec3*)pointer;
                    //    for (int i = 0; i < colors.Length; i++)
                    //    {
                    //        array[i] = colors[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.colorBuffer = buffer;
                    this.colorBuffer = colors.GenVertexBuffer(VBOConfig.Vec3, BufferUsage.StaticDraw);
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
        public IEnumerable<IndexBuffer> GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int vertexCount = positions.Length;
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.Lines, 0, vertexCount);
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
        }

    }
}