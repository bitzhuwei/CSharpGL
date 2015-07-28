using System;
using System.Runtime.InteropServices;

namespace CSharpGL.Objects.Texts
{
    public static class FreeTypeAPI
    {
        const string freetypeDll = @"Texts\freetype.dll";

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
        public static extern int FT_Get_Char_Index(System.IntPtr face, char c);

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
    public enum FT_LOAD_TYPES
    {
        FT_LOAD_DEFAULT = 0x0,
        FT_LOAD_NO_SCALE = 1 << 0,
        FT_LOAD_NO_HINTING = 1 << 1,
        FT_LOAD_RENDER = 1 << 2,
        FT_LOAD_NO_BITMAP = 1 << 3,
        FT_LOAD_VERTICAL_LAYOUT = 1 << 4,
        FT_LOAD_FORCE_AUTOHINT = 1 << 5,
        FT_LOAD_CROP_BITMAP = 1 << 6,
        FT_LOAD_PEDANTIC = 1 << 7,
        FT_LOAD_IGNORE_GLOBAL_ADVANCE_WIDTH = 1 << 9,
        FT_LOAD_NO_RECURSE = 1 << 10,
        FT_LOAD_IGNORE_TRANSFORM = 1 << 11,
        FT_LOAD_MONOCHROME = 1 << 12,
        FT_LOAD_LINEAR_DESIGN = 1 << 13,
        FT_LOAD_NO_AUTOHINT = 1 << 15,
        /* Bits 16..19 are used by `FT_LOAD_TARGET_' */
        FT_LOAD_COLOR = 1 << 20,

        /* */

        /* used internally only by certain font drivers! */
        FT_LOAD_ADVANCE_ONLY = 1 << 8,
        FT_LOAD_SBITS_ONLY = 1 << 14,
    }

    public enum FT_RENDER_MODES
    {
        FT_RENDER_MODE_NORMAL = 0,
        FT_RENDER_MODE_LIGHT = 1
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Library
    {
        public System.IntPtr memory;
        public Generic generic;
        public int major;
        public int minor;
        public int patch;
        public uint modules;
        public System.IntPtr module0, module1, module2, module3, module4, module5, module6, module7, module8, module9, module10;
        public System.IntPtr module11, module12, module13, module14, module15, module16, module17, module18, module19, module20;
        public System.IntPtr module21, module22, module23, module24, module25, module26, module27, module28, module29, module30;
        public System.IntPtr module31;
        public ListRec renderers;
        public System.IntPtr renderer;
        public System.IntPtr auto_hinter;
        public System.IntPtr raster_pool;
        public long raster_pool_size;
        public System.IntPtr debug0, debug1, debug2, debug3;
        public int refCount;

    }

    [StructLayout(LayoutKind.Sequential)]
    public class Generic
    {
        public System.IntPtr data;
        public System.IntPtr finalizer;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class BBox
    {
        public int xMin, yMin;
        public int xMax, yMax;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class ListRec
    {
        public System.IntPtr head;
        public System.IntPtr tail;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Vector
    {
        public int x;
        public int y;
    }

    /// <summary>
    /// 一个TTF文件里的字形会被转换为Face。Face就是一个TTF里字形的集合。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class Face
    {
        public int num_faces;
        public int face_index;
        public int face_flags;
        public int style_flags;
        public int num_glyphs;
        public string family_name;
        public string style_name;
        public int num_fixed_sizes;
        public System.IntPtr available_sizes;
        public int num_charmaps;
        public System.IntPtr charmaps;
        public Generic generic;
        public BBox box;
        public ushort units_per_EM;
        public short ascender;
        public short descender;
        public short height;
        public short max_advance_width;
        public short max_advance_height;
        public short underline_position;
        public short underline_tickness;
        public System.IntPtr glyphrec;
        public System.IntPtr size;
        public System.IntPtr charmap;
        public System.IntPtr driver;
        public System.IntPtr memory;
        public System.IntPtr stream;
        public ListRec sizes_list;
        public Generic autohint;
        public System.IntPtr extensions;
        public System.IntPtr internal_face;

    }

    [StructLayout(LayoutKind.Sequential)]
    public class GlyphRec
    {
        public System.IntPtr library;
        public System.IntPtr clazz;
        public int format;
        public Vector advance;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class GlyphClass
    {
        public int size;
        public uint format;
        public System.IntPtr init;
        public System.IntPtr done;
        public System.IntPtr copy;
        public System.IntPtr transform;
        public System.IntPtr bbox;
        public System.IntPtr prepare;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class BitmapGlyph
    {
        public GlyphRec root;
        public int left;
        public int top;
        public Bitmap bitmap;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class Bitmap
    {
        public int rows;
        public int width;
        public int pitch;
        public IntPtr buffer;
        public short num_grays;
        public sbyte pixel_mode;
        public sbyte palette_mode;
        public IntPtr palette;
    }

}
