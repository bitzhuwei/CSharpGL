using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Common.FurExample
{
    public class VBM
    {
        public const int VBM_FLAG_HAS_VERTICES = 0x00000001;
        public const int VBM_FLAG_HAS_INDICES = 0x00000002;
        public const int VBM_FLAG_HAS_FRAMES = 0x00000004;
        public const int VBM_FLAG_HAS_MATERIALS = 0x00000008;
    }

    public struct VBM_HEADER
    {
        public uint magic;
        public uint size;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;//char name[64];
        public uint num_attribs;
        public uint num_frames;
        public uint num_vertices;
        public uint num_indices;
        public uint indexype;
    }

    public struct VBM_ATTRIB_HEADER
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name; //char name[64];
        public uint type;
        public uint components;
        public uint flags;
    }

    public struct VBM_FRAME_HEADER
    {
        public uint first;
        public uint count;
        public uint flags;
    }

    //public struct VBM_RENDER_CHUNK
    //{
    //    public uint material_index;
    //    public uint first;
    //    public uint count;
    //}

}
