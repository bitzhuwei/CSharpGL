using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Enumerations
{
    //class BlendFunc
    //{
    //}
    /// <summary>
    /// BlendingDestinationFactor
    /// </summary>
    public enum BlendingDestinationFactor : uint
    {
        Zero = GL.GL_ZERO,
        One = GL.GL_ONE,
        SourceColor = GL.GL_SRC_COLOR,
        OneMinusSourceColor = GL.GL_ONE_MINUS_SRC_COLOR,
        SourceAlpha = GL.GL_SRC_ALPHA,
        OneMinusSourceAlpha = GL.GL_ONE_MINUS_SRC_ALPHA,
        DestinationAlpha = GL.GL_DST_ALPHA,
        OneMinusDestinationAlpha = GL.GL_ONE_MINUS_DST_ALPHA,
    }

    /// <summary>
    /// The blending source factor.
    /// </summary>
    public enum BlendingSourceFactor : uint
    {
        DestinationColor = GL.GL_DST_COLOR,
        OneMinusDestinationColor = GL.GL_ONE_MINUS_DST_COLOR,
        SourceAlphaSaturate = GL.GL_SRC_ALPHA_SATURATE,
        SourceAlpha = GL.GL_SRC_ALPHA
    }
}
