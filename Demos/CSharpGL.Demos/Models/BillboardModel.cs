using System;
namespace CSharpGL.Demos
{
    internal class BillboardModel : IBufferable
    {
        public const string strPosition = "position";
        private VertexAttributeBuffer positionBufferPtr;

        private static readonly float[] positions =
        {
		    -0.5f, -0.5f, 0.0f,
		    0.5f, -0.5f, 0.0f,
		    -0.5f,  0.5f, 0.0f,
		    0.5f,  0.5f, 0.0f,
        };

        public VertexAttributeBuffer GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    int length = positions.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(float), length, VertexAttributeConfig.Vec3, BufferUsage.DynamicDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (float*)pointer;
                        for (int i = 0; i < positions.Length; i++)
                        {
                            array[i] = positions[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBufferPtr = bufferPtr;
                }
                return positionBufferPtr;
            }
            else
            {
                return null;
            }
        }

        public IndexBuffer GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int vertexCount = 4;
                ZeroIndexBuffer bufferPtr = ZeroIndexBuffer.Create(DrawMode.TriangleStrip, 0, vertexCount);
                this.indexBufferPtr = bufferPtr;
            }

            return this.indexBufferPtr;
        }

        private IndexBuffer indexBufferPtr = null;

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}