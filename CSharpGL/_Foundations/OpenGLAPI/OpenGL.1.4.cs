using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CSharpGL
{
    public static partial class OpenGL
    {

        #region OpenGL 1.4

        //  Delegates
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sfactorRGB"></param>
        ///// <param name="dfactorRGB"></param>
        ///// <param name="sfactorAlpha"></param>
        ///// <param name="dfactorAlpha"></param>
        //public delegate void glBlendFuncSeparate(uint sfactorRGB, uint dfactorRGB, uint sfactorAlpha, uint dfactorAlpha);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="first"></param>
        /// <param name="count"></param>
        /// <param name="primcount"></param>
        public delegate void glMultiDrawArrays(uint mode, int[] first, int[] count, int primcount);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="count"></param>
        /// <param name="type"></param>
        /// <param name="indices"></param>
        /// <param name="primcount"></param>
        public delegate void glMultiDrawElements(uint mode, int[] count, uint type, IntPtr indices, int primcount);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="parameter"></param>
        //public delegate void glPointParameterf(uint pname, float parameter);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glPointParameterfv(uint pname, float[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="parameter"></param>
        //public delegate void glPointParameteri(uint pname, int parameter);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glPointParameteriv(uint pname, int[] parameters);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoordf(float coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoordfv(float[] coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoordd(double coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="coord"></param>
        //public delegate void glFogCoorddv(double[] coord);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="type"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glFogCoordPointer(uint type, int stride, IntPtr pointer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3b(sbyte red, sbyte green, sbyte blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3bv(sbyte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3d(double red, double green, double blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3dv(double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3f(float red, float green, float blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3fv(float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3i(int red, int green, int blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3iv(int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3s(short red, short green, short blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3sv(short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3ub(byte red, byte green, byte blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3ubv(byte[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3ui(uint red, uint green, uint blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3uiv(uint[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="red"></param>
        ///// <param name="green"></param>
        ///// <param name="blue"></param>
        //public delegate void glSecondaryColor3us(ushort red, ushort green, ushort blue);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glSecondaryColor3usv(ushort[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glSecondaryColorPointer(int size, uint type, int stride, IntPtr pointer);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2d(double x, double y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2dv(double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2f(float x, float y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2fv(float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2i(int x, int y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2iv(int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glWindowPos2s(short x, short y);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos2sv(short[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3d(double x, double y, double z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3dv(double[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3f(float x, float y, float z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3fv(float[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3i(int x, int y, int z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3iv(int[] v);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glWindowPos3s(short x, short y, short z);
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="v"></param>
        //public delegate void glWindowPos3sv(short[] v);

        //  Constants
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_DST_RGB = 0x80C8;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_SRC_RGB = 0x80C9;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_DST_ALPHA = 0x80CA;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_BLEND_SRC_ALPHA = 0x80CB;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_POINT_FADE_THRESHOLD_SIZE = 0x8128;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_COMPONENT16 = 0x81A5;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_DEPTH_COMPONENT24 = 0x81A6;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DEPTH_COMPONENT32 = 0x81A7;
        /// <summary>
        /// 
        /// </summary>
        public const uint GL_MIRRORED_REPEAT = 0x8370;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_MAX_TEXTURE_LOD_BIAS = 0x84FD;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_LOD_BIAS = 0x8501;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_INCR_WRAP = 0x8507;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_DECR_WRAP = 0x8508;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_DEPTH_SIZE = 0x884A;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPARE_MODE = 0x884C;
        ///// <summary>
        ///// 
        ///// </summary>
        //public const uint GL_TEXTURE_COMPARE_FUNC = 0x884D;

        #endregion

    }
}
