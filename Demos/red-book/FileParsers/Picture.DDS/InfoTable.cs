using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public class InfoTable
    {
        public static readonly DDS_FORMAT_GL_INFO[] gl_info_table = new DDS_FORMAT_GL_INFO[]
{
    // format,              type,               internalFormat,     swizzle_r,      swizzle_g,      swizzle_b,      swizzle_a
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    0 ),        // DDS_FORMAT_UNKNOWN
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    0 ),        // DDS_FORMAT_R32G32B32A32_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_FLOAT,           GL.GL_RGBA32F,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   128 ),      // DDS_FORMAT_R32G32B32A32_FLOAT
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA_INTEGER,      GL.GL_UNSIGNED_INT,    GL.GL_RGBA32UI,        GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   128 ),      // DDS_FORMAT_R32G32B32A32_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA_INTEGER,      GL.GL_INT,             GL.GL_RGBA32I,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   128 ),      // DDS_FORMAT_R32G32B32A32_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    96 ),       // DDS_FORMAT_R32G32B32_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RGB,               GL.GL_FLOAT,           GL.GL_RGB32F,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     96 ),       // DDS_FORMAT_R32G32B32_FLOAT
    new DDS_FORMAT_GL_INFO( GL.GL_RGB_INTEGER,       GL.GL_UNSIGNED_INT,    GL.GL_RGB32UI,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     96 ),       // DDS_FORMAT_R32G32B32_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RGB_INTEGER,       GL.GL_INT,             GL.GL_RGB32I,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     96 ),       // DDS_FORMAT_R32G32B32_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),       // DDS_FORMAT_R16G16B16A16_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_HALF_FLOAT,      GL.GL_RGBA16F,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_FLOAT
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_UNSIGNED_SHORT,  GL.GL_RGBA16,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA_INTEGER,      GL.GL_UNSIGNED_SHORT,  GL.GL_RGBA16UI,        GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_SHORT,           GL.GL_RGBA16_SNORM,    GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_SNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA_INTEGER,      GL.GL_SHORT,           GL.GL_RGBA16I,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   64 ),       // DDS_FORMAT_R16G16B16A16_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),       // DDS_FORMAT_R32G32_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RG,                GL.GL_FLOAT,           GL.GL_RG32F,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     64 ),       // DDS_FORMAT_R32G32_FLOAT
    new DDS_FORMAT_GL_INFO( GL.GL_RG_INTEGER,        GL.GL_UNSIGNED_INT,    GL.GL_RG32UI,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     64 ),       // DDS_FORMAT_R32G32_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RG_INTEGER,        GL.GL_INT,             GL.GL_RG32I,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     64 ),       // DDS_FORMAT_R32G32_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),       // DDS_FORMAT_R32G8X24_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_DEPTH_STENCIL,     GL.GL_FLOAT_32_UNSIGNED_INT_24_8_REV,  GL.GL_DEPTH32F_STENCIL8, GL.GL_NONE, GL.GL_NONE, GL.GL_NONE,    GL.GL_NONE,    64 ),       // DDS_FORMAT_D32_FLOAT_S8X24_UINT (THIS MAY NOT BE RIGHT)
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),       // DDS_FORMAT_R32_FLOAT_X8X24_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    64 ),      // DDS_FORMAT_X32_TYPELESS_G8X24_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R10G10B10A2_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_UNSIGNED_INT,    GL.GL_RGB10_A2,        GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R10G10B10A2_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA_INTEGER,      GL.GL_UNSIGNED_INT,    GL.GL_RGB10_A2UI,      GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R10G10B10A2_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RGB,               GL.GL_UNSIGNED_INT,    GL.GL_R11F_G11F_B10F,  GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R11G11B10_FLOAT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R8G8B8A8_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_RGBA8,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_SRGB8_ALPHA8,    GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_UNORM_SRGB
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA_INTEGER,      GL.GL_UNSIGNED_BYTE,   GL.GL_RGBA8UI,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_BYTE,            GL.GL_RGBA8_SNORM,     GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_SNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA_INTEGER,      GL.GL_BYTE,            GL.GL_RGBA8I,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA,   32 ),      // DDS_FORMAT_R8G8B8A8_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R16G16_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RG,                GL.GL_HALF_FLOAT,      GL.GL_RG16F,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_FLOAT
    new DDS_FORMAT_GL_INFO( GL.GL_RG,                GL.GL_UNSIGNED_SHORT,  GL.GL_RG16,            GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RG_INTEGER,        GL.GL_UNSIGNED_SHORT,  GL.GL_RG16UI,          GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RG,                GL.GL_SHORT,           GL.GL_RG16_SNORM,      GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_SNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RG_INTEGER,        GL.GL_SHORT,           GL.GL_RG16I,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R16G16_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R32_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_DEPTH_COMPONENT,   GL.GL_FLOAT,           GL.GL_DEPTH_COMPONENT32F,  GL.GL_RED,     GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_D32_FLOAT
    new DDS_FORMAT_GL_INFO( GL.GL_RED,               GL.GL_FLOAT,           GL.GL_R32F,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R32_FLOAT
    new DDS_FORMAT_GL_INFO( GL.GL_RED_INTEGER,       GL.GL_UNSIGNED_INT,    GL.GL_R32UI,           GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R32_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RED_INTEGER,       GL.GL_INT,             GL.GL_R32I,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     32 ),      // DDS_FORMAT_R32_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R24G8_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_DEPTH_STENCIL,     GL.GL_UNSIGNED_INT,    GL.GL_DEPTH24_STENCIL8, GL.GL_RED,        GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_D24_UNORM_S8_UINT (MAY NOT BE CORRECT)
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_R24_UNORM_X8_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    32 ),      // DDS_FORMAT_X24_TYPELESS_G8_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_R8G8_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RG,                GL.GL_UNSIGNED_BYTE,   GL.GL_RG8,             GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R8G8_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RG_INTEGER,        GL.GL_UNSIGNED_BYTE,   GL.GL_RG8UI,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R8G8_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RG,                GL.GL_BYTE,            GL.GL_RG8_SNORM,       GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R8G8_SNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RG_INTEGER,        GL.GL_BYTE,            GL.GL_RG8I,            GL.GL_RED,         GL.GL_GREEN,       GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R8G8_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_R16_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RED,               GL.GL_HALF_FLOAT,      GL.GL_R16F,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_FLOAT
    new DDS_FORMAT_GL_INFO( GL.GL_DEPTH_COMPONENT,   GL.GL_HALF_FLOAT,      GL.GL_DEPTH_COMPONENT16, GL.GL_RED,       GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_D16_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RED,               GL.GL_UNSIGNED_SHORT,  GL.GL_R16,             GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RED_INTEGER,       GL.GL_UNSIGNED_SHORT,  GL.GL_R16UI,           GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RED,               GL.GL_SHORT,           GL.GL_R16_SNORM,       GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_SNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RED_INTEGER,       GL.GL_SHORT,           GL.GL_R16I,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R16_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    8 ),       // DDS_FORMAT_R8_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RED,               GL.GL_UNSIGNED_BYTE,   GL.GL_R8,              GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     8 ),       // DDS_FORMAT_R8_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RED_INTEGER,       GL.GL_UNSIGNED_BYTE,   GL.GL_R8UI,            GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     8 ),       // DDS_FORMAT_R8_UINT
    new DDS_FORMAT_GL_INFO( GL.GL_RED,               GL.GL_BYTE,            GL.GL_R8_SNORM,        GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     8 ),       // DDS_FORMAT_R8_SNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RED_INTEGER,       GL.GL_BYTE,            GL.GL_R8I,             GL.GL_RED,         GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ONE,     8 ),       // DDS_FORMAT_R8_SINT
    new DDS_FORMAT_GL_INFO( GL.GL_RED,               GL.GL_BYTE,            GL.GL_R8,              GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_RED,     8 ),       // DDS_FORMAT_A8_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    0 ),       // DDS_FORMAT_R1_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RGB,               GL.GL_UNSIGNED_SHORT,  GL.GL_RGB9_E5,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE,     16 ),      // DDS_FORMAT_R9G9B9E5_SHAREDEXP
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_R8G8_B8G8_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,    16 ),      // DDS_FORMAT_G8R8_G8B8_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO       ,0      ),      // DDS_FORMAT_BC1_TYPELESS
#if  GL_EXT_texture_compression_s3tc
    new DDS_FORMAT_GL_INFO( GL.GL_COMPRESSED_RGB_S3TC_DXT1_EXT, GL.GL_NONE, GL.GL_COMPRESSED_RGB_S3TC_DXT1_EXT, GL.GL_RED, GL.GL_GREEN,  GL.GL_BLUE,        GL.GL_ONE        ,0      ),      // DDS_FORMAT_BC1_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO       ,0      ),      // DDS_FORMAT_BC1_UNORM_SRGB
