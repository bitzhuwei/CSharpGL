using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceFieldFont
{
    public partial class SingleLineModel
    {
        private string text;
        private float lineWidth;

        public float LineWidth
        {
            get { return lineWidth; }
        }
        private float lineHeight;

        public float LineHeight
        {
            get { return lineHeight; }
        }

        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;

                    UpdateBuffer(value);
                }
            }
        }

        private void UpdateBuffer(string text)
        {
            UpdatePositionBuffer(text);
            UpdateTexCoordBuffer(text);

            this.drawCmd.VertexCount = Math.Min(this.Capacity, text.Length) * 4;
        }

        private unsafe void UpdateTexCoordBuffer(string text)
        {
            GlyphServer server = this.glyphServer;
            float textureWidth = server.TextureWidth;
            float textureHeight = server.TextureHeight;
            //float maxHeight = server.MaxHeight;
            //float maxDiff = server.MaxDiff;
            Dictionary<char, GlyphInfo> dict = server.CharGlyphDict;
            //float cursorX = 0, cursorY = 0;
            var glyphTexCoord = (GlyphTexCoord*)this.texCoordBuffer.MapBuffer(MapBufferAccess.ReadWrite);
            int index = 0;
            for (int i = 0; i < this.Capacity && i < text.Length; i++)
            {
                char c = text[i];
                GlyphInfo glyphInfo;
                if (dict.TryGetValue(c, out glyphInfo))
                {
                    float left = (glyphInfo.x) / textureWidth;
                    float right = (glyphInfo.x + glyphInfo.width) / textureWidth;
                    float bottom = (glyphInfo.y) / textureHeight;
                    float top = (glyphInfo.y + glyphInfo.height) / textureHeight;
                    glyphTexCoord[index] = new GlyphTexCoord(
                        new vec2(left, top),
                        new vec2(left, bottom),
                        new vec2(right, bottom),
                        new vec2(right, top)
                        );
                    index++;
                }
            }
            this.texCoordBuffer.UnmapBuffer();
        }

        private unsafe void UpdatePositionBuffer(string text)
        {
            GlyphServer server = this.glyphServer;
            float maxHeight = server.MaxHeight;
            float maxDiff = server.MaxDiff;
            Dictionary<char, GlyphInfo> dict = server.CharGlyphDict;
            float cursorX = 0, cursorY = 0;
            var glyphPositions = (GlyphPosition*)this.positionBuffer.MapBuffer(MapBufferAccess.ReadWrite);
            for (int i = 0; i < this.Capacity && i < text.Length; i++)
            {
                char c = text[i];
                GlyphInfo glyphInfo;
                if (dict.TryGetValue(c, out glyphInfo))
                {
                    float left = cursorX + glyphInfo.xOffset;
                    float right = left + glyphInfo.width;
                    float bottom = cursorY + maxHeight - glyphInfo.yOffset - maxDiff;
                    float top = bottom + glyphInfo.height;
                    glyphPositions[i] = new GlyphPosition(
                        new vec2(left, top),
                        new vec2(left, bottom),
                        new vec2(right, bottom),
                        new vec2(right, top)
                        );
                    cursorX += glyphInfo.xAdvance;
                }
            }
            // move glyphs to center in model space.
            //float halfWidth = cursorX / 2, halfHeight = maxHeight / 2;
            //for (int i = 0; i < text.Length; i++)
            //{
            //    GlyphPosition position = glyphPositions[i];
            //    float left = position.leftBottom.x;
            //    float right = position.rightBottom.x;
            //    float bottom = position.leftBottom.y;
            //    float top = position.leftTop.y;
            //    left -= halfWidth; right -= halfWidth;
            //    bottom -= halfHeight; top -= halfHeight;
            //    left /= cursorX; right /= cursorX;
            //    bottom /= maxHeight; top /= maxHeight;
            //    glyphPositions[index] = new GlyphPosition(
            //        new vec2(left, top),
            //        new vec2(left, bottom),
            //        new vec2(right, bottom),
            //        new vec2(right, top)
            //        );
            //}
            this.positionBuffer.UnmapBuffer();

            this.lineWidth = cursorX;
            this.lineHeight = maxHeight;
        }
    }
}
