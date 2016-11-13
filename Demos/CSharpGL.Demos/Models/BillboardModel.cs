using System;
namespace CSharpGL.Demos
{
    internal class BillboardModel : IBufferable
    {
        public const string strPosition = "position";
        private VertexBuffer positionBuffer;

        private static readonly float[] positions =
        {
		    -0.5f, -0.5f, 0.0f,
		    0.5f, -0.5f, 0.0f,
		    -0.5f,  0.5f, 0.0f,
		    0.5f,  0.5f, 0.0f,
        };

        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBuffer == null)
                {
                    //int length = positions.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(float), length, VBOConfig.Vec3, BufferUsage.DynamicDraw, varNameInShader);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (float*)pointer;
                    //    for (int i = 0; i < positions.Length; i++)
                    //    {
                    //        array[i] = positions[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.positionBuffer = buffer;
                    this.positionBuffer = positions.GetVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.DynamicDraw);
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