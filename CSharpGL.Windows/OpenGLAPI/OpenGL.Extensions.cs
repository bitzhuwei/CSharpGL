//using System;
//using System.Text;

//namespace CSharpGL
//{
//    // TODO: members of OpenGL in this file is not organized yet.
//    public static partial class OpenGL
//    {
//        #region GL_EXT_draw_range_elements

//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="mode"></param>
//        ///// <param name="start"></param>
//        ///// <param name="end"></param>
//        ///// <param name="count"></param>
//        ///// <param name="type"></param>
//        ///// <param name="indices"></param>
//        //public delegate void glDrawRangeElements(uint mode, uint start, uint end, uint count, uint type, IntPtr indices);

//        #endregion GL_EXT_draw_range_elements

//        #region GL_SGI_color_table

//        //  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="width"></param>
//        ///// <param name="format"></param>
//        ///// <param name="type"></param>
//        ///// <param name="table"></param>
//        //public delegate void glColorTableSGI(uint target, uint internalformat, uint width, uint format, uint type, IntPtr table);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glColorTableParameterfvSGI(uint target, uint pname, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glColorTableParameterivSGI(uint target, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="width"></param>
//        //public delegate void glCopyColorTableSGI(uint target, uint internalformat, int x, int y, uint width);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="format"></param>
//        ///// <param name="type"></param>
//        ///// <param name="table"></param>
//        //public delegate void glGetColorTableSGI(uint target, uint format, uint type, IntPtr table);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetColorTableParameterfvSGI(uint target, uint pname, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetColorTableParameterivSGI(uint target, uint pname, int[] parameters);

//        #endregion GL_SGI_color_table

//        #region GL_EXT_convolution

//        //  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="width"></param>
//        ///// <param name="format"></param>
//        ///// <param name="type"></param>
//        ///// <param name="image"></param>
//        //public delegate void glConvolutionFilter1D(uint target, uint internalformat, int width, uint format, uint type, IntPtr image);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="width"></param>
//        ///// <param name="height"></param>
//        ///// <param name="format"></param>
//        ///// <param name="type"></param>
//        ///// <param name="image"></param>
//        //public delegate void glConvolutionFilter2D(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr image);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glConvolutionParameterf(uint target, uint pname, float parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glConvolutionParameterfv(uint target, uint pname, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameter"></param>
//        //public delegate void glConvolutionParameteri(uint target, uint pname, int parameter);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glConvolutionParameteriv(uint target, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="width"></param>
//        //public delegate void glCopyConvolutionFilter1D(uint target, uint internalformat, int x, int y, int width);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="width"></param>
//        ///// <param name="height"></param>
//        //public delegate void glCopyConvolutionFilter2D(uint target, uint internalformat, int x, int y, int width, int height);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="format"></param>
//        ///// <param name="type"></param>
//        ///// <param name="image"></param>
//        //public delegate void glGetConvolutionFilter(uint target, uint format, uint type, IntPtr image);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetConvolutionParameterfv(uint target, uint pname, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetConvolutionParameteriv(uint target, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="format"></param>
//        ///// <param name="type"></param>
//        ///// <param name="row"></param>
//        ///// <param name="column"></param>
//        ///// <param name="span"></param>
//        //public delegate void glGetSeparableFilter(uint target, uint format, uint type, IntPtr row, IntPtr column, IntPtr span);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="width"></param>
//        ///// <param name="height"></param>
//        ///// <param name="format"></param>
//        ///// <param name="type"></param>
//        ///// <param name="row"></param>
//        ///// <param name="column"></param>
//        //public delegate void glSeparableFilter2D(uint target, uint internalformat, int width, int height, uint format, uint type, IntPtr row, IntPtr column);

//        #endregion GL_EXT_convolution

//        //#region GL_SGI_color_matrix

//        //#endregion

//        //#region GL_EXT_histogram

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="reset"></param>
//        ///// <param name="format"></param>
//        ///// <param name="type"></param>
//        ///// <param name="values"></param>
//        //public delegate void glGetHistogram(uint target, bool reset, uint format, uint type, IntPtr values);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetHistogramParameterfv(uint target, uint pname, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetHistogramParameteriv(uint target, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="reset"></param>
//        ///// <param name="format"></param>
//        ///// <param name="type"></param>
//        ///// <param name="values"></param>
//        //public delegate void glGetMinmax(uint target, bool reset, uint format, uint type, IntPtr values);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetMinmaxParameterfv(uint target, uint pname, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetMinmaxParameteriv(uint target, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="width"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="sink"></param>
//        //public delegate void glHistogram(uint target, int width, uint internalformat, bool sink);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="sink"></param>
//        //public delegate void glMinmax(uint target, uint internalformat, bool sink);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        //public delegate void glResetHistogram(uint target);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        //public delegate void glResetMinmax(uint target);

//        //#endregion

//        //#region GL_EXT_blend_color

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="red"></param>
//        ///// <param name="green"></param>
//        ///// <param name="blue"></param>
//        ///// <param name="alpha"></param>
//        //public delegate void glBlendColor(float red, float green, float blue, float alpha);

//        //#endregion

//        //#region GL_EXT_blend_minmax

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="mode"></param>
//        //public delegate void glBlendEquation(uint mode);

//        //#endregion

//        //#region GL_multitexture

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="texture"></param>
//        //public delegate void glActiveTexture(uint texture);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="texture"></param>
//        //public delegate void glClientActiveTexture(uint texture);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        //public delegate void glMultiTexCoord1d(uint target, double s);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord1dv(uint target, double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        //public delegate void glMultiTexCoord1f(uint target, float s);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord1fv(uint target, float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        //public delegate void glMultiTexCoord1i(uint target, int s);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord1iv(uint target, int[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        //public delegate void glMultiTexCoord1s(uint target, short s);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord1sv(uint target, short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        //public delegate void glMultiTexCoord2d(uint target, double s, double t);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord2dv(uint target, double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        //public delegate void glMultiTexCoord2f(uint target, float s, float t);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord2fv(uint target, float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        //public delegate void glMultiTexCoord2i(uint target, int s, int t);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord2iv(uint target, int[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        //public delegate void glMultiTexCoord2s(uint target, short s, short t);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord2sv(uint target, short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        ///// <param name="r"></param>
//        //public delegate void glMultiTexCoord3d(uint target, double s, double t, double r);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord3dv(uint target, double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        ///// <param name="r"></param>
//        //public delegate void glMultiTexCoord3f(uint target, float s, float t, float r);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord3fv(uint target, float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        ///// <param name="r"></param>
//        //public delegate void glMultiTexCoord3i(uint target, int s, int t, int r);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord3iv(uint target, int[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        ///// <param name="r"></param>
//        //public delegate void glMultiTexCoord3s(uint target, short s, short t, short r);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord3sv(uint target, short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        ///// <param name="r"></param>
//        ///// <param name="q"></param>
//        //public delegate void glMultiTexCoord4d(uint target, double s, double t, double r, double q);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord4dv(uint target, double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        ///// <param name="r"></param>
//        ///// <param name="q"></param>
//        //public delegate void glMultiTexCoord4f(uint target, float s, float t, float r, float q);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord4fv(uint target, float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        ///// <param name="r"></param>
//        ///// <param name="q"></param>
//        //public delegate void glMultiTexCoord4i(uint target, int s, int t, int r, int q);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord4iv(uint target, int[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="s"></param>
//        ///// <param name="t"></param>
//        ///// <param name="r"></param>
//        ///// <param name="q"></param>
//        //public delegate void glMultiTexCoord4s(uint target, short s, short t, short r, short q);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="v"></param>
//        //public delegate void glMultiTexCoord4sv(uint target, short[] v);

//        //#endregion

