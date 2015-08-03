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
    }

    public enum GetTexImageFormats : uint
    {
        Alpha = GL.GL_ALPHA,
        RGB = GL.GL_RGB,
        RGBA = GL.GL_RGBA,
        Luminance = GL.GL_LUMINANCE,
        LuminanceAlpha = GL.GL_LUMINANCE_ALPHA,
    }

    public enum GetTexImageTypes : uint
    {
        UnsignedByte = GL.GL_UNSIGNED_BYTE,
        UnsignedShort565 = GL.GL_UNSIGNED_SHORT_5_6_5,
        UnsignedShort4444 = GL.GL_UNSIGNED_SHORT_4_4_4_4,
        UnsignedShort5551 = GL.GL_UNSIGNED_SHORT_5_5_5_1,
    }
}
