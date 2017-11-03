using System;
using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    /// Information of rendering a glyph.
    /// 绘制一个字符（串）所需要的信息。
    /// </summary>
    public class GlyphInfo : ICloneable
    {
        /// <summary>
        /// The glyph(a character or a string).
        /// 此字符（串）。
        /// </summary>
        public readonly string characters;
        /// <summary>
        /// UV information.
        /// 此字形在纹理的偏移量（uv）
        /// </summary>
        public readonly QuadUVStruct quad;

        /// <summary>
        /// Index of the the texture which this glyph belongs to in the 2D texture array.
        /// 此字符所在的纹理，在二维纹理数组中的索引。
        /// </summary>
        public readonly int textureIndex;

        /// <summary>
        /// Information of rendering a glyph.
        /// 绘制一个字符（串）所需要的信息。
        /// </summary>
        /// <param name="characters">The glyph(a character or a string).此字符（串）。</param>
        /// <param name="leftTop">UV of left top.此字符的字形在纹理的横向偏移量（左上角uv）</param>
        /// <param name="rightBottom">UV of right bottom.此字符的字形在纹理的纵向偏移量（右下角uv）</param>
        /// <param name="textureIndex">Index of the the texture which this glyph belongs to in the 2D texture array.此字符所在的纹理，在二维纹理数组中的索引。</param>
        public GlyphInfo(string characters, vec2 leftTop, vec2 rightBottom, int textureIndex)
        {
            this.characters = characters;
            var leftBottom = new vec2(leftTop.x, rightBottom.y);
            var rightTop = new vec2(rightBottom.x, leftTop.y);
            this.quad = new QuadUVStruct(leftTop, leftBottom, rightBottom, rightTop);
            this.textureIndex = textureIndex;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("glyph:[{0}], quad:[{1}], texture index:[{2}]", this.characters, this.quad, this.textureIndex);
        }

        /// <summary>
        /// clone this object.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            // all members are primitive type or structs, so let's simply memberwise clone.
            return this.MemberwiseClone();
        }
    }
}
