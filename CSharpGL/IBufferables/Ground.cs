using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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


        public const string strPosition = "position";
        public const string strColor = "color";
        private PropertyBufferPtr positionBufferPtr;
        private PropertyBufferPtr colorBufferPtr;

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(positions.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < positions.Length; i++)
                            {
                                array[i] = positions[i];
                            }
                        }

                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return positionBufferPtr;
            }
            else if (bufferName == strColor)
            {
                if (colorBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<vec3>(
                        varNameInShader, 3, OpenGL.GL_FLOAT, BufferUsage.StaticDraw))
                    {
                        buffer.Alloc(colors.Length);
                        unsafe
                        {
                            var array = (vec3*)buffer.Header.ToPointer();
                            for (int i = 0; i < colors.Length; i++)
                            {
                                array[i] = colors[i];
                            }
                        }

                        colorBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }
                return colorBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(
                    DrawMode.Lines, 0, positions.Length))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as IndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }

        private IndexBufferPtr indexBufferPtr = null;
    }
}

