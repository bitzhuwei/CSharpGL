using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public enum TexImage2DTargets : uint
    {
        Texture2D = GL.GL_TEXTURE_2D,
        ProxyTexture2D = GL.GL_PROXY_TEXTURE_2D,
    }

    public enum TexImage2DFormats : uint
    {
        Alpha = GL.GL_ALPHA,
        RGB = GL.GL_RGB,
        RGBA = GL.GL_RGBA,
        Luminance = GL.GL_LUMINANCE,
        LuminanceAlpha = GL.GL_LUMINANCE_ALPHA,
    }

    public enum TexImage2DTypes : uint
    {
        UnsignedByte = GL.GL_UNSIGNED_BYTE,
        UnsignedShort565 = GL.GL_UNSIGNED_SHORT_5_6_5,
        UnsignedShort4444 = GL.GL_UNSIGNED_SHORT_4_4_4_4,
        UnsignedShort5551 = GL.GL_UNSIGNED_SHORT_5_5_5_1,
    }
}
