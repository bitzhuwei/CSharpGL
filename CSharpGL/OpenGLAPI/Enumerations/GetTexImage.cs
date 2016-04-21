using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum GetTexImageTargets : uint
    {
        Texture1D = GL.GL_TEXTURE_1D,
        Texture2D = GL.GL_TEXTURE_2D,
        Texture3D = GL.GL_TEXTURE_3D,
        TextureCubeMapPositiveX = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X,
        TextureCubeMapNegativeX = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_X,
        TextureCubeMapPositiveY = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Y,
        TextureCubeMapNegativeY = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Y,
        TextureCubeMapPositiveZ = GL.GL_TEXTURE_CUBE_MAP_POSITIVE_Z,
        TextureCubeMapNegativeZ = GL.GL_TEXTURE_CUBE_MAP_NEGATIVE_Z,
    }

    public enum GetTexImageFormats : uint
    {
        Red = GL.GL_RED,
        Green = GL.GL_GREEN,
        Blue = GL.GL_BLUE,
        Alpha = GL.GL_ALPHA,
        RGB = GL.GL_RGB,
        BGR = GL.GL_BGR,
        RGBA = GL.GL_RGBA,
        BGRA = GL.GL_BGRA,
        Luminance = GL.GL_LUMINANCE,
        LuminanceAlpha = GL.GL_LUMINANCE_ALPHA,
    }

    /// <summary>
    /// 在你需要使用加入这些选项：
    /// GL_UNSIGNED_BYTE, GL_BYTE, GL_UNSIGNED_SHORT, GL_SHORT, GL_UNSIGNED_INT, GL_INT, GL_FLOAT, GL_UNSIGNED_BYTE_3_3_2, GL_UNSIGNED_BYTE_2_3_3_REV, GL_UNSIGNED_SHORT_5_6_5, GL_UNSIGNED_SHORT_5_6_5_REV, GL_UNSIGNED_SHORT_4_4_4_4, GL_UNSIGNED_SHORT_4_4_4_4_REV, GL_UNSIGNED_SHORT_5_5_5_1, GL_UNSIGNED_SHORT_1_5_5_5_REV, GL_UNSIGNED_INT_8_8_8_8, GL_UNSIGNED_INT_8_8_8_8_REV, GL_UNSIGNED_INT_10_10_10_2, and GL_UNSIGNED_INT_2_10_10_10_REV
    /// check: https://www.opengl.org/sdk/docs/man2/xhtml/glGetTexImage.xml
    /// </summary>
    public enum GetTexImageTypes : uint
    {
        UnsignedByte = GL.GL_UNSIGNED_BYTE,
        UnsignedShort565 = GL.GL_UNSIGNED_SHORT_5_6_5,
        UnsignedShort4444 = GL.GL_UNSIGNED_SHORT_4_4_4_4,
        UnsignedShort5551 = GL.GL_UNSIGNED_SHORT_5_5_5_1,
    }
}
