using System;

namespace CSharpGL
{
    public static partial class OpenGL
    {
        #region OpenGL 1.2

        //  Delegates
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        ///// <param name="alpha"></param>
        //public delegate void glBlendColor(float red, float green, float blue, float alpha);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="mode"></param>
        //public delegate void glBlendEquation(uint mode);
        /// <summary>
        ///
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        public delegate void glDrawRangeElements(uint mode, uint start, uint end, int count, uint type, IntPtr indices);

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="internalformat"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="border"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public delegate void glTexImage3D(uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels);

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public delegate void glTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels);

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="level"></param>
        /// <param name="xoffset"></param>
        /// <param name="yoffset"></param>
        /// <param name="zoffset"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="depth"></param>
        /// <param name="format"></param>
        /// <param name="type"></param>
        /// <param name="pixels"></param>
        public delegate void glTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr pixels);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="yoffset"></param>
        ///// <param name="zoffset"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public delegate void glCopyTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int x, int y, int width, int height);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="table"></param>
        //public delegate void glColorTable(uint target, uint internalformat, int width, uint format, uint type, IntPtr table);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glColorTableParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glColorTableParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        //public delegate void glCopyColorTable(uint target, uint internalformat, int x, int y, int width);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="table"></param>
        //public delegate void glGetColorTable(uint target, uint format, uint type, IntPtr table);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetColorTableParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetColorTableParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="start"></param>
        ///// <param name="count"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="data"></param>
        //public delegate void glColorSubTable(uint target, int start, int count, uint format, uint type, IntPtr data);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="start"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        //public delegate void glCopyColorSubTable(uint target, int start, int x, int y, int width);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="image"></param>
        //public delegate void glConvolutionFilter1D(uint target, uint internalformat, int width, uint format, uint type, IntPtr image);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="image"></param>
        //public delegate void glConvolutionFilter2D(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr image);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameterf(uint target, uint pname, float parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameteri(uint target, uint pname, int parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glConvolutionParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        //public delegate void glCopyConvolutionFilter1D(uint target, uint internalformat, int x, int y, int width);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        //public delegate void glCopyConvolutionFilter2D(uint target, uint internalformat, int x, int y, int width, int height);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="image"></param>
        //public delegate void glGetConvolutionFilter(uint target, uint format, uint type, IntPtr image);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetConvolutionParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetConvolutionParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        ///// <param name="span"></param>
        //public delegate void glGetSeparableFilter(uint target, uint format, uint type, IntPtr row, IntPtr column, IntPtr span);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        //public delegate void glSeparableFilter2D(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr row, IntPtr column);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="reset"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="values"></param>
        //public delegate void glGetHistogram(uint target, bool reset, uint format, uint type, IntPtr values);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetHistogramParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetHistogramParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="reset"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="values"></param>
        //public delegate void glGetMinmax(uint target, bool reset, uint format, uint type, IntPtr values);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetMinmaxParameterfv(uint target, uint pname, float[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetMinmaxParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="width"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="sink"></param>
        //public delegate void glHistogram(uint target, int width, uint internalformat, bool sink);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="sink"></param>
        //public delegate void glMinmax(uint target, uint internalformat, bool sink);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        //public delegate void glResetHistogram(uint target);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        //public delegate void glResetMinmax(uint target);

        //  Constants
        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_BYTE_3_3_2 = 0x8032;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_8_8_8_8 = 0x8035;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_10_10_10_2 = 0x8036;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BINDING_3D = 0x806A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PACK_SKIP_IMAGES = 0x806B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PACK_IMAGE_HEIGHT = 0x806C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNPACK_SKIP_IMAGES = 0x806D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNPACK_IMAGE_HEIGHT = 0x806E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_3D = 0x806F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PROXY_TEXTURE_3D = 0x8070;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_DEPTH = 0x8071;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_WRAP_R = 0x8072;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_3D_TEXTURE_SIZE = 0x8073;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_BYTE_2_3_3_REV = 0x8362;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_5_6_5 = 0x8363;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_5_6_5_REV = 0x8364;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_4_4_4_4_REV = 0x8365;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_SHORT_1_5_5_5_REV = 0x8366;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_8_8_8_8_REV = 0x8367;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_BGR = 0x80E0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_BGRA = 0x80E1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_ELEMENTS_VERTICES = 0x80E8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_ELEMENTS_INDICES = 0x80E9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLAMP_TO_EDGE = 0x812F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_MIN_LOD = 0x813A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_MAX_LOD = 0x813B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BASE_LEVEL = 0x813C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_MAX_LEVEL = 0x813D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SMOOTH_POINT_SIZE_RANGE = 0x0B12;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SMOOTH_POINT_SIZE_GRANULARITY = 0x0B13;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SMOOTH_LINE_WIDTH_RANGE = 0x0B22;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_ALIASED_LINE_WIDTH_RANGE = 0x846E;

        #endregion OpenGL 1.2
    }
}