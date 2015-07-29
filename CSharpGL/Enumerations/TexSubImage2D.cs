using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum TexSubImage2DTarget : uint
    {
        Texture2D = GL.GL_TEXTURE_2D,
        TextureCubeMapPositiveX = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X,
        TextureCubeMapNegativeX = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        TextureCubeMapPositiveY = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Y,
        TextureCubeMapNegativeY = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        TextureCubeMapPositiveZ = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Z,
        TextureCubeMapNegativeZ = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Z,
    }

    public enum TexSubImage2DFormat : uint
    {
        Alpha =GL.GL_ALPHA,
        RGB = GL.GL_RGB,
        RGBA = GL.GL_RGBA,
        Luminance = GL.GL_LUMINANCE,
        LuminanceAlpha = GL.GL_LUMINANCE_ALPHA,
    }

    public enum TexSubImage2DType : uint
    {
        UnsignedByte = GL.GL_UNSIGNED_BYTE,
        UnsignedShort565 = GL.GL_UNSIGNED_SHORT_5_6_5,
        UnsignedShort4444 = GL.GL_UNSIGNED_SHORT_4_4_4_4,
        UnsignedShort5551 = GL.GL_UNSIGNED_SHORT_5_5_5_1,
    }
}
