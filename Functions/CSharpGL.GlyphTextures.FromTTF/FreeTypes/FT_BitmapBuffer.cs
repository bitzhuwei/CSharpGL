using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.GlyphTextures.FromTTF.FreeTypes
{
    /// <summary>
    /// 字形的具体信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class FT_BitmapBuffer
    {
        /// <summary>
        /// 行数
        /// </summary>
        public int rows;

        /// <summary>
        /// 列数
        /// </summary>
        public int width;

        public int pitch;

        /// <summary>
        /// 字形点阵缓存所在位置
        /// </summary>
        public IntPtr buffer;

        public short num_grays;
        public sbyte pixel_mode;
        public sbyte palette_mode;
        public IntPtr palette;
    }
}