//        //#region GL_texture_compression

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="level"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="width"></param>
//        ///// <param name="height"></param>
//        ///// <param name="depth"></param>
//        ///// <param name="border"></param>
//        ///// <param name="imageSize"></param>
//        ///// <param name="data"></param>
//        //public delegate void glCompressedTexImage3D(uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="level"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="width"></param>
//        ///// <param name="height"></param>
//        ///// <param name="border"></param>
//        ///// <param name="imageSize"></param>
//        ///// <param name="data"></param>
//        //public delegate void glCompressedTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, int imageSize, IntPtr data);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="level"></param>
//        ///// <param name="internalformat"></param>
//        ///// <param name="width"></param>
//        ///// <param name="border"></param>
//        ///// <param name="imageSize"></param>
//        ///// <param name="data"></param>
//        //public delegate void glCompressedTexImage1D(uint target, int level, uint internalformat, int width, int border, int imageSize, IntPtr data);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="level"></param>
//        ///// <param name="xoffset"></param>
//        ///// <param name="yoffset"></param>
//        ///// <param name="zoffset"></param>
//        ///// <param name="width"></param>
//        ///// <param name="height"></param>
//        ///// <param name="depth"></param>
//        ///// <param name="format"></param>
//        ///// <param name="imageSize"></param>
//        ///// <param name="data"></param>
//        //public delegate void glCompressedTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr data);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="level"></param>
//        ///// <param name="xoffset"></param>
//        ///// <param name="yoffset"></param>
//        ///// <param name="width"></param>
//        ///// <param name="height"></param>
//        ///// <param name="format"></param>
//        ///// <param name="imageSize"></param>
//        ///// <param name="data"></param>
//        //public delegate void glCompressedTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr data);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="level"></param>
//        ///// <param name="xoffset"></param>
//        ///// <param name="width"></param>
//        ///// <param name="format"></param>
//        ///// <param name="imageSize"></param>
//        ///// <param name="data"></param>
//        //public delegate void glCompressedTexSubImage1D(uint target, int level, int xoffset, int width, uint format, int imageSize, IntPtr data);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="level"></param>
//        ///// <param name="img"></param>
//        //public delegate void glGetCompressedTexImage(uint target, int level, IntPtr img);

//        //#endregion

//        //#region GL_multisample

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="value"></param>
//        ///// <param name="invert"></param>
//        //public delegate void glSampleCoverage(float value, bool invert);

//        //#endregion

//        //#region GL_texture_env_add

//        ////  Appears to not have any functionality

//        //#endregion


//        //#region GL_transpose_matrix

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="m"></param>
//        //public delegate void glLoadTransposeMatrixf(float[] m);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="m"></param>
//        //public delegate void glLoadTransposeMatrixd(double[] m);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="m"></param>
//        //public delegate void glMultTransposeMatrixf(float[] m);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="m"></param>
//        //public delegate void glMultTransposeMatrixd(double[] m);

//        //#endregion

//        //#region GL_NV_blend_square

//        ////  Appears to be empty.

//        //#endregion

//        //#region GL_EXT_fog_coord

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="coord"></param>
//        //public delegate void glFogCoordf(float coord);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="coord"></param>
//        //public delegate void glFogCoordfv(float[] coord);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="coord"></param>
//        //public delegate void glFogCoordd(double coord);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="coord"></param>
//        //public delegate void glFogCoorddv(double[] coord);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="type"></param>
//        ///// <param name="stride"></param>
//        ///// <param name="pointer"></param>
//        //public delegate void glFogCoordPointer(uint type, int stride, IntPtr pointer);

//        //#endregion

//        //#region GL_EXT_multi_draw_arrays

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="mode"></param>
//        ///// <param name="first"></param>
//        ///// <param name="count"></param>
//        ///// <param name="primcount"></param>
//        //public delegate void glMultiDrawArrays(uint mode, int[] first, int[] count, int primcount);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="mode"></param>
//        ///// <param name="count"></param>
//        ///// <param name="type"></param>
//        ///// <param name="indices"></param>
//        ///// <param name="primcount"></param>
//        //public delegate void glMultiDrawElements(uint mode, int[] count, uint type, IntPtr indices, int primcount);

//        //#endregion

//        //#region GL_point_parameters

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="pname"></param>
//        ///// <param name="param"></param>
//        //public delegate void glPointParameterf(uint pname, float param);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glPointParameterfv(uint pname, float[] parameters);

//        //#endregion

//        //#region GL_EXT_secondary_color

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="red"></param>
//        ///// <param name="green"></param>
//        ///// <param name="blue"></param>
//        //public delegate void glSecondaryColor3b(sbyte red, sbyte green, sbyte blue);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glSecondaryColor3bv(sbyte[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="red"></param>
//        ///// <param name="green"></param>
//        ///// <param name="blue"></param>
//        //public delegate void glSecondaryColor3d(double red, double green, double blue);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glSecondaryColor3dv(double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="red"></param>
//        ///// <param name="green"></param>
//        ///// <param name="blue"></param>
//        //public delegate void glSecondaryColor3f(float red, float green, float blue);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glSecondaryColor3fv(float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="red"></param>
//        ///// <param name="green"></param>
//        ///// <param name="blue"></param>
//        //public delegate void glSecondaryColor3i(int red, int green, int blue);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glSecondaryColor3iv(int[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="red"></param>
//        ///// <param name="green"></param>
//        ///// <param name="blue"></param>
//        //public delegate void glSecondaryColor3s(short red, short green, short blue);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glSecondaryColor3sv(short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="red"></param>
//        ///// <param name="green"></param>
//        ///// <param name="blue"></param>
//        //public delegate void glSecondaryColor3ub(byte red, byte green, byte blue);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glSecondaryColor3ubv(byte[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="red"></param>
//        ///// <param name="green"></param>
//        ///// <param name="blue"></param>
//        //public delegate void glSecondaryColor3ui(uint red, uint green, uint blue);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glSecondaryColor3uiv(uint[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="red"></param>
//        ///// <param name="green"></param>
//        ///// <param name="blue"></param>
//        //public delegate void glSecondaryColor3us(ushort red, ushort green, ushort blue);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glSecondaryColor3usv(ushort[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="stride"></param>
//        ///// <param name="pointer"></param>
//        //public delegate void glSecondaryColorPointer(int size, uint type, int stride, IntPtr pointer);

//        //#endregion

//        //#region  GL_EXT_blend_func_separate

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="sfactorRGB"></param>
//        ///// <param name="dfactorRGB"></param>
//        ///// <param name="sfactorAlpha"></param>
//        ///// <param name="dfactorAlpha"></param>
//        //public delegate void glBlendFuncSeparate(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);

//        ////  Constants

//        //#endregion

//        //#region GL_texture_env_crossbar

//        ////  No methods or constants.

//        //#endregion

//        //#region GL_window_pos

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        //public delegate void glWindowPos2d(double x, double y);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glWindowPos2dv(double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        //public delegate void glWindowPos2f(float x, float y);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glWindowPos2fv(float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        //public delegate void glWindowPos2i(int x, int y);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glWindowPos2iv(int[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        //public delegate void glWindowPos2s(short x, short y);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glWindowPos2sv(short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        //public delegate void glWindowPos3d(double x, double y, double z);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glWindowPos3dv(double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        //public delegate void glWindowPos3f(float x, float y, float z);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glWindowPos3fv(float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        //public delegate void glWindowPos3i(int x, int y, int z);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glWindowPos3iv(int[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        //public delegate void glWindowPos3s(short x, short y, short z);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="v"></param>
//        //public delegate void glWindowPos3sv(short[] v);

//        //#endregion

//        //#region GL_vertex_buffer_object

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="buffer"></param>
//        //public delegate void glBindBuffer(uint target, uint buffer);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="n"></param>
//        ///// <param name="buffers"></param>
//        //public delegate void glDeleteBuffers(int n, uint[] buffers);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="n"></param>
//        ///// <param name="buffers"></param>
//        //public delegate void glGenBuffers(int n, uint[] buffers);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="buffer"></param>
//        ///// <returns></returns>
//        //public delegate bool glIsBuffer(uint buffer);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="size"></param>
//        ///// <param name="data"></param>
//        ///// <param name="usage"></param>
//        //public delegate void glBufferData(uint target, uint size, IntPtr data, uint usage);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="offset"></param>
//        ///// <param name="size"></param>
//        ///// <param name="data"></param>
//        //public delegate void glBufferSubData(uint target, uint offset, uint size, IntPtr data);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="offset"></param>
//        ///// <param name="size"></param>
//        ///// <param name="data"></param>
//        //public delegate void glGetBufferSubData(uint target, uint offset, uint size, IntPtr data);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="access"></param>
//        ///// <returns></returns>
//        //public delegate IntPtr glMapBuffer(uint target, uint access);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <returns></returns>
//        //public delegate bool glUnmapBuffer(uint target);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetBufferParameteriv(uint target, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetBufferPointerv(uint target, uint pname, IntPtr parameters);

//        //#endregion

//        //#region GL_occlusion_query

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="n"></param>
//        ///// <param name="ids"></param>
//        //public delegate void glGenQueries(int n, uint[] ids);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="n"></param>
//        ///// <param name="ids"></param>
//        //public delegate void glDeleteQueries(int n, uint[] ids);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="id"></param>
//        ///// <returns></returns>
//        //public delegate bool glIsQuery(uint id);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="id"></param>
//        //public delegate void glBeginQuery(uint target, uint id);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        //public delegate void glEndQuery(uint target);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetQueryiv(uint target, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="id"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetQueryObjectiv(uint id, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="id"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetQueryObjectuiv(uint id, uint pname, uint[] parameters);

