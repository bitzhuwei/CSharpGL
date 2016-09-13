using System;

namespace CSharpGL
{
    public static partial class OpenGL
    {
        #region OpenGL 1.5

        //  Delegates
        /// <summary>
        ///
        /// </summary>
        /// <param name="n"></param>
        /// <param name="ids"></param>
        public delegate void glGenQueries(int n, uint[] ids);
        /// <summary>
        ///
        /// </summary>
        /// <param name="n"></param>
        /// <param name="ids"></param>
        public delegate void glDeleteQueries(int n, uint[] ids);
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public delegate bool glIsQuery(uint id);
        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="id"></param>
        public delegate void glBeginQuery(uint target, uint id);
        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        public delegate void glEndQuery(uint target);
        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public delegate void glGetQueryiv(uint target, uint pname, int[] parameters);
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public delegate void glGetQueryObjectiv(uint id, uint pname, int[] parameters);
        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pname"></param>
        /// <param name="parameters"></param>
        public delegate void glGetQueryObjectuiv(uint id, uint pname, uint[] parameters);
        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="buffer"></param>
        public delegate void glBindBuffer(uint target, uint buffer);

        /// <summary>
        ///
        /// </summary>
        /// <param name="n"></param>
        /// <param name="buffers"></param>
        public delegate void glDeleteBuffers(int n, uint[] buffers);

        /// <summary>
        ///
        /// </summary>
        /// <param name="n"></param>
        /// <param name="buffers"></param>
        public delegate void glGenBuffers(int n, uint[] buffers);

        /// <summary>
        ///
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public delegate bool glIsBuffer(uint buffer);

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="size"></param>
        /// <param name="data"></param>
        /// <param name="usage"></param>
        public delegate void glBufferData(uint target, int size, IntPtr data, uint usage);

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="data"></param>
        public delegate void glBufferSubData(uint target, int offset, int size, IntPtr data);

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        /// <param name="data"></param>
        public delegate void glGetBufferSubData(uint target, int offset, int size, IntPtr data);

        /// <summary>
        /// 把服务端（GPU）上的当前Buffer Object映射到客户端（CPU）的内存上。
        /// </summary>
        /// <param name="target"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        public delegate IntPtr glMapBuffer(uint target, uint access);

        /// <summary>
        ///
        /// </summary>
        /// <param name="target"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="access"></param>
        /// <returns></returns>
        public delegate IntPtr glMapBufferRange(uint target, int offset, int length, uint access);

        /// <summary>
        /// 把客户端（CPU）上的当前Buffer Object映射到服务端（GPU）的内存上。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public delegate bool glUnmapBuffer(uint target);

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

        //  Constants
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_BUFFER_SIZE = 0x8764;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_BUFFER_USAGE = 0x8765;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_QUERY_COUNTER_BITS = 0x8864;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_CURRENT_QUERY = 0x8865;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_QUERY_RESULT = 0x8866;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_QUERY_RESULT_AVAILABLE = 0x8867;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_ARRAY_BUFFER = 0x8892;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_ELEMENT_ARRAY_BUFFER = 0x8893;

        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_ARRAY_BUFFER_BINDING = 0x8894;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING = 0x889F;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_READ_ONLY = 0x88B8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_WRITE_ONLY = 0x88B9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_READ_WRITE = 0x88BA;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_BUFFER_ACCESS = 0x88BB;

        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_BUFFER_MAPPED = 0x88BC;
        ///// <summary>
        /////
        ///// </summary>
        //public const uint GL_BUFFER_MAP_POINTER = 0x88BD;
        /// <summary>
        ///
        /// </summary>
        public const uint GL_STREAM_DRAW = 0x88E0;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_STREAM_READ = 0x88E1;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_STREAM_COPY = 0x88E2;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_STATIC_DRAW = 0x88E4;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_STATIC_READ = 0x88E5;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_STATIC_COPY = 0x88E6;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_DYNAMIC_DRAW = 0x88E8;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_DYNAMIC_READ = 0x88E9;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_DYNAMIC_COPY = 0x88EA;

        /// <summary>
        ///
        /// </summary>
        public const uint GL_SAMPLES_PASSED = 0x8914;

        #endregion OpenGL 1.5
    }
}