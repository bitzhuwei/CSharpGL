using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts.FreeTypes
{
    [StructLayout(LayoutKind.Sequential)]
    public class FT_BitmapGlyph
    {
        public GlyphRec root;
        public int left;
        /// <summary>
        /// 基线高度。
        /// </summary>
        public int top;
        public Bitmap bitmap;
    }

}