//        //#endregion

//        //#region GL_shader_objects

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="obj"></param>
//        //public delegate void glDeleteObject(uint obj);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="pname"></param>
//        ///// <returns></returns>
//        //public delegate uint glGetHandle(uint pname);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="containerObj"></param>
//        ///// <param name="attachedObj"></param>
//        //public delegate void glDetachObject(uint containerObj, uint attachedObj);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="shaderType"></param>
//        ///// <returns></returns>
//        //public delegate uint glCreateShaderObject(uint shaderType);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="shaderObj"></param>
//        ///// <param name="count"></param>
//        ///// <param name="source"></param>
//        ///// <param name="length"></param>
//        //public delegate void glShaderSource(uint shaderObj, int count, string[] source, ref int length);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="shaderObj"></param>
//        //public delegate void glCompileShader(uint shaderObj);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <returns></returns>
//        //public delegate uint glCreateProgramObject();
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="containerObj"></param>
//        ///// <param name="obj"></param>
//        //public delegate void glAttachObject(uint containerObj, uint obj);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        //public delegate void glLinkProgram(uint programObj);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        //public delegate void glUseProgramObject(uint programObj);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        //public delegate void glValidateProgram(uint programObj);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="v0"></param>
//        //public delegate void glUniform1f(int location, float v0);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="v0"></param>
//        ///// <param name="v1"></param>
//        //public delegate void glUniform2f(int location, float v0, float v1);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="v0"></param>
//        ///// <param name="v1"></param>
//        ///// <param name="v2"></param>
//        //public delegate void glUniform3f(int location, float v0, float v1, float v2);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="v0"></param>
//        ///// <param name="v1"></param>
//        ///// <param name="v2"></param>
//        ///// <param name="v3"></param>
//        //public delegate void glUniform4f(int location, float v0, float v1, float v2, float v3);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="v0"></param>
//        //public delegate void glUniform1i(int location, int v0);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="v0"></param>
//        ///// <param name="v1"></param>
//        //public delegate void glUniform2i(int location, int v0, int v1);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="v0"></param>
//        ///// <param name="v1"></param>
//        ///// <param name="v2"></param>
//        //public delegate void glUniform3i(int location, int v0, int v1, int v2);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="v0"></param>
//        ///// <param name="v1"></param>
//        ///// <param name="v2"></param>
//        ///// <param name="v3"></param>
//        //public delegate void glUniform4i(int location, int v0, int v1, int v2, int v3);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniform1fv(int location, int count, float[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniform2fv(int location, int count, float[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniform3fv(int location, int count, float[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniform4fv(int location, int count, float[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniform1iv(int location, int count, int[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniform2iv(int location, int count, int[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniform3iv(int location, int count, int[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniform4iv(int location, int count, int[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="transpose"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniformMatrix2fv(int location, int count, bool transpose, float[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="transpose"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniformMatrix3fv(int location, int count, bool transpose, float[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="location"></param>
//        ///// <param name="count"></param>
//        ///// <param name="transpose"></param>
//        ///// <param name="value"></param>
//        //public delegate void glUniformMatrix4fv(int location, int count, bool transpose, float[] value);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="obj"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetObjectParameterfv(uint obj, uint pname, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="obj"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetObjectParameteriv(uint obj, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="obj"></param>
//        ///// <param name="maxLength"></param>
//        ///// <param name="length"></param>
//        ///// <param name="infoLog"></param>
//        //public delegate void glGetInfoLog(uint obj, int maxLength, ref int length, string infoLog);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="containerObj"></param>
//        ///// <param name="maxCount"></param>
//        ///// <param name="count"></param>
//        ///// <param name="obj"></param>
//        //public delegate void glGetAttachedObjects(uint containerObj, int maxCount, ref int count, ref uint obj);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        ///// <param name="name"></param>
//        ///// <returns></returns>
//        //public delegate int glGetUniformLocation(uint programObj, string name);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        ///// <param name="index"></param>
//        ///// <param name="maxLength"></param>
//        ///// <param name="length"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="name"></param>
//        //public delegate void glGetActiveUniform(uint programObj, uint index, int maxLength, ref int length, ref int size, ref uint type, string name);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        ///// <param name="location"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetUniformfv(uint programObj, int location, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        ///// <param name="location"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetUniformiv(uint programObj, int location, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="obj"></param>
//        ///// <param name="maxLength"></param>
//        ///// <param name="length"></param>
//        ///// <param name="source"></param>
//        //public delegate void glGetShaderSource(uint obj, int maxLength, ref int length, string source);

//        //#endregion

//        //#region GL_vertex_program

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        //public delegate void glVertexAttrib1d(uint index, double x);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib1dv(uint index, double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        //public delegate void glVertexAttrib1f(uint index, float x);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib1fv(uint index, float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        //public delegate void glVertexAttrib1s(uint index, short x);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib1sv(uint index, short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        //public delegate void glVertexAttrib2d(uint index, double x, double y);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib2dv(uint index, double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        //public delegate void glVertexAttrib2f(uint index, float x, float y);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib2fv(uint index, float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        //public delegate void glVertexAttrib2s(uint index, short x, short y);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib2sv(uint index, short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        //public delegate void glVertexAttrib3d(uint index, double x, double y, double z);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib3dv(uint index, double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        //public delegate void glVertexAttrib3f(uint index, float x, float y, float z);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib3fv(uint index, float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        //public delegate void glVertexAttrib3s(uint index, short x, short y, short z);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib3sv(uint index, short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4Nbv(uint index, sbyte[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4Niv(uint index, int[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4Nsv(uint index, short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        ///// <param name="w"></param>
//        //public delegate void glVertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4Nubv(uint index, byte[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4Nuiv(uint index, uint[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4Nusv(uint index, ushort[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4bv(uint index, sbyte[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        ///// <param name="w"></param>
//        //public delegate void glVertexAttrib4d(uint index, double x, double y, double z, double w);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4dv(uint index, double[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        ///// <param name="w"></param>
//        //public delegate void glVertexAttrib4f(uint index, float x, float y, float z, float w);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4fv(uint index, float[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4iv(uint index, int[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        ///// <param name="w"></param>
//        //public delegate void glVertexAttrib4s(uint index, short x, short y, short z, short w);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4sv(uint index, short[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4ubv(uint index, byte[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4uiv(uint index, uint[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="v"></param>
//        //public delegate void glVertexAttrib4usv(uint index, ushort[] v);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="normalized"></param>
//        ///// <param name="stride"></param>
//        ///// <param name="pointer"></param>
//        //public delegate void glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        //public delegate void glEnableVertexAttribArray(uint index);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        //public delegate void glDisableVertexAttribArray(uint index);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="format"></param>
//        ///// <param name="len"></param>
//        ///// <param name="str"></param>
//        //public delegate void glProgramString(uint target, uint format, int len, IntPtr str);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="program"></param>
//        //public delegate void glBindProgram(uint target, uint program);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="n"></param>
//        ///// <param name="programs"></param>
//        //public delegate void glDeletePrograms(int n, uint[] programs);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="n"></param>
//        ///// <param name="programs"></param>
//        //public delegate void glGenPrograms(int n, uint[] programs);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        ///// <param name="w"></param>
//        //public delegate void glProgramEnvParameter4d(uint target, uint index, double x, double y, double z, double w);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glProgramEnvParameter4dv(uint target, uint index, double[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        ///// <param name="w"></param>
//        //public delegate void glProgramEnvParameter4f(uint target, uint index, float x, float y, float z, float w);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glProgramEnvParameter4fv(uint target, uint index, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        ///// <param name="w"></param>
//        //public delegate void glProgramLocalParameter4d(uint target, uint index, double x, double y, double z, double w);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glProgramLocalParameter4dv(uint target, uint index, double[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="x"></param>
//        ///// <param name="y"></param>
//        ///// <param name="z"></param>
//        ///// <param name="w"></param>
//        //public delegate void glProgramLocalParameter4f(uint target, uint index, float x, float y, float z, float w);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glProgramLocalParameter4fv(uint target, uint index, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetProgramEnvParameterdv(uint target, uint index, double[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetProgramEnvParameterfv(uint target, uint index, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetProgramLocalParameterdv(uint target, uint index, double[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetProgramLocalParameterfv(uint target, uint index, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetProgramiv(uint target, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="str"></param>
//        //public delegate void glGetProgramString(uint target, uint pname, IntPtr str);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetVertexAttribdv(uint index, uint pname, double[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetVertexAttribfv(uint index, uint pname, float[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="parameters"></param>
//        //public delegate void glGetVertexAttribiv(uint index, uint pname, int[] parameters);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="index"></param>
//        ///// <param name="pname"></param>
//        ///// <param name="pointer"></param>
//        //public delegate void glGetVertexAttribPointerv(uint index, uint pname, IntPtr pointer);

