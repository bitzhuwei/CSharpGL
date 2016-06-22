using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public enum TexSubImage2DTarget : uint
    {
        Texture2D = OpenGL.GL_TEXTURE_2D,
        TextureCubeMapPositiveX = OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_X,
        TextureCubeMapNegativeX = OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        TextureCubeMapPositiveY = OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_Y,
        TextureCubeMapNegativeY = OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        TextureCubeMapPositiveZ = OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_Z,
        TextureCubeMapNegativeZ = OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Z,
    }

    public enum TexSubImage2DFormats : uint
    {
        Alpha =OpenGL.GL_ALPHA,
        RGB = OpenGL.GL_RGB,
        RGBA = OpenGL.GL_RGBA,
        Luminance = OpenGL.GL_LUMINANCE,
        LuminanceAlpha = OpenGL.GL_LUMINANCE_ALPHA,
        RedInteger = OpenGL.GL_RED_INTEGER,
    }

    public enum TexSubImage2DType : uint
    {
        UnsignedByte = OpenGL.GL_UNSIGNED_BYTE,
        UnsignedShort565 = OpenGL.GL_UNSIGNED_SHORT_5_6_5,
        UnsignedShort4444 = OpenGL.GL_UNSIGNED_SHORT_4_4_4_4,
        UnsignedShort5551 = OpenGL.GL_UNSIGNED_SHORT_5_5_5_1,
        UnsignedInt = OpenGL.GL_UNSIGNED_INT,
    }
}
