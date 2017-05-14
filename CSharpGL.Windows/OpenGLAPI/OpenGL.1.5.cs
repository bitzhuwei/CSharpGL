using System;

namespace CSharpGL
{
    public static partial class OpenGL
    {
        #region OpenGL 1.5

        ////  Delegates
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="ids"></param>
        //internal delegate void glGenQueries(int n, uint[] ids);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="ids"></param>
        //internal delegate void glDeleteQueries(int n, uint[] ids);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //internal delegate bool glIsQuery(uint id);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="id"></param>
        //internal delegate void glBeginQuery(uint target, uint id);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        //internal delegate void glEndQuery(uint target);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //internal delegate void glGetQueryiv(uint target, uint pname, int[] parameters);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //internal delegate void glGetQueryObjectiv(uint id, uint pname, int[] parameters);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //internal delegate void glGetQueryObjectuiv(uint id, uint pname, uint[] parameters);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="buffer"></param>
        //internal delegate void glBindBuffer(uint target, uint buffer);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="buffers"></param>
        //internal delegate void glDeleteBuffers(int n, uint[] buffers);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="n"></param>
        ///// <param name="buffers"></param>
        //internal delegate void glGenBuffers(int n, uint[] buffers);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="buffer"></param>
        ///// <returns></returns>
        //internal delegate bool glIsBuffer(uint buffer);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="size"></param>
        ///// <param name="data"></param>
        ///// <param name="usage"></param>
        //public delegate void glBufferData(uint target, int size, IntPtr data, uint usage);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="offset"></param>
        ///// <param name="size"></param>
        ///// <param name="data"></param>
        //public delegate void glBufferSubData(uint target, int offset, int size, IntPtr data);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="offset"></param>
        ///// <param name="size"></param>
        ///// <param name="data"></param>
        //public delegate void glGetBufferSubData(uint target, int offset, int size, IntPtr data);

        ///// <summary>
        ///// 把服务端（GPU）上的当前Buffer Object映射到客户端（CPU）的内存上。
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="access"></param>
        ///// <returns></returns>
        //internal delegate IntPtr glMapBuffer(uint target, uint access);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="offset"></param>
        ///// <param name="length"></param>
        ///// <param name="access"></param>
        ///// <returns></returns>
        //internal delegate IntPtr glMapBufferRange(uint target, int offset, int length, uint access);

        ///// <summary>
        ///// 把客户端（CPU）上的当前Buffer Object映射到服务端（GPU）的内存上。
        ///// </summary>
        ///// <param name="target"></param>
        ///// <returns></returns>
        //internal delegate bool glUnmapBuffer(uint target);

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetBufferParameteriv(uint target, uint pname, int[] parameters);
        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="pname"></param>
        ///// <param name="parameters"></param>
        //public delegate void glGetBufferPointerv(uint target, uint pname, IntPtr[] parameters);

        #endregion OpenGL 1.5
    }
}