using System;
namespace CSharpGL
{
    /// <summary>
    /// Square.
    /// <para>Uses <see cref="ZeroIndexBuffer"/></para>
    /// </summary>
    public class Square : IBufferable
    {
        private SquareModel model;

        /// <summary>
        /// Square.
        /// </summary>
        public Square()
        {
            this.model = new SquareModel();
        }

        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strTexCoord = "texCoord";

        private VertexAttributeBuffer positionBuffer;
        private VertexAttributeBuffer uvBuffer;
        private IndexBuffer indexBuffer;

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
                    int length = model.positions.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec3*)pointer;
                        for (int i = 0; i < model.positions.Length; i++)
                        {
                            array[i] = model.positions[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.positionBuffer = bufferPtr;
                }
                return this.positionBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.uvBuffer == null)
                {
                    int length = model.texCoords.Length;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(vec2), length, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
                    unsafe
                    {
                        IntPtr pointer = bufferPtr.MapBuffer(MapBufferAccess.WriteOnly);
                        var array = (vec2*)pointer;
                        for (int i = 0; i < model.texCoords.Length; i++)
                        {
                            array[i] = model.texCoords[i];
                        }
                        bufferPtr.UnmapBuffer();
                    }
                    this.uvBuffer = bufferPtr;
                }
                return this.uvBuffer;
            }
            else
            {
                return null;
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
                int vertexCount = this.model.positions.Length;
                ZeroIndexBuffer bufferPtr = ZeroIndexBuffer.Create(this.model.GetDrawModel(), 0, vertexCount);
                this.indexBuffer = bufferPtr;
            }

            return this.indexBuffer;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}