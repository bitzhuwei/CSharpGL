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

        private VertexBuffer positionBuffer;
        private VertexBuffer uvBuffer;
        private IndexBuffer indexBuffer;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexBuffer GetVertexAttributeBuffer(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBuffer == null)
                {
                    //int length = model.positions.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(vec3), length, VBOConfig.Vec3, BufferUsage.StaticDraw, varNameInShader);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (vec3*)pointer;
                    //    for (int i = 0; i < model.positions.Length; i++)
                    //    {
                    //        array[i] = model.positions[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.positionBuffer = buffer;
                    // another way to do this:
                    this.positionBuffer = this.model.positions.GetVertexBuffer(VBOConfig.Vec3, varNameInShader, BufferUsage.StaticDraw);
                }
                return this.positionBuffer;
            }
            else if (bufferName == strTexCoord)
            {
                if (this.uvBuffer == null)
                {
                    //int length = model.texCoords.Length;
                    //VertexBuffer buffer = VertexBuffer.Create(typeof(vec2), length, VBOConfig.Vec2, BufferUsage.StaticDraw, varNameInShader);
                    //unsafe
                    //{
                    //    IntPtr pointer = buffer.MapBuffer(MapBufferAccess.WriteOnly);
                    //    var array = (vec2*)pointer;
                    //    for (int i = 0; i < model.texCoords.Length; i++)
                    //    {
                    //        array[i] = model.texCoords[i];
                    //    }
                    //    buffer.UnmapBuffer();
                    //}
                    //this.uvBuffer = buffer;
                    // another way to do this:
                    this.uvBuffer = this.model.texCoords.GetVertexBuffer(VBOConfig.Vec2, varNameInShader, BufferUsage.StaticDraw);
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
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(this.model.GetDrawModel(), 0, vertexCount);
                this.indexBuffer = buffer;
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