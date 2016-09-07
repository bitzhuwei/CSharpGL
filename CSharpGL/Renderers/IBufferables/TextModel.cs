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

        private PropertyBufferPtr positionBufferPtr;
        private PropertyBufferPtr uvBufferPtr;
        private ZeroIndexBufferPtr indexBufferPtr;
        private int maxCharCount;

        /// <summary>
        ///
        /// </summary>
        /// <param name="bufferName"></param>
        /// <param name="varNameInShader"></param>
        /// <returns></returns>
        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<GlyphPosition>(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.DynamicDraw))
                    {
                        buffer.Create(maxCharCount);

                        positionBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }

                return positionBufferPtr;
            }
            else if (bufferName == strUV)
            {
                if (uvBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<GlyphTexCoord>(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.DynamicDraw))
                    {
                        buffer.Create(maxCharCount);

                        uvBufferPtr = buffer.GetBufferPtr() as PropertyBufferPtr;
                    }
                }

                return uvBufferPtr;
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
        public IndexBufferPtr GetIndex()
        {
            if (indexBufferPtr == null)
            {
                using (var buffer = new ZeroIndexBuffer(
                  DrawMode.Quads, 0, maxCharCount * 4))
                {
                    indexBufferPtr = buffer.GetBufferPtr() as ZeroIndexBufferPtr;
                }
            }

            return indexBufferPtr;
        }
        /// <summary>
        /// Uses <see cref="ZeroIndexBufferPtr"/> or <see cref="OneIndexBufferPtr"/>.
        /// </summary>
        /// <returns></returns>
        public bool UsesZeroIndexBufferPtr() { return true; }

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