//        //#endregion

//        //#region GL_vertex_shader

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        ///// <param name="index"></param>
//        ///// <param name="name"></param>
//        //public delegate void glBindAttribLocation(uint programObj, uint index, string name);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        ///// <param name="index"></param>
//        ///// <param name="maxLength"></param>
//        ///// <param name="length"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="name"></param>
//        //public delegate void glGetActiveAttrib(uint programObj, uint index, int maxLength, int[] length, int[] size, uint[] type, string name);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="programObj"></param>
//        ///// <param name="name"></param>
//        ///// <returns></returns>
//        //public delegate uint glGetAttribLocation(uint programObj, string name);

//        //#endregion

//        //#region GL_draw_buffers

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="n"></param>
//        ///// <param name="bufs"></param>
//        //public delegate void glDrawBuffers(int n, uint[] bufs);

//        //#endregion

//        //#region GL_texture_non_power_of_two

//        ////  No methods or constants

//        //#endregion

//        //#region GL_EXT_blend_equation_separate

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="modeRGB"></param>
//        ///// <param name="modeAlpha"></param>
//        //public delegate void glBlendEquationSeparate(uint modeRGB, uint modeAlpha);


//        //#endregion

//        //#region GL_EXT_stencil_two_side

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="face"></param>
//        //public delegate void glActiveStencilFace(uint face);

//        //#endregion

//        //#region GL_EXT_draw_instanced

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="mode"></param>
//        ///// <param name="start"></param>
//        ///// <param name="count"></param>
//        ///// <param name="primcount"></param>
//        //public delegate void glDrawArraysInstanced(uint mode, int start, int count, int primcount);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="mode"></param>
//        ///// <param name="count"></param>
//        ///// <param name="type"></param>
//        ///// <param name="indices"></param>
//        ///// <param name="primcount"></param>
//        //public delegate void glDrawElementsInstanced(uint mode, int count, uint type, IntPtr indices, int primcount);

//        //#endregion

//        #region GL_vertex_array_object

//        //  Delegates
//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="array"></param>
//        internal delegate void glBindVertexArray(uint array);

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="n"></param>
//        /// <param name="arrays"></param>
//        internal delegate void glDeleteVertexArrays(int n, uint[] arrays);

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="n"></param>
//        /// <param name="arrays"></param>
//        internal delegate void glGenVertexArrays(int n, uint[] arrays);

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="array"></param>
//        /// <returns></returns>
//        public delegate bool glIsVertexArray(uint array);
//        #endregion GL_vertex_array_object


//        //#region GGL_EXT_transform_feedback

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="primitiveMode"></param>
//        //public delegate void glBeginTransformFeedback(uint primitiveMode);
//        ///// <summary>
//        /////
//        ///// </summary>
//        //public delegate void glEndTransformFeedback();
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="buffer"></param>
//        ///// <param name="offset"></param>
//        ///// <param name="size"></param>
//        //public delegate void glBindBufferRange(uint target, uint index, uint buffer, int offset, int size);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="buffer"></param>
//        ///// <param name="offset"></param>
//        //public delegate void glBindBufferOffset(uint target, uint index, uint buffer, int offset);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="target"></param>
//        ///// <param name="index"></param>
//        ///// <param name="buffer"></param>
//        //public delegate void glBindBufferBase(uint target, uint index, uint buffer);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="program"></param>
//        ///// <param name="count"></param>
//        ///// <param name="varyings"></param>
//        ///// <param name="bufferMode"></param>
//        //public delegate void glTransformFeedbackVaryings(uint program, int count, string[] varyings, uint bufferMode);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="program"></param>
//        ///// <param name="index"></param>
//        ///// <param name="bufSize"></param>
//        ///// <param name="length"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="name"></param>
//        //public delegate void glGetTransformFeedbackVarying(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, string name);

//        ////  Constants

//        //#endregion

//        //#region WGL_extensions_string

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="hdc"></param>
//        ///// <returns></returns>
//        //public delegate string wglGetExtensionsString(IntPtr hdc);

//        //#endregion

//        #region WGL_create_context

//        //  Delegates
//        /// <summary>
//        /// Creates a render context with the specified attributes.
//        /// </summary>
//        /// <param name="hDC">device context handle.</param>
//        /// <param name="hShareContext">
//        /// If is not null, then all shareable data (excluding
//        /// OpenGL texture objects named 0) will be shared by <paramref name="hShareContext"/>,
//        /// all other contexts <paramref name="hShareContext"/> already shares with, and the
//        /// newly created context. An arbitrary number of contexts can share
//        /// data in this fashion.</param>
//        /// <param name="attribList">
//        /// specifies a list of attributes for the context. The
//        /// list consists of a sequence of &lt;name, value&gt; pairs terminated by the
//        /// value 0. If an attribute is not specified in <paramref name="attribList"/>, then the
//        /// default value specified below is used instead. If an attribute is
//        /// specified more than once, then the last value specified is used.
//        /// </param>
//        /// <returns></returns>
//        public delegate IntPtr wglCreateContextAttribs(IntPtr hDC, IntPtr hShareContext, int[] attribList);
//        #endregion WGL_create_context


//        #region GL_clear_buffer_object

