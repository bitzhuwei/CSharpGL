using System;

namespace CSharpGL
{
    /// <summary>
    ///
    /// </summary>
    public partial class TextModel : IBufferable
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="maxCharCount"></param>
        public TextModel(int maxCharCount)
        {
            this.maxCharCount = maxCharCount;
        }

        /// <summary>
        ///
        /// </summary>
        public const string strPosition = "position";

        /// <summary>
        ///
        /// </summary>
        public const string strUV = "uv";

        private VertexAttributeBuffer positionBufferPtr;
        private VertexAttributeBuffer uvBufferPtr;
        private ZeroIndexBuffer indexBufferPtr;
        private int maxCharCount;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public VertexAttributeBuffer GetVertexAttributeBufferPtr(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (this.positionBufferPtr == null)
                {
                    int length = maxCharCount;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(GlyphPosition), length, VertexAttributeConfig.Vec2, BufferUsage.DynamicDraw, varNameInShader);

                    this.positionBufferPtr = bufferPtr;
                }

                return this.positionBufferPtr;
            }
            else if (bufferName == strUV)
            {
                if (this.uvBufferPtr == null)
                {
                    int length = maxCharCount;
                    VertexAttributeBuffer bufferPtr = VertexAttributeBuffer.Create(typeof(GlyphTexCoord), length, VertexAttributeConfig.Vec2, BufferUsage.DynamicDraw, varNameInShader);
                    this.uvBufferPtr = bufferPtr;
                }

                return this.uvBufferPtr;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IndexBuffer GetIndexBufferPtr()
        {
            if (this.indexBufferPtr == null)
            {
                int vertexCount = maxCharCount * 4;
                ZeroIndexBuffer bufferPtr = ZeroIndexBuffer.Create(DrawMode.Quads, 0, vertexCount);
                this.indexBufferPtr = bufferPtr;
            }

            return this.indexBufferPtr;
        }

        /// <summary>
        /// Uses <see cref="ZeroIndexBuffer"/> or <see cref="OneIndexBuffer"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBuffer() { return true; }

        /// <summary>
        ///
        /// </summary>
        public struct GlyphPosition
        {
            /// <summary>
            ///
            /// </summary>
            public vec2 leftUp;

            /// <summary>
            ///
            /// </summary>
            public vec2 leftDown;

            /// <summary>
            ///
            /// </summary>
            public vec2 rightUp;

            /// <summary>
            ///
            /// </summary>
            public vec2 rightDown;

            /// <summary>
            ///
            /// </summary>
            /// <param name="leftUp"></param>
            /// <param name="leftDown"></param>
            /// <param name="rightUp"></param>
            /// <param name="rightDown"></param>
            public GlyphPosition(
                vec2 leftUp,
                vec2 leftDown,
                vec2 rightUp,
                vec2 rightDown)
            {
                this.leftUp = leftUp;
                this.leftDown = leftDown;
                this.rightUp = rightUp;
                this.rightDown = rightDown;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public struct GlyphTexCoord
        {
            /// <summary>
            ///
            /// </summary>
            public vec2 leftUp;

            /// <summary>
            ///
            /// </summary>
            public vec2 leftDown;

            /// <summary>
            ///
            /// </summary>
            public vec2 rightUp;

            /// <summary>
            ///
            /// </summary>
            public vec2 rightDown;

            /// <summary>
            ///
            /// </summary>
            /// <param name="leftUp"></param>
            /// <param name="leftDown"></param>
            /// <param name="rightUp"></param>
            /// <param name="rightDown"></param>
            public GlyphTexCoord(
                vec2 leftUp,
                vec2 leftDown,
                vec2 rightUp,
                vec2 rightDown)
            {
                this.leftUp = leftUp;
                this.leftDown = leftDown;
                this.rightUp = rightUp;
                this.rightDown = rightDown;
            }
        }
    }
}