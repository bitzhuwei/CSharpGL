using System;
namespace CSharpGL
{
    public partial class WinGL
    {
        #region OpenGL 3.0

        //  Delegates
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="r"></param>
        ///// <param name="g"></param>
        ///// <param name="b"></param>
        ///// <param name="a"></param>
        //public delegate void glColorMaski(uint index, bool r, bool g, bool b, bool a);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="data"></param>
        //public delegate void glGetBooleani_v(uint target, uint index, bool[] data);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="data"></param>
        //public delegate void glGetIntegeri_v(uint target, uint index, int[] data);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        //public delegate void glEnablei(uint target, uint index);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        //public delegate void glDisablei(uint target, uint index);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //public delegate bool glIsEnabledi(uint target, uint index);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="primitiveMode"></param>
        //public delegate void glBeginTransformFeedback(uint primitiveMode);

        ///// <summary>
        /////
        ///// </summary>
        //public delegate void glEndTransformFeedback();
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="index"></param>
        ///// <param name="buffer"></param>
        ///// <param name="offset"></param>
        ///// <param name="size"></param>
        //internal delegate void glBindBufferRange(uint target, uint index, uint buffer, int offset, int size);

        ///// <summary>
        ///// </summary>
        ///// <param name="target">Specifies the target buffer object.</param>
        ///// <param name="bindingPoint">Specify the index of the binding point within the array specified by <paramref name="target"/></param>
        ///// <param name="bufferName">Buffer name generated from glGenBuffers().</param>
        //internal delegate void glBindBufferBase(uint target, uint bindingPoint, uint bufferName);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="count"></param>
        ///// <param name="varyings"></param>
        ///// <param name="bufferMode"></param>
        //public delegate void glTransformFeedbackVaryings(uint program, int count, string[] varyings, uint bufferMode);
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
        //public delegate void glGetTransformFeedbackVarying(uint program, uint index, int bufSize, int[] length, int[] size, uint[] type, string name);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="clamp"></param>
        //public delegate void glClampColor(uint target, uint clamp);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="mode"></param>
        //internal delegate void glBeginConditionalRender(uint id, uint mode);

        ///// <summary>
        /////
        ///// </summary>
        //internal delegate void glEndConditionalRender();

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glVertexAttribIPointer(uint index, int size, uint type, int stride, IntPtr pointer);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="size"></param>
        ///// <param name="type"></param>
        ///// <param name="stride"></param>
        ///// <param name="pointer"></param>
        //public delegate void glVertexAttribLPointer(uint index, int size, uint type, int stride, IntPtr pointer);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribIiv(uint index, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetVertexAttribIuiv(uint index, uint pname, uint[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttribI1i(uint index, int x);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttribI2i(uint index, int x, int y);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttribI3i(uint index, int x, int y, int z);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttribI4i(uint index, int x, int y, int z, int w);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        //public delegate void glVertexAttribI1ui(uint index, uint x);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //public delegate void glVertexAttribI2ui(uint index, uint x, uint y);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        //public delegate void glVertexAttribI3ui(uint index, uint x, uint y, uint z);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="z"></param>
        ///// <param name="w"></param>
        //public delegate void glVertexAttribI4ui(uint index, uint x, uint y, uint z, uint w);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI1iv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI2iv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI3iv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4iv(uint index, int[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI1uiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI2uiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI3uiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4uiv(uint index, uint[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4bv(uint index, sbyte[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4sv(uint index, short[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4ubv(uint index, byte[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="index"></param>
        ///// <param name="v"></param>
        //public delegate void glVertexAttribI4usv(uint index, ushort[] v);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="location"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetUniformuiv(uint program, int location, uint[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="colorNumber"></param>
        ///// <param name="name"></param>
        //public delegate void glBindFragDataLocation(uint program, uint colorNumber, string name);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="colorNumber"></param>
        ///// <param name="index"></param>
        ///// <param name="name"></param>
        //public delegate void glBindFragDataLocationIndexed(uint program, uint colorNumber, uint index, string name);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public delegate int glGetFragDataLocation(uint program, string name);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="program"></param>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public delegate int glGetFragDataIndex(uint program, string name);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        //internal delegate void glUniform1ui(int location, uint v0);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        ///// <param name="v1"></param>
        //internal delegate void glUniform2ui(int location, uint v0, uint v1);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        ///// <param name="v1"></param>
        ///// <param name="v2"></param>
        //internal delegate void glUniform3ui(int location, uint v0, uint v1, uint v2);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="v0"></param>
        ///// <param name="v1"></param>
        ///// <param name="v2"></param>
        ///// <param name="v3"></param>
        //internal delegate void glUniform4ui(int location, uint v0, uint v1, uint v2, uint v3);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //internal delegate void glUniform1uiv(int location, int count, uint[] value);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //internal delegate void glUniform2uiv(int location, int count, uint[] value);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //internal delegate void glUniform3uiv(int location, int count, uint[] value);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="location"></param>
        ///// <param name="count"></param>
        ///// <param name="value"></param>
        //internal delegate void glUniform4uiv(int location, int count, uint[] value);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glTexParameterIiv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glTexParameterIuiv(uint target, uint pname, uint[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetTexParameterIiv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetTexParameterIuiv(uint target, uint pname, uint[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="drawbuffer"></param>
        ///// <param name="value"></param>
        //public delegate void glClearBufferiv(uint buffer, int drawbuffer, int[] value);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="drawbuffer"></param>
        ///// <param name="value"></param>
        //public delegate void glClearBufferuiv(uint buffer, int drawbuffer, uint[] value);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="drawbuffer"></param>
        ///// <param name="value"></param>
        //public delegate void glClearBufferfv(uint buffer, int drawbuffer, float[] value);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <param name="drawbuffer"></param>
        ///// <param name="depth"></param>
        ///// <param name="stencil"></param>
        //public delegate void glClearBufferfi(uint buffer, int drawbuffer, float depth, int stencil);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="index"></param>
        ///// <returns></returns>
        //public delegate string glGetStringi(uint name, uint index);

        #endregion OpenGL 3.0
    }
}