//        //  Delegates
//        /// <summary>
//        /// Fill a buffer object's data store with a fixed value
//        /// </summary>
//        /// <param name="target">Specifies the target buffer object. The symbolic constant must be GL_ARRAY_BUFFER​, GL_ATOMIC_COUNTER_BUFFER​, GL_COPY_READ_BUFFER​, GL_COPY_WRITE_BUFFER​, GL_DRAW_INDIRECT_BUFFER​, GL_DISPATCH_INDIRECT_BUFFER​, GL_ELEMENT_ARRAY_BUFFER​, GL_PIXEL_PACK_BUFFER​, GL_PIXEL_UNPACK_BUFFER​, GL_QUERY_BUFFER​, GL_SHADER_STORAGE_BUFFER​, GL_TEXTURE_BUFFER​, GL_TRANSFORM_FEEDBACK_BUFFER​, or GL_UNIFORM_BUFFER​.</param>
//        /// <param name="internalformat">The sized internal format with which the data will be stored in the buffer object.</param>
//        /// <param name="format">Specifies the format of the pixel data. For transfers of depth, stencil, or depth/stencil data, you must use GL_DEPTH_COMPONENT​, GL_STENCIL_INDEX​, or GL_DEPTH_STENCIL​, where appropriate. For transfers of normalized integer or floating-point color image data, you must use one of the following: GL_RED​, GL_GREEN​, GL_BLUE​, GL_RG​, GL_RGB​, GL_BGR​, GL_RGBA​, and GL_BGRA​. For transfers of non-normalized integer data, you must use one of the following: GL_RED_INTEGER​, GL_GREEN_INTEGER​, GL_BLUE_INTEGER​, GL_RG_INTEGER​, GL_RGB_INTEGER​, GL_BGR_INTEGER​, GL_RGBA_INTEGER​, and GL_BGRA_INTEGER​.</param>
//        /// <param name="type">Specifies the data type of the pixel data. The following symbolic values are accepted: GL_UNSIGNED_BYTE​, GL_BYTE​, GL_UNSIGNED_SHORT​, GL_SHORT​, GL_UNSIGNED_INT​, GL_INT​, GL_FLOAT​, GL_UNSIGNED_BYTE_3_3_2​, GL_UNSIGNED_BYTE_2_3_3_REV​, GL_UNSIGNED_SHORT_5_6_5​, GL_UNSIGNED_SHORT_5_6_5_REV​, GL_UNSIGNED_SHORT_4_4_4_4​, GL_UNSIGNED_SHORT_4_4_4_4_REV​, GL_UNSIGNED_SHORT_5_5_5_1​, GL_UNSIGNED_SHORT_1_5_5_5_REV​, GL_UNSIGNED_INT_8_8_8_8​, GL_UNSIGNED_INT_8_8_8_8_REV​, GL_UNSIGNED_INT_10_10_10_2​, and GL_UNSIGNED_INT_2_10_10_10_REV​.</param>
//        /// <param name="data">Specifies a pointer to a single pixel of data to upload. This parameter may not be NULL.</param>
//        public delegate void glClearBufferData(uint target, uint internalformat, uint format, uint type, IntPtr data);
//        /// <summary>
//        /// Fill all or part of buffer object's data store with a fixed value
//        /// </summary>
//        /// <param name="target">Specifies the target buffer object. The symbolic constant must be GL_ARRAY_BUFFER​, GL_ATOMIC_COUNTER_BUFFER​, GL_COPY_READ_BUFFER​, GL_COPY_WRITE_BUFFER​, GL_DRAW_INDIRECT_BUFFER​, GL_DISPATCH_INDIRECT_BUFFER​, GL_ELEMENT_ARRAY_BUFFER​, GL_PIXEL_PACK_BUFFER​, GL_PIXEL_UNPACK_BUFFER​, GL_QUERY_BUFFER​, GL_SHADER_STORAGE_BUFFER​, GL_TEXTURE_BUFFER​, GL_TRANSFORM_FEEDBACK_BUFFER​, or GL_UNIFORM_BUFFER​.</param>
//        /// <param name="internalformat">The sized internal format with which the data will be stored in the buffer object.</param>
//        /// <param name="offset">The offset, in basic machine units into the buffer object's data store at which to start filling.</param>
//        /// <param name="size">The size, in basic machine units of the range of the data store to fill.</param>
//        /// <param name="format">Specifies the format of the pixel data. For transfers of depth, stencil, or depth/stencil data, you must use GL_DEPTH_COMPONENT​, GL_STENCIL_INDEX​, or GL_DEPTH_STENCIL​, where appropriate. For transfers of normalized integer or floating-point color image data, you must use one of the following: GL_RED​, GL_GREEN​, GL_BLUE​, GL_RG​, GL_RGB​, GL_BGR​, GL_RGBA​, and GL_BGRA​. For transfers of non-normalized integer data, you must use one of the following: GL_RED_INTEGER​, GL_GREEN_INTEGER​, GL_BLUE_INTEGER​, GL_RG_INTEGER​, GL_RGB_INTEGER​, GL_BGR_INTEGER​, GL_RGBA_INTEGER​, and GL_BGRA_INTEGER​.</param>
//        /// <param name="type">Specifies the data type of the pixel data. The following symbolic values are accepted: GL_UNSIGNED_BYTE​, GL_BYTE​, GL_UNSIGNED_SHORT​, GL_SHORT​, GL_UNSIGNED_INT​, GL_INT​, GL_FLOAT​, GL_UNSIGNED_BYTE_3_3_2​, GL_UNSIGNED_BYTE_2_3_3_REV​, GL_UNSIGNED_SHORT_5_6_5​, GL_UNSIGNED_SHORT_5_6_5_REV​, GL_UNSIGNED_SHORT_4_4_4_4​, GL_UNSIGNED_SHORT_4_4_4_4_REV​, GL_UNSIGNED_SHORT_5_5_5_1​, GL_UNSIGNED_SHORT_1_5_5_5_REV​, GL_UNSIGNED_INT_8_8_8_8​, GL_UNSIGNED_INT_8_8_8_8_REV​, GL_UNSIGNED_INT_10_10_10_2​, and GL_UNSIGNED_INT_2_10_10_10_REV​.</param>
//        /// <param name="data">Specifies a pointer to a single pixel of data to upload. This parameter may not be NULL.</param>
//        public delegate void glClearBufferSubData(uint target, uint internalformat, IntPtr offset, uint size, uint format, uint type, IntPtr data);
//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="buffer"></param>
//        /// <param name="internalformat"></param>
//        /// <param name="format"></param>
//        /// <param name="type"></param>
//        /// <param name="data"></param>
//        public delegate void glClearNamedBufferData(uint buffer, uint internalformat, uint format, uint type, IntPtr data);
//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="buffer"></param>
//        /// <param name="internalformat"></param>
//        /// <param name="offset"></param>
//        /// <param name="size"></param>
//        /// <param name="format"></param>
//        /// <param name="type"></param>
//        /// <param name="data"></param>
//        public delegate void glClearNamedBufferSubData(uint buffer, uint internalformat, IntPtr offset, uint size, uint format, uint type, IntPtr data);

//        #endregion

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="readTarget"></param>
//        /// <param name="writeTarget"></param>
//        /// <param name="readOffset"></param>
//        /// <param name="writeOffset"></param>
//        /// <param name="size"></param>
//        public delegate void glCopyBufferSubData(uint readTarget, uint writeTarget, IntPtr readOffset, IntPtr writeOffset, IntPtr size);

//        #region GL_compute_shader

//        //  Delegates
//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="num_groups_x"></param>
//        /// <param name="num_groups_y"></param>
//        /// <param name="num_groups_z"></param>
//        public delegate void glDispatchCompute(uint num_groups_x, uint num_groups_y, uint num_groups_z);

//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="indirect"></param>
//        //public delegate void glDispatchComputeIndirect(IntPtr indirect);
//        #endregion GL_compute_shader

//        //#region GL_copy_image

//        ////  Delegates
//        ///// <summary>
//        ///// Perform a raw data copy between two images
//        ///// </summary>
//        ///// <param name="srcName">The name of a texture or renderbuffer object from which to copy.</param>
//        ///// <param name="srcTarget">The target representing the namespace of the source name srcName​.</param>
//        ///// <param name="srcLevel">The mipmap level to read from the source.</param>
//        ///// <param name="srcX">The X coordinate of the left edge of the souce region to copy.</param>
//        ///// <param name="srcY">The Y coordinate of the top edge of the souce region to copy.</param>
//        ///// <param name="srcZ">The Z coordinate of the near edge of the souce region to copy.</param>
//        ///// <param name="dstName">The name of a texture or renderbuffer object to which to copy.</param>
//        ///// <param name="dstTarget">The target representing the namespace of the destination name dstName​.</param>
//        ///// <param name="dstLevel">The desination mipmap level.</param>
//        ///// <param name="dstX">The X coordinate of the left edge of the destination region.</param>
//        ///// <param name="dstY">The Y coordinate of the top edge of the destination region.</param>
//        ///// <param name="dstZ">The Z coordinate of the near edge of the destination region.</param>
//        ///// <param name="srcWidth">The width of the region to be copied.</param>
//        ///// <param name="srcHeight">The height of the region to be copied.</param>
//        ///// <param name="srcDepth">The depth of the region to be copied.</param>
//        //public delegate void glCopyImageSubData(uint srcName, uint srcTarget, int srcLevel, int srcX, int srcY, int srcZ, uint dstName,
//        //    uint dstTarget, int dstLevel, int dstX, int dstY, int dstZ, uint srcWidth, uint srcHeight, uint srcDepth);

//        //#endregion

//        //#region GL_ES3_compatibility
//        //#endregion

//        //#region GL_internalformat_query2

//        ////  Delegates
//        ///// <summary>
//        ///// Retrieve information about implementation-dependent support for internal formats
//        ///// </summary>
//        ///// <param name="target">Indicates the usage of the internal format. target​ must be GL_TEXTURE_1D​, GL_TEXTURE_1D_ARRAY​, GL_TEXTURE_2D​, GL_TEXTURE_2D_ARRAY​, GL_TEXTURE_3D​, GL_TEXTURE_CUBE_MAP​, GL_TEXTURE_CUBE_MAP_ARRAY​, GL_TEXTURE_RECTANGLE​, GL_TEXTURE_BUFFER​, GL_RENDERBUFFER​, GL_TEXTURE_2D_MULTISAMPLE​ or GL_TEXTURE_2D_MULTISAMPLE_ARRAY​.</param>
//        ///// <param name="internalformat">Specifies the internal format about which to retrieve information.</param>
//        ///// <param name="pname">Specifies the type of information to query.</param>
//        ///// <param name="bufSize">Specifies the maximum number of basic machine units that may be written to params​ by the function.</param>
//        ///// <param name="parameters">Specifies the address of a variable into which to write the retrieved information.</param>
//        //public delegate void glGetInternalformativ(uint target, uint internalformat, uint pname, uint bufSize, int[] parameters);
//        ///// <summary>
//        ///// Retrieve information about implementation-dependent support for internal formats
//        ///// </summary>
//        ///// <param name="target">Indicates the usage of the internal format. target​ must be GL_TEXTURE_1D​, GL_TEXTURE_1D_ARRAY​, GL_TEXTURE_2D​, GL_TEXTURE_2D_ARRAY​, GL_TEXTURE_3D​, GL_TEXTURE_CUBE_MAP​, GL_TEXTURE_CUBE_MAP_ARRAY​, GL_TEXTURE_RECTANGLE​, GL_TEXTURE_BUFFER​, GL_RENDERBUFFER​, GL_TEXTURE_2D_MULTISAMPLE​ or GL_TEXTURE_2D_MULTISAMPLE_ARRAY​.</param>
//        ///// <param name="internalformat">Specifies the internal format about which to retrieve information.</param>
//        ///// <param name="pname">Specifies the type of information to query.</param>
//        ///// <param name="bufSize">Specifies the maximum number of basic machine units that may be written to params​ by the function.</param>
//        ///// <param name="parameters">Specifies the address of a variable into which to write the retrieved information.</param>
//        //public delegate void glGetInternalformati64v(uint target, uint internalformat, uint pname, uint bufSize, Int64[] parameters);
//        //#endregion

