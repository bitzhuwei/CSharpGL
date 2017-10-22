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
        /// 此字符。
        /// </summary>
        public readonly char character;
        /// <summary>
        /// 此字符的字形在纹理的横向偏移量（左上角）
        /// </summary>
        public readonly vec2 leftTop;

        /// <summary>
        /// 此字符的字形在纹理的纵向偏移量（左下角）
        /// </summary>
        public readonly vec2 leftBottom;

        /// <summary>
        /// 此字符的字形在纹理的纵向偏移量（右下角）
        /// </summary>
        public readonly vec2 rightBottom;

        /// <summary>
        /// 此字符的字形在纹理的纵向偏移量（右上角）
        /// </summary>
        public readonly vec2 rightTop;

        /// <summary>
        /// 此字符的字形所在的纹理。
        /// </summary>
        public readonly Texture texture;

        /// <summary>
        /// 绘制一个字符所需要的所有信息
        /// </summary>
        /// <param name="character">此字符。</param>
        /// <param name="leftTop">此字符的字形在纹理的横向偏移量（左上角）</param>
        /// <param name="leftBottom">此字符的字形在纹理的纵向偏移量（左下角）</param>
        /// <param name="rightBottom">此字符的字形在纹理的纵向偏移量（右下角）</param>
        /// <param name="rightTop">此字符的字形在纹理的纵向偏移量（右上角）</param>
        /// <param name="texture">此字符的字形所在的纹理</param>
        public GlyphInfo(char character, vec2 leftTop, vec2 leftBottom, vec2 rightBottom, vec2 rightTop, Texture texture)
        {
            this.character = character;
            this.leftTop = leftTop;
            this.leftBottom = leftBottom;
            this.rightBottom = rightBottom;
            this.rightTop = rightTop;
            this.texture = texture;
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("left top: {0}, right bottom: {1}", leftTop, rightBottom);
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