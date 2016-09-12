namespace CSharpGL
{
    public static partial class OpenGL
    {
        #region OpenGL 1.3

        //  Delegates
        /// <summary>
        ///
        /// </summary>
        /// <param name="texture"></param>
        public delegate void glActiveTexture(uint texture);

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

        //  Constants
        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE0 = 0x84C0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE1 = 0x84C1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE2 = 0x84C2;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE3 = 0x84C3;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE4 = 0x84C4;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE5 = 0x84C5;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE6 = 0x84C6;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE7 = 0x84C7;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE8 = 0x84C8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE9 = 0x84C9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE10 = 0x84CA;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE11 = 0x84CB;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE12 = 0x84CC;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE13 = 0x84CD;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE14 = 0x84CE;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE15 = 0x84CF;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE16 = 0x84D0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE17 = 0x84D1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE18 = 0x84D2;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE19 = 0x84D3;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE20 = 0x84D4;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE21 = 0x84D5;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE22 = 0x84D6;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE23 = 0x84D7;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE24 = 0x84D8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE25 = 0x84D9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE26 = 0x84DA;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE27 = 0x84DB;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE28 = 0x84DC;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE29 = 0x84DD;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE30 = 0x84DE;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE31 = 0x84DF;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_ACTIVE_TEXTURE = 0x84E0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MULTISAMPLE = 0x809D;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_ALPHA_TO_ONE = 0x809F;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_COVERAGE = 0x80A0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_BUFFERS = 0x80A8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLES = 0x80A9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_COVERAGE_VALUE = 0x80AA;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLE_COVERAGE_INVERT = 0x80AB;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP = 0x8513;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_BINDING_CUBE_MAP = 0x8514;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_PROXY_TEXTURE_CUBE_MAP = 0x851B;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPRESSED_RGB = 0x84ED;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPRESSED_RGBA = 0x84EE;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_COMPRESSION_HINT = 0x84EF;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_COMPRESSED_IMAGE_SIZE = 0x86A0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_TEXTURE_COMPRESSED = 0x86A1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_CLAMP_TO_BORDER = 0x812D;

        #endregion OpenGL 1.3
    }
}