//        //#region GL_invalidate_subdata

//        ////  Delegates
//        ///// <summary>
//        ///// Invalidate a region of a texture image
//        ///// </summary>
//        ///// <param name="texture">The name of a texture object a subregion of which to invalidate.</param>
//        ///// <param name="level">The level of detail of the texture object within which the region resides.</param>
//        ///// <param name="xoffset">The X offset of the region to be invalidated.</param>
//        ///// <param name="yoffset">The Y offset of the region to be invalidated.</param>
//        ///// <param name="zoffset">The Z offset of the region to be invalidated.</param>
//        ///// <param name="width">The width of the region to be invalidated.</param>
//        ///// <param name="height">The height of the region to be invalidated.</param>
//        ///// <param name="depth">The depth of the region to be invalidated.</param>
//        //public delegate void glInvalidateTexSubImage(uint texture, int level, int xoffset,
//        //    int yoffset, int zoffset, uint width, uint height, uint depth);
//        ///// <summary>
//        ///// Invalidate the entirety a texture image
//        ///// </summary>
//        ///// <param name="texture">The name of a texture object to invalidate.</param>
//        ///// <param name="level">The level of detail of the texture object to invalidate.</param>
//        //public delegate void glInvalidateTexImage(uint texture, int level);
//        ///// <summary>
//        ///// Invalidate a region of a buffer object's data store
//        ///// </summary>
//        ///// <param name="buffer">The name of a buffer object, a subrange of whose data store to invalidate.</param>
//        ///// <param name="offset">The offset within the buffer's data store of the start of the range to be invalidated.</param>
//        ///// <param name="length">The length of the range within the buffer's data store to be invalidated.</param>
//        //public delegate void glInvalidateBufferSubData(uint buffer, IntPtr offset, IntPtr length);
//        ///// <summary>
//        ///// Invalidate the content of a buffer object's data store
//        ///// </summary>
//        ///// <param name="buffer">The name of a buffer object whose data store to invalidate.</param>
//        //public delegate void glInvalidateBufferData(uint buffer);
//        ///// <summary>
//        ///// Invalidate the content some or all of a framebuffer object's attachments
//        ///// </summary>
//        ///// <param name="target">The target to which the framebuffer is attached. target​ must be GL_FRAMEBUFFER​, GL_DRAW_FRAMEBUFFER​, or GL_READ_FRAMEBUFFER​.</param>
//        ///// <param name="numAttachments">The number of entries in the attachments​ array.</param>
//        ///// <param name="attachments">The address of an array identifying the attachments to be invalidated.</param>
//        //public delegate void glInvalidateFramebuffer(uint target, uint numAttachments, uint[] attachments);
//        ///// <summary>
//        ///// Invalidate the content of a region of some or all of a framebuffer object's attachments
//        ///// </summary>
//        ///// <param name="target">The target to which the framebuffer is attached. target​ must be GL_FRAMEBUFFER​, GL_DRAW_FRAMEBUFFER​, or GL_READ_FRAMEBUFFER​.</param>
//        ///// <param name="numAttachments">The number of entries in the attachments​ array.</param>
//        ///// <param name="attachments">The address of an array identifying the attachments to be invalidated.</param>
//        ///// <param name="x">The X offset of the region to be invalidated.</param>
//        ///// <param name="y">The Y offset of the region to be invalidated.</param>
//        ///// <param name="width">The width of the region to be invalidated.</param>
//        ///// <param name="height">The height of the region to be invalidated.</param>
//        //public delegate void glInvalidateSubFramebuffer(uint target, uint numAttachments, uint[] attachments,
//        //    int x, int y, uint width, uint height);

//        //#endregion

//        //#region ARB_multi_draw_indirect

//        ///// <summary>
//        ///// Render multiple sets of primitives from array data, taking parameters from memory
//        ///// </summary>
//        ///// <param name="mode">Specifies what kind of primitives to render. Symbolic constants GL_POINTS​, GL_LINE_STRIP​, GL_LINE_LOOP​, GL_LINES​, GL_LINE_STRIP_ADJACENCY​, GL_LINES_ADJACENCY​, GL_TRIANGLE_STRIP​, GL_TRIANGLE_FAN​, GL_TRIANGLES​, GL_TRIANGLE_STRIP_ADJACENCY​, GL_TRIANGLES_ADJACENCY​, and GL_PATCHES​ are accepted.</param>
//        ///// <param name="indirect">Specifies the address of an array of structures containing the draw parameters.</param>
//        ///// <param name="primcount">Specifies the the number of elements in the array of draw parameter structures.</param>
//        ///// <param name="stride">Specifies the distance in basic machine units between elements of the draw parameter array.</param>
//        //public delegate void glMultiDrawArraysIndirect(uint mode, IntPtr indirect, uint primcount, uint stride);
//        ///// <summary>
//        ///// Render indexed primitives from array data, taking parameters from memory
//        ///// </summary>
//        ///// <param name="mode">Specifies what kind of primitives to render. Symbolic constants GL_POINTS​, GL_LINE_STRIP​, GL_LINE_LOOP​, GL_LINES​, GL_LINE_STRIP_ADJACENCY​, GL_LINES_ADJACENCY​, GL_TRIANGLE_STRIP​, GL_TRIANGLE_FAN​, GL_TRIANGLES​, GL_TRIANGLE_STRIP_ADJACENCY​, GL_TRIANGLES_ADJACENCY​, and GL_PATCHES​ are accepted.</param>
//        ///// <param name="type">Specifies the type of data in the buffer bound to the GL_ELEMENT_ARRAY_BUFFER​ binding.</param>
//        ///// <param name="indirect">Specifies a byte offset (cast to a pointer type) into the buffer bound to GL_DRAW_INDIRECT_BUFFER​, which designates the starting point of the structure containing the draw parameters.</param>
//        ///// <param name="primcount">Specifies the number of elements in the array addressed by indirect​.</param>
//        ///// <param name="stride">Specifies the distance in basic machine units between elements of the draw parameter array.</param>
//        //public delegate void glMultiDrawElementsIndirect(uint mode, uint type, IntPtr indirect, uint primcount, uint stride);

//        //#endregion

//        #region GL_program_interface_query

//        /// <summary>
//        /// Query a property of an interface in a program
//        /// </summary>
//        /// <param name="program">The name of a program object whose interface to query.</param>
//        /// <param name="programInterface">A token identifying the interface within program​ to query.</param>
//        /// <param name="pname">The name of the parameter within programInterface​ to query.</param>
//        /// <param name="parameters">The address of a variable to retrieve the value of pname​ for the program interface..</param>
//        public delegate void glGetProgramInterfaceiv(uint program, uint programInterface, uint pname, int[] parameters);

//        /// <summary>
//        /// Query the index of a named resource within a program
//        /// </summary>
//        /// <param name="program">The name of a program object whose resources to query.</param>
//        /// <param name="programInterface">A token identifying the interface within program​ containing the resource named name​.</param>
//        /// <param name="name">The name of the resource to query the index of.</param>
//        internal delegate uint glGetProgramResourceIndex(uint program, uint programInterface, string name);

//        /// <summary>
//        /// Query the name of an indexed resource within a program
//        /// </summary>
//        /// <param name="program">The name of a program object whose resources to query.</param>
//        /// <param name="programInterface">A token identifying the interface within program​ containing the indexed resource.</param>
//        /// <param name="index">The index of the resource within programInterface​ of program​.</param>
//        /// <param name="bufSize">The size of the character array whose address is given by name​.</param>
//        /// <param name="length">The address of a variable which will receive the length of the resource name.</param>
//        /// <param name="name">The address of a character array into which will be written the name of the resource.</param>
//        public delegate void glGetProgramResourceName(uint program, uint programInterface, uint index, uint bufSize, uint[] length, string[] name);

