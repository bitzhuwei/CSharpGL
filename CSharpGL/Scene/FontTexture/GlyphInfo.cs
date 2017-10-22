using System;
using System.Drawing;

namespace CSharpGL
{
    /// <summary>
    /// 绘制一个字符所需要的所有信息
    /// </summary>
    public class GlyphInfo : ICloneable
    {
        /// <summary>
        ///
        /// </summary>
        public static readonly GlyphInfo Default = new GlyphInfo(0, 0, 0, 0);

        /// <summary>
        /// 此字符的字形在纹理的横向偏移量（左上角）
        /// </summary>
        public readonly int xoffset;

        /// <summary>
        /// 此字符的字形在纹理的纵向偏移量（左上角）
        /// </summary>
        public readonly int yoffset;

        /// <summary>
        /// 此字符的字形宽度
        /// </summary>
        public readonly int width;

        /// <summary>
        /// 此字符的字形高度
        /// </summary>
        public readonly int height;

        /// <summary>
        /// 此字符所在的字形贴图的索引。
        /// </summary>
        public readonly int glyphMapIndex;

        /// <summary>
        /// 绘制一个字符所需要的所有信息
        /// </summary>
        /// <param name="xoffset">此字符的字形在纹理的横向偏移量（左上角）</param>
        /// <param name="yoffset">此字符的字形在纹理的纵向偏移量（左上角）</param>
        /// <param name="width">此字符的字形宽度</param>
        /// <param name="height">此字符的字形高度</param>
        public GlyphInfo(int xoffset, int yoffset, int width, int height)
        {
            this.xoffset = xoffset;
            this.yoffset = yoffset;
            this.width = width;
            this.height = height;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Rectangle ToRectangle(int shrinkX = 0, int shrinkY = 0, int shrinkWidth = 0, int shrinkHeight = 0)
        {
            return new Rectangle(this.xoffset + shrinkX, this.yoffset + shrinkY,
                this.width + shrinkWidth, this.height + shrinkHeight);
        }

        /// <summary>
        ///
        /// </summary>
        public override string ToString()
        {
            return string.Format("offset:{0}, {1}; size:{2}, {3};", xoffset, yoffset, width, height);
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