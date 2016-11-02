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

        private VertexAttributeBufferPtr positionBufferPtr;
        private VertexAttributeBufferPtr uvBufferPtr;
        private IndexBufferPtr indexBufferPtr;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBufferPtr GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    int length = model.positions.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec3), length, VertexAttributeConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
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
                    this.positionBufferPtr = bufferPtr;
                }
                return this.positionBufferPtr;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.uvBufferPtr == null)
                {
                    int length = model.texCoords.Length;
                    VertexAttributeBufferPtr bufferPtr = VertexAttributeBufferPtr.Create(typeof(vec2), length, VertexAttributeConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
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
                    this.uvBufferPtr = bufferPtr;
                }
                return this.uvBufferPtr;
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
        public IndexBufferPtr GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int vertexCount = this.model.positions.Length;
                ZeroIndexBufferPtr bufferPtr = ZeroIndexBufferPtr.Create(this.model.GetDrawModel(), 0, vertexCount);
                this.indexBufferPtr = bufferPtr;
            }

            return this.indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }
    }
}