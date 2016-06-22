using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
        /// <summary>
        /// The initial value is GL_ZERO
        /// </summary>
        Zero = OpenGL.GL_ZERO,
        One = OpenGL.GL_ONE,
        SourceColor = OpenGL.GL_SRC_COLOR,
        OneMinusSourceColor = OpenGL.GL_ONE_MINUS_SRC_COLOR,
        DestinationColor = OpenGL.GL_DST_COLOR,
        OneMinusDestinationColor = OpenGL.GL_ONE_MINUS_DST_COLOR,
        SourceAlpha = OpenGL.GL_SRC_ALPHA,
        OneMinusSourceAlpha = OpenGL.GL_ONE_MINUS_SRC_ALPHA,
        DestinationAlpha = OpenGL.GL_DST_ALPHA,
        OneMinusDestinationAlpha = OpenGL.GL_ONE_MINUS_DST_ALPHA,
        ConstantColor = OpenGL.GL_CONSTANT_COLOR,
        OneMinusConstantColor = OpenGL.GL_ONE_MINUS_CONSTANT_COLOR,
        ConstantAlpha = OpenGL.GL_CONSTANT_ALPHA,
        OneMinusConstantAlpha = OpenGL.GL_ONE_MINUS_CONSTANT_ALPHA,
    }

    /// <summary>
    /// The blending source factor.
    /// </summary>
    public enum BlendingSourceFactor : uint
    {
        /// <summary>
        /// The initial value is GL_ONE
        /// </summary>
        One = OpenGL.GL_ONE,
        Zero = OpenGL.GL_ZERO,
        SourceColor = OpenGL.GL_SRC_COLOR,
        OneMinusSourceColor = OpenGL.GL_ONE_MINUS_SRC_COLOR,
        DestinationColor = OpenGL.GL_DST_COLOR,
        OneMinusDestinationColor = OpenGL.GL_ONE_MINUS_DST_COLOR,
        SourceAlpha = OpenGL.GL_SRC_ALPHA,
        OneMinusSourceAlpha = OpenGL.GL_ONE_MINUS_SRC_ALPHA,
        DestinationAlpha = OpenGL.GL_DST_ALPHA,
        OneMinusDestinationAlpha = OpenGL.GL_ONE_MINUS_DST_ALPHA,
        ConstantColor = OpenGL.GL_CONSTANT_COLOR,
        OneMinusConstantColor = OpenGL.GL_ONE_MINUS_CONSTANT_COLOR,
        ConstantAlpha = OpenGL.GL_CONSTANT_ALPHA,
        OneMinusConstantAlpha = OpenGL.GL_ONE_MINUS_CONSTANT_ALPHA,
        SourceAlphaSaturate = OpenGL.GL_SRC_ALPHA_SATURATE,
    }
}
