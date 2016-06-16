using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// 正方形
    /// </summary>
    public class Ground : IBufferable
    {
        internal vec3[] positions;
        internal vec3[] colors;

        public Ground(int squreCountPerLine)
        {
            this.positions = GeneratePositions(squreCountPerLine);
            this.colors = GenerateColors(squreCountPerLine);
        }


        private vec3[] GenerateColors(int squreCountPerLine)
        {
            var colors = new vec3[(squreCountPerLine + 1) * 4];
            int index = 0;
            for (int i = 0; i < (squreCountPerLine + 1); i++)
            {
                if (squreCountPerLine % 2 == 0)
                {
                    if (i == squreCountPerLine / 2)
                    {
                        colors[index++] = new vec3(1, 0, 0);
                        colors[index++] = new vec3(1, 1, 1);
                    }
                    else
                    {
                        colors[index++] = new vec3(1, 1, 1);
                        colors[index++] = new vec3(1, 1, 1);
                    }
                }
                else
                {
                    if (i == squreCountPerLine / 2 || i == squreCountPerLine / 2 + 1)
                    {
                        colors[index++] = new vec3(1, 0, 0);
                        colors[index++] = new vec3(1, 1, 1);
                    }
                    else
                    {
                        colors[index++] = new vec3(1, 1, 1);
                        colors[index++] = new vec3(1, 1, 1);
                    }
                }
            }
            for (int i = 0; i < (squreCountPerLine + 1); i++)
            {
                if (squreCountPerLine % 2 == 0)
                {
                    if (i == squreCountPerLine / 2)
                    {
                        colors[index++] = new vec3(0, 0, 1);
                        colors[index++] = new vec3(1, 1, 1);
                    }
                    else
                    {
                        colors[index++] = new vec3(1, 1, 1);
                        colors[index++] = new vec3(1, 1, 1);
                    }
                }
                else
                {
                    if (i == squreCountPerLine / 2 || i == squreCountPerLine / 2 + 1)
                    {
                        colors[index++] = new vec3(0, 0, 1);
                        colors[index++] = new vec3(1, 1, 1);
                    }
                    else
                    {
                        colors[index++] = new vec3(1, 1, 1);
                        colors[index++] = new vec3(1, 1, 1);
                    }
                }
            }

            return colors;
        }

        private vec3[] GeneratePositions(int squreCountPerLine)
        {
            var positions = new vec3[(squreCountPerLine + 1) * 4];
            int index = 0;
            for (int i = 0; i < (squreCountPerLine + 1); i++)
            {
                positions[index++] = new vec3(
                    1, 0, -1 + 2 * (float)i / (float)(squreCountPerLine));
                positions[index++] = new vec3(
                    -1, 0, -1 + 2 * (float)i / (float)(squreCountPerLine));
            }
            for (int i = 0; i < (squreCountPerLine + 1); i++)
            {
                positions[index++] = new vec3(
                    -1 + 2 * (float)i / (float)(squreCountPerLine), 0, 1);
                positions[index++] = new vec3(
                    -1 + 2 * (float)i / (float)(squreCountPerLine), 0, -1);
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

