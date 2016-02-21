using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL.GlyphTextures
{
    /// <summary>
    /// 绘制一个字符所需要的所有信息
    /// </summary>
    public class CharacterInfo
    {
        public static readonly CharacterInfo Default = new CharacterInfo() { yoffset = 0, xoffset = 0, height = 0, width = 0, };

        /// <summary>
        /// 此字符的字形在纹理的横向偏移量
        /// </summary>
        public int xoffset;

        /// <summary>
        /// 此字符的字形在纹理的纵向偏移量
        /// </summary>
        public int yoffset;

        /// <summary>
        /// 此字符的字形宽度
        /// </summary>
        public int width;

        /// <summary>
        /// 此字符的字形高度
        /// </summary>
        public int height;

        public override string ToString()
        {
            return string.Format("{0}offset:{1}, {2}; size:{3}, {4};",
                "", xoffset, yoffset, width, height);
        }
    }
}
