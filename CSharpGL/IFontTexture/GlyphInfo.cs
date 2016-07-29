using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// 绘制一个字符所需要的所有信息
    /// </summary>
    public class GlyphInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly GlyphInfo Default = new GlyphInfo(0, 0, 0, 0);

        /// <summary>
        /// 此字符的字形在纹理的横向偏移量（左上角）
        /// </summary>
        public float xoffset;

        /// <summary>
        /// 此字符的字形在纹理的纵向偏移量（左上角）
        /// </summary>
        public float yoffset;

        /// <summary>
        /// 此字符的字形宽度
        /// </summary>
        public float width;

        /// <summary>
        /// 此字符的字形高度
        /// </summary>
        public float height;
        /// <summary>
        /// 绘制一个字符所需要的所有信息
        /// </summary>
        /// <param name="xoffset">此字符的字形在纹理的横向偏移量（左上角）</param>
        /// <param name="yoffset">此字符的字形在纹理的纵向偏移量（左上角）</param>
        /// <param name="width">此字符的字形宽度</param>
        /// <param name="height">此字符的字形高度</param>
        public GlyphInfo(float xoffset, float yoffset, float width, float height)
        {
            this.xoffset = xoffset;
            this.yoffset = yoffset;
            this.width = width;
            this.height = height;
        }

        //public CharacterInfo() { }

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return string.Format("offset:{0}, {1}; size:{2}, {3};", xoffset, yoffset, width, height);
        }
    }
}
