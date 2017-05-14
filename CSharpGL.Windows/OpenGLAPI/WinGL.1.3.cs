namespace CSharpGL
{
    public partial class WinGL
    {
        #region OpenGL 1.3

        //  Delegates
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="texture"></param>
        //public delegate void glActiveTexture(uint texture);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="invert"></param>
        //public delegate void glSampleCoverage(float value, bool invert);
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
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexImage3D(uint target, int level, uint internalformat, int width, int height, int depth, int border, int imageSize, IntPtr data);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="border"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexImage2D(uint target, int level, uint internalformat, int width, int height, int border, int imageSize, IntPtr data);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="internalformat"></param>
        ///// <param name="width"></param>
        ///// <param name="border"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexImage1D(uint target, int level, uint internalformat, int width, int border, int imageSize, IntPtr data);
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
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexSubImage3D(uint target, int level, int xoffset, int yoffset, int zoffset, int width, int height, int depth, uint format, int imageSize, IntPtr data);
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
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexSubImage2D(uint target, int level, int xoffset, int yoffset, int width, int height, uint format, int imageSize, IntPtr data);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="xoffset"></param>
        ///// <param name="width"></param>
        ///// <param name="format"></param>
        ///// <param name="imageSize"></param>
        ///// <param name="data"></param>
        //public delegate void glCompressedTexSubImage1D(uint target, int level, int xoffset, int width, uint format, int imageSize, IntPtr data);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="level"></param>
        ///// <param name="img"></param>
        //public delegate void glGetCompressedTexImage(uint target, int level, IntPtr img);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="texture"></param>
        //public delegate void glClientActiveTexture(uint texture);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1d(uint target, double s);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1dv(uint target, double[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1f(uint target, float s);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1fv(uint target, float[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1i(uint target, int s);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1iv(uint target, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        //public delegate void glMultiTexCoord1s(uint target, short s);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord1sv(uint target, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2d(uint target, double s, double t);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2dv(uint target, double[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2f(uint target, float s, float t);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2fv(uint target, float[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2i(uint target, int s, int t);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2iv(uint target, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        //public delegate void glMultiTexCoord2s(uint target, short s, short t);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord2sv(uint target, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3d(uint target, double s, double t, double r);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3dv(uint target, double[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3f(uint target, float s, float t, float r);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3fv(uint target, float[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3i(uint target, int s, int t, int r);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3iv(uint target, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        //public delegate void glMultiTexCoord3s(uint target, short s, short t, short r);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord3sv(uint target, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4d(uint target, double s, double t, double r, double q);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4dv(uint target, double[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4f(uint target, float s, float t, float r, float q);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4fv(uint target, float[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4i(uint target, int s, int t, int r, int q);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4iv(uint target, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="s"></param>
        ///// <param name="t"></param>
        ///// <param name="r"></param>
        ///// <param name="q"></param>
        //public delegate void glMultiTexCoord4s(uint target, short s, short t, short r, short q);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="v"></param>
        //public delegate void glMultiTexCoord4sv(uint target, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glLoadTransposeMatrixf(float[] m);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glLoadTransposeMatrixd(double[] m);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glMultTransposeMatrixf(float[] m);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="m"></param>
        //public delegate void glMultTransposeMatrixd(double[] m);

        #endregion OpenGL 1.3
    }
}