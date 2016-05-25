using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum TexImage2DTargets : uint
    {
        Texture2D = OpenGL.GL_TEXTURE_2D,
        ProxyTexture2D = OpenGL.GL_PROXY_TEXTURE_2D,
    }

    public enum TexImage2DFormats : uint
    {
        Alpha = OpenGL.GL_ALPHA,
        RGB = OpenGL.GL_RGB,
        RGBA = OpenGL.GL_RGBA,
        Luminance = OpenGL.GL_LUMINANCE,
        LuminanceAlpha = OpenGL.GL_LUMINANCE_ALPHA,
    }

    public enum TexImage2DTypes : uint
    {
        UnsignedByte = OpenGL.GL_UNSIGNED_BYTE,
        UnsignedShort565 = OpenGL.GL_UNSIGNED_SHORT_5_6_5,
        UnsignedShort4444 = OpenGL.GL_UNSIGNED_SHORT_4_4_4_4,
        UnsignedShort5551 = OpenGL.GL_UNSIGNED_SHORT_5_5_5_1,
    }
}
