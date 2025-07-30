
using CSharpGL;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static CSharpGL.GLProgram;
using static demos.glGuide8code.vgl;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demos.glGuide8code {
    /*

    Vermilion Book - DDS File Support

        Adapted from information obtained at http://msdn.microsoft.com/en-us/library/windows/desktop/bb943991%28v=vs.85%29.aspx

*/
    public unsafe class vgl {

        public struct DDS_PIXELFORMAT {
            public UInt32 dwSize;
            public UInt32 dwFlags;
            public UInt32 dwFourCC;
            public UInt32 dwRGBBitCount;
            public UInt32 dwRBitMask;
            public UInt32 dwGBitMask;
            public UInt32 dwBBitMask;
            public UInt32 dwABitMask;
        }

        public struct DDS_HEADER {
            public UInt32 size;
            public UInt32 flags;
            public UInt32 height;
            public UInt32 width;
            public UInt32 pitch_or_linear_size;
            public UInt32 depth;
            public UInt32 mip_levels;
            public fixed UInt32 reserved[11];
            public DDS_PIXELFORMAT ddspf;
            public UInt32 caps1;
            public UInt32 caps2;
            public UInt32 caps3;
            public UInt32 caps4;
            public UInt32 reserved2;
        }

        public struct DDS_HEADER_DXT10 {
            public UInt32 format;
            public UInt32 dimension;
            public UInt32 misc_flag;
            public UInt32 array_size;
            public UInt32 reserved;
        }

        public struct DDS_FILE_HEADER {
            public UInt32 magic;
            public DDS_HEADER std_header;
            public DDS_HEADER_DXT10 dxt10_header;
        }
        public struct DDS_FORMAT_GL_INFO {
            public GLenum format;
            public GLenum type;
            public GLenum internalFormat;
            public GLenum swizzle_r;
            public GLenum swizzle_g;
            public GLenum swizzle_b;
            public GLenum swizzle_a;
            public GLsizei bits_per_texel;

            public DDS_FORMAT_GL_INFO(
                uint format,
                uint type,
                uint internalFormat,
                uint swizzle_r,
                uint swizzle_g,
                uint swizzle_b,
                uint swizzle_a,
                int bits_per_texel) {
                this.format = format;
                this.type = type;
                this.internalFormat = internalFormat;
                this.swizzle_r = swizzle_r;
                this.swizzle_g = swizzle_g;
                this.swizzle_b = swizzle_b;
                this.swizzle_a = swizzle_a;
                this.bits_per_texel = bits_per_texel;
            }
            public DDS_FORMAT_GL_INFO(
                     uint format,
                     uint type,
                     uint internalFormat,
                     uint swizzle_r,
                     uint swizzle_g,
                     uint swizzle_b,
                     uint swizzle_a)
                // TODO: 0 for bits_per_texel?
                : this(format, type, internalFormat, swizzle_r, swizzle_g, swizzle_b, swizzle_a, 0) {
            }
        }

        // Enough mips for 16K x 16K, which is the minumum required for OpenGL 4.x
        private const int MAX_TEXTURE_MIPS = 14;

        // Each texture image data structure contains an array of MAX_TEXTURE_MIPS
        // of these mipmap structures. The structure represents the mipmap data for
        // all slices at that level.
        public struct vglImageMipData {
            public GLsizei width;                              // Width of this mipmap level
            public GLsizei height;                             // Height of this mipmap level
            public GLsizei depth;                              // Depth pof mipmap level
            public GLsizeiptr mipStride;                       // Distance in bytes between mip levels in memory
            public GLubyte* data;                              // Pointer to data
        };

        // This is the main image data structure. It contains all the parameters needed
        // to place texture data into a texture object using OpenGL.
        public struct vglImageData {
            public GLenum target;                              // Texture target (1D, 2D, cubemap, array, etc.)
            public GLenum internalFormat;                      // Recommended internal format (GL_RGBA32F, etc).
            public GLenum format;                              // Format in memory
            public GLenum type;                                // Type in memory (GL_RED, GL_RGB, etc.)
            const int swizzleSize = 4;
            public fixed GLenum swizzle[swizzleSize];          // Swizzle for RGBA
            public GLsizei mipLevels;                          // Number of present mipmap levels
            public GLsizei slices;                             // Number of slices (for arrays)
            public GLsizeiptr sliceStride;                     // Distance in bytes between slices of an array texture
            public GLsizeiptr totalDataSize;                   // Complete amount of data allocated for texture
            //[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_TEXTURE_MIPS)]
            public vglImageMipData[] mip;// = new vglImageMipData[MAX_TEXTURE_MIPS];                      // Actual mipmap data
            public vglImageData() { this.mip = new vglImageMipData[MAX_TEXTURE_MIPS]; }

            //public vglImageData(
            //    uint target,
            //    uint internalFormat,
            //    uint format,
            //    uint type,
            //    uint* swizzle,
            //    int mipLevels,
            //    int slices,
            //    int sliceStride,
            //    int totalDataSize,
            //    vglImageMipData[] mip) {
            //    this.target = target;
            //    this.internalFormat = internalFormat;
            //    this.format = format;
            //    this.type = type;
            //    //this.swizzle = swizzle;
            //    for (int i = 0; i < swizzleSize; i++) { this.swizzle[i] = swizzle[i]; }
            //    this.mipLevels = mipLevels;
            //    this.slices = slices;
            //    this.sliceStride = sliceStride;
            //    this.totalDataSize = totalDataSize;
            //    this.mip = mip;
            //}
        };

        public static bool vgl_DDSHeaderToImageDataHeader(DDS_FILE_HEADER header, ref vglImageData image) {
            if (header.std_header.ddspf.dwFlags == DDS_DDPF_FOURCC &&
                header.std_header.ddspf.dwFourCC == DDS_FOURCC_DX10) {
                if (header.dxt10_header.format < gl_info_table.Length/*NUM_DDS_FORMATS*/) {
                    DDS_FORMAT_GL_INFO format = gl_info_table[header.dxt10_header.format];
                    image.format = format.format;
                    image.type = format.type;
                    image.internalFormat = format.internalFormat;
                    image.swizzle[0] = format.swizzle_r;
                    image.swizzle[1] = format.swizzle_g;
                    image.swizzle[2] = format.swizzle_b;
                    image.swizzle[3] = format.swizzle_a;
                    image.mipLevels = (GLsizei)header.std_header.mip_levels;
                    return true;
                }
            }
            else if (header.std_header.ddspf.dwFlags == DDS_DDPF_FOURCC) {
                image.swizzle[0] = GL.GL_RED;
                image.swizzle[1] = GL.GL_GREEN;
                image.swizzle[2] = GL.GL_BLUE;
                image.swizzle[3] = GL.GL_ALPHA;
                image.mipLevels = (GLsizei)header.std_header.mip_levels;

                switch (header.std_header.ddspf.dwFourCC) {
                case 116:
                image.format = GL.GL_RGBA;
                image.type = GL.GL_FLOAT;
                image.internalFormat = GL.GL_RGBA32F;
                /*
                image.swizzle[0] = GL.GL_ALPHA;
                image.swizzle[1] = GL.GL_BLUE;
                image.swizzle[2] = GL.GL_GREEN;
                image.swizzle[3] = GL.GL_RED;
                */
                return true;
                default:
                break;
                }
            }
            else {
                image.swizzle[0] = GL.GL_RED;
                image.swizzle[1] = GL.GL_GREEN;
                image.swizzle[2] = GL.GL_BLUE;
                image.swizzle[3] = GL.GL_ALPHA;
                image.mipLevels = (GLsizei)header.std_header.mip_levels;

                switch (header.std_header.ddspf.dwFlags) {
                case DDS_DDPF_RGB:
                image.format = GL.GL_BGR;
                image.type = GL.GL_UNSIGNED_BYTE;
                image.internalFormat = GL.GL_RGB8;
                image.swizzle[3] = GL.GL_ONE;
                return true;
                case (DDS_DDPF_RGB | DDS_DDPF_ALPHA):
                case (DDS_DDPF_RGB | DDS_DDPF_ALPHAPIXELS):
                image.format = GL.GL_BGRA;
                image.type = GL.GL_UNSIGNED_BYTE;
                image.internalFormat = GL.GL_RGBA8;
                return true;
                case DDS_DDPF_ALPHA:
                image.format = GL.GL_RED;
                image.type = GL.GL_UNSIGNED_BYTE;
                image.internalFormat = GL.GL_R8;
                image.swizzle[0] = image.swizzle[1] = image.swizzle[2] = GL.GL_ZERO;
                image.swizzle[3] = GL.GL_RED;
                return true;
                case DDS_DDPF_LUMINANCE:
                image.format = GL.GL_RED;
                image.type = GL.GL_UNSIGNED_BYTE;
                image.internalFormat = GL.GL_R8;
                image.swizzle[0] = image.swizzle[1] = image.swizzle[2] = GL.GL_RED;
                image.swizzle[3] = GL.GL_ONE;
                return true;
                case (DDS_DDPF_LUMINANCE | DDS_DDPF_ALPHA):
                image.format = GL.GL_RG;
                image.type = GL.GL_UNSIGNED_BYTE;
                image.internalFormat = GL.GL_RG8;
                image.swizzle[0] = image.swizzle[1] = image.swizzle[2] = GL.GL_RED;
                image.swizzle[3] = GL.GL_GREEN;
                return true;
                default:
                break;
                }
            }

            image.format = image.type = image.internalFormat = GL.GL_NONE;
            image.swizzle[0] = image.swizzle[1] = image.swizzle[2] = image.swizzle[3] = GL.GL_ZERO;

            return false;
        }

        static GLsizei vgl_GetDDSStride(DDS_FILE_HEADER header, GLsizei width) {
            if (header.std_header.ddspf.dwFlags == DDS_DDPF_FOURCC
             && header.std_header.ddspf.dwFourCC == DDS_FOURCC_DX10) {
                if (header.dxt10_header.format < gl_info_table.Length/*NUM_DDS_FORMATS*/) {
                    DDS_FORMAT_GL_INFO format = gl_info_table[header.dxt10_header.format];
                    return (format.bits_per_texel * width + 7) / 8;
                }
            }
            else {
                switch (header.std_header.ddspf.dwFlags) {
                case DDS_DDPF_RGB:
                return width * 3;
                case (DDS_DDPF_RGB | DDS_DDPF_ALPHA):
                case (DDS_DDPF_RGB | DDS_DDPF_ALPHAPIXELS):
                return width * 4;
                case DDS_DDPF_ALPHA:
                return width;
                default:
                break;
                }
            }

            return 0;
        }

        static GLenum vgl_GetTargetFromDDSHeader(DDS_FILE_HEADER header) {
            // If the DX10 header is present it's format should be non-zero (unless it's unknown)
            if (header.dxt10_header.format != 0) {
                // Check the dimension...
                switch (header.dxt10_header.dimension) {
                // Could be a 1D or 1D array texture
                case DDS_RESOURCE_DIMENSION_TEXTURE1D:
                if (header.dxt10_header.array_size > 1) {
                    return GL.GL_TEXTURE_1D_ARRAY;
                }
                return GL.GL_TEXTURE_1D;
                // 2D means 2D, 2D array, cubemap or cubemap array
                case DDS_RESOURCE_DIMENSION_TEXTURE2D:
                if ((header.dxt10_header.misc_flag & DDS_RESOURCE_MISC_TEXTURECUBE) != 0) {
                    if (header.dxt10_header.array_size > 1)
                        return GL.GL_TEXTURE_CUBE_MAP_ARRAY;
                    return GL.GL_TEXTURE_CUBE_MAP;
                }
                if (header.dxt10_header.array_size > 1)
                    return GL.GL_TEXTURE_2D_ARRAY;
                return GL.GL_TEXTURE_2D;
                // 3D should always be a volume texture
                case DDS_RESOURCE_DIMENSION_TEXTURE3D:
                return GL.GL_TEXTURE_3D;
                }
                return GL.GL_NONE;
            }

            // No DX10 header. Check volume texture flag
            if ((header.std_header.caps2 & DDSCAPS2_VOLUME) != 0) { return GL.GL_TEXTURE_3D; }

            // Could be a cubemap
            if ((header.std_header.caps2 & DDSCAPS2_CUBEMAP) != 0) {
                // This shouldn't happen if the DX10 header is present, but what the hey
                if (header.dxt10_header.array_size > 1) return GL.GL_TEXTURE_CUBE_MAP_ARRAY;
                else return GL.GL_TEXTURE_CUBE_MAP;
            }

            // Alright, if there's no height, guess 1D
            if (header.std_header.height <= 1)
                return GL.GL_TEXTURE_1D;

            // Last ditch, probably 2D
            return GL.GL_TEXTURE_2D;
        }

        public static void vglLoadDDS(string filename, ref vglImageData image) {
            using (var reader = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                var file_header = new DDS_FILE_HEADER();
                {
                    //public UInt32 magic;
                    //public DDS_HEADER std_header;
                    var headerSize = sizeof(UInt32) + sizeof(DDS_HEADER);
                    var span = new Span<byte>(&file_header, headerSize);
                    reader.Read(span);
                    //fread(&file_header, sizeof(UInt32) + sizeof(DDS_HEADER), 1, f);
                }

                if (file_header.magic != DDS_MAGIC) {
                    goto done_close_file;
                }

                if (file_header.std_header.ddspf.dwFourCC == DDS_FOURCC_DX10) {
                    //public DDS_HEADER_DXT10 dxt10_header;
                    var headerSize = sizeof(DDS_HEADER_DXT10);
                    var span = new Span<byte>(&file_header.dxt10_header, headerSize);
                    reader.Read(span);
                    //fread(&file_header.dxt10_header, sizeof(file_header.dxt10_header), 1, f);
                }

                if (!vgl_DDSHeaderToImageDataHeader(file_header, ref image))
                    goto done_close_file;

                image.target = vgl_GetTargetFromDDSHeader(file_header);

                if (image.target == GL.GL_NONE)
                    goto done_close_file;

                {
                    //size_t current_pos = ftell(f);
                    //size_t file_size;
                    //fseek(f, 0, SEEK_END);
                    //file_size = ftell(f);
                    //fseek(f, (long)current_pos, SEEK_SET);
                    image.totalDataSize = (GLsizeiptr)(reader.Length - reader.Position); // file_size - current_pos;
                    image.mip[0].data = (GLubyte*)Marshal.AllocHGlobal(image.totalDataSize);// new uint8_t[image.totalDataSize];
                    var size = image.totalDataSize;
                    var span = new Span<byte>((void*)image.mip[0].data, size);
                    reader.Read(span);
                    //fread(image.mip[0].data, file_size - current_pos, 1, f);
                }

                //GLubyte* ptr = reinterpret_cast<GLubyte*>(image.mip[0].data);
                var ptr = (GLubyte*)image.mip[0].data;

                var width = (GLsizei)file_header.std_header.width;
                var height = (GLsizei)file_header.std_header.height;
                var depth = (GLsizei)file_header.std_header.depth;

                image.sliceStride = 0;

                if (image.mipLevels == 0) {
                    image.mipLevels = 1;
                }

                for (var level = 0; level < image.mipLevels; ++level) {
                    image.mip[level].data = ptr;
                    image.mip[level].width = width;
                    image.mip[level].height = height;
                    image.mip[level].depth = depth;
                    image.mip[level].mipStride = vgl_GetDDSStride(file_header, width) * height;
                    image.sliceStride += image.mip[level].mipStride;
                    ptr += image.mip[level].mipStride;
                    width >>= 1;
                    height >>= 1;
                    depth >>= 1;
                }

            done_close_file:
                ;
                //fclose(f);
            }
        }


        public static void vglUnloadImage(ref vglImageData image) {
            //delete[] reinterpret_cast<uint8_t *> (image->mip[0].data);
            Marshal.FreeHGlobal((IntPtr)image.mip[0].data);
        }

        public static void vglLoadTexture(GL gl, ref vglImageData image) {
            GLubyte* ptr = (GLubyte*)image.mip[0].data;

            switch (image.target) {
            case GL.GL_TEXTURE_1D:
            gl.glTexStorage1D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width);
            for (var level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage1D(GL.GL_TEXTURE_1D,
                                level,
                                0,
                                image.mip[level].width,
                                image.format, image.type,
                                (IntPtr)image.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_1D_ARRAY:
            gl.glTexStorage2D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.slices);
            for (var level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage2D(GL.GL_TEXTURE_1D,
                                level,
                                0, 0,
                                image.mip[level].width, image.slices,
                                image.format, image.type,
                                (IntPtr)image.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_2D:
            gl.glTexStorage2D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.mip[0].height);
            for (var level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage2D(GL.GL_TEXTURE_2D,
                                level,
                                0, 0,
                                image.mip[level].width, image.mip[level].height,
                                image.format, image.type,
                                (IntPtr)image.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_CUBE_MAP:
            for (var level = 0; level < image.mipLevels; ++level) {
                ptr = (GLubyte*)image.mip[level].data;
                for (uint face = 0; face < 6; face++) {
                    gl.glTexImage2D(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + face,
                                 level,
                                 (int)image.internalFormat,
                                 image.mip[level].width, image.mip[level].height,
                                 0,
                                 image.format, image.type,
                                 (IntPtr)(ptr + image.sliceStride * face));
                }
            }
            break;
            case GL.GL_TEXTURE_2D_ARRAY:
            gl.glTexStorage3D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.mip[0].height,
                           image.slices);
            for (var level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage3D(GL.GL_TEXTURE_2D_ARRAY,
                                level,
                                0, 0, 0,
                                image.mip[level].width, image.mip[level].height, image.slices,
                                image.format, image.type,
                                (IntPtr)image.mip[level].data);
            }
            break;
            case GL.GL_TEXTURE_CUBE_MAP_ARRAY:
            gl.glTexStorage3D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.mip[0].height,
                           image.slices);
            break;
            case GL.GL_TEXTURE_3D:
            gl.glTexStorage3D(image.target,
                           image.mipLevels,
                           image.internalFormat,
                           image.mip[0].width,
                           image.mip[0].height,
                           image.mip[0].depth);
            for (var level = 0; level < image.mipLevels; ++level) {
                gl.glTexSubImage3D(GL.GL_TEXTURE_3D,
                                level,
                                0, 0, 0,
                                image.mip[level].width, image.mip[level].height, image.mip[level].depth,
                                image.format, image.type,
                                (IntPtr)image.mip[level].data);
            }
            break;
            default:
            break;
            }

            //gl.glTexParameteriv(image.target, GL.GL_TEXTURE_SWIZZLE_RGBA, reinterpret_cast <const GLint*> (image.swizzle));
            var swizzle = stackalloc GLint[4];
            for (var i = 0; i < 4; i++) { swizzle[i] = (GLint)image.swizzle[i]; }
            gl.glTexParameteriv(image.target, GL.GL_TEXTURE_SWIZZLE_RGBA, swizzle);
        }

        //public static readonly int NUM_DDS_FORMATS = gl_info_table.Length;// (sizeof(gl_info_table) / sizeof(gl_info_table[0]));

        public static readonly DDS_FORMAT_GL_INFO[] gl_info_table = {
         // format,                  type,                  internalFormat,        swizzle_r,         swizzle_g,         swizzle_b,         swizzle_a,  bits_per_texel
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    0 ),        // DDS_FORMAT_UNKNOWN
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    0 ),        // DDS_FORMAT_R32G32B32A32_TYPELESS
    new( GL.GL_RGBA,              GL.GL_FLOAT,           GL.GL_RGBA32F,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   128 ),      // DDS_FORMAT_R32G32B32A32_FLOAT
    new( GL.GL_RGBA_INTEGER,      GL.GL_UNSIGNED_INT,    GL.GL_RGBA32UI,        GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   128 ),      // DDS_FORMAT_R32G32B32A32_UINT
    new( GL.GL_RGBA_INTEGER,      GL.GL_INT,             GL.GL_RGBA32I,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   128 ),      // DDS_FORMAT_R32G32B32A32_SINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    96 ),       // DDS_FORMAT_R32G32B32_TYPELESS
    new( GL.GL_RGB,               GL.GL_FLOAT,           GL.GL_RGB32F,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     96 ),       // DDS_FORMAT_R32G32B32_FLOAT
    new( GL.GL_RGB_INTEGER,       GL.GL_UNSIGNED_INT,    GL.GL_RGB32UI,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     96 ),       // DDS_FORMAT_R32G32B32_UINT
    new( GL.GL_RGB_INTEGER,       GL.GL_INT,             GL.GL_RGB32I,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     96 ),       // DDS_FORMAT_R32G32B32_SINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),       // DDS_FORMAT_R16G16B16A16_TYPELESS
    new( GL.GL_RGBA,              GL.GL_HALF_FLOAT,      GL.GL_RGBA16F,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_FLOAT
    new( GL.GL_RGBA,              GL.GL_UNSIGNED_SHORT,  GL.GL_RGBA16,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_UNORM
    new( GL.GL_RGBA_INTEGER,      GL.GL_UNSIGNED_SHORT,  GL.GL_RGBA16UI,        GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_UINT
    new( GL.GL_RGBA,              GL.GL_SHORT,           GL.GL_RGBA16_SNORM,    GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_SNORM
    new( GL.GL_RGBA_INTEGER,      GL.GL_SHORT,           GL.GL_RGBA16I,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_SINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),       // DDS_FORMAT_R32G32_TYPELESS
    new( GL.GL_RG,                GL.GL_FLOAT,           GL.GL_RG32F,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     64 ),       // DDS_FORMAT_R32G32_FLOAT
    new( GL.GL_RG_INTEGER,        GL.GL_UNSIGNED_INT,    GL.GL_RG32UI,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     64 ),       // DDS_FORMAT_R32G32_UINT
    new( GL.GL_RG_INTEGER,        GL.GL_INT,             GL.GL_RG32I,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     64 ),       // DDS_FORMAT_R32G32_SINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),       // DDS_FORMAT_R32G8X24_TYPELESS
    new( GL.GL_DEPTH_STENCIL,     GL.GL_FLOAT_32_UNSIGNED_INT_24_8_REV,  GL.GL_DEPTH32F_STENCIL8, GL.GL_NONE, GL.GL_NONE, GL.GL_NONE,    GL.GL_NONE,    64 ),       // DDS_FORMAT_D32_FLOAT_S8X24_UINT (THIS MAY NOT BE RIGHT)
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),       // DDS_FORMAT_R32_FLOAT_X8X24_TYPELESS
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),      // DDS_FORMAT_X32_TYPELESS_G8X24_UINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R10G10B10A2_TYPELESS
    new( GL.GL_RGBA,              GL.GL_UNSIGNED_INT,    GL.GL_RGB10_A2,        GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R10G10B10A2_UNORM
    new( GL.GL_RGBA_INTEGER,      GL.GL_UNSIGNED_INT,    GL.GL_RGB10_A2UI,      GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R10G10B10A2_UINT
    new( GL.GL_RGB,               GL.GL_UNSIGNED_INT,    GL.GL_R11F_G11F_B10F,  GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R11G11B10_FLOAT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R8G8B8A8_TYPELESS
    new( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_RGBA8,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_UNORM
    new( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_SRGB8_ALPHA8,    GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_UNORM_SRGB
    new( GL.GL_RGBA_INTEGER,      GL.GL_UNSIGNED_BYTE,   GL.GL_RGBA8UI,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_UINT
    new( GL.GL_RGBA,              GL.GL_BYTE,            GL.GL_RGBA8_SNORM,     GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_SNORM
    new( GL.GL_RGBA_INTEGER,      GL.GL_BYTE,            GL.GL_RGBA8I,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_SINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R16G16_TYPELESS
    new( GL.GL_RG,                GL.GL_HALF_FLOAT,      GL.GL_RG16F,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_FLOAT
    new( GL.GL_RG,                GL.GL_UNSIGNED_SHORT,  GL.GL_RG16,            GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_UNORM
    new( GL.GL_RG_INTEGER,        GL.GL_UNSIGNED_SHORT,  GL.GL_RG16UI,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_UINT
    new( GL.GL_RG,                GL.GL_SHORT,           GL.GL_RG16_SNORM,      GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_SNORM
    new( GL.GL_RG_INTEGER,        GL.GL_SHORT,           GL.GL_RG16I,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_SINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R32_TYPELESS
    new( GL.GL_DEPTH_COMPONENT,   GL.GL_FLOAT,           GL.GL_DEPTH_COMPONENT32F,  GL.GL_RED,     GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_D32_FLOAT
    new( GL.GL_RED,               GL.GL_FLOAT,           GL.GL_R32F,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R32_FLOAT
    new( GL.GL_RED_INTEGER,       GL.GL_UNSIGNED_INT,    GL.GL_R32UI,           GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R32_UINT
    new( GL.GL_RED_INTEGER,       GL.GL_INT,             GL.GL_R32I,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R32_SINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R24G8_TYPELESS
    new( GL.GL_DEPTH_STENCIL,     GL.GL_UNSIGNED_INT,    GL.GL_DEPTH24_STENCIL8, GL.GL_RED,        GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_D24_UNORM_S8_UINT (MAY NOT BE CORRECT)
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R24_UNORM_X8_TYPELESS
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_X24_TYPELESS_G8_UINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_R8G8_TYPELESS
    new( GL.GL_RG,                GL.GL_UNSIGNED_BYTE,   GL.GL_RG8,             GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R8G8_UNORM
    new( GL.GL_RG_INTEGER,        GL.GL_UNSIGNED_BYTE,   GL.GL_RG8UI,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R8G8_UINT
    new( GL.GL_RG,                GL.GL_BYTE,            GL.GL_RG8_SNORM,       GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R8G8_SNORM
    new( GL.GL_RG_INTEGER,        GL.GL_BYTE,            GL.GL_RG8I,            GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R8G8_SINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_R16_TYPELESS
    new( GL.GL_RED,               GL.GL_HALF_FLOAT,      GL.GL_R16F,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_FLOAT
    new( GL.GL_DEPTH_COMPONENT,   GL.GL_HALF_FLOAT,      GL.GL_DEPTH_COMPONENT16, GL.GL_RED,       GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_D16_UNORM
    new( GL.GL_RED,               GL.GL_UNSIGNED_SHORT,  GL.GL_R16,             GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_UNORM
    new( GL.GL_RED_INTEGER,       GL.GL_UNSIGNED_SHORT,  GL.GL_R16UI,           GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_UINT
    new( GL.GL_RED,               GL.GL_SHORT,           GL.GL_R16_SNORM,       GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_SNORM
    new( GL.GL_RED_INTEGER,       GL.GL_SHORT,           GL.GL_R16I,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_SINT
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    8 ),       // DDS_FORMAT_R8_TYPELESS
    new( GL.GL_RED,               GL.GL_UNSIGNED_BYTE,   GL.GL_R8,              GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     8 ),       // DDS_FORMAT_R8_UNORM
    new( GL.GL_RED_INTEGER,       GL.GL_UNSIGNED_BYTE,   GL.GL_R8UI,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     8 ),       // DDS_FORMAT_R8_UINT
    new( GL.GL_RED,               GL.GL_BYTE,            GL.GL_R8_SNORM,        GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     8 ),       // DDS_FORMAT_R8_SNORM
    new( GL.GL_RED_INTEGER,       GL.GL_BYTE,            GL.GL_R8I,             GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     8 ),       // DDS_FORMAT_R8_SINT
    new( GL.GL_RED,               GL.GL_BYTE,            GL.GL_R8,              GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_RED,     8 ),       // DDS_FORMAT_A8_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    0 ),       // DDS_FORMAT_R1_UNORM
    new( GL.GL_RGB,               GL.GL_UNSIGNED_SHORT,  GL.GL_RGB9_E5,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R9G9B9E5_SHAREDEXP
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_R8G8_B8G8_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_G8R8_G8B8_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC1_TYPELESS
//#if defined GL.GL_EXT_texture_compression_s3tc
//    new( GL.GL_COMPRESSED_RGB_S3TC_DXT1_EXT, GL.GL_NONE, GL.GL_COMPRESSED_RGB_S3TC_DXT1_EXT, GL.GL_RED, GL.GL_GREEN,  GL.GL_BLUE,        GL.GL_ONE              ),      // DDS_FORMAT_BC1_UNORM
//    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC1_UNORM_SRGB
//#else
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC1_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC1_UNORM_SRGB
//#endif
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC2_TYPELESS
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC2_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC2_UNORM_SRGB
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC3_TYPELESS
//#if defined GL.GL_EXT_texture_compression_s3tc
////    new( GL.GL_COMPRESSED_RGB_S3TC_DXT3_EXT,  GL.GL_NONE, GL.GL_COMPRESSED_RGB_S3TC_DXT3_EXT, GL.GL_ZERO, GL.GL_ZERO, GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC3_UNORM
//    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC3_UNORM
//    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC3_UNORM_SRGB
//#else
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC3_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC3_UNORM_SRGB
//#endif
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC4_TYPELESS
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC4_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC4_SNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC5_TYPELESS
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC5_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC5_SNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_B5G6R5_UNORM
    new( GL.GL_RGBA,              GL.GL_UNSIGNED_SHORT,  GL.GL_RGB5_A1,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA            ),      // DDS_FORMAT_B5G5R5A1_UNORM
    new( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_RGBA8,           GL.GL_BLUE,        GL.GL_GREEN,       GL.GL_RED,         GL.GL_ALPHA            ),      // DDS_FORMAT_B8G8R8A8_UNORM
    new( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_RGBA8,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE              ),      // DDS_FORMAT_B8G8R8X8_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_R10G10B10_XR_BIAS_A2_UNORM
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_B8G8R8A8_TYPELESS
    new( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_SRGB8_ALPHA8,    GL.GL_BLUE,        GL.GL_GREEN,       GL.GL_RED,         GL.GL_ALPHA            ),      // DDS_FORMAT_B8G8R8A8_UNORM_SRGB
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_B8G8R8X8_TYPELESS
    new( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_SRGB8_ALPHA8,    GL.GL_BLUE,        GL.GL_GREEN,       GL.GL_RED,         GL.GL_ONE              ),      // DDS_FORMAT_B8G8R8X8_UNORM_SRGB
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC6H_TYPELESS
    //igonre it for now: new( GL.GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT_ARB, GL.GL_NONE, GL.GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT_ARB, GL.GL_RED, GL.GL_GREEN, GL.GL_BLUE,     GL.GL_ONE          ),      // DDS_FORMAT_BC6H_UF16
    //igonre it for now: new( GL.GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT_ARB, GL.GL_NONE, GL.GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT_ARB, GL.GL_RED, GL.GL_GREEN, GL.GL_BLUE, GL.GL_ONE         ),   // DDS_FORMAT_BC6H_SF16
    new( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_BC7_TYPELESS
    //igonre it for now: new( GL.GL_COMPRESSED_RGBA_BPTC_UNORM_ARB, GL.GL_NONE, GL.GL_COMPRESSED_RGBA_BPTC_UNORM_ARB, GL.GL_RED, GL.GL_GREEN, GL.GL_BLUE, GL.GL_ALPHA            ),      // DDS_FORMAT_BC7_UNORM
    //igonre it for now: new( GL.GL_COMPRESSED_SRGB_ALPHA_BPTC_UNORM_ARB, GL.GL_NONE, GL.GL_COMPRESSED_SRGB_ALPHA_BPTC_UNORM_ARB, GL.GL_RED, GL.GL_GREEN, GL.GL_BLUE, GL.GL_ALPHA         ), // DDS_FORMAT_BC7_UNORM_SRGB
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_AYUV
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_Y410
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_Y416
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_NV12
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_P010
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_P016
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_420_OPAQUE
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_YUY2
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_Y210
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_Y216
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_NV11
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_AI44
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_IA44
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_P8
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_A8P8
    new( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO             ),      // DDS_FORMAT_B4G4R4A4_UNORM
        };



        public enum DDS_FORMAT {
            DDS_FORMAT_UNKNOWN = 0,
            DDS_FORMAT_R32G32B32A32_TYPELESS = 1,
            DDS_FORMAT_R32G32B32A32_FLOAT = 2,
            DDS_FORMAT_R32G32B32A32_UINT = 3,
            DDS_FORMAT_R32G32B32A32_SINT = 4,
            DDS_FORMAT_R32G32B32_TYPELESS = 5,
            DDS_FORMAT_R32G32B32_FLOAT = 6,
            DDS_FORMAT_R32G32B32_UINT = 7,
            DDS_FORMAT_R32G32B32_SINT = 8,
            DDS_FORMAT_R16G16B16A16_TYPELESS = 9,
            DDS_FORMAT_R16G16B16A16_FLOAT = 10,
            DDS_FORMAT_R16G16B16A16_UNORM = 11,
            DDS_FORMAT_R16G16B16A16_UINT = 12,
            DDS_FORMAT_R16G16B16A16_SNORM = 13,
            DDS_FORMAT_R16G16B16A16_SINT = 14,
            DDS_FORMAT_R32G32_TYPELESS = 15,
            DDS_FORMAT_R32G32_FLOAT = 16,
            DDS_FORMAT_R32G32_UINT = 17,
            DDS_FORMAT_R32G32_SINT = 18,
            DDS_FORMAT_R32G8X24_TYPELESS = 19,
            DDS_FORMAT_D32_FLOAT_S8X24_UINT = 20,
            DDS_FORMAT_R32_FLOAT_X8X24_TYPELESS = 21,
            DDS_FORMAT_X32_TYPELESS_G8X24_UINT = 22,
            DDS_FORMAT_R10G10B10A2_TYPELESS = 23,
            DDS_FORMAT_R10G10B10A2_UNORM = 24,
            DDS_FORMAT_R10G10B10A2_UINT = 25,
            DDS_FORMAT_R11G11B10_FLOAT = 26,
            DDS_FORMAT_R8G8B8A8_TYPELESS = 27,
            DDS_FORMAT_R8G8B8A8_UNORM = 28,
            DDS_FORMAT_R8G8B8A8_UNORM_SRGB = 29,
            DDS_FORMAT_R8G8B8A8_UINT = 30,
            DDS_FORMAT_R8G8B8A8_SNORM = 31,
            DDS_FORMAT_R8G8B8A8_SINT = 32,
            DDS_FORMAT_R16G16_TYPELESS = 33,
            DDS_FORMAT_R16G16_FLOAT = 34,
            DDS_FORMAT_R16G16_UNORM = 35,
            DDS_FORMAT_R16G16_UINT = 36,
            DDS_FORMAT_R16G16_SNORM = 37,
            DDS_FORMAT_R16G16_SINT = 38,
            DDS_FORMAT_R32_TYPELESS = 39,
            DDS_FORMAT_D32_FLOAT = 40,
            DDS_FORMAT_R32_FLOAT = 41,
            DDS_FORMAT_R32_UINT = 42,
            DDS_FORMAT_R32_SINT = 43,
            DDS_FORMAT_R24G8_TYPELESS = 44,
            DDS_FORMAT_D24_UNORM_S8_UINT = 45,
            DDS_FORMAT_R24_UNORM_X8_TYPELESS = 46,
            DDS_FORMAT_X24_TYPELESS_G8_UINT = 47,
            DDS_FORMAT_R8G8_TYPELESS = 48,
            DDS_FORMAT_R8G8_UNORM = 49,
            DDS_FORMAT_R8G8_UINT = 50,
            DDS_FORMAT_R8G8_SNORM = 51,
            DDS_FORMAT_R8G8_SINT = 52,
            DDS_FORMAT_R16_TYPELESS = 53,
            DDS_FORMAT_R16_FLOAT = 54,
            DDS_FORMAT_D16_UNORM = 55,
            DDS_FORMAT_R16_UNORM = 56,
            DDS_FORMAT_R16_UINT = 57,
            DDS_FORMAT_R16_SNORM = 58,
            DDS_FORMAT_R16_SINT = 59,
            DDS_FORMAT_R8_TYPELESS = 60,
            DDS_FORMAT_R8_UNORM = 61,
            DDS_FORMAT_R8_UINT = 62,
            DDS_FORMAT_R8_SNORM = 63,
            DDS_FORMAT_R8_SINT = 64,
            DDS_FORMAT_A8_UNORM = 65,
            DDS_FORMAT_R1_UNORM = 66,
            DDS_FORMAT_R9G9B9E5_SHAREDEXP = 67,
            DDS_FORMAT_R8G8_B8G8_UNORM = 68,
            DDS_FORMAT_G8R8_G8B8_UNORM = 69,
            DDS_FORMAT_BC1_TYPELESS = 70,
            DDS_FORMAT_BC1_UNORM = 71,
            DDS_FORMAT_BC1_UNORM_SRGB = 72,
            DDS_FORMAT_BC2_TYPELESS = 73,
            DDS_FORMAT_BC2_UNORM = 74,
            DDS_FORMAT_BC2_UNORM_SRGB = 75,
            DDS_FORMAT_BC3_TYPELESS = 76,
            DDS_FORMAT_BC3_UNORM = 77,
            DDS_FORMAT_BC3_UNORM_SRGB = 78,
            DDS_FORMAT_BC4_TYPELESS = 79,
            DDS_FORMAT_BC4_UNORM = 80,
            DDS_FORMAT_BC4_SNORM = 81,
            DDS_FORMAT_BC5_TYPELESS = 82,
            DDS_FORMAT_BC5_UNORM = 83,
            DDS_FORMAT_BC5_SNORM = 84,
            DDS_FORMAT_B5G6R5_UNORM = 85,
            DDS_FORMAT_B5G5R5A1_UNORM = 86,
            DDS_FORMAT_B8G8R8A8_UNORM = 87,
            DDS_FORMAT_B8G8R8X8_UNORM = 88,
            DDS_FORMAT_R10G10B10_XR_BIAS_A2_UNORM = 89,
            DDS_FORMAT_B8G8R8A8_TYPELESS = 90,
            DDS_FORMAT_B8G8R8A8_UNORM_SRGB = 91,
            DDS_FORMAT_B8G8R8X8_TYPELESS = 92,
            DDS_FORMAT_B8G8R8X8_UNORM_SRGB = 93,
            DDS_FORMAT_BC6H_TYPELESS = 94,
            DDS_FORMAT_BC6H_UF16 = 95,
            DDS_FORMAT_BC6H_SF16 = 96,
            DDS_FORMAT_BC7_TYPELESS = 97,
            DDS_FORMAT_BC7_UNORM = 98,
            DDS_FORMAT_BC7_UNORM_SRGB = 99,
            DDS_FORMAT_AYUV = 100,
            DDS_FORMAT_Y410 = 101,
            DDS_FORMAT_Y416 = 102,
            DDS_FORMAT_NV12 = 103,
            DDS_FORMAT_P010 = 104,
            DDS_FORMAT_P016 = 105,
            DDS_FORMAT_420_OPAQUE = 106,
            DDS_FORMAT_YUY2 = 107,
            DDS_FORMAT_Y210 = 108,
            DDS_FORMAT_Y216 = 109,
            DDS_FORMAT_NV11 = 110,
            DDS_FORMAT_AI44 = 111,
            DDS_FORMAT_IA44 = 112,
            DDS_FORMAT_P8 = 113,
            DDS_FORMAT_A8P8 = 114,
            DDS_FORMAT_B4G4R4A4_UNORM = 115
        };


        public const int DDS_MAGIC = 0x20534444;

        public const int DDSCAPS_COMPLEX = 0x00000008;
        public const int DDSCAPS_MIPMAP = 0x00400000;
        public const int DDSCAPS_TEXTURE = 0x00001000;

        public const int DDSCAPS2_CUBEMAP = 0x00000200;
        public const int DDSCAPS2_CUBEMAP_POSITIVEX = 0x00000400;
        public const int DDSCAPS2_CUBEMAP_NEGATIVEX = 0x00000800;
        public const int DDSCAPS2_CUBEMAP_POSITIVEY = 0x00001000;
        public const int DDSCAPS2_CUBEMAP_NEGATIVEY = 0x00002000;
        public const int DDSCAPS2_CUBEMAP_POSITIVEZ = 0x00004000;
        public const int DDSCAPS2_CUBEMAP_NEGATIVEZ = 0x00008000;
        public const int DDSCAPS2_VOLUME = 0x00200000;

        public const int DDS_CUBEMAP_ALLFACES =
            (DDSCAPS2_CUBEMAP_POSITIVEX |
             DDSCAPS2_CUBEMAP_NEGATIVEX |
             DDSCAPS2_CUBEMAP_POSITIVEY |
             DDSCAPS2_CUBEMAP_NEGATIVEY |
             DDSCAPS2_CUBEMAP_POSITIVEZ |
             DDSCAPS2_CUBEMAP_NEGATIVEZ);

        public const int DDS_RESOURCE_DIMENSION_UNKNOWN = 0;
        public const int DDS_RESOURCE_DIMENSION_BUFFER = 1;
        public const int DDS_RESOURCE_DIMENSION_TEXTURE1D = 2;
        public const int DDS_RESOURCE_DIMENSION_TEXTURE2D = 3;
        public const int DDS_RESOURCE_DIMENSION_TEXTURE3D = 4;

        public const int DDS_RESOURCE_MISC_TEXTURECUBE = 0x00000004;

        public const int DDS_FOURCC_DX10 = 0x30315844;
        public const int DDS_FOURCC_DXT1 = 0x31545844;
        public const int DDS_FOURCC_DXT2 = 0x32545844;
        public const int DDS_FOURCC_DXT3 = 0x33545844;
        public const int DDS_FOURCC_DXT4 = 0x34545844;
        public const int DDS_FOURCC_DXT5 = 0x35545844;

        public const int DDS_DDPF_ALPHAPIXELS = 0x00000001;
        public const int DDS_DDPF_ALPHA = 0x00000002;
        public const int DDS_DDPF_FOURCC = 0x00000004;
        public const int DDS_DDPF_RGB = 0x00000040;
        public const int DDS_DDPF_YUV = 0x00000200;
        public const int DDS_DDPF_LUMINANCE = 0x00020000;
    }
}