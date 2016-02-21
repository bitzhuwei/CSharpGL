using CSharpGL.Objects.Models;
using CSharpGL.Objects.Textures;
using CSharpGL.Objects.VertexBuffers;
using GLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Texts
{
    /// <summary>
    /// 用于渲染一段文字
    /// </summary>
    public class StringModel : IModel
    {
        public sampler2D glyphTexture { get; set; }
        public GlyphPosition[] positions { get; set; }
        public GlyphColor[] colors { get; set; }
        public GlyphTexCoord[] texCoords { get; set; }

        public Objects.VertexBuffers.BufferRenderer GetPositionBufferRenderer(string varNameInShader)
        {
            using (var buffer = new PositionBuffer(varNameInShader))
            {
                buffer.Alloc(positions.Length);
                unsafe
                {
                    GlyphPosition* array = (GlyphPosition*)buffer.FirstElement();
                    for (int i = 0; i < positions.Length; i++)
                    {
                        array[i] = positions[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        public Objects.VertexBuffers.BufferRenderer GetColorBufferRenderer(string varNameInShader)
        {
            using (var buffer = new ColorBuffer(varNameInShader))
            {
                buffer.Alloc(colors.Length);
                unsafe
                {
                    GlyphColor* array = (GlyphColor*)buffer.FirstElement();
                    for (int i = 0; i < colors.Length; i++)
                    {
                        array[i] = colors[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        public Objects.VertexBuffers.BufferRenderer GetTexCoordBufferRenderer(string varNameInShader)
        {
            using (var buffer = new TexCoordBuffer(varNameInShader))
            {
                buffer.Alloc(texCoords.Length);
                unsafe
                {
                    GlyphTexCoord* array = (GlyphTexCoord*)buffer.FirstElement();
                    for (int i = 0; i < texCoords.Length; i++)
                    {
                        array[i] = texCoords[i];
                    }
                }

                return buffer.GetRenderer();
            }
        }

        public Objects.VertexBuffers.BufferRenderer GetNormalBufferRenderer(string varNameInShader)
        {
            return null;
        }

        public Objects.VertexBuffers.BufferRenderer GetIndexes()
        {
            using (var buffer = new ZeroIndexBuffer(DrawMode.Quads, 0, this.positions.Length * 4))
            {
                return buffer.GetRenderer();
            }
        }

        public struct GlyphPosition
        {
            public vec2 leftUp;
            public vec2 leftDown;
            public vec2 rightUp;
            public vec2 rightDown;
        }

        public struct GlyphColor
        {
            public vec4 leftUp;
            public vec4 leftDown;
            public vec4 rightUp;
            public vec4 rightDown;
        }

        public struct GlyphTexCoord
        {
            public vec2 leftUp;
            public vec2 leftDown;
            public vec2 rightUp;
            public vec2 rightDown;
        }

        public class PositionBuffer : PropertyBuffer<GlyphPosition>
        {
            public PositionBuffer(string varNameInShader)
                : base(varNameInShader, 2, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }
        public class ColorBuffer : PropertyBuffer<GlyphColor>
        {
            public ColorBuffer(string varNameInShader)
                : base(varNameInShader, 4, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }

        public class TexCoordBuffer : PropertyBuffer<GlyphTexCoord>
        {
            public TexCoordBuffer(string varNameInShader)
                : base(varNameInShader, 2, GL.GL_FLOAT, BufferUsage.StaticDraw)
            { }
        }
    }
}
