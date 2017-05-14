using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL
{
    public static partial class OpenGL
    {
        #region OpenGL 2.0

        //  Delegates
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="modeRGB"></param>
        ///// <param name="modeAlpha"></param>
        //public delegate void glBlendEquationSeparate(uint modeRGB, uint modeAlpha);
        /// <summary>
        /// Select buffers that are written to.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="bufs"></param>
        public delegate void glDrawBuffers(int n, uint[] bufs);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="face"></param>
        ///// <param name="sfail"></param>
        ///// <param name="dpfail"></param>
        ///// <param name="dppass"></param>
        //public delegate void glStencilOpSeparate(uint face, uint sfail, uint dpfail, uint dppass);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="face"></param>
        ///// <param name="func"></param>
        ///// <param name="reference"></param>
        ///// <param name="mask"></param>
        //public delegate void glStencilFuncSeparate(uint face, uint func, int reference, uint mask);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="face"></param>
        ///// <param name="mask"></param>
        //public delegate void glStencilMaskSeparate(uint face, uint mask);
        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="shader"></param>
        internal delegate void glAttachShader(uint program, uint shader);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="index"></param>
        /// <param name="name"></param>
        public delegate void glBindAttribLocation(uint program, uint index, string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shader"></param>
        internal delegate void glCompileShader(uint shader);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        internal delegate uint glCreateProgram();

        /// <summary>
        /// create a shader object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        internal delegate uint glCreateShader(uint type);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        internal delegate void glDeleteProgram(uint program);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shader"></param>
        internal delegate void glDeleteShader(uint shader);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="shader"></param>
        internal delegate void glDetachShader(uint program, uint shader);

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        public delegate void glDisableVertexAttribArray(uint index);

        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        internal delegate void glEnableVertexAttribArray(uint index);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="index"></param>
        ///// <param name="bufSize"></param>
        ///// <param name="length"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="name"></param>
        //public delegate void glGetActiveAttrib(uint program, uint index, int bufSize, out int length, out int size, out uint type, StringBuilder name);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="index"></param>
        ///// <param name="bufSize"></param>
        ///// <param name="length"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="name"></param>
        //public delegate void glGetActiveUniform(uint program, uint index, int bufSize, out int length, out int size, out uint type, StringBuilder name);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="maxCount"></param>
        ///// <param name="count"></param>
        ///// <param name="obj"></param>
        //public delegate void glGetAttachedShaders(uint program, int maxCount, int[] count, uint[] obj);
        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal delegate int glGetAttribLocation(uint program, string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        internal delegate void glGetProgramiv(uint program, uint pname, int[] parameters);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="bufSize"></param>
        /// <param name="length"></param>
        /// <param name="infoLog"></param>
        public delegate void glGetProgramInfoLog(uint program, int bufSize, IntPtr length, StringBuilder infoLog);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shader"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        internal delegate void glGetShaderiv(uint shader, uint pname, int[] parameters);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shader"></param>
        /// <param name="bufSize"></param>
        /// <param name="length"></param>
        /// <param name="infoLog"></param>
        internal delegate void glGetShaderInfoLog(uint shader, int bufSize, IntPtr length, StringBuilder infoLog);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shader"></param>
        /// <param name="bufSize"></param>
        /// <param name="length"></param>
        /// <param name="source"></param>
        public delegate void glGetShaderSource(uint shader, int bufSize, IntPtr length, StringBuilder source);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal delegate int glGetUniformLocation(uint program, string name);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="location"></param>
        /// <param name="parameters"></param>
        public delegate void glGetUniformfv(uint program, int location, float[] parameters);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <param name="location"></param>
        /// <param name="parameters"></param>
        public delegate void glGetUniformiv(uint program, int location, int[] parameters);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribdv(uint index, uint pname, double[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribfv(uint index, uint pname, float[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribiv(uint index, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="pointer"></param>
        //public delegate void glGetVertexAttribPointerv(uint index, uint pname, IntPtr pointer);
        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public delegate bool glIsProgram(uint program);

        /// <summary>
        ///
        /// </summary>
        /// <param name="shader"></param>
        /// <returns></returns>
        public delegate bool glIsShader(uint shader);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        internal delegate void glLinkProgram(uint program);

        //  By specifying 'ThrowOnUnmappableChar' we protect ourselves from inadvertantly using a unicode character
        //  in the source which the marshaller cannot map. Without this, it maps it to '?' leading to long and pointless
        //  sessions of trying to find bugs in the shader, which are most often just copied and pasted unicode characters!
        //  If you're getting exceptions here, remove all unicode crap from your input files (remember, some unicode
        //  characters you can't even see).
        /// <summary>
        ///
        /// </summary>
        /// <param name="shader"></param>
        /// <param name="count"></param>
        /// <param name="source"></param>
        /// <param name="length"></param>
        [UnmanagedFunctionPointer(CallingConvention.StdCall, ThrowOnUnmappableChar = true)]
        internal delegate void glShaderSource(uint shader, int count, string[] source, int[] length);

        /// <summary>
        ///
        /// </summary>
        /// <param name="program"></param>
        internal delegate void glUseProgram(uint program);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        internal delegate void glUniform1f(int location, float v0);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        internal delegate void glUniform2f(int location, float v0, float v1);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        internal delegate void glUniform3f(int location, float v0, float v1, float v2);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        internal delegate void glUniform4f(int location, float v0, float v1, float v2, float v3);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        internal delegate void glUniform1i(int location, int v0);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        internal delegate void glUniform2i(int location, int v0, int v1);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        internal delegate void glUniform3i(int location, int v0, int v1, int v2);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="v3"></param>
        internal delegate void glUniform4i(int location, int v0, int v1, int v2, int v3);

        // TODO: public delegate void glUniform1fv(int location, int count, IntPtr value); is also available.
        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform1fv(int location, int count, float[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform2fv(int location, int count, float[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform3fv(int location, int count, float[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform4fv(int location, int count, float[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform1iv(int location, int count, int[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform2iv(int location, int count, int[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform3iv(int location, int count, int[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="value"></param>
        internal delegate void glUniform4iv(int location, int count, int[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="transpose"></param>
        /// <param name="value"></param>
        internal delegate void glUniformMatrix2fv(int location, int count, bool transpose, float[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="transpose"></param>
        /// <param name="value"></param>
        internal delegate void glUniformMatrix3fv(int location, int count, bool transpose, float[] value);

        /// <summary>
        ///
        /// </summary>
        /// <param name="location"></param>
        /// <param name="count"></param>
        /// <param name="transpose"></param>
        /// <param name="value"></param>
        internal delegate void glUniformMatrix4fv(int location, int count, bool transpose, float[] value);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        //public delegate void glValidateProgram(uint program);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttrib1d(uint index, double x);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib1dv(uint index, double[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttrib1f(uint index, float x);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib1fv(uint index, float[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttrib1s(uint index, short x);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib1sv(uint index, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttrib2d(uint index, double x, double y);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib2dv(uint index, double[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttrib2f(uint index, float x, float y);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib2fv(uint index, float[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttrib2s(uint index, short x, short y);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib2sv(uint index, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttrib3d(uint index, double x, double y, double z);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib3dv(uint index, double[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttrib3f(uint index, float x, float y, float z);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib3fv(uint index, float[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttrib3s(uint index, short x, short y, short z);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib3sv(uint index, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nbv(uint index, sbyte[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Niv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nsv(uint index, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4Nub(uint index, byte x, byte y, byte z, byte w);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nubv(uint index, byte[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nuiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4Nusv(uint index, ushort[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4bv(uint index, sbyte[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4d(uint index, double x, double y, double z, double w);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4dv(uint index, double[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4f(uint index, float x, float y, float z, float w);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4fv(uint index, float[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4iv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttrib4s(uint index, short x, short y, short z, short w);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4sv(uint index, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4ubv(uint index, byte[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4uiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttrib4usv(uint index, ushort[] v);
        /// <summary>
        ///
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="type"></param>
        /// <param name="normalized"></param>
        /// <param name="stride"></param>
        /// <param name="pointer"></param>
        internal delegate void glVertexAttribPointer(uint index, int size, uint type, bool normalized, int stride, IntPtr pointer);

        #endregion OpenGL 2.0
    }
}