using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    //class BlendFunc
    //{
    //}
    /// <summary>
    /// BlendingDestinationFactor
    /// </summary>
    public enum BlendingDestinationFactor : uint
    {
        Zero = OpenGL.GL_ZERO,
        One = OpenGL.GL_ONE,
        SourceColor = OpenGL.GL_SRC_COLOR,
        OneMinusSourceColor = OpenGL.GL_ONE_MINUS_SRC_COLOR,
        SourceAlpha = OpenGL.GL_SRC_ALPHA,
        OneMinusSourceAlpha = OpenGL.GL_ONE_MINUS_SRC_ALPHA,
        DestinationAlpha = OpenGL.GL_DST_ALPHA,
        OneMinusDestinationAlpha = OpenGL.GL_ONE_MINUS_DST_ALPHA,
    }

    /// <summary>
    /// The blending source factor.
    /// </summary>
    public enum BlendingSourceFactor : uint
    {
        DestinationColor = OpenGL.GL_DST_COLOR,
        OneMinusDestinationColor = OpenGL.GL_ONE_MINUS_DST_COLOR,
        SourceAlphaSaturate = OpenGL.GL_SRC_ALPHA_SATURATE,
        SourceAlpha = OpenGL.GL_SRC_ALPHA
    }
}
