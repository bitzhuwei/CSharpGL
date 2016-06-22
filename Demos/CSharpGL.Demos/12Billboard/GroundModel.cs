using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL.Demos
{
    /// <summary>
    /// 正方形
    /// </summary>
    internal class GroundModel : IBufferable
    {
        internal vec3[] positions;

        public GroundModel(int squreCountPerLine)
        {
            this.positions = GeneratePositions(squreCountPerLine);
        }

        private static vec3[] GeneratePositions(int squreCountPerLine)
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
        private PropertyBufferPtr positionBufferPtr;

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