//        /// <summary>
//        /// Retrieve values for multiple properties of a single active resource within a program object
//        /// </summary>
//        /// <param name="program">The name of a program object whose resources to query.</param>
//        /// <param name="programInterface">A token identifying the interface within program​ containing the resource named name​.</param>
//        /// <param name="index">The index within the programInterface​ to query information about.</param>
//        /// <param name="propCount">The number of properties being queried.</param>
//        /// <param name="props">An array of properties of length propCount​ to query.</param>
//        /// <param name="bufSize">The number of GLint values in the params​ array.</param>
//        /// <param name="length">If not NULL, then this value will be filled in with the number of actual parameters written to params​.</param>
//        /// <param name="parameters">The output array of parameters to write.</param>
//        public delegate void glGetProgramResourceiv(uint program, uint programInterface, uint index, uint propCount, uint[] props, uint bufSize, uint[] length, int[] parameters);

//        /// <summary>
//        /// Query the location of a named resource within a program.
//        /// </summary>
//        /// <param name="program">The name of a program object whose resources to query.</param>
//        /// <param name="programInterface">A token identifying the interface within program​ containing the resource named name​.</param>
//        /// <param name="name">The name of the resource to query the location of.</param>
//        public delegate int glGetProgramResourceLocation(uint program, uint programInterface, string name);

//        /// <summary>
//        /// Query the fragment color index of a named variable within a program.
//        /// </summary>
//        /// <param name="program">The name of a program object whose resources to query.</param>
//        /// <param name="programInterface">A token identifying the interface within program​ containing the resource named name​.</param>
//        /// <param name="name">The name of the resource to query the location of.</param>
//        public delegate int glGetProgramResourceLocationIndex(uint program, uint programInterface, string name);

//        #endregion GL_program_interface_query

//        #region GL_shader_storage_buffer_object

//        /// <summary>
//        /// Change an active shader storage block binding.
//        /// </summary>
//        /// <param name="program">The name of the program containing the block whose binding to change.</param>
//        /// <param name="storageBlockIndex">The index storage block within the program.</param>
//        /// <param name="storageBlockBinding">The index storage block binding to associate with the specified storage block.</param>
//        internal delegate void glShaderStorageBlockBinding(uint program, uint storageBlockIndex, uint storageBlockBinding);
//        #endregion GL_shader_storage_buffer_object

//        //#region GL_stencil_texturing

//        ////  Constants
//        ///// <summary>
//        /////
//        ///// </summary>
//        //public const uint GL_DEPTH_STENCIL_TEXTURE_MODE = 0x90EA;

//        //#endregion

//        //#region GL_texture_buffer_range

//        ///// <summary>
//        ///// Bind a range of a buffer's data store to a buffer texture
//        ///// </summary>
//        ///// <param name="target">Specifies the target of the operation and must be GL_TEXTURE_BUFFER​.</param>
//        ///// <param name="internalformat">Specifies the internal format of the data in the store belonging to buffer​.</param>
//        ///// <param name="buffer">Specifies the name of the buffer object whose storage to attach to the active buffer texture.</param>
//        ///// <param name="offset">Specifies the offset of the start of the range of the buffer's data store to attach.</param>
//        ///// <param name="size">Specifies the size of the range of the buffer's data store to attach.</param>
//        //public delegate void glTexBufferRange(uint target, uint internalformat, uint buffer, IntPtr offset, IntPtr size);
//        ///// <summary>
//        ///// Bind a range of a buffer's data store to a buffer texture
//        ///// </summary>
//        ///// <param name="texture">The texture.</param>
//        ///// <param name="target">Specifies the target of the operation and must be GL_TEXTURE_BUFFER​.</param>
//        ///// <param name="internalformat">Specifies the internal format of the data in the store belonging to buffer​.</param>
//        ///// <param name="buffer">Specifies the name of the buffer object whose storage to attach to the active buffer texture.</param>
//        ///// <param name="offset">Specifies the offset of the start of the range of the buffer's data store to attach.</param>
//        ///// <param name="size">Specifies the size of the range of the buffer's data store to attach.</param>
//        //public delegate void glTextureBufferRange(uint texture, uint target, uint internalformat, uint buffer, IntPtr offset, IntPtr size);

//        //#endregion

//        //#region GL_texture_storage_multisample

//        ////  Delegates
//        ///// <summary>
//        ///// Specify storage for a two-dimensional multisample texture.
//        ///// </summary>
//        ///// <param name="target">Specify the target of the operation. target​ must be GL_TEXTURE_2D_MULTISAMPLE​ or GL_PROXY_TEXTURE_2D_MULTISAMPLE​.</param>
//        ///// <param name="samples">Specify the number of samples in the texture.</param>
//        ///// <param name="internalformat">Specifies the sized internal format to be used to store texture image data.</param>
//        ///// <param name="width">Specifies the width of the texture, in texels.</param>
//        ///// <param name="height">Specifies the height of the texture, in texels.</param>
//        ///// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
//        //public delegate void glTexStorage2DMultisample(uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
//        ///// <summary>
//        ///// Specify storage for a three-dimensional multisample array texture
//        ///// </summary>
//        ///// <param name="target">Specify the target of the operation. target​ must be GL_TEXTURE_3D_MULTISAMPLE_ARRAY​ or GL_PROXY_TEXTURE_3D_MULTISAMPLE_ARRAY​.</param>
//        ///// <param name="samples">Specify the number of samples in the texture.</param>
//        ///// <param name="internalformat">Specifies the sized internal format to be used to store texture image data.</param>
//        ///// <param name="width">Specifies the width of the texture, in texels.</param>
//        ///// <param name="height">Specifies the height of the texture, in texels.</param>
//        ///// <param name="depth">Specifies the depth of the texture, in layers.</param>
//        ///// <param name="fixedsamplelocations">Specifies the depth of the texture, in layers.</param>
//        //public delegate void glTexStorage3DMultisample(uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);
//        ///// <summary>
//        ///// Specify storage for a two-dimensional multisample texture.
//        ///// </summary>
//        ///// <param name="texture">The texture.</param>
//        ///// <param name="target">Specify the target of the operation. target​ must be GL_TEXTURE_2D_MULTISAMPLE​ or GL_PROXY_TEXTURE_2D_MULTISAMPLE​.</param>
//        ///// <param name="samples">Specify the number of samples in the texture.</param>
//        ///// <param name="internalformat">Specifies the sized internal format to be used to store texture image data.</param>
//        ///// <param name="width">Specifies the width of the texture, in texels.</param>
//        ///// <param name="height">Specifies the height of the texture, in texels.</param>
//        ///// <param name="fixedsamplelocations">Specifies whether the image will use identical sample locations and the same number of samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
//        //public delegate void glTexStorage2DMultisample(uint texture, uint target, uint samples, uint internalformat, uint width, uint height, bool fixedsamplelocations);
//        ///// <summary>
//        ///// Specify storage for a three-dimensional multisample array texture
//        ///// </summary>
//        ///// <param name="texture">The texture.</param>
//        ///// <param name="target">Specify the target of the operation. target​ must be GL_TEXTURE_3D_MULTISAMPLE_ARRAY​ or GL_PROXY_TEXTURE_3D_MULTISAMPLE_ARRAY​.</param>
//        ///// <param name="samples">Specify the number of samples in the texture.</param>
//        ///// <param name="internalformat">Specifies the sized internal format to be used to store texture image data.</param>
//        ///// <param name="width">Specifies the width of the texture, in texels.</param>
//        ///// <param name="height">Specifies the height of the texture, in texels.</param>
//        ///// <param name="depth">Specifies the depth of the texture, in layers.</param>
//        ///// <param name="fixedsamplelocations">Specifies the depth of the texture, in layers.</param>
//        //public delegate void glTexStorage3DMultisample(uint texture, uint target, uint samples, uint internalformat, uint width, uint height, uint depth, bool fixedsamplelocations);

//        //#endregion

//        //#region GL_texture_view

//        ////  Delegates
//        ///// <summary>
//        ///// Initialize a texture as a data alias of another texture's data store.
//        ///// </summary>
//        ///// <param name="texture">Specifies the texture object to be initialized as a view.</param>
//        ///// <param name="target">Specifies the target to be used for the newly initialized texture.</param>
//        ///// <param name="origtexture">Specifies the name of a texture object of which to make a view.</param>
//        ///// <param name="internalformat">Specifies the internal format for the newly created view.</param>
//        ///// <param name="minlevel">Specifies lowest level of detail of the view.</param>
//        ///// <param name="numlevels">Specifies the number of levels of detail to include in the view.</param>
//        ///// <param name="minlayer">Specifies the index of the first layer to include in the view.</param>
//        ///// <param name="numlayers">Specifies the number of layers to include in the view.</param>
//        //public delegate void glTextureView(uint texture, uint target, uint origtexture, uint internalformat, uint minlevel, uint numlevels, uint minlayer, uint numlayers);
//        //#endregion

