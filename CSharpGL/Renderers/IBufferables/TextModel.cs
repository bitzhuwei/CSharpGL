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

        private VertexBuffer positionBuffer;
        private VertexBuffer uvBuffer;
        private ZeroIndexBuffer indexBuffer;
        private int maxCharCount;

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
                    int length = maxCharCount;
                    VertexBuffer buffer = VertexBuffer.Create(typeof(GlyphPosition), length, VBOConfig.Vec2, varNameInShader, BufferUsage.DynamicDraw);

                    this.positionBuffer = buffer;
                }

                return this.positionBuffer;
            }
            else if (bufferName == strUV)
            {
                if (this.uvBuffer == null)
                {
                    int length = maxCharCount;
                    VertexBuffer buffer = VertexBuffer.Create(typeof(GlyphTexCoord), length, VBOConfig.Vec2, varNameInShader, BufferUsage.DynamicDraw);
                    this.uvBuffer = buffer;
                }

                return this.uvBuffer;
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
        public IndexBuffer GetIndexBuffer()
        {
            if (this.indexBuffer == null)
            {
                int vertexCount = maxCharCount * 4;
                ZeroIndexBuffer buffer = ZeroIndexBuffer.Create(DrawMode.Quads, 0, vertexCount);
                this.indexBuffer = buffer;
            }

            return this.indexBuffer;
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