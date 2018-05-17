using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class TextBillboardNode
    {
        private string text = string.Empty;
        private GlyphsModel textModel;
        private VertexBuffer positionBuffer;
        private VertexBuffer strBuffer;
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
                    ArrangeCharaters(v, this.glyphServer);
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

            if (totalWidth != 0.0f && totalHeight != 0.0f)
            {
                this.widthByHeight = totalWidth / totalHeight;
                this.heightByWidth = totalHeight / totalWidth;
                this.Width = (int)(this.Height * this.widthByHeight);// auto size means auto width.
            }
            else
            {
                this.Width = 0;
            }
        }

        /// <summary>
        /// start from (0, 0) to the right.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="server"></param>
        unsafe private void UVPass(string text, GlyphServer server)
        {
            VertexBuffer buffer = this.strBuffer;
            var textureIndexArray = (QuadSTRStruct*)buffer.MapBuffer(MapBufferAccess.WriteOnly);
            int index = 0;
            foreach (var c in text)
            {
                if (index >= this.textModel.Capacity) { break; }

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
            const float height = 2; // 2 is the height value in clip space.
            totalWidth = 0;
            totalHeight = height;
            int index = 0;
            foreach (var c in text)
            {
                if (index >= this.textModel.Capacity) { break; }

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

                var leftTop = new vec2(totalWidth, height);
                var leftBottom = new vec2(totalWidth, 0);
                var rightBottom = new vec2(totalWidth + wByH, 0);
                var rightTop = new vec2(totalWidth + wByH, height);
                positionArray[index++] = new QuadPositionStruct(leftTop, leftBottom, rightBottom, rightTop);

                totalWidth += wByH;
            }

            buffer.UnmapBuffer();
        }

        private vec3 _color = new vec3(0, 0, 0);
        /// <summary>
        /// Text color.
        /// </summary>
        public vec3 Color
        {
            get { return this._color; }
            set
            {
                if (this._color != value)
                {
                    this._color = value;

                    ModernRenderUnit unit = this.RenderUnit;
                    if (unit == null) { return; }
                    RenderMethod method = unit.Methods[0];
                    if (method == null) { return; }
                    ShaderProgram program = method.Program;
                    if (program == null) { return; }

                    program.SetUniform(textColor, this._color);
                }
            }
        }
    }
}
