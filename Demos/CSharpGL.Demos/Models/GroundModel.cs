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
        private VertexBuffer positionBuffer;

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    //int length = positions.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.positionBuffer = positions.GetVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
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