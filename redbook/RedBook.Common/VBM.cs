using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RedBook.Common
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
        public uint num_chunks;
        public uint num_vertices;
        public uint num_indices;
        public uint indexype;
        public uint num_materials;
        public uint flags;
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

    public struct VBM_RENDER_CHUNK
    {
        public uint material_index;
        public uint first;
        public uint count;
    }

    public struct VBM_VEC4F
    {
        public float x;
        public float y;
        public float z;
        public float w;
    }

    public struct VBM_VEC3F
    {
        public float x;
        public float y;
        public float z;
    }

    public struct VBM_VEC2F
    {
        public float x;
        public float y;
    }

    public struct VBM_MATERIAL
    {
        /// <summary>
        /// Name of material
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string name;//char name[32]; 
        /// <summary>
        /// Ambient color
        /// </summary>
        public VBM_VEC3F ambient;
        /// <summary>
        /// Diffuse color
        /// </summary>
        public VBM_VEC3F diffuse;
        /// <summary>
        /// Specular color
        /// </summary>
        public VBM_VEC3F specular;
        /// <summary>
        /// Specular exponent
        /// </summary>
        public VBM_VEC3F specular_exp;
        /// <summary>
        /// Shininess
        /// </summary>
        public float shininess;
        /// <summary>
        /// Alpha (transparency)
        /// </summary>
        public float alpha;
        /// <summary>
        /// Transmissivity
        /// </summary>
        public VBM_VEC3F transmission;
        /// <summary>
        /// Index of refraction (optical density)
        /// </summary>
        public float ior;
        /// <summary>
        /// Ambient map (texture)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ambient_map;   // char ambient_map[64];                   
        /// <summary>
        /// Diffuse map (texture)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string diffuse_map;   // char diffuse_map[64];   
        /// <summary>
        /// Specular map (texture)
        /// </summary>

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string specular_map;  // char specular_map[64];                  
        /// <summary>
        /// Normal map (texture)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string normal_map;    // char normal_map[64];                    
    }
}