//        //#region GL_vertex_attrib_binding

//        ////  Delegates
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="bindingindex"></param>
//        ///// <param name="buffer"></param>
//        ///// <param name="offset"></param>
//        ///// <param name="stride"></param>
//        //public delegate void glBindVertexBuffer(uint bindingindex, uint buffer, IntPtr offset, uint stride);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="attribindex"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="normalized"></param>
//        ///// <param name="relativeoffset"></param>
//        //public delegate void glVertexAttribFormat(uint attribindex, int size, uint type, bool normalized, uint relativeoffset);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="attribindex"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="relativeoffset"></param>
//        //public delegate void glVertexAttribIFormat(uint attribindex, int size, uint type, uint relativeoffset);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="attribindex"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="relativeoffset"></param>
//        //public delegate void glVertexAttribLFormat(uint attribindex, int size, uint type, uint relativeoffset);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="attribindex"></param>
//        ///// <param name="bindingindex"></param>
//        //public delegate void glVertexAttribBinding(uint attribindex, uint bindingindex);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="bindingindex"></param>
//        ///// <param name="divisor"></param>
//        //public delegate void glVertexBindingDivisor(uint bindingindex, uint divisor);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="vaobj"></param>
//        ///// <param name="bindingindex"></param>
//        ///// <param name="buffer"></param>
//        ///// <param name="offset"></param>
//        ///// <param name="stride"></param>
//        //public delegate void glVertexArrayBindVertexBuffer(uint vaobj, uint bindingindex, uint buffer, IntPtr offset, uint stride);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="vaobj"></param>
//        ///// <param name="attribindex"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="normalized"></param>
//        ///// <param name="relativeoffset"></param>
//        //public delegate void glVertexArrayVertexAttribFormat(uint vaobj, uint attribindex, int size, uint type, bool normalized, uint relativeoffset);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="vaobj"></param>
//        ///// <param name="attribindex"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="relativeoffset"></param>
//        //public delegate void glVertexArrayVertexAttribIFormat(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="vaobj"></param>
//        ///// <param name="attribindex"></param>
//        ///// <param name="size"></param>
//        ///// <param name="type"></param>
//        ///// <param name="relativeoffset"></param>
//        //public delegate void glVertexArrayVertexAttribLFormat(uint vaobj, uint attribindex, int size, uint type, uint relativeoffset);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="vaobj"></param>
//        ///// <param name="attribindex"></param>
//        ///// <param name="bindingindex"></param>
//        //public delegate void glVertexArrayVertexAttribBinding(uint vaobj, uint attribindex, uint bindingindex);
//        ///// <summary>
//        /////
//        ///// </summary>
//        ///// <param name="vaobj"></param>
//        ///// <param name="bindingindex"></param>
//        ///// <param name="divisor"></param>
//        //public delegate void glVertexArrayVertexBindingDivisor(uint vaobj, uint bindingindex, uint divisor);
//        //#endregion

//        #region transform feedbacks

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="target"></param>
//        /// <param name="id"></param>
//        public delegate void glBindTransformFeedback(uint target, uint id);
//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="id"></param>
//        public delegate void glIsTransformFeedback(uint id);

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="n"></param>
//        /// <param name="ids"></param>
//        public delegate void glDeleteTransformFeedbacks(int n, uint[] ids);

//        /// <summary>
//        ///
//        /// </summary>
//        public delegate void glPauseTransformFeedback();

//        /// <summary>
//        ///
//        /// </summary>
//        public delegate void glResumeTransformFeedback();
//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="program"></param>
//        /// <param name="uniformBlockIndex"></param>
//        /// <param name="uniformBlockBinding"></param>
//        internal delegate void glUniformBlockBinding(uint program, uint uniformBlockIndex, uint uniformBlockBinding);

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="program"></param>
//        /// <param name="uniformBlockName"></param>
//        /// <returns></returns>
//        internal delegate uint glGetUniformBlockIndex(uint program, string uniformBlockName);

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="program"></param>
//        /// <param name="uniformBlockIndex"></param>
//        /// <param name="pname"></param>
//        /// <param name="pointer"></param>
//        /// <returns></returns>
//        internal delegate uint glGetActiveUniformBlockiv(uint program, uint uniformBlockIndex, uint pname, uint[] pointer);
//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="mode"></param>
//        /// <param name="id"></param>
//        public delegate void glDrawTransformFeedback(uint mode, uint id);

//        #endregion transform feedbacks

//        #region patch

//        /// <summary>
//        /// specifies the parameters for patch primitives
//        /// </summary>
//        /// <param name="pname">Specifies the name of the parameter to set.</param>
//        /// <param name="value">Specifies the new value for the parameter given by <paramref name="pname"/>​.</param>
//        internal delegate void glPatchParameteri(uint pname, int value);

//        /// <summary>
//        /// specifies the parameters for patch primitives
//        /// </summary>
//        /// <param name="pname">Specifies the name of the parameter to set.</param>
//        /// <param name="values">Specifies the address of an array containing the new values for the parameter given by <paramref name="pname"/>​.</param>
//        internal delegate void glPatchParameterfv(uint pname, float[] values);

//        #endregion patch

//        #region texture

//        /// <summary>
//        /// void glBindImageTexture(uint unit, uint texture, int level, bool layered, int layer, uint access, uint format);
//        /// </summary>
//        private static GLDelegates.void_uint_uint_int_bool_int_uint_uint glBindImageTexture;

//        /// <summary>
//        /// bind a level of a texture to an image unit(a uniform image2D in compute shader).
//        /// <para>for more information check http://www.unix.com/man-page/debian/3g/GLBINDIMAGETEXTURE/</para>
//        /// </summary>
//        /// <param name="unit">Specifies the index of the image unit to which to bind the texture.<para>a uniform image2D variable's location.</para></param>
//        /// <param name="texture">Specifies the name of the texture to bind to the image unit.<para>texture's id from glGenTexture().</para></param>
//        /// <param name="level">Specifies the level of the texture that is to be bound.</param>
//        /// <param name="layered">Specifies whether a layered texture binding is to be established.</param>
//        /// <param name="layer">If <paramref name="layered"/>​ is false, specifies the layer of texture​ to be bound to the image unit. Ignored otherwise.</param>
//        /// <param name="access">Specifies a token indicating the type of access that will be performed on the image.<para>OpenGL.GL_READ_ONLY, OpenGL.GL_WRITE_ONLY, OpenGL.GL_READ_WRITE etc.</para></param>
//        /// <param name="format">Specifies the format that the elements of the image will be treated as for the purposes of formatted stores.<para>OpenGL.GL_RGBA32F etc.</para></param>
//        public static void BindImageTexture(uint unit, uint texture, int level, bool layered, int layer, uint access, uint format)
//        {
//            if (glBindImageTexture == null)
//            {
//                glBindImageTexture = WinGL.Instance.GetDelegateFor("glBindImageTexture", GLDelegates.typeof_void_uint_uint_int_bool_int_uint_uint) as GLDelegates.void_uint_uint_int_bool_int_uint_uint;
//            }
//            glBindImageTexture(unit, texture, level, layered, layer, access, format);
//        }

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="target"></param>
//        /// <param name="levels"></param>
//        /// <param name="internalformat"></param>
//        /// <param name="width"></param>
//        public delegate void glTexStorage1D(uint target, int levels, uint internalformat, int width);

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="target"></param>
//        /// <param name="levels"></param>
//        /// <param name="internalformat"></param>
//        /// <param name="width"></param>
//        /// <param name="height"></param>
//        public delegate void glTexStorage2D(uint target, int levels, uint internalformat, int width, int height);

//        /// <summary>
//        ///
//        /// </summary>
//        /// <param name="target"></param>
//        /// <param name="levels"></param>
//        /// <param name="internalformat"></param>
//        /// <param name="width"></param>
//        /// <param name="height"></param>
//        /// <param name="depth"></param>
//        public delegate void glTexStorage3D(uint target, int levels, uint internalformat, int width, int height, int depth);

//        #endregion texture

//        /// <summary>
//        /// defines a barrier ordering memory transactions
//        /// </summary>
//        /// <param name="barriers">Specifies the barriers to insert.</param>
//        public delegate void glMemoryBarrier(uint barriers);

//    }
//}