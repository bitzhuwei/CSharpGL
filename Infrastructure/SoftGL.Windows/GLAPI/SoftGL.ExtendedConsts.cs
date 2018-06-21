using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL
{
    public partial class SoftGL
    {

        #region WGL_create_context

        internal const int WGL_CONTEXT_DEBUG_BIT_ARB = 0x0001;
        internal const int WGL_CONTEXT_FORWARD_COMPATIBLE_BIT_ARB = 0x0002;
        internal const int WGL_CONTEXT_CORE_PROFILE_BIT_ARB = 0x00000001;
        internal const int WGL_CONTEXT_COMPATIBILITY_PROFILE_BIT_ARB = 0x00000002;
        internal const int WGL_DRAW_TO_WINDOW_ARB = 0x2001;
        internal const int WGL_ACCELERATION_ARB = 0x2003;
        internal const int WGL_SWAP_METHOD_ARB = 0x2007;
        internal const int WGL_SUPPORT_OPENGL_ARB = 0x2010;
        internal const int WGL_DOUBLE_BUFFER_ARB = 0x2011;
        internal const int WGL_PIXEL_TYPE_ARB = 0x2013;
        internal const int WGL_COLOR_BITS_ARB = 0x2014;
        internal const int WGL_RED_BITS_ARB = 0x2015;
        internal const int WGL_GREEN_BITS_ARB = 0x2017;
        internal const int WGL_BLUE_BITS_ARB = 0x2019;
        internal const int WGL_ALPHA_BITS_ARB = 0x201B;
        internal const int WGL_ACCUM_BITS_ARB = 0x201D;
        internal const int WGL_ACCUM_RED_BITS_ARB = 0x201E;
        internal const int WGL_ACCUM_GREEN_BITS_ARB = 0x201F;
        internal const int WGL_ACCUM_BLUE_BITS_ARB = 0x2020;
        internal const int WGL_ACCUM_ALPHA_BITS_ARB = 0x2021;
        internal const int WGL_DEPTH_BITS_ARB = 0x2022;
        internal const int WGL_STENCIL_BITS_ARB = 0x2023;
        internal const int WGL_AUX_BUFFERS_ARB = 0x2024;
        internal const int WGL_FULL_ACCELERATION_ARB = 0x2027;
        internal const int WGL_SWAP_EXCHANGE_ARB = 0x2028;
        internal const int WGL_TYPE_RGBA_ARB = 0x202B;
        internal const int WGL_CONTEXT_MAJOR_VERSION_ARB = 0x2091;
        internal const int WGL_CONTEXT_MINOR_VERSION_ARB = 0x2092;
        internal const int WGL_CONTEXT_LAYER_PLANE_ARB = 0x2093;
        internal const int WGL_CONTEXT_FLAGS_ARB = 0x2094;
        internal const int ERROR_INVALID_VERSION = 0x2095;
        internal const int ERROR_INVALID_PROFILE = 0x2096;
        internal const int WGL_CONTEXT_PROFILE_MASK_ARB = 0x9126;


        #endregion WGL_create_context

    }
}