#else
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO      ,0       ),      // DDS_FORMAT_BC1_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO       ,0      ),      // DDS_FORMAT_BC1_UNORM_SRGB
#endif
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO      ,0       ),      // DDS_FORMAT_BC2_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO      ,0       ),      // DDS_FORMAT_BC2_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO      ,0       ),      // DDS_FORMAT_BC2_UNORM_SRGB
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO      ,0       ),      // DDS_FORMAT_BC3_TYPELESS
#if  GL_EXT_texture_compression_s3tc
//    new DDS_FORMAT_GL_INFO( GL.GL_COMPRESSED_RGB_S3TC_DXT3_EXT,  GL.GL_NONE, GL.GL_COMPRESSED_RGB_S3TC_DXT3_EXT, GL.GL_ZERO, GL.GL_ZERO, GL.GL_ZERO,        GL.GL_ZERO    ,0         ),      // DDS_FORMAT_BC3_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO    ,0         ),      // DDS_FORMAT_BC3_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO     ,0        ),      // DDS_FORMAT_BC3_UNORM_SRGB
#else
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO       ,0      ),      // DDS_FORMAT_BC3_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO       ,0      ),      // DDS_FORMAT_BC3_UNORM_SRGB
#endif
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO          ,0   ),      // DDS_FORMAT_BC4_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO         ,0    ),      // DDS_FORMAT_BC4_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO         ,0    ),      // DDS_FORMAT_BC4_SNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO        ,0     ),      // DDS_FORMAT_BC5_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO        ,0     ),      // DDS_FORMAT_BC5_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO       ,0      ),      // DDS_FORMAT_BC5_SNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO       ,0      ),      // DDS_FORMAT_B5G6R5_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_UNSIGNED_SHORT,  GL.GL_RGB5_A1,         GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ALPHA     ,0       ),      // DDS_FORMAT_B5G5R5A1_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_RGBA8,           GL.GL_BLUE,        GL.GL_GREEN,       GL.GL_RED,         GL.GL_ALPHA     ,0       ),      // DDS_FORMAT_B8G8R8A8_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_RGBA8,           GL.GL_RED,         GL.GL_GREEN,       GL.GL_BLUE,        GL.GL_ONE       ,0       ),      // DDS_FORMAT_B8G8R8X8_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO      ,0       ),      // DDS_FORMAT_R10G10B10_XR_BIAS_A2_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO      ,0       ),      // DDS_FORMAT_B8G8R8A8_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_SRGB8_ALPHA8,    GL.GL_BLUE,        GL.GL_GREEN,       GL.GL_RED,         GL.GL_ALPHA     ,0       ),      // DDS_FORMAT_B8G8R8A8_UNORM_SRGB
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO      ,0       ),      // DDS_FORMAT_B8G8R8X8_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_RGBA,              GL.GL_UNSIGNED_BYTE,   GL.GL_SRGB8_ALPHA8,    GL.GL_BLUE,        GL.GL_GREEN,       GL.GL_RED,         GL.GL_ONE        ,0      ),      // DDS_FORMAT_B8G8R8X8_UNORM_SRGB
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO       ,0      ),      // DDS_FORMAT_BC6H_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT_ARB, GL.GL_NONE, GL.GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT_ARB, GL.GL_RED, GL.GL_GREEN, GL.GL_BLUE,     GL.GL_ONE     ,0     ),      // DDS_FORMAT_BC6H_UF16
    new DDS_FORMAT_GL_INFO( GL.GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT_ARB, GL.GL_NONE, GL.GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT_ARB, GL.GL_RED, GL.GL_GREEN, GL.GL_BLUE, GL.GL_ONE       ,0  ),   // DDS_FORMAT_BC6H_SF16
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,              GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO        ,0     ),      // DDS_FORMAT_BC7_TYPELESS
    new DDS_FORMAT_GL_INFO( GL.GL_COMPRESSED_RGBA_BPTC_UNORM_ARB, GL.GL_NONE, GL.GL_COMPRESSED_RGBA_BPTC_UNORM_ARB, GL.GL_RED, GL.GL_GREEN, GL.GL_BLUE, GL.GL_ALPHA        ,0    ),      // DDS_FORMAT_BC7_UNORM
    new DDS_FORMAT_GL_INFO( GL.GL_COMPRESSED_SRGB_ALPHA_BPTC_UNORM_ARB, GL.GL_NONE, GL.GL_COMPRESSED_SRGB_ALPHA_BPTC_UNORM_ARB, GL.GL_RED, GL.GL_GREEN, GL.GL_BLUE, GL.GL_ALPHA  ,0       ), // DDS_FORMAT_BC7_UNORM_SRGB
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO          ,0   ),      // DDS_FORMAT_AYUV
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO      ,0       ),      // DDS_FORMAT_Y410
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO        ,0     ),      // DDS_FORMAT_Y416
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO          ,0   ),      // DDS_FORMAT_NV12
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO          ,0   ),      // DDS_FORMAT_P010
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO          ,0   ),      // DDS_FORMAT_P016
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO          ,0   ),      // DDS_FORMAT_420_OPAQUE
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO          ,0   ),      // DDS_FORMAT_YUY2
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO         ,0    ),      // DDS_FORMAT_Y210
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO         ,0    ),      // DDS_FORMAT_Y216
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO         ,0    ),      // DDS_FORMAT_NV11
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO          ,0   ),      // DDS_FORMAT_AI44
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO         ,0    ),      // DDS_FORMAT_IA44
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO        ,0     ),      // DDS_FORMAT_P8
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO         ,0    ),      // DDS_FORMAT_A8P8
    new DDS_FORMAT_GL_INFO( GL.GL_NONE,          GL.GL_NONE,            GL.GL_NONE,            GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO,        GL.GL_ZERO         ,0    ),      // DDS_FORMAT_B4G4R4A4_UNORM
};
    }
}
