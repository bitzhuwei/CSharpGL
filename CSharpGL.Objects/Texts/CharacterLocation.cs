using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts
{
    /// <summary>
    /// 一个字形在大纹理上的位置信息。
    /// </summary>
    struct CharacterLocation
    {
        public float advanceX;	// advance.x
        public float advanceY;	// advance.y

        public float bitmapWidth;	// bitmap.width;
        public float bitmapHeight;	// bitmap.height;

        public float bitmapLeft;	// bitmap_left;
        public float bitmapTop;	// bitmap_top;

        /// <summary>
        /// x offset of glyph in texture coordinates
        /// </summary>
        public float xoffset;
        /// <summary>
        /// y offset of glyph in texture coordinates
        /// </summary>
        public float yoffset;
    }
}
