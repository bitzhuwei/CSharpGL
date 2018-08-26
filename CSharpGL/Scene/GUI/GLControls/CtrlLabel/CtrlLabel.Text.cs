using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class CtrlLabel
    {
        private string text = string.Empty;
        private GlyphsModel labelModel;
        private VertexBuffer positionBuffer;
        private VertexBuffer stringBuffer;
        private DrawArraysCmd drawCmd;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler TextChanged;
        /// <summary>
        /// 
        /// </summary>
        protected void DoTextChanged()
        {
            var textChanged = this.TextChanged;
            if (textChanged != null)
            {
                TextChanged(this, EventArgs.Empty);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public unsafe string Text
        {
            get { return text; }
            set
            {
                string v = value == null ? string.Empty : value;
                if (v != text)
                {
                    text = v;
                    ArrangeCharaters(v, GlyphServer.DefaultServer);
                    DoTextChanged();
                }
            }
        }

        unsafe private void ArrangeCharaters(string text, GlyphServer server)
        {
            float totalWidth, totalHeight;
            PositionPass(text, server, out totalWidth, out totalHeight);
            UVPass(text, server);

            this.drawCmd.VertexCount = text.Length * 4; // each alphabet needs 4 vertexes.

            this.Width = (int)(totalWidth * this.Height / totalHeight); // auto size means auto width.
        }

        /// <summary>
        /// start from (0, 0) to the right.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="server"></param>
        unsafe private void UVPass(string text, GlyphServer server)
        {
            VertexBuffer buffer = this.stringBuffer;
            var textureIndexArray = (QuadSTRStruct*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
            int index = 0;
            foreach (var c in text)
            {
                if (index >= this.labelModel.Capacity) { break; }

                GlyphInfo glyphInfo;
                if (server.GetGlyphInfo(c, out glyphInfo))
                {
                    textureIndexArray[index] = glyphInfo.quad;
                }

                index++;
            }

            buffer.UnmapBuffer();
        }

        /// <summary>
        /// start from (0, 0) to the right.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="server"></param>
        /// <param name="totalWidth"></param>
        /// <param name="totalHeight"></param>
        unsafe private void PositionPass(string text, GlyphServer server,
            out float totalWidth, out float totalHeight)
        {
            int textureWidth = server.TextureWidth;
            int textureHeight = server.TextureHeight;
            VertexBuffer buffer = this.positionBuffer;
            var positionArray = (QuadPositionStruct*)buffer.MapBuffer(MapBufferAccess.ReadWrite);
            const float height = 2.0f; // let's say height is 2.0f.
            totalWidth = 0;
            totalHeight = height;
            int index = 0;
            foreach (var c in text)
            {
                if (index >= this.labelModel.Capacity) { break; }

                GlyphInfo glyphInfo;
                float wByH = 0;
                if (server.GetGlyphInfo(c, out glyphInfo))
                {
                    float w = (glyphInfo.quad.rightBottom.x - glyphInfo.quad.leftBottom.x) * textureWidth;
                    float h = (glyphInfo.quad.rightBottom.y - glyphInfo.quad.rightTop.y) * textureHeight;
                    wByH = height * w / h;
                }
                else
                {
                    // put an empty glyph(square) here.
                    wByH = height * 1.0f / 1.0f;
                }

                var leftTop = new vec2(totalWidth, height / 2);
                var leftBottom = new vec2(totalWidth, -height / 2);
                var rightBottom = new vec2(totalWidth + wByH, -height / 2);
                var rightTop = new vec2(totalWidth + wByH, height / 2);
                positionArray[index++] = new QuadPositionStruct(leftTop, leftBottom, rightBottom, rightTop);
                totalWidth += wByH;
            }

            // move to center.
            const float scale = 1f;
            for (int i = 0; i < text.Length; i++)
            {
                if (i >= this.labelModel.Capacity) { break; }

                QuadPositionStruct quad = positionArray[i];
                var newPos = new QuadPositionStruct(
                    // y is already in [-1, 1], so just shrink x to [-1, 1]
                    new vec2(quad.leftTop.x / totalWidth * 2.0f - 1f, quad.leftTop.y) * scale,
                    new vec2(quad.leftBottom.x / totalWidth * 2.0f - 1f, quad.leftBottom.y) * scale,
                    new vec2(quad.rightBottom.x / totalWidth * 2.0f - 1f, quad.rightBottom.y) * scale,
                    new vec2(quad.rightTop.x / totalWidth * 2.0f - 1f, quad.rightTop.y) * scale
                    );

                positionArray[i] = newPos;
            }

            buffer.UnmapBuffer();
        }

        private vec3 color = new vec3(0, 0, 0);
        /// <summary>
        /// Text color.
        /// </summary>
        public vec3 Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value;

                    ModernRenderUnit unit = this.RenderUnit;
                    if (unit == null) { return; }
                    RenderMethod method = unit.Methods[0];
                    if (method == null) { return; }
                    ShaderProgram program = method.Program;
                    if (program == null) { return; }

                    program.SetUniform("textColor", value);
                }
            }
        }
    }
}
