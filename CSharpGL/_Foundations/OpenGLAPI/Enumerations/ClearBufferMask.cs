using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    /// <summary>
    /// Used in OpenGL.BlitFramebuffer, OpenGL.Clear and 1 other function
    /// </summary>
    [Flags]
    public enum ClearBufferMask : uint
    {
        /// <summary>
        /// Original was GL_NONE = 0
        /// </summary>
        None = OpenGL.GL_NONE,// ((uint)0),
        /// <summary>
        /// Original was GL_DEPTH_BUFFER_BIT = 0x00000100
        /// </summary>
        DepthBufferBit = OpenGL.GL_DEPTH_BUFFER_BIT,// ((uint)0x00000100),
        /// <summary>
        /// Original was GL_ACCUM_BUFFER_BIT = 0x00000200
        /// </summary>
        AccumBufferBit = OpenGL.GL_ACCUM_BUFFER_BIT,// ((uint)0x00000200),
        /// <summary>
        /// Original was GL_STENCIL_BUFFER_BIT = 0x00000400
        /// </summary>
        StencilBufferBit = OpenGL.GL_STENCIL_BUFFER_BIT,// ((uint)0x00000400),
        /// <summary>
        /// Original was GL_COLOR_BUFFER_BIT = 0x00004000
        /// </summary>
        ColorBufferBit = OpenGL.GL_COLOR_BUFFER_BIT,// ((uint)0x00004000),
        /// <summary>
        /// Original was GL_COVERAGE_BUFFER_BIT_NV = 0x00008000
        /// </summary>
        CoverageBufferBitNv = OpenGL.GL_COVERAGE_BUFFER_BIT_NV,// ((uint)0x00008000),
    }
}
