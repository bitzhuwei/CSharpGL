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

    /// <summary>
    /// FreeType库
    /// </summary>
    public class FreeTypeLiabrary : FreeTypeObjectBase<FT_Library>
    {
        /// <summary>
        /// 初始化FreeType库
        /// </summary>
        public FreeTypeLiabrary()
        {
            int ret = FreeTypeAPI.FT_Init_FreeType(out this.pointer);
            if (ret != 0) { throw new Exception("Could not init freetype library!"); }

            this.obj = (FT_Library)Marshal.PtrToStructure(this.pointer, typeof(FT_Library));
            //lib = Marshal.PtrToStructure<Library>(libptr);
        }

        protected override void ReleaseResource()
        {
            FreeTypeAPI.FT_Done_FreeType(this.pointer);
        }

    }

    [StructLayout(LayoutKind.Sequential)]
    public class FT_Library
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

        public override string ToString()
        {
            return string.Format("major: {0}, minor: {1}, refCount: {2}", major, minor, refCount);
        }
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

    public abstract class FreeTypeObjectBase<T> : IDisposable where T : class
    {
        /// <summary>
        /// 指针
        /// </summary>
        public IntPtr pointer;

        /// <summary>
        /// 对象
        /// </summary>
        public T obj;

        public override string ToString()
        {
            return string.Format("{0}: [{1}]", this.pointer, this.obj);
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        private Boolean disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(Boolean disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //TODO: Managed cleanup code here, while managed refs still valid
            }
            //TODO: Unmanaged cleanup code here
            ReleaseResource();
            this.pointer = IntPtr.Zero;
            this.obj = null;

            disposed = true;
        }

        /// <summary>
        /// Unmanaged cleanup code here
        /// </summary>
        protected abstract void ReleaseResource();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate 
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        #endregion

    }

    /// <summary>
    /// 初始化字体库
    /// </summary>
    public class FreeTypeFace : FreeTypeObjectBase<FT_Face>
    {
        public int size;

        /// <summary>
        /// 初始化字体库
        /// </summary>
        /// <param name="library"></param>
        /// <param name="fontFullname"></param>
        /// <param name="size"></param>
        public FreeTypeFace(FreeTypeLiabrary library, string fontFullname, int size)
        {
            int retb = FreeTypeAPI.FT_New_Face(library.pointer, fontFullname, 0, out pointer);
            if (retb != 0) { throw new Exception("Could not open font"); }

            this.obj = (FT_Face)Marshal.PtrToStructure(pointer, typeof(FT_Face));

            this.size = size;

            // Freetype measures the font size in 1/64th of pixels for accuracy 
            // so we need to request characters in size*64
            // 设置字符大小？
            FreeTypeAPI.FT_Set_Char_Size(this.pointer, size << 6, size << 6, 96, 96);

            // Provide a reasonably accurate estimate for expected pixel sizes
            // when we later on create the bitmaps for the font
            // 设置像素大小？
            FreeTypeAPI.FT_Set_Pixel_Sizes(this.pointer, size, size);
        }

        /// <summary>
        /// Unmanaged cleanup code here
        /// </summary>
        protected override void ReleaseResource()
        {
            FreeTypeAPI.FT_Done_Face(this.pointer);
        }

    }
    /// <summary>
    /// 一个TTF文件里的字形会被转换为Face。Face就是一个TTF里字形的集合。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class FT_Face
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

    /// <summary>
    /// 把字形转换为纹理
    /// </summary>
    public class FreeTypeBitmapGlyph : FreeTypeObjectBase<FT_BitmapGlyph>
    {
        /// <summary>
        /// char 
        /// </summary>
        public char glyphChar;

        /// <summary>
        /// 把字形转换为纹理    
        /// </summary>
        /// <param name="face"></param>
        /// <param name="c"></param>
        public FreeTypeBitmapGlyph(FreeTypeFace face, char c)
        {
            // We first convert the number index to a character index
            // 根据字符获取其编号
            int index = FreeTypeAPI.FT_Get_Char_Index(face.pointer, Convert.ToChar(c));

            // Here we load the actual glyph for the character
            // 加载此字符的字形
            int ret = FreeTypeAPI.FT_Load_Glyph(face.pointer, index, FT_LOAD_TYPES.FT_LOAD_DEFAULT);
            if (ret != 0) { throw new Exception(string.Format("Could not load character '{0}'", Convert.ToChar(c))); }
            
            int retb = FreeTypeAPI.FT_Get_Glyph(face.obj.glyphrec, out this.pointer);
            if (retb != 0) return;
            object objGlyphRec = Marshal.PtrToStructure(face.obj.glyphrec, typeof(GlyphRec));
            GlyphRec glyph_rec = (GlyphRec)objGlyphRec;

            FreeTypeAPI.FT_Glyph_To_Bitmap(out this.pointer, FT_RENDER_MODES.FT_RENDER_MODE_NORMAL, 0, 1);
            this.obj = (FT_BitmapGlyph)Marshal.PtrToStructure(this.pointer, typeof(FT_BitmapGlyph));
        }

        protected override void ReleaseResource()
        {
            //throw new NotImplementedException();
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public class FT_BitmapGlyph
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
