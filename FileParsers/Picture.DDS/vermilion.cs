using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public partial class vermilion
    {
        /// <summary>
        /// Enough mips for 16K x 16K, which is the minumum required for OpenGL 4.x
        /// </summary>
        public const int MAX_TEXTURE_MIPS = 14;
        public static readonly int NUM_DDS_FORMATS;
        static vermilion()
        {
            NUM_DDS_FORMATS = InfoTable.gl_info_table.Length;//(sizeof(gl_info_table) / sizeof(gl_info_table[0]));
        }
    }
    // Each texture image data structure contains an array of MAX_TEXTURE_MIPS
    // of these mipmap structures. The structure represents the mipmap data for
    // all slices at that level.
    struct vglImageMipData
    {
        public int width;                              // Width of this mipmap level
        public int height;                             // Height of this mipmap level
        public int depth;                              // Depth pof mipmap level
        public int mipStride;                       // Distance in bytes between mip levels in memory
        public IntPtr data;                               // Pointer to data
        //public int[] data;
    };

    // This is the main image data structure. It contains all the parameters needed
    // to place texture data into a texture object using OpenGL.
    struct vglImageData
    {
        public uint target;                              // Texture target (1D, 2D, cubemap, array, etc.)
        public uint internalFormat;                      // Recommended internal format (GL_RGBA32F, etc).
        public uint format;                              // Format in memory
        public uint type;                                // Type in memory (GL_RED, GL_RGB, etc.)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] swizzle;// = new uint[4];                          // Swizzle for RGBA
        public int mipLevels;                          // Number of present mipmap levels
        public int slices;                             // Number of slices (for arrays)
        public int sliceStride;                     // Distance in bytes between slices of an array texture
        public int totalDataSize;                   // Complete amount of data allocated for texture
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = vermilion.MAX_TEXTURE_MIPS)]
        public vglImageMipData[] mip;// = new vglImageMipData[vermilion.MAX_TEXTURE_MIPS];      // Actual mipmap data
    };

}
