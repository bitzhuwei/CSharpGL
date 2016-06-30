using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL
{
    public partial class TextModel : IBufferable
    {

        public TextModel(int maxCharCount)
        {
            this.maxCharCount = maxCharCount;
        }
        public const string strPosition = "position";
        public const string strUV = "uv";
        public PropertyBufferPtr positionBufferPtr;
        public PropertyBufferPtr uvBufferPtr;
        public ZeroIndexBufferPtr indexBufferPtr;
        public int maxCharCount;

        public PropertyBufferPtr GetProperty(string bufferName, string varNameInShader)
        {
            if (bufferName == strPosition)
            {
                if (positionBufferPtr == null)
                {
                    using (var buffer = new PropertyBuffer<GlyphPosition>(varNameInShader, 2, OpenGL.GL_FLOAT, BufferUsage.DynamicDraw))
                    {
                        buffer.Alloc(maxCharCount);

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
                        buffer.Alloc(maxCharCount);

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


        public struct GlyphPosition
        {
            public vec2 leftUp;
            public vec2 leftDown;
            public vec2 rightUp;
            public vec2 rightDown;

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

        public struct GlyphTexCoord
        {
            public vec2 leftUp;
            public vec2 leftDown;
            public vec2 rightUp;
            public vec2 rightDown;

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