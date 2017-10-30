using System;
using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    /// 绘制一个字符所需要的所有信息
    /// </summary>
    public class GlyphInfo : ICloneable
    {
        ///// <summary>
        /////
        ///// </summary>
        //public static readonly GlyphInfo Default = new GlyphInfo('\0', 0, 0, 0, 0, null);

        /// <summary>
        /// 此字符（串）。
        /// </summary>
        public readonly string characters;
        /// <summary>
        /// 此字符的字形在纹理的偏移量（uv）
        /// </summary>
        public readonly QuadStruct quad;
        ///// <summary>
        ///// 此字符的字形在纹理的横向偏移量（左上角uv）
        ///// </summary>
        //public readonly vec2 leftTop;

        ///// <summary>
        ///// 此字符的字形在纹理的纵向偏移量（左下角uv）
        ///// </summary>
        //public readonly vec2 leftBottom;

        ///// <summary>
        ///// 此字符的字形在纹理的纵向偏移量（右下角uv）
        ///// </summary>
        //public readonly vec2 rightBottom;

        ///// <summary>
        ///// 此字符的字形在纹理的纵向偏移量（右上角uv）
        ///// </summary>
        //public readonly vec2 rightTop;

        ///// <summary>
        ///// 高宽比。
        ///// </summary>
        //public float WidthByHeight { get { return (rightBottom.x - leftTop.x) / (rightBottom.y - leftTop.y); } }

        /// <summary>
        /// 此字符的字形所在的纹理，在的数组中的索引。
        /// </summary>
        public readonly int textureIndex;

        /// <summary>
        /// 绘制一个字符所需要的所有信息
        /// </summary>
        /// <param name="characters">此字符（串）。</param>
        /// <param name="leftTop">此字符的字形在纹理的横向偏移量（左上角uv）</param>
        /// <param name="rightBottom">此字符的字形在纹理的纵向偏移量（右下角uv）</param>
        /// <param name="textureIndex">此字符的字形所在的纹理，在的数组中的索引</param>
        public GlyphInfo(string characters, vec2 leftTop, vec2 rightBottom, int textureIndex)
        {
            this.characters = characters;
            var leftBottom = new vec2(leftTop.x, rightBottom.y);
            var rightTop = new vec2(rightBottom.x, leftTop.y);
            this.quad = new QuadStruct(leftTop, leftBottom, rightBottom, rightTop);
            this.textureIndex = textureIndex;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("[{0}], quad:[{1}], texture index:[{2}]", this.characters, this.quad, this.textureIndex);
        }

        /// <summary>
        /// clone this object.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
