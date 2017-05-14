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
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="mode"></param>
        ///// <param name="start"></param>
        ///// <param name="end"></param>
        ///// <param name="count"></param>
        ///// <param name="type"></param>
        ///// <param name="indices"></param>
        //public delegate void glDrawRangeElements(uint mode, uint start, uint end, int count, uint type, IntPtr indices);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="depth"></param>
        ///// <param name="border"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="pixels"></param>
        //public delegate void glTexImage3D(uint target, int level, int internalformat, int width, int height, int depth, int border, uint format, uint type, IntPtr pixels);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="yoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="pixels"></param>
        //public delegate void glTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, uint type, IntPtr pixels);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="yoffset"></param>
        ///// <param name="zoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="depth"></param>
        ///// <param name="format"></param>
        ///// <param name="type"></param>
        ///// <param name="pixels"></param>
        //public delegate void glTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, uint type, IntPtr pixels);

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

        #endregion OpenGL 1.2
    }
}