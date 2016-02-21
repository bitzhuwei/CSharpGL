using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.GlyphTextures.FreeTypes
{
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
        public FT_Generic generic;
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
        public FT_ListRec sizes_list;
        public FT_Generic autohint;
        public System.IntPtr extensions;
        public System.IntPtr internal_face;

        public override string ToString()
        {
            return string.Format("num_charmaps:{0},num_faces:{1},num_glyphs:{2},style_name:{3}", num_charmaps, num_faces, num_glyphs, style_name);
        }
    }
}
