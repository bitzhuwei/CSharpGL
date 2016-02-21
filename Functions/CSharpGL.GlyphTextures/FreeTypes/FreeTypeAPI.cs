using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.GlyphTextures.FreeTypes
{
    /// <summary>
    /// 封装了一些FreeType的函数。
    /// </summary>
    public static class FreeTypeAPI
    {
        const string freetypeDll = @"FreeTypes\freetype.dll";

        /// <summary>
        /// Before using any other FreeType function, we need to initialize the library
        /// 在使用任何其它FreeType函数前，我们必须初始化此库。
        /// </summary>
        /// <param name="lib"></param>
        /// <returns></returns>
        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Init_FreeType(out System.IntPtr lib);
        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Done_FreeType(System.IntPtr lib);

        /// <summary>
        /// 加载字体库
        /// </summary>
        /// <param name="lib"></param>
        /// <param name="fname"></param>
        /// <param name="index"></param>
        /// <param name="face"></param>
        /// <returns></returns>
        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_New_Face(System.IntPtr lib,
            string fname,
            int index,
            out System.IntPtr face);

        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Char_Size(System.IntPtr face,
            int width,
            int height,
            int horz_resolution,
            int vert_resolution);

        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Set_Pixel_Sizes(System.IntPtr face,
            int pixel_width,
            int pixel_height);

        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Done_Face(System.IntPtr face);

        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Get_Char_Index(System.IntPtr face, int c);

        /// <summary>
        /// 加载此字符的字形到指定的face.
        /// </summary>
        /// <param name="face"></param>
        /// <param name="index"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Load_Glyph(System.IntPtr face,
            int index,
            FT_LOAD_TYPES flags);

        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern int FT_Get_Glyph(System.IntPtr glyphrec,
            out System.IntPtr glyph);

        [DllImport(freetypeDll, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FT_Glyph_To_Bitmap(out System.IntPtr glyph,
            FT_RENDER_MODES render_mode,
            int origin,
            int destroy);
    }

    //[StructLayout(LayoutKind.Sequential)]
    //public class GlyphClass
    //{
    //    public int size;
    //    public uint format;
    //    public System.IntPtr init;
    //    public System.IntPtr done;
    //    public System.IntPtr copy;
    //    public System.IntPtr transform;
    //    public System.IntPtr bbox;
    //    public System.IntPtr prepare;
    //}
}
