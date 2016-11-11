using System;

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
        private VertexAttributeBuffer positionBuffer;

        public VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    int length = positions.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.positionBuffer = bufferPtr;
                }
                return this.positionBuffer;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int vertexCount = positions.Length;
                ZeroIndexBuffer bufferPtr = ZeroIndexBuffer.Create(DrawMode.Lines, 0, vertexCount);
                this.indexBuffer = bufferPtr;
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