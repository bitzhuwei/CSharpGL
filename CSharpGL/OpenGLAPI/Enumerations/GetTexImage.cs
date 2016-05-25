using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum GetTexImageTargets : uint
    {
        Texture1D = OpenGL.GL_TEXTURE_1D,
        Texture2D = OpenGL.GL_TEXTURE_2D,
        Texture3D = OpenGL.GL_TEXTURE_3D,
        TextureCubeMapPositiveX = OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_X,
        TextureCubeMapNegativeX = OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        TextureCubeMapPositiveY = OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_Y,
        TextureCubeMapNegativeY = OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        TextureCubeMapPositiveZ = OpenGL.GL_TEXTURE_CUBE_MAP_POSITIVE_Z,
        TextureCubeMapNegativeZ = OpenGL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Z,
    }

    public enum GetTexImageFormats : uint
    {
        Red = OpenGL.GL_RED,
        Green = OpenGL.GL_GREEN,
        Blue = OpenGL.GL_BLUE,
        Alpha = OpenGL.GL_ALPHA,
        RGB = OpenGL.GL_RGB,
        BGR = OpenGL.GL_BGR,
        RGBA = OpenGL.GL_RGBA,
        BGRA = OpenGL.GL_BGRA,
        Luminance = OpenGL.GL_LUMINANCE,
        LuminanceAlpha = OpenGL.GL_LUMINANCE_ALPHA,
    }

    /// <summary>
    /// 在你需要使用加入这些选项：
    /// GL_UNSIGNED_BYTE, GL_BYTE, GL_UNSIGNED_SHORT, GL_SHORT, GL_UNSIGNED_INT, GL_INT, GL_FLOAT, GL_UNSIGNED_BYTE_3_3_2, GL_UNSIGNED_BYTE_2_3_3_REV, GL_UNSIGNED_SHORT_5_6_5, GL_UNSIGNED_SHORT_5_6_5_REV, GL_UNSIGNED_SHORT_4_4_4_4, GL_UNSIGNED_SHORT_4_4_4_4_REV, GL_UNSIGNED_SHORT_5_5_5_1, GL_UNSIGNED_SHORT_1_5_5_5_REV, GL_UNSIGNED_INT_8_8_8_8, GL_UNSIGNED_INT_8_8_8_8_REV, GL_UNSIGNED_INT_10_10_10_2, and GL_UNSIGNED_INT_2_10_10_10_REV
    /// check: https://www.opengl.org/sdk/docs/man2/xhtml/glGetTexImage.xml
    /// </summary>
    public enum GetTexImageTypes : uint
    {
        UnsignedByte = OpenGL.GL_UNSIGNED_BYTE,
        UnsignedShort565 = OpenGL.GL_UNSIGNED_SHORT_5_6_5,
        UnsignedShort4444 = OpenGL.GL_UNSIGNED_SHORT_4_4_4_4,
        UnsignedShort5551 = OpenGL.GL_UNSIGNED_SHORT_5_5_5_1,
    }
}
