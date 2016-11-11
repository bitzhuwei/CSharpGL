using System;
namespace CSharpGL.Demos
{
    internal class BillboardModel : IBufferable
    {
        public const string strPosition = "position";
        private VertexAttributeBuffer positionBuffer;

        private static readonly float[] positions =
        {
		    -0.5f, -0.5f, 0.0f,
		    0.5f, -0.5f, 0.0f,
		    -0.5f,  0.5f, 0.0f,
		    0.5f,  0.5f, 0.0f,
        };

        public VertexAttributeBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBuffer == null)
                {
                    int length = positions.Length;
                    VertexAttributeBuffer buffer = VertexAttributeBuffer.Create(typeof(float), length, VertexAttributeConfig.Vec3, BufferUsage.DynamicDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (float*)pointer;
                        for (int i = 0; i < positions.Length; i++)
                        {
                            array[i] = positions[i];
                        }
                        buffer.UnmapBuffer();
                    }
                    this.positionBuffer = buffer;
                }
                return positionBuffer;
            }
            else
            {
                return null;
            }
        }

        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int vertexCount = 4;
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.TriangleStrip, 0, vertexCount